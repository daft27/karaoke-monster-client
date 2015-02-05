using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

namespace Karaoke_Monsutaa
{
    public partial class Login : Form
    {
        static String MD5File(String filename)
        {
            String md5sum = "";
            try
            {
                StringBuilder sb = new StringBuilder();
                FileStream fs = File.OpenRead(filename);//new FileStream(filename, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] hash = md5.ComputeHash(fs);
                fs.Close();
                foreach (byte hex in hash)
                    sb.Append(hex.ToString("x2"));
                md5sum = sb.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return md5sum;
        }


        public static FMOD.System system = null;

        static String username = "";
        static String password = "";
        public static int recdevice = 0;

        private WebClient wc = new WebClient();

        public Login()
        {
            InitializeComponent();

            // begin crc check for updates
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            wc.DownloadStringAsync(new Uri("http://karaoke.fansub.tv/update/kmlaunch.md5"));

            // load lastnick
            try
            {
                StreamReader sr = new StreamReader("lastnick.txt");
                String lastnick = sr.ReadLine();
                if (lastnick.Trim().Length > 0)
                    usernameBox.Text = lastnick.Trim();
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("failed to read lastnick.txt: " + e.Message);
            }
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Console.WriteLine("md5 data completed");
            if (e.Error == null)
            {
                String s = e.Result.Trim();
                backgroundWorker1.RunWorkerAsync(e.Result.Trim());
            }

        }

        public void Init()
        {
            comboBoxOutput.SelectedIndex = 0;
            comboBoxOutput.Items.Add("DirectSound");
            comboBoxOutput.Items.Add("Windows Multimedia WaveOut");
            comboBoxOutput.Items.Add("ASIO");
            comboBoxOutput.Items.Add("Windows Audio Session (Vista)");

            comboBoxServer.SelectedIndex = 0;
        }

        private void BuildOps()
        {
            StringBuilder drivername = new StringBuilder(256);
            FMOD.RESULT result;
            FMOD.GUID guid = new FMOD.GUID();

            // get playback audio systems
            int numdrivers = 0;
            result = system.getNumDrivers(ref numdrivers);
            ERRCHECK(result);
            for (int count = 0; count < numdrivers; count++)
            {
                try
                {
                    result = system.getDriverInfo(count, drivername, drivername.Capacity, ref guid);
                    ERRCHECK(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("e " + e.Message);
                    drivername.Append("Unknown");
                }

                comboBoxPlayback.Items.Add(drivername.ToString());
            }
            if (comboBoxPlayback.Items.Count > 0)
                comboBoxPlayback.SelectedIndex = 0;

            // get recording audio systems 
            result = system.getRecordNumDrivers(ref numdrivers);
            ERRCHECK(result);
            for (int count = 0; count < numdrivers; count++)
            {
                try
                {
                    result = system.getRecordDriverInfo(count, drivername, drivername.Capacity, ref guid);
                    ERRCHECK(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("e " + e.Message);
                    drivername.Append("Unknown");
                }

                comboBoxRecord.Items.Add(drivername.ToString());
            }
            if(comboBoxRecord.Items.Count > 0)
                comboBoxRecord.SelectedIndex = 0;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // check for valid username
            if (usernameBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            // old version alert
            if (getUpdate.Visible)
                MessageBox.Show("You are logging on using an older version of KaraokeMONSTER. Click the Update Available button on the login screen to update to the latest version.");

            // save data, proceed to next part
            username = usernameBox.Text;
            password = passwordBox.Text;

            try
            {
                StreamWriter sw = new StreamWriter("lastnick.txt");
                sw.WriteLine(usernameBox.Text.Trim());
                sw.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine("lastnick error: " + err.Message);
            }
            

            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        static public String Username
        {
            get
            {
                return username;
            }
        }

        static public String Password
        {
            get
            {
                return password;
            }
        }

        private void comboBoxPlayback_SelectedIndexChanged(object sender, EventArgs e)
        {
            FMOD.RESULT result;
            int selected = comboBoxPlayback.SelectedIndex;
            result = system.setDriver(selected);
            ERRCHECK(result);
        }



        private void comboBoxRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            FMOD.RESULT result;
            int selected = comboBoxRecord.SelectedIndex;

            //result = system.setRecordDriver(selected);
            recdevice = selected;
            //ERRCHECK(result);

        }

        private void ERRCHECK(FMOD.RESULT result)
        {
            if (result != FMOD.RESULT.OK)
            {
                throw new Exception("FMOD error! " + result + " - " + FMOD.Error.String(result));
            }
        }

        private void comboBoxOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOutput.SelectedIndex <= 0)
                return;

            FMOD.RESULT result = FMOD.RESULT.OK;
            switch (comboBoxOutput.SelectedIndex)
            {
                case 1:
                    result = system.setOutput(FMOD.OUTPUTTYPE.DSOUND);
                    break;
                case 2:
                    result = system.setOutput(FMOD.OUTPUTTYPE.WINMM);
                    break;
                case 3:
                    result = system.setOutput(FMOD.OUTPUTTYPE.ASIO);
                    break;
                case 4:
                    result = system.setOutput(FMOD.OUTPUTTYPE.WASAPI);
                    break;
            }
            ERRCHECK(result);


            comboBoxOutput.Visible = false;
            comboBoxPlayback.Visible = true;
            comboBoxRecord.Visible = true;
            BuildOps();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            audioSettings.Visible = false;
            comboBoxOutput.Visible = true;
        }

        private void getUpdate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("kmlaunch.exe");
            Application.Exit();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool reqUpd = false;
            String remotedata = (String) e.Argument;
            String[] files = remotedata.Split(new char[] { '\n' });
            foreach (String file in files)
            {
                String remotehash = file.Substring(0, 32);
                String remotename = file.Substring(34);

                // don't include the kmlaunch.md5 file that typically gets included
                if (remotename == "kmlaunch.md5")
                    continue;

                Console.WriteLine("Processing " + remotename + " (" + remotehash + ")");
                String localhash = MD5File(remotename);
                Console.WriteLine("Hash = " + localhash);

                if (remotehash != localhash)
                {
                    // update the updater
                    if (remotename == "kmlaunch.exe")
                    {
                        //String destPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + System.IO.Path.DirectorySeparatorChar + "KaraokeMONSTER" + System.IO.Path.DirectorySeparatorChar;
                        //if (!Directory.Exists(destPath))
                        //    Directory.CreateDirectory(destPath);
                        try
                        {
                            new WebClient().DownloadFile("http://karaoke.fansub.tv/update/" + remotename, remotename + ".tmp");
                            if (File.Exists(remotename + ".tmp"))
                            {
                                String updhash = MD5File(remotename + ".tmp");
                                if (updhash == remotehash)
                                    File.Replace(remotename + ".tmp", remotename, null);
                                else
                                    File.Delete(remotename + ".tmp");
                            }
                            Thread.Sleep(1000);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("exc: " + ex.Message);
                        }
                    }
                    reqUpd = true;
                }
            }
            if(reqUpd)
                backgroundWorker1.ReportProgress(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
                getUpdate.Visible = true;
        }

        private void comboBoxServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxServer.SelectedIndex)
            {
                case 0:
                    Network.ServerAddr = "haruhi.fansub.tv"; break;
                case 1:
                    Network.ServerAddr = "localhost"; break;
            }
        }

    }
}
