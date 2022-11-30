using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ThreadLive
{
    /// <summary>
    /// Thread Example DJM
    /// Simple flashing button example
    /// documentation for threading: https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread?view=net-7.0
    /// </summary>
    public partial class Form1 : Form
    {
        //thread 1
        Thread newThread;           
        Boolean running = false;    //flag to signal to flash or not
        Boolean flag = false;       //flag to signal the colour of the button
        Boolean endThread = false;  //flag to tell the thread to exit
        public Form1()
        {
            InitializeComponent();
            newThread = new Thread(ThreadMethod);   //create a thread passingthe ThreadMethod() as the thread
            newThread.Start();                      //start it executing
            Console.WriteLine("Thead 1");
        }

        /// <summary>
        /// Thread method to flash a button
        /// </summary>
        public void ThreadMethod()  
        {//thread 2
            Console.WriteLine("Thead 2");
            while(endThread == false)           //should the thread continue executing?
            {
                if (running == false)           //should it flash the buton?
                    continue;                   //no? Do nothing but the thread is still running
                if (flag == false)
                {
                    this.button1.BackColor = Color.Red;
                    flag = true;
                }
                else
                {
                    this.button1.BackColor = Color.Gray;
                    flag = false;
                }
                Thread.Sleep(500);              //sleep for half a second to slow down the flash but remember nothing is being locked even without the sleep because the thrad is running in a timeslice
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            running = !running;                 //signal to the thread to flash the button or not
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button 2 pressed");
             //newThread.Suspend(); //this is depricated and should not be used as it could kill a thread halfway through an important task.
            endThread = true;       //should signal to it instead
        }
    }
}
