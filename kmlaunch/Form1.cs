using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Threading;

namespace kmlaunch
{
    public partial class Launcher : Form
    {
        private String destPath = "";
        int filesCnt = 0;
        int filesCmp = 0;

        WebClient wc = new WebClient();
        Queue<String> filesDL = new Queue<String>();
        public Launcher(String destPathIn)
        {
            InitializeComponent();

            destPath = destPathIn;
        }
        static String MD5File(String filename)
        {
            String md5sum = "";
            try
            {
                StringBuilder sb = new StringBuilder();
                FileStream fs = File.OpenRead(filename); // new FileStream(filename, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] hash = md5.ComputeHash(fs);
                fs.Close();
                foreach (byte hex in hash)
                    sb.Append(hex.ToString("x2"));
                md5sum = sb.ToString();
            }
            catch (Exception e)
            {
            }
            return md5sum;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient wc2 = new WebClient();
            String remotedata = wc2.DownloadString("http://karaoke.fansub.tv/update/kmlaunch.md5").Trim();
            String[] files = remotedata.Split(new char[]{'\n'});
            Console.WriteLine("L = " + filesCnt);

            wc = new WebClient();
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);

            foreach (String file in files)
            {
                String remotehash = file.Substring(0, 32);
                String remotename = file.Substring(34);

                if (remotename == "kmlaunch.md5")
                    continue;

                Console.WriteLine("Processing " + remotename + " (" + remotehash + ")");
                String localhash = MD5File(destPath + remotename);
                Console.WriteLine("Hash = "  + localhash);

                if (remotehash != localhash)
                    filesDL.Enqueue(remotename);
            }

            filesCnt = filesDL.Count;
            if (filesDL.Count > 0)
            {
                String name = filesDL.Dequeue();
                Console.WriteLine("Strarting @ " + name + " / " + filesCnt);
                wc.DownloadFileAsync(new Uri("http://karaoke.fansub.tv/update/" + name), destPath + name);
            }
            else
                Close();
            
        }

        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            filesCmp++;            
            if (filesDL.Count > 0)
            {
                String name = filesDL.Dequeue();
                Console.WriteLine("Strarting @ " + name);
                wc.DownloadFileAsync(new Uri("http://karaoke.fansub.tv/update/" + name), destPath + name);
            }
            if (filesCmp == filesCnt)
            {                
                Thread.Sleep(1000);
                Close();
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("V = " + e.ProgressPercentage);
            progressBar1.Value = (filesCmp * 100 / filesCnt) + (e.ProgressPercentage / filesCnt);

        }
    }
}
