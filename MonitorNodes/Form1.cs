//using Microsoft.Win32;
using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
//using System.Net.NetworkInformation;
//using System.Text;
//using System.Threading;
//using System.Management;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Net.Sockets;
//using System.Net;
//using System.Windows.Forms.DataVisualization.Charting;
//using System.Drawing.Imaging;

namespace MonitorNodes
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Set combobox for sleep time
            waitTime.DropDownStyle = ComboBoxStyle.DropDownList;
            waitTime.SelectedIndex = 1;
            //Disable the stop button, not needed if it's not running
            stopButton.Enabled = false;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            checkForUpdate();

        }

        //This is a variable is for tracking the wait time the user sets. 
        Int16 userWaitTime;
        System.ComponentModel.BackgroundWorker worker;
        bool forceIPv4 = false;
        //bool pieChart = false;
        ToolTip t1 = new ToolTip();
        bool showGraph = true;
        

        private void monitorButton_Click(object sender, EventArgs e)
        {
            //Stop multiple background workers!
            if (worker != null && worker.IsBusy)
            {
                return;
            }

            //Set the name of the machine if they type localhost
            if (ipAddressBox.Text == "localhost") { ipAddressBox.Text = "127.0.0.1"; }
            if(ipAddressBox.Text == "" || ipAddressBox.Text == null || string.IsNullOrWhiteSpace(ipAddressBox.Text))
            {
                ipAddressBox.Text = "127.0.0.1";
            }
            monitorButton.Enabled = false;
            ipAddressBox.Enabled = false;
            stopButton.Enabled = true;
            userWaitTime = Convert.ToInt16(waitTime.SelectedItem.ToString());
            listBox1.Items.Add("Sleep time has been set to: " + userWaitTime + " seconds.");
            listBox1.Items.Add("Testing: " + ipAddressBox.Text);
            waitTime.Enabled = false;
            worker = new System.ComponentModel.BackgroundWorker();
            worker.DoWork += new System.ComponentModel.DoWorkEventHandler(testConnection);
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerAsync();
            myIPAddress.Text = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[0].ToString();


        }


        //This function is for testing a node on the network
        private void testConnection(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //listbox.TopIndex = listbox.Items.Count - 1;
            listBox1.Invoke(new Action(() => listBox1.Items.Add(" Start! ")));
            //bool to determin if the while loop has run once for things I want to do ONE time
            bool checkedOS = true;
            string osVersion = null;
            int maxMem = 104857600;
            int pingTimeOut = -1;
            


            bool canConnect = false;
            while (true)
            {
                //Check to see if the worker has been cancled. 
                if (worker.CancellationPending == true)
                {
                    worker.Dispose();
                    return;
                }
                
                //This is to warn if the program is eating up TOO much memory, 50MB is the warning.
                if(System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 >= maxMem)
                {
                    string answerToContinue = MessageBox.Show("Warning, the application is taking up 100MB or more, would you like to continue? If you say yes then the error will show again at " + maxMem + " bytes", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).ToString();
                    if(answerToContinue == "No")
                    {
                        stopButton_Click();
                        return;
                    }
                    else
                    {
                        maxMem = maxMem * 2;
                    }

                    //Null item
                    answerToContinue = null;
                }
                
                //Do this once if check OS is checked
                if (checkedOS == true && attemptOSVersion.Checked == true)
                {
                    osVersion = GetOsVersion(ipAddressBox.Text);
                    checkedOS = false;
                }
                //Check to see if they want auto scroll, if so then scroll
                if(autoScroll.Checked == true)
                {
                    listBox1.Invoke(new Action(() => listBox1.TopIndex = listBox1.Items.Count - 1));
                }

                //Get ping info
                string pingInfo = "";
                string pingTTL = "";
                System.Net.IPAddress hostIP = null;
                
                

                //bool to stop continuing ping if host cannot be converted to IP
                if (ipAddressBox.Text != "")
                {
                    try
                    {
                        System.Net.NetworkInformation.Ping myPing = new System.Net.NetworkInformation.Ping();
                        String host = null;

                        if (forceIPv4 == true)
                        {
                            host = Array.FindAll(System.Net.Dns.GetHostEntry(ipAddressBox.Text).AddressList, a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)[0].ToString();
                        }
                        else
                        {
                            host = ipAddressBox.Text;
                        }
                        

                        byte[] buffer = new byte[32];
                        System.Net.NetworkInformation.PingOptions pingOptions = new System.Net.NetworkInformation.PingOptions();

                        System.Net.NetworkInformation.PingReply reply = null;
                        try
                        {
                            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                            stopwatch.Start();
                            reply = myPing.Send(host, 1000, buffer, pingOptions);
                            stopwatch.Stop();
                            pingTimeOut = stopwatch.Elapsed.Milliseconds;
                            hostIP = reply.Address;
                        }
                        catch(Exception)
                        {
                            //MessageBox.Show("Error sending ping: " + ex.Message);
                            listBox1.Invoke(new Action(() => listBox1.Items.Add("Cannot find IP address of the hostname: " + ipAddressBox.Text)));
                            canConnect = false;

                        }

                        if (/*reply != null &&*/ reply.Status.ToString().Contains("Success") && reply.Options.Ttl.ToString() != null )
                        {
                            
                            canConnect = true;
                            
                            //IPv6 doesn't have TTL, check for that
                            if(/*pingTTL == null*/ reply.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                            {

                                pingTTL = null;
                            }
                            else
                            {
                                pingTTL = reply.Options.Ttl.ToString();
                            }
                            
                            
                            pingInfo = reply.RoundtripTime.ToString();
                            //MessageBox.Show(pingInfo);
                            
                        }

                        
                    }

                    catch (Exception)
                    {
                       //Failed to get host or ping
                    }
                }
                else
                {
                    canConnect = false;
                }

                if (canConnect == true)
                {
                    if (showFailsOnly.Checked == false)
                    {
                        //This is what's printed to the screen
                        //invoke because this is in another thread!
                        try
                        {
                            this.Invoke(new Action(() => this.BackColor = System.Drawing.Color.Green));
                        }
                        catch (Exception)
                        {

                        }

                        listBox1.Invoke(new Action(() => listBox1.Items.Add("IP Address: " + hostIP)));
                        listBox1.Invoke(new Action(() => listBox1.Items.Add(DateTime.Now + "  " + (ipAddressBox.Text) + " is " + "UP")));
                        listBox1.Invoke(new Action(() => listBox1.Items.Add("Round Trip Time: " + pingInfo)));
                        if (pingTimeOut >= 0) { listBox1.Invoke(new Action(() => listBox1.Items.Add(pingTimeOut.ToString() + " milliseconds"))); }
                        
                        try
                        {
                            if (pingTTL != null || hostIP.AddressFamily != System.Net.Sockets.AddressFamily.InterNetworkV6) { listBox1.Invoke(new Action(() => listBox1.Items.Add("TTL: " + pingTTL))); }
                        }
                        catch (Exception)
                        {
                            //
                        }
                        //Get OS Version info if the user selects it
                        if (attemptOSVersion.Checked == true) { if (osVersion != null) { listBox1.Invoke(new Action(() => listBox1.Items.Add("OS: " + osVersion))); } }
                        listBox1.Invoke(new Action(() => listBox1.Items.Add(" ")));

                        //Set max timeout
                        if(Convert.ToInt32(maxTimeOutCounter.Text) < pingTimeOut)
                        {
                            maxTimeOutCounter.Invoke(new Action(() => maxTimeOutCounter.Text = pingTimeOut.ToString()));
                        }
                    }
                    

                    //Tick Succsess
                    succeedCounter.Invoke(new Action(() => succeedCounter.Text = (Convert.ToInt32(succeedCounter.Text) + 1).ToString() ));

                    

                }
                else
                {
                    this.Invoke(new Action(() => this.BackColor = System.Drawing.Color.Red));
                    //invoke because this is in another thread!
                    listBox1.Invoke(new Action(() => listBox1.Items.Add("IP Address: " + hostIP)));
                    listBox1.Invoke(new Action(() => listBox1.Items.Add(DateTime.Now + "  " + (ipAddressBox.Text) + " is " + "DOWN")));
                    listBox1.Invoke(new Action(() => listBox1.Items.Add(" ")));
                    //Tick fail
                    failCounter.Invoke(new Action(() => failCounter.Text = (Convert.ToInt32(failCounter.Text) + 1).ToString()));
                }
                //timeout

                //Get the reliability, succseed / total
                reliabilityCounter.Invoke(new Action(() => reliabilityCounter.Text = Math.Round((Convert.ToDouble(succeedCounter.Text) / (Convert.ToDouble(succeedCounter.Text) + Convert.ToDouble(failCounter.Text))) * 100, 2).ToString() + "%"));

                //update chart
                updateChart();
                if(userWaitTime != 0)
                {
                    System.Threading.Thread.Sleep(userWaitTime * 1000);
                }
                



                GC.Collect();


            }
            
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            this.BackColor = SystemColors.Control;
            worker.CancelAsync();
            //stopThread = true;
            ipAddressBox.Enabled = true;
            waitTime.Enabled = true;
            monitorButton.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sPath = "output.txt";
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
            SaveFile.Close();

            //Null items
            SaveFile = null;
            sPath = null;
        }

        public string GetOsVersion(string ipAddress)
        {
            if(ipAddressBox.Text == "") { return "ADDRESS EMPTY"; }
            System.Net.NetworkInformation.Ping myPing = new System.Net.NetworkInformation.Ping();
            String host = ipAddressBox.Text;
            byte[] buffer = new byte[32];
            //MessageBox.Show(timeout.ToString());
            System.Net.NetworkInformation.PingOptions pingOptions = new System.Net.NetworkInformation.PingOptions();
            System.Net.NetworkInformation.PingReply reply;
            try {
                reply = myPing.Send(host, 1000, buffer, pingOptions);
            }
            catch (Exception ex)
            {
                //FIX!!
                return ex.Message;
            }

            //Null out variables not needed
            myPing = null;
            host = null;
            buffer = null;
            pingOptions = null;
            

             int pingTTL = reply.Options.Ttl;
            reply = null;
            GC.Collect();



            //Only attempt this if it's a Windows host
            if (pingTTL <= 128 && pingTTL > 64)
                {
                
                try
                {
                    //This will display the message to the user letting them know the program is getting the OS
                    listBox1.Items.Add("Trying to get OS information, this may take a second or two");
                    //Check to see if the port is open before you access the registry, if not the .NET API will freeze and sometimes crash
                        
                        using (var reg = Microsoft.Win32.RegistryKey.OpenRemoteBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, ipAddress))
                        using (var key = reg.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\"))
                        {
                            return string.Format("Name:{0}, Version:{1}", key.GetValue("ProductName"), key.GetValue("CurrentVersion"));
                        }
                    

                }
                catch(Exception)
                {
                    
                        return "Windows";
                    

                }
                

                }
                else if (pingTTL <= 64)
                {
                        return "Linux";
                }
                else if (pingTTL <= 255 && pingTTL >= 129)
                {
                    return "Unix";
                }
                else
                {
                    return "Error getting OS";
                }
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            succeedCounter.Text = "0";
            failCounter.Text = "0";
            updateChart();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            maxTimeOutCounter.Text = "0";
            reliabilityCounter.Text = "0";
        }

        private void ipAddressBox_TextChanged(object sender, EventArgs e)
        {
            ActiveForm.AcceptButton = monitorButton;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox1 box = new AboutBox1())
            {
                box.ShowDialog(this);
            }
            
        }

        //START Overloads
        private void aboutToolStripMenuItem_Click()
        {
            using (AboutBox1 box = new AboutBox1())
            {
                box.ShowDialog(this);
            }
        }

        private void stopButton_Click()
        {
            
            //Only run if the worker is busy
            if(worker != null && worker.IsBusy == true)
            {
                stopButton.Enabled = false;
                this.BackColor = SystemColors.Control;
                worker.CancelAsync();
                //stopThread = true;
                ipAddressBox.Enabled = true;
                waitTime.Enabled = true;
                monitorButton.Enabled = true;
            }
            

        }
        private void saveAs(string path = "output.txt")
        {
            //string sPath = path;
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(path);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
            SaveFile.Close();
            SaveFile = null;
        }
        private void saveAs(string path = "output.txt", string imageOutput = "graph.png")
        {
            //string sPath = path;
            //Save text file
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(path);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
            SaveFile.Close();

            //Save image
            pingChart.SaveImage(imageOutput, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            SaveFile = null;
        }

        //END Overloads

        //Catch User input into form
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode.ToString())
            {
                case "F1":
                    aboutToolStripMenuItem_Click();
                    break;

                case "Escape":
                    stopButton_Click();
                    break;

                case "S":
                    stopButton_Click();
                    break;

                case "W":
                    saveAs("output.txt");
                    break;

                case "C":
                    listBox1.Items.Clear();
                    succeedCounter.Text = "0";
                    failCounter.Text = "0";
                    updateChart();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    break;


          

            }
            
        }

        private void stayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check if the menu item is checked, if not check it and make the Windows on top
            if(stayOnTopToolStripMenuItem.Checked != true)
            {
                Form1.ActiveForm.TopMost = true;
                stayOnTopToolStripMenuItem.Checked = true;
            }
            else
            {
                Form1.ActiveForm.TopMost = false;
                stayOnTopToolStripMenuItem.Checked = false;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void columnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pingChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void pieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pingChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        //This will update the chart when ever called and grab the numbers from the counters
        private void updateChart()
        {
            if(showGraph == true)
            {
                if(pingChart.Series[0].ChartType == System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie)
            {
                    
                    //This is a pie chart
                pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.Clear()));
                pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.Add(0)));
                pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.ElementAt(0).Label = "Succeed " + succeedCounter.Text));
                pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.ElementAt(0).SetValueXY(0, Convert.ToInt32(succeedCounter.Text))));
                pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.Add(1)));
                pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.ElementAt(1).Label = "Failed " + failCounter.Text));
                pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.ElementAt(1).SetValueXY(0, Convert.ToInt32(failCounter.Text))));
                

            }
            else
            {
                    //This is a column chart
                    //I can't figure out why 1 is being added to succeed point even though there are 0
                    if(succeedCounter.Text == "0")
                    {
                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.Clear()));
                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.Add(0)));
                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.ElementAt(0).AxisLabel = "Failed " + failCounter.Text));
                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.ElementAt(0).SetValueY(Convert.ToInt32(failCounter.Text))));
                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.AddXY(1, 0)));

                    }
                    else
                    {
                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.Clear()));
                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.Add(0)));
                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.ElementAt(0).AxisLabel = "Succeed " + succeedCounter.Text));
                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.ElementAt(0).SetValueY(Convert.ToInt32(succeedCounter.Text))));
                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.AddXY(1, 0)));

                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.Add(1)));
                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.ElementAt(1).AxisLabel = "Failed " + failCounter.Text));
                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.ElementAt(1).SetValueY(Convert.ToInt32(failCounter.Text))));
                        pingChart.Invoke(new Action(() => pingChart.Series["Pings"].Points.AddXY(0, 1)));
                    }
                
            }
            }
            
            
        }

        private void forceIPv4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (forceIPv4ToolStripMenuItem.Checked != true)
            {
                forceIPv4 = true;
                forceIPv4ToolStripMenuItem.Checked = true;
            }
            else
            {
                forceIPv4 = false;
                forceIPv4ToolStripMenuItem.Checked = false;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            saveFileDialog.Filter = "Text Files | *.txt";
            saveFileDialog.ShowDialog();
            string saveFilePath = saveFileDialog.FileName;
            saveAs(saveFilePath);
        }

        //Saving the output and the graph, right now image part doesn't work as the user cannot open it
        private void saveAsWithGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is currently being worked on. For now you can screen shot the graph.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*
            //This will save the text and the image
            saveFileDialog.Filter = "Text Files | *.txt";
            saveFileDialog.FileName = "out";
            saveFileDialog.ShowDialog();
            string saveFilePath = saveFileDialog.FileName;
            saveAs(saveFilePath);

            saveFileDialog.Reset();
            saveFileDialog.Filter = "PNG | *.png";
            saveFileDialog.FileName = "out";
            saveFileDialog.ShowDialog();
            string saveImagePath = saveFileDialog.FileName;
            saveAs(saveImagePath);
            */
        }

        //This is to copy what ever the user selects into the clipboard
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String strItem;
            string copyto = null;
            foreach (Object selecteditem in listBox1.SelectedItems)
            {
                strItem = (selecteditem as String) + Environment.NewLine;
                copyto = copyto + strItem;
                
                //Process(strItem);
            }
            Clipboard.SetText(copyto);
            
            copyto = null;
            strItem = null;
        }

        //Help Tips!
        private void listBox1_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Select one or multiple lines to copy to clipboard", listBox1);
        }

        private void pingChart_MouseLeave(object sender, EventArgs e)
        {
            t1.Hide(listBox1);
            
        }

        //This will change the text green if what they provide is a valid IP, will check as typing
        private void ipAddressBox_KeyDown(object sender, KeyEventArgs e)
        {

        }


        //This option hides the graph
        private void hideGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hideGraphToolStripMenuItem.Checked != true)
            {
                showGraph = false;
                pingChart.Series["Pings"].Points.Clear();
                pingChart.Visible = false;
                GC.Collect();
                this.Size = new Size(625, 468);
                hideGraphToolStripMenuItem.Checked = true;
            }
            else
            {
                showGraph = true;
                pingChart.Visible = true;
                this.Size = new Size(983, 468);
                hideGraphToolStripMenuItem.Checked = false;
            }

        }

        private void changeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://martinojones.com/monitornode/changelog.txt");
        }

        private void checkForUpdate(bool returnMessage = false)
        {
            string line1 = null;
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    client.DownloadFile("https://martinojones.com/monitornode/changelog.txt", "changelog.txt");
                }
            }
            catch(Exception)
            {
                //Only show message if the user is expecting to see a message, don't want shown at launch
                if (returnMessage == true)
                {
                    MessageBox.Show("Failed to contact server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            

            try
            {
                line1 = System.IO.File.ReadLines("changelog.txt").First();
            }
            catch(Exception )
            {
                //Only show message if the user is expecting to see a message, don't want shown at launch
                if (returnMessage == true)
                {
                    MessageBox.Show("Cannot find changelog file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            finally
            {
                //delete file downloaded
                try
                {
                    System.IO.File.Delete("changelog.txt");
                }
                catch(Exception)
                {
                    MessageBox.Show("Was unable to remove the changelog file downloaded to the current diretory.");
                }

                //split if it's not null meaning it couldn't get the lastest version
                if (line1 != null)
                {
                    line1 = line1.Split('#')[1];
                }

                var currentVersion = new Version(Application.ProductVersion);
                var onlineVersion = new Version(line1);

                if(currentVersion < onlineVersion)
                {
                    string updateAnswer = MessageBox.Show("There's an update. Version: " + line1 + ". Would you like to update?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString();
                    if(updateAnswer == "Yes")
                    {
                        using (var client = new System.Net.WebClient())
                        {
                            client.DownloadFile("https://martinojones.com/monitornode/monitornode.exe", "monitornode" + line1 + ".exe");
                        }
                    }
                }
                else
                {
                    if(returnMessage == true)
                    {
                        MessageBox.Show("You're on the latest update. Version " + line1);
                    }
                }
                
            }

            
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkForUpdate(true);
        }

        private void ipAddressBox_KeyDown(object sender, KeyPressEventArgs e)
        {
            System.Net.IPAddress ipAddress = null;

            bool isValidIp = System.Net.IPAddress.TryParse(ipAddressBox.Text, out ipAddress);
            if (isValidIp == true)
            {
                ipAddressBox.ForeColor = Color.Green;
            }
            else
            {
                ipAddressBox.ForeColor = Color.Black;
            }
            ipAddress = null;
        }


    }



}