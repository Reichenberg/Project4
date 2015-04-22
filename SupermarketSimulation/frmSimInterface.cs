//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 4
//	File Name:		frmSimInterface.cs
//	Description:    Gui for the supermarket simulation
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Chance Reichenberg, reichenberg@etsu.edu, Duncan Perkins, perkinsdt@goldmail.etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Friday, April 10, 2015
//	Copyright:		Duncan Perkins, Chance Reichenberg, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriorityQueueUtility;

namespace SupermarketSimulation
{
    /// <summary>
    /// Gui for the SuperMarket Simulation
    /// </summary>
    public partial class frmSimInterface : Form
    {
        Random rand = new Random();
        //Priority Queue to manage events
        PriorityQueue<Event> PQ = new PriorityQueue<Event>();
        //List of queues to represent registers
        List<Queue<Customer>> registers;

        //Variables to base simulation on
        int numCustomers = 600;
        int hoursOfOperation = 16;
        int numRegisters = 5;
        int expectedCheckoutDurationMin = 6;
        int expectedCheckoutDurationSeconds = 15;
        int TimeInterval;

        //Statistics variables
        int eventsProcessed, arrivals, departures;
        int longestQueue = 0;
        TimeSpan shortestServiceTime, longestServiceTime, averageServiceTime, totalServiceTime;
        TimeSpan[] WaitingTime;
        

        /// <summary>
        /// Default constructor for the form
        /// </summary>
        public frmSimInterface()
        {
            InitializeComponent();
            TimeInterval = SimulationSpeed.Value * 100;
            lblSpeed.Text = SimulationSpeed.Value.ToString();
        }

        /// <summary>
        /// Button click event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRun_Click(object sender, EventArgs e)
        {
            

            if (!String.IsNullOrEmpty(txtCustomers.Text) && !String.IsNullOrEmpty(txtHours.Text) && !String.IsNullOrEmpty(txtRegisters.Text) && !String.IsNullOrEmpty(txtCheckoutDurationMinutes.Text) && !String.IsNullOrEmpty(txtCheckoutDurationSeconds.Text))
            {
                ToggleControls();
                ResetStats();

                numCustomers = PoissonNum(Double.Parse(txtCustomers.Text));
                hoursOfOperation = int.Parse(txtHours.Text);
                numRegisters = int.Parse(txtRegisters.Text);
                WaitingTime = new TimeSpan[numRegisters];
                expectedCheckoutDurationMin = int.Parse(txtCheckoutDurationMinutes.Text);
                expectedCheckoutDurationSeconds = int.Parse(txtCheckoutDurationSeconds.Text);
            }
            else
            {
                MessageBox.Show("All fields must be filled. Please enter data into the fields.");
                return;
            }

             registers = new List<Queue<Customer>>();

            //Adds a Queue to the list for each register
             for (int count = 0; count < numRegisters; count++ )
             {
                 registers.Add(new Queue<Customer>());
             }
                 GenerateCustomerArrivals();
              int n = await RunSimulation();
             
        }


        /// <summary>
        /// Negative exponential distribution generator method
        /// </summary>
        /// <param name="expectedValue">Value used to generate Negative exponential value</param>
        /// <returns>Negative exponential number</returns>
        private double NegExponentialNum(double expectedValue)
        {
            return -expectedValue * Math.Log(rand.NextDouble());
        }

        /// <summary>
        /// Poisson distribution number generator method
        /// </summary>
        /// <param name="expectedValue">value used to generate the numbers around</param>
        /// <returns>poisson distribution value</returns>
        private int PoissonNum(double expectedValue)
        {
            double dLimit = -expectedValue;
            double dSum = Math.Log(rand.NextDouble());

            int count;
            for(count = 0; dSum > dLimit; count++)
            {
                dSum += Math.Log(rand.NextDouble());
            }
            return count;
        }

        /// <summary>
        /// Method to generate customer events
        /// </summary>
        private void GenerateCustomerArrivals()
        {
            for(int i = 0; i < numCustomers; i++)
            {
                Customer tempCust = new Customer(i + 1, new TimeSpan(0, rand.Next(hoursOfOperation * 60), 0), new TimeSpan());
                PQ.Enqueue(new Event(EVENTTYPE.ENTER, tempCust, tempCust.ArrivalTime));
            }
        }

        /// <summary>
        /// Method that runs the Supermarket Simulation
        /// </summary>
        private async Task<int> RunSimulation()
        {
            //Set the stats variables so that they will most certainly be overwritten
            shortestServiceTime = new TimeSpan(1,0,0);
            longestServiceTime = new TimeSpan(0,0,0);
            while(PQ.Count != 0)
            {
                int shortestLineIndex = 0;
                int lineLength = registers[0].Count;
                Event tempEvent = PQ.Peek();

                //Handles the enter event  by adding the person to the shortest line 
                //and creating an exit event based on the time they have to wait to exit
                if(tempEvent.Type == EVENTTYPE.ENTER)
                {
                    //Gets the index of the shortest line to be checked out
                    for(int i = 0; i < registers.Count; i++)
                    {
                        shortestLineIndex = (registers[i].Count < lineLength) ? i : shortestLineIndex;
                    }

                    //Sets the current waiting time to the total amoumt of time for
                    //each person to make it through the line
                    //WaitingTime[shortestLineIndex] += tempEvent.Customer.TimeToServe;
                    //tempEvent.Customer.TimeWaiting = WaitingTime[shortestLineIndex];        //Sets the customer's time needed to wait to that total waiting time
                    registers[shortestLineIndex].Enqueue(tempEvent.Customer);               //Add the customer to the shortest line

                    PQ.Dequeue();       //Then remove that customer's arrival from the priority Queue

                    if(registers[shortestLineIndex].Peek().CustomerID == tempEvent.Customer.CustomerID)
                    {
                        SetCustomerTimeToServe(registers[shortestLineIndex].Peek());

                    }
                    



                    
                    arrivals++;         //Increment Arrivals
                    lblArrivals.Text = String.Format("Arrivals: {0}", arrivals.ToString());
                }

                //Handles the exit event by finding where the person is and removing them from their line
                if(tempEvent.Type == EVENTTYPE.LEAVE)
                {
                    for(int count = 0; count < registers.Count; count++)
                        if (registers[count].Count > 0)
                        {
                            if (registers[count].Peek().CustomerID == tempEvent.Customer.CustomerID)
                            {
                                //Subtract the customer to be dequeued's TimeToServe from the Waiting time for that line
                                //WaitingTime[count] -= registers[count].Peek().TimeToServe;
                                registers[count].Dequeue();     //Remove the customer from that line

                                PQ.Dequeue();       //Then remove that customer's Exit from the priority Queue

                                if (registers[count].Count > 0)
                                {
                                    if (registers[count].Peek().TimeToServe == new TimeSpan())
                                    {
                                        SetCustomerTimeToServe(registers[count].Peek());

                                    }
                                }


                                departures++;       //Increment departures
                                lblDepartures.Text = String.Format("Departures: {0}", departures.ToString());

                                break;
                            }
                        }
                    
                }
                
                eventsProcessed++;
                lblEvents.Text = String.Format("Events Processed: {0}",eventsProcessed.ToString());
                GetLongestQueue();
                int n = await VisualizeData();
            }

            averageServiceTime = new TimeSpan(0, 0, (int)(totalServiceTime.TotalSeconds / numCustomers));
            lblAvgWait.Text = String.Format("Average Wait Time: {0}", averageServiceTime.ToString());
            lblShortestWait.Text = String.Format("Shortest Wait: {0}", shortestServiceTime.ToString());
            lblLongestWait.Text = String.Format("Longest Wait: {0}", longestServiceTime.ToString());
            ToggleControls();
            return 1;
        }

        /// <summary>                                                
        /// Creates the Psuedo-Graphical View of the simulation      
        /// </summary>                                               
        /// <returns>1 for done</returns>                            
        public async Task<int> VisualizeData()
        {
            string str = "";
            string tempstr = "";
            int biggest = 0;
            List<Queue<Customer>> RegisterCopy = new List<Queue<Customer>>();
            int StringLength = 7;
            foreach (Queue<Customer> q in registers)
            {
                RegisterCopy.Add(new Queue<Customer>(q.ToList()));
            }
            int TitleSpot = ((registers.Count*StringLength) / 2) - 4;
            for (int i = 0; i < TitleSpot; i++)
            {
                str += " ";
            }
            str += "Registers\r\n";

            for (int i = 0; i < registers.Count * StringLength; i++)
            {
                str += "-";
            }
            str += "\r\n";
            int RegisterIndex = 0;
            for (int i = 0; i < registers.Count; i++)
            {
                string SpacesString = "";
                tempstr = "R " + i  ;
                if (tempstr.Length < StringLength)
                {
                    int NewSpaces = (StringLength - tempstr.Length);
                    for (int k = 0; k < NewSpaces-1; k++)
                    {
                        SpacesString += " ";
                    }
                    SpacesString += "|";
 
                }
                tempstr += SpacesString;
                str += tempstr;
                RegisterIndex++;
            }
            str += "\r\n";
            for (int i = 0; i < RegisterIndex*StringLength; i++)
            {
                str += "-";
            }

                str += "\r\n";

            for (int j = 0; j < registers.Count; j++)
            {
                if (registers[j].Count-1 > registers[biggest].Count-1)
                {
                    biggest = j;
                }
            }

            for (int l = 0; l < registers[biggest].Count; l++)
            {
                foreach (Queue<Customer> q in RegisterCopy)
                {
                    if (q.Count > 0)
                    {
                        string SpacesString = "";
                        tempstr = q.Dequeue().CustomerID.ToString();
                        if (tempstr.Length < StringLength)
                        {
                            
                            int NewSpaces = (StringLength - tempstr.Length);
                            for (int i = 0; i < NewSpaces-1; i++)
                            {
                                SpacesString += " ";
                            }
                            SpacesString += "|";
                        }
                        tempstr += SpacesString;
                        str+=tempstr;

                    }

                    else
                    {
                        for (int i = 0; i < StringLength-1; i++)
                        {
                            str += " ";
                        }
                        str += "|";

                    }

                }
                str += "\r\n";
            }
            
            int n = await Wait();
            txtSimulationVisual.Text = str;
            return 1;
        }

        /// <summary>
        /// Validates data entered into text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyValidation_KeyPress(object sender, KeyPressEventArgs e)
        {
            //If the base is less than 10 only allow characters that are less than the base to be entered. If the base is 10 or greater allow 0-9 to be entered
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the close button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Method that loops through the registers and sets the longestQueue to the longest current queue;
        /// </summary>
        private void GetLongestQueue()
        {
            foreach(var line in registers)
            {
                longestQueue = (line.Count > longestQueue) ? line.Count : longestQueue;
            }

            lblLongestQueue.Text = String.Format("Longest Queue Encountered: {0}", longestQueue.ToString());
            
        }

        /// <summary>
        /// Resets Statistics and stats labels
        /// </summary>
        private void ResetStats()
        {
            arrivals = 0;
            lblArrivals.Text = "Arrivals: ";
            departures = 0;
            lblDepartures.Text = "Departures: ";
            eventsProcessed = 0;
            lblEvents.Text = "Events Processed: ";
            longestQueue = 0;
            lblLongestQueue.Text = "Longest Queue Encountered: ";
            shortestServiceTime = new TimeSpan();
            longestServiceTime = new TimeSpan();
            averageServiceTime = new TimeSpan();
            totalServiceTime = new TimeSpan();
            lblAvgWait.Text = "Average Time To be Serviced: ";
            lblShortestWait.Text = "Shortest Wait: " ;
            lblLongestWait.Text = "Longest Wait: ";
        }
        
        /// <summary>
        /// Sets the time interval for the simulation
        /// </summary>
        /// <returns>1 for done</returns>
        public async Task<int> Wait()
        {
            await Task.Delay(TimeInterval);
            return 1;
        }

        /// <summary>
        /// Method for the Slider scroll event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimulationSpeed_Scroll(object sender, EventArgs e)
        {
            TimeInterval = SimulationSpeed.Value * 100;
            lblSpeed.Text = SimulationSpeed.Value.ToString();

        }

        /// <summary>
        /// Method to give a customer a Time taken to be served, and adds their exit event to the Priority Queue
        /// </summary>
        /// <param name="cust">Customer to be given a Time to be served and added to the Priority Queue</param>
        private void SetCustomerTimeToServe(Customer cust)
        {
            cust.TimeToServe = new TimeSpan(0, 0, (int)(120 + NegExponentialNum(expectedCheckoutDurationSeconds + (expectedCheckoutDurationMin * 60))));

            TimeSpan custExitTime = cust.ArrivalTime + cust.TimeToServe;

            //If the customer's wait time is less than the shortest wait time, then set it to be the shortest wait time.
            shortestServiceTime = (cust.TimeToServe < shortestServiceTime) ? cust.TimeToServe : shortestServiceTime;
            //If the customer's wait time is longer than the longest wait time, then set it to be the longest wait time.
            longestServiceTime = (cust.TimeToServe > longestServiceTime) ? cust.TimeToServe : longestServiceTime;
            //Add the customer's wait time to the total service time
            totalServiceTime += cust.TimeToServe;
            PQ.Enqueue(new Event(EVENTTYPE.LEAVE, cust, custExitTime));
        }

        /// <summary>
        /// Toggles the Enabled property for the user controls
        /// </summary>
        private void ToggleControls()
        {
            btnRun.Enabled = !btnRun.Enabled;
            txtCheckoutDurationMinutes.Enabled = !txtCheckoutDurationMinutes.Enabled;
            txtCheckoutDurationSeconds.Enabled = !txtCheckoutDurationSeconds.Enabled;
            txtCustomers.Enabled = !txtCustomers.Enabled;
            txtHours.Enabled = !txtHours.Enabled;
            txtRegisters.Enabled = !txtRegisters.Enabled;
        }

    
    
    }

}
