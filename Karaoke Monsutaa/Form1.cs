using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Yeti;
using Yeti.Lame;
using Yeti.MMedia.Mp3;
using System.Net.Sockets;
using System.Net;
using System.Xml;


namespace Karaoke_Monsutaa
{
    public partial class Form1 : Form
    {
        // playback system
        private FMOD.System system = null;
        private FMOD.Sound alertSound = null;
        private FMOD.Channel channel = null;
        //private FMOD.Sound[] sound = new FMOD.Sound[5];
        //private FMOD.Channel[] channel = new FMOD.Channel[5];
        private FMOD.ChannelGroup groupA = null, groupB = null, masterGroup = null;
        private Song playingSong = null;
        private int silenceCnt = 0;
        private ulong runTicks = 0;
        private int nonStarterCnt = 0;
        private bool delayedMusicSend = false;
        private int delayedMusicSendCnt = 0;
        private float maxVocaldb = 0;
        private int maxVocaldbticks = 0;
        private ulong lastSongAdded = 0;

        // DSP controls
        private FMOD.DSP dspreverb = null, dspreverb2 = null, dspnormalize = null, dsppitch = null, dspnormalize2 = null;
        private FMOD.DSP dspmutelow = null, dspboosthigh = null, dsphighpass = null, dsplowpass = null;
        private FMOD.DSP dspwarmth = null, dspthicken = null;
        private bool reverbon = true;
        float pitchOff = 1.0f;
        private FMOD.DSPConnection dspconnectiontemp = null;
        private FMOD.DSPConnection dspconnectiontemp2 = null;
        private FMOD.DSPConnection dspconnectiontemp3 = null;
        private FMOD.DSPConnection dspconnectiontemp4 = null;
        private FMOD.DSPConnection dspconnectiontemp5 = null;
        private FMOD.DSPConnection dspconnectiontemp6 = null;
        private FMOD.DSPConnection dspconnectiontemp7 = null;
        private FMOD.DSPConnection dspconnectiontemp8 = null;
        private FMOD.DSPConnection dspconnectiontemp9 = null;

        // encoding options
        private bool recording = false;
        private Compressor compressor = new Compressor();
        private InputRecorder recorder = new InputRecorder();

        // spectrum & miku
        private const int SPECTRUMSIZE = 64;
        private float[] spectrum = new float[SPECTRUMSIZE];

        // networked components
        private Login login = new Login();
        private bool autoNetworkRetry = false;
        private String lastFilenameUsed = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
            
            FMOD.RESULT result;
            result = FMOD.Factory.System_Create(ref system);
            ERRCHECK(result);
            Login.system = system;
            Track.system = system;
            InputRecorder.system = system;
            Compressor.system = system;

            uint version = 0;
            result = system.getVersion(ref version);
            ERRCHECK(result);
            if (version < FMOD.VERSION.number)
            {
                MessageBox.Show("Error!  You are using an old version of FMOD " + version.ToString("X") + ".  This program requires " + FMOD.VERSION.number.ToString("X") + ".");
                Application.Exit();
            }

            // popup login info
            login.Init();

            if (login.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Login failed, can't continue...");
                Application.Exit();
                Environment.Exit(-1);
            }

            this.Text = Login.Username + " @ Karaoke MONSTER " + " v0.87";

            // caps check
            FMOD.CAPS caps = FMOD.CAPS.NONE;
            FMOD.SPEAKERMODE speakermode = FMOD.SPEAKERMODE.STEREO;

            int minfrequency = 0, maxfrequency = 0;
            StringBuilder name = new StringBuilder(128);

            result = system.getDriverCaps(0, ref caps, ref minfrequency, ref maxfrequency, ref speakermode);
            ERRCHECK(result);

            if ((caps & FMOD.CAPS.HARDWARE_EMULATED) == FMOD.CAPS.HARDWARE_EMULATED) /* The user has the 'Acceleration' slider set to off!  This is really bad for latency!. */
            {                                                                        /* You might want to warn the user about this. */
                MessageBox.Show("Hardware Emulation detected. This may cause synchronization problems.");
                //result = system.setDSPBufferSize(1024, 10);	                     /* At 48khz, the latency between issuing an fmod command and hearing it will now be about 213ms. */
                ERRCHECK(result);
            }


            // system init
            result = system.init(16, FMOD.INITFLAGS.NORMAL, (IntPtr)null);
            ERRCHECK(result);

            // channel init
            result = system.createChannelGroup("Group A", ref groupA);
            ERRCHECK(result);

            result = system.createChannelGroup("Group B", ref groupB);
            ERRCHECK(result);

            result = system.getMasterChannelGroup(ref masterGroup);
            ERRCHECK(result);

            result = masterGroup.addGroup(groupA);
            ERRCHECK(result);

            result = masterGroup.addGroup(groupB);
            ERRCHECK(result);

            // dsp system

            result = system.createDSPByType(FMOD.DSP_TYPE.REVERB, ref dspreverb);
            ERRCHECK(result);

            result = system.createDSPByType(FMOD.DSP_TYPE.REVERB, ref dspreverb2);
            ERRCHECK(result);

            result = system.createDSPByType(FMOD.DSP_TYPE.PITCHSHIFT, ref dsppitch);
            ERRCHECK(result);

            result = system.createDSPByType(FMOD.DSP_TYPE.NORMALIZE, ref dspnormalize);
            ERRCHECK(result);
            dspnormalize.setParameter((int)FMOD.DSP_NORMALIZE.FADETIME, 4000);
            dspnormalize.setParameter((int)FMOD.DSP_NORMALIZE.THRESHHOLD, .10f);
            dspnormalize.setParameter((int)FMOD.DSP_NORMALIZE.MAXAMP,  20);

            result = system.createDSPByType(FMOD.DSP_TYPE.NORMALIZE, ref dspnormalize2);
            ERRCHECK(result);
            dspnormalize2.setParameter((int)FMOD.DSP_NORMALIZE.FADETIME, 10000);
            dspnormalize2.setParameter((int)FMOD.DSP_NORMALIZE.THRESHHOLD, .25f);
            dspnormalize2.setParameter((int)FMOD.DSP_NORMALIZE.MAXAMP, 5);

            // hpf for useless noise. 
            result = system.createDSPByType(FMOD.DSP_TYPE.HIGHPASS, ref dsphighpass);
            ERRCHECK(result);
            dsphighpass.setParameter((int)FMOD.DSP_HIGHPASS.CUTOFF, 80);

            // lpf for hiss
            result = system.createDSPByType(FMOD.DSP_TYPE.LOWPASS_SIMPLE, ref dsplowpass);
            ERRCHECK(result);
            dsplowpass.setParameter((int)FMOD.DSP_LOWPASS_SIMPLE.CUTOFF, 16000);

            // deaden noise
            result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, ref dspmutelow);
            ERRCHECK(result);
            dspmutelow.setParameter((int)FMOD.DSP_PARAMEQ.CENTER, 49.00f); // 49 = G1, A0 = 27.50
            dspmutelow.setParameter((int)FMOD.DSP_PARAMEQ.GAIN, 0.20f);


            // warmth
            result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, ref dspwarmth);
            ERRCHECK(result);
            dspwarmth.setParameter((int)FMOD.DSP_PARAMEQ.CENTER, 240.00f); 
            dspwarmth.setParameter((int)FMOD.DSP_PARAMEQ.GAIN, 1.20f);
            dspwarmth.setParameter((int)FMOD.DSP_PARAMEQ.BANDWIDTH, 1.50f); 


            // thicken 
            result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, ref dspthicken);
            ERRCHECK(result);
            dspthicken.setParameter((int)FMOD.DSP_PARAMEQ.CENTER, 1200.00f); 
            dspthicken.setParameter((int)FMOD.DSP_PARAMEQ.GAIN, 0.80f);
            dspthicken.setParameter((int)FMOD.DSP_PARAMEQ.BANDWIDTH, 1.0f); 
            
            // add vocal presence
            result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, ref dspboosthigh);
            ERRCHECK(result);
            dspboosthigh.setParameter((int)FMOD.DSP_PARAMEQ.CENTER, 7000.0f); // E7
            dspboosthigh.setParameter((int)FMOD.DSP_PARAMEQ.GAIN, 1.40f);
            dspboosthigh.setParameter((int)FMOD.DSP_PARAMEQ.BANDWIDTH, 0.75f); // half octave

            result = groupB.addDSP(dsplowpass, ref dspconnectiontemp9);
            ERRCHECK(result);

            result = groupB.addDSP(dsphighpass, ref dspconnectiontemp8);
            ERRCHECK(result);

            result = groupB.addDSP(dspmutelow, ref dspconnectiontemp6);
            ERRCHECK(result);

            result = groupB.addDSP(dspboosthigh, ref dspconnectiontemp7);
            ERRCHECK(result);

            dspconnectiontemp7 = null;
            result = groupB.addDSP(dspwarmth, ref dspconnectiontemp7);
            ERRCHECK(result);

            dspconnectiontemp7 = null;
            result = groupB.addDSP(dspthicken, ref dspconnectiontemp7);
            ERRCHECK(result);

            result = groupB.addDSP(dspnormalize, ref dspconnectiontemp4);
            ERRCHECK(result);

            result = groupA.addDSP(dspnormalize2, ref dspconnectiontemp5);
            ERRCHECK(result);


            //groupA.setVolume(0.5f);
            result = groupA.addDSP(dspreverb, ref dspconnectiontemp);
            ERRCHECK(result);

            volumeTrack1.Value = 7;
            volumeTrack1_Scroll(null, null);

            result = groupB.addDSP(dspreverb2, ref dspconnectiontemp3);
            ERRCHECK(result);

            volumeBarTrack2.Value = 8;
            volumeBarTrack2_Scroll(null, null);


            // recording init
            recorder.Init();

            //----------- netstream playback
            result = system.setStreamBufferSize(32*1024, FMOD.TIMEUNIT.RAWBYTES);
            ERRCHECK(result);

            result = system.setNetworkTimeout(5000);
            ERRCHECK(result);

            playTrack1.Enabled = false;
            stopTrack1.Enabled = false;

            // ---- comm server
            network1.Activate();

            // --- start sound
            result = system.createSound("button-42.mp3", FMOD.MODE.HARDWARE | FMOD.MODE.CREATESTREAM, ref alertSound);
            ERRCHECK(result);


            /*
                Read and display all tags associated with this file
            FMOD.TAG tag = new FMOD.TAG();
            for (; ; )
            {
                /*
                    An index of -1 means "get the first tag that's new or updated".
                    If no tags are new or updated then getTag will return FMOD_ERR_TAGNOTFOUND.
                    This is the first time we've read any tags so they'll all be new but after we've read them, 
                    they won't be new any more.
                if (sound.getTag(null, -1, ref tag) != FMOD.RESULT.OK)
                {
                    break;
                }
                if (tag.datatype == FMOD.TAGDATATYPE.STRING)
                {
                    System.Console.WriteLine(tag.name + " = " + Marshal.PtrToStringAnsi(tag.data) + " (" + tag.datalen + " bytes)");
                }
            }
                */

            /*
                Load up an extra plugin that is not normally used by FMOD.
            */

            /*
            uint handle = 0;
            result = system.loadPlugin("codec_aac.dll", ref handle, 2400);
            if (result != FMOD.RESULT.OK)
            {
                System.Console.WriteLine("Problem loading codec_aac.dll  ");
            }
            else
            {
                System.Console.WriteLine("OK codec_aac.dll");
            }
             */
        }

        public void playAlert()
        {
            if (alertCheckBox.Checked && !recording)
            {
                FMOD.RESULT result;

                result = system.playSound(FMOD.CHANNELINDEX.REUSE, alertSound, true, ref channel);
                ERRCHECK(result);
                result = channel.setPaused(false);
                ERRCHECK(result);
            }
        }

        public float GetMusicDB()
        {
            double avg = 0;

            groupA.getSpectrum(spectrum, SPECTRUMSIZE, 0, FMOD.DSP_FFT_WINDOW.TRIANGLE);
            //masterGroup.getSpectrum(spectrum, SPECTRUMSIZE, 0, FMOD.DSP_FFT_WINDOW.TRIANGLE);

            for (int i = 0; i < SPECTRUMSIZE; i++)
            {
                if (spectrum[i] > 0)
                        avg += (double)spectrum[i] * (double)spectrum[i];
            }
            avg /= (double)SPECTRUMSIZE;
                         
            avg = Math.Sqrt(avg);

            // avg = root mean square of all recorded amplitudes
            avg = 20.0 * Math.Log10(avg / 0.000002);

            return (float) avg;
        }

        public float GetUserDB()
        {
            return recorder.GetActiveDB(groupB);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (masterGroup != null)
            {
                runTicks++;

                if (runTicks % 3000 == 0) // 5900
                    Network.Send(new string[] { "ping" });
            }

            if (system != null)
            {
                system.update();

                if (playingSong != null)
                {

                    if (autoNetworkRetry && playingSong.Ready)
                        playTrack1_Click(null, null);
                    else if (autoNetworkRetry)
                    {
                        int pct = (int) playingSong.PctBuffered;
//                        Console.WriteLine("pct buff = " + pct);
                        if(pct > progressBarLoading.Maximum)
                            pct = progressBarLoading.Maximum;
                        if(pct < progressBarLoading.Minimum)
                            pct = progressBarLoading.Minimum;

                        progressBarLoading.Value = pct;

                        if (pct == 0)
                            nonStarterCnt++;
                    }

                    if (songLabel.Text.Length == 0 && playingSong.Ready)
                    {
                        String artist = playingSong.Artist;
                        String title = playingSong.Title;
                        if (artist.Length > 0 && title.Length > 0)
                            songLabel.Text = artist + "\r\n" + title;
                        else if (artist.Length == 0 && title.Length > 0)
                            songLabel.Text = title;
                        else if (artist.Length > 0 && title.Length == 0)
                            songLabel.Text = artist;
                        else
                            songLabel.Text = "Unknown";

                        playlist1.Refresh();
                    }


                    // delayed music start message. lets the server collect a few seconds of data, and allows the user
                    // to make quick changes.
                    if (delayedMusicSend)
                    {
                        delayedMusicSendCnt++;

                        if (delayedMusicSendCnt > (BroadcastStream.LowBandwidth ? 200 : 50))
                        {
                            pitchUp.Enabled = false;
                            pitchNormal.Enabled = false;
                            pitchDown.Enabled = false;
                            delayedMusicSend = false;
                            //Network.Send("<music name=\"" + Login.Username + "\" artist=\"" + playingSong.Artist.Replace("&", "") + "\" title=\"" + playingSong.Title + "\" source=\"" + openFileDialog.FileName + "\" pitch=\"" + pitchOff + "\" live=\"1\" />\r\n)");
                            Network.Send(new string[] { "music", "name", Login.Username, "artist", playingSong.Artist, "title", playingSong.Title, "source", lastFilenameUsed, "length", playingSong.LengthMS.ToString(), "pitch", pitchOff.ToString(), "live", "1" });
                        }
                    }

                    uint lenms = playingSong.LengthMS;
                    if (lenms == 0)
                        lenms = (uint) playingSong.LengthPassed;
                    //int lenms2 = playingSong.LengthPassed;
                    uint ms = playingSong.PositionMS;
                    bool paused = playingSong.Paused;

                    if(!paused)
                    {
                        // update time
                        timeLabel.Text = (ms / 1000 / 60) + ":" + ((ms / 1000 % 60) < 10 ? "0" : "") + (ms / 1000 % 60) + " / " + (lenms / 1000 / 60) + ":" + ((lenms / 1000 % 60) < 10 ? "0" : "") + (lenms / 1000 % 60);

                        //playingSong.BuffDelay();

                        // ---- update spectrum analyzer ---
                        float musicdb = GetMusicDB();

                        if (musicdb > volumeBar1.Maximum)
                            volumeBar1.Value = volumeBar1.Maximum;
                        else if (musicdb < volumeBar1.Minimum)
                            volumeBar1.Value = volumeBar1.Minimum;
                        else
                            volumeBar1.Value = (int) musicdb;



                        float vocaldb = recorder.GetActiveDB();

                        if (playingSong.SelfOwn)
                        {
                            if (vocaldb > maxVocaldb)
                                maxVocaldb = vocaldb;

                            maxVocaldbticks++;
                        }

                        if(!recording)
                        {
                            vocaldb = GetUserDB();
                        }


                        voiceInputLabel.BackColor = Color.Transparent;
                        if (vocaldb > volumeBar2.Maximum)
                        {
                            volumeBar2.Value = volumeBar2.Maximum;
                            voiceInputLabel.BackColor = Color.Red;
                        }
                        else if (vocaldb < volumeBar2.Minimum)
                            volumeBar2.Value = volumeBar2.Minimum;
                        else if (volumeBar2.Value > (int)vocaldb)
                            volumeBar2.Increment(-5);
                        else
                            volumeBar2.Value = (int)vocaldb;



                        Console.WriteLine("vdb = " + vocaldb + " mdb = " + musicdb);

                        avatar1.SetMode(musicdb, vocaldb);

                        //Console.WriteLine("avg = " + musicdb);
                        if (!autoNetworkRetry && musicdb < 10 && vocaldb < 15 && ms > 5000)
                            silenceCnt++;
                        else if (musicdb > 10)
                            silenceCnt = 0;

                        // stop on streaming silence
                        if (silenceCnt > 65) // 15
                        {
                            Console.WriteLine("Form1.Update Silence stop");
                            stopTrack1_Click(null, null);
                        }

                        // stop within .2 seconds of end of track
                        if (lenms > 0 && (lenms - ms) < 200)
                        {
                            Console.WriteLine("Form1.Update Near end stop {0} {1}", lenms, ms);
                            stopTrack1_Click(null, null);
                        }
                    }

                    // discard it
                    //if (nonStarterCnt > 50)
                    //    stopTrack1_Click(null, null);
                        //playingSong = null;

                    // makes miku dance
                    avatar1.Refresh();

                }

                // --- record system ---
                if (recording && playingSong != null)
                {
                    uint trackpos = playingSong.PositionPCMBytes;

                    compressor.Update(trackpos);
                    recorder.Update();
//                    Console.WriteLine("{0} drift, {1}, {2}", (int) (compressor.Length / 2 / compressor.Channels) - (int) recorder.Length, (compressor.Length / 2 / compressor.Channels), recorder.Length);
                }

                // update note
                noteLabel.Text = recorder.LastNote;
            }
        }

        private void ERRCHECK(FMOD.RESULT result)
        {
            if (result != FMOD.RESULT.OK)
            {
                timer.Stop();
                String error = "FMOD error! " + result + " - " + FMOD.Error.String(result) + Environment.StackTrace;
                
                System.Console.WriteLine(error);
                MessageBox.Show(error);
                // throw new Exception(error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pitchOff == 1.0f)
            {
                groupA.addDSP(dsppitch, ref dspconnectiontemp2);
                dsppitch.setParameter((int)FMOD.DSP_PITCHSHIFT.FFTSIZE, 1024);
            }

            pitchOff -= .02f;
            if (playingSong != null)
                playingSong.Pitch = pitchOff;

            if (pitchOff == 1.0f)
                dsppitch.remove();

            dsppitch.setParameter((int)FMOD.DSP_PITCHSHIFT.PITCH, 1 / pitchOff);
        }

        private void pitchDown_Click(object sender, EventArgs e)
        {
            if (pitchOff == 1.0f)
            {
                groupA.addDSP(dsppitch, ref dspconnectiontemp2);
                dsppitch.setParameter((int)FMOD.DSP_PITCHSHIFT.FFTSIZE, 1024);
            }

            pitchOff += .02f;
            if (playingSong != null)
                playingSong.Pitch = pitchOff;

            if (pitchOff == 1.0f)
                dsppitch.remove();

            dsppitch.setParameter((int)FMOD.DSP_PITCHSHIFT.PITCH, 1 / pitchOff);
        }

        private void pitchNormal_Click(object sender, EventArgs e)
        {
            pitchOff = 1.0f;
            dsppitch.remove();
            if (playingSong != null && (playingSong.Owner == Login.Username || playingSong.Owner == ""))
                playingSong.Pitch = pitchOff;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            lastFilenameUsed = openFileDialog.FileName;
            Console.WriteLine("OFD_FO " + openFileDialog.FileName);
            compressor.Load(openFileDialog.FileName);
            if (sender is Song)
            {
                playingSong = (Song) sender;
            }
            else
            {
                playingSong = new Song("", "", "", openFileDialog.FileName, pitchOff, 0, -1);
                playlist1.AddSong(playingSong);
            }
            playingSong.Load();
            playingSong.EndSonged += new Song.EndTrackHandler(playingSong_EndSonged);

            songLabel.Text = "";
            
            loadTrack1.Enabled = false;
            playTrack1.Enabled = true;
            stopTrack1.Enabled = true;
            playTrack1.Text = "Start";
            songLabel.Visible = true;
            pitchNormal_Click(null, null);
        }

        void playingSong_EndSonged(Song s)
        {
            Console.WriteLine("Form1.Playingsong_ended");
            stopTrack1_Click(s, null);
        }

        private void playTrack1_Click(object sender, EventArgs e)
        {
            //FMOD.RESULT result;
            nonStarterCnt = 0;

            if (playingSong != null)
            {
                // if still recording, end it
                if (playingSong.Ready)
                {
                    delayedMusicSendCnt = 0;
                    // recording mode
                    if (playingSong.Owner == "" || playingSong.Owner == Login.Username)
                    {
                        pitchUp.Enabled = true;
                        pitchNormal.Enabled = true;
                        pitchDown.Enabled = true;

                        playingSong.Owner = Login.Username;
                        playingSong.Pitch = pitchOff;
                        if (!playingSong.Playback)
                        {
                            delayedMusicSend = true;
                            beginRecording();
                            playingSong.Live = 1;
                            playlist1.Refresh();
                        }
                    }
                    else // playback mode
                    {
                        delayedMusicSend = false;
                        pitchUp.Enabled = false;
                        pitchNormal.Enabled = false;
                        pitchDown.Enabled = false;
                        Console.WriteLine("P " + pitchOff + " vs P " + playingSong.Pitch);
                        if (pitchOff != playingSong.Pitch)
                        {
                            if (pitchOff == 1.0f)
                            {
                                groupA.addDSP(dsppitch, ref dspconnectiontemp2);
                                dsppitch.setParameter((int)FMOD.DSP_PITCHSHIFT.FFTSIZE, 1024);
                            }

                            pitchOff = playingSong.Pitch;
                            Console.WriteLine("Remote pitch control = " + pitchOff);

                            if (pitchOff == 1.0f)
                                dsppitch.remove();

                            dsppitch.setParameter((int)FMOD.DSP_PITCHSHIFT.PITCH, 1 / pitchOff);
                        }
                    }

                    silenceCnt = 0;

                    autoNetworkRetry = false;
                    progressBarLoading.Visible = false;

                    playingSong.Play(groupA, groupB);

                    playTrack1.Text = "Retry";

                    timeLabel.Visible = true;
                    timeLabel.BringToFront();
                    //songLabel.BringToFront();
                }
                else
                {
                    autoNetworkRetry = true;
                    progressBarLoading.Visible = true;
                    playTrack1.Enabled = false;
                    //MessageBox.Show("Not ready?!");
                }
                //result = channel[0].setPaused(false);

            }
        }

        private void loadTrack1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                Console.WriteLine("Load done");
                //playTrack1_Click(sender, null);
        }

        private void beginRecording()
        {
            if (recording == true)
            {
                endRecording();
                Thread.Sleep(1000);
                system.update();
                Thread.Sleep(1000);
            }
            if (maxVocaldbticks > 3000 && maxVocaldb == 0 && recorder.Enabled)
            {
                recorder.Enabled = false;
                MessageBox.Show("No recording device detected.  Your recording input has been disabled.");
            }

            recording = true;
            //compressor.Begin(new FileStream("out2.mp3", FileMode.Create));
            if(compressor.Enabled)
                compressor.Begin(new BroadcastStream(playingSong.Source, (uint)(playingSong.PositionPCMBytes * .5), Track.MODE.MUSIC));
            //recorder.Begin(new FileStream("out.mp3", FileMode.Create));
            if(recorder.Enabled)
                recorder.Begin(new BroadcastStream(playingSong.Source, (uint)(playingSong.PositionPCMBytes * .5), Track.MODE.USER));

            Console.WriteLine("Record Track Begin22");
        }

        private void endRecording()
        {
            if (!recording)
                return;

            recorder.End();
            compressor.End();
            Console.WriteLine("Record Track End");
            //Network.Send("<recend />\r\n)");
            Network.Send(new string[] { "recend" });
            recording = false;
        }

        private void stopTrack1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Form1.stopTrack1");
            if (playingSong != null)
            {
                pitchUp.Enabled = true;
                pitchNormal.Enabled = true;
                pitchDown.Enabled = true;

                delayedMusicSend = false;
                autoNetworkRetry = false;
                progressBarLoading.Visible = false;

                endRecording();
                Song temp = playingSong;
                playingSong = null;
                if(nonStarterCnt != 50 && !(sender is Song))
                    temp.Stop();

                playTrack1.Enabled = false;
                stopTrack1.Enabled = false;
                loadTrack1.Enabled = true;

                volumeBar1.Value = volumeBar1.Minimum;
                volumeBar2.Value = volumeBar2.Minimum;

                avatar1.Mode = Avatar.MODE.INTERESTED;

                timeLabel.Visible = false;
                songLabel.Visible = false;

            }
        }

        private void volumeTrack1_Scroll(object sender, EventArgs e)
        {
            if (groupA != null)
            {
                Console.WriteLine("VT1 " + volumeTrack1.Value);

                float reverbF = reverbon ? .5f : 1.0f;
                groupA.setVolume(reverbF * (float) (1.0f * Math.Pow(volumeTrack1.Value / 10.0, 2)));
            }
        }


        private void reverbToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (reverbToggle1.Checked)
            {
                groupA.addDSP(dspreverb, ref dspconnectiontemp);
                reverbon = true;
            }
            else
            {
                dspreverb.remove();
                reverbon = false;
            }

            volumeTrack1_Scroll(null, null);
        }



        private void playlist1_SongStarted(Song s)
        {
            Console.WriteLine("Form1.Update Playingsong started");

            stopTrack1_Click(null, null);
            String tempName = openFileDialog.FileName;
            openFileDialog.FileName = s.Source;
            openFileDialog1_FileOk(s, null);
            playTrack1_Click(null, null);
            openFileDialog.FileName = tempName;
            if (s.SelfOwn && File.Exists(s.Source))
                lastFilenameUsed = s.Source;
        }

        private void network1_MsgReceived(List<string> obj)
        {
            Console.WriteLine("PRogNet " + obj[0]);
            switch (obj[0])
            {

                case "karaoke":
                    runTicks = 0;
                    room1.ParseCommand(obj);
                    break;
                case "welcome":
                case "stage":
                case "action":
                case "msg":
                case "join":
                case "disconnect":
                case "left":
                    if( room1.ParseCommand(obj) )  // returns true if an audible alert is allowed
                        playAlert();

                    break;
                case "song":
                    playlist1.ParseCommand(obj);
                    if (runTicks > 100)
                    {
                        if (playNewCheckBox.Checked && (runTicks - lastSongAdded) > 30)
                        {
                            Song s = playlist1.SelectedSong;
                            if (s != null)
                            {
                                //Thread.Sleep(1000);
                                if(playingSong == null || (playingSong.Owner != Login.Username && playingSong == s) || silenceCnt > 0)
                                    playlist1_SongStarted(s);
                            }
                        }
                        
                        room1.ParseCommand(obj);
                    }
                    lastSongAdded = runTicks;
                    break;
                case "clear":
                case "recend":
                    playlist1.ParseCommand(obj);
                    break;
                case "stop":
                    stopTrack1_Click(null, null);
                    break;
                case "forceupgrade":
                    {
                        System.Diagnostics.Process.Start("kmlaunch.exe");
                        Application.Exit();
                        break;
                    }
                case "pong":
                    break;
                default:
                    Console.WriteLine("Uknown: " + obj[0]);
                    break;
            }

        }

        private void volumeBarTrack2_Scroll(object sender, EventArgs e)
        {
            if (groupB != null)
                groupB.setVolume((float) Math.Pow(volumeBarTrack2.Value * .1f, 2));

        }

        private void delay1_CheckedChanged(object sender, EventArgs e)
        {
            if (playingSong != null && playingSong.PositionMS > 0)
            {
                playingSong.SyncDelay(0, delay1.Checked);
            }
        }

        private void delay2_CheckedChanged(object sender, EventArgs e)
        {
            if (playingSong != null && playingSong.PositionMS > 0)
            {
                playingSong.SyncDelay(1, delay2.Checked);
            }

        }

        private void volumeBarTrack3_Scroll(object sender, EventArgs e)
        {

        }

        private void delay3_CheckedChanged(object sender, EventArgs e)
        {
            if (playingSong != null && playingSong.PositionMS > 0)
            {
                playingSong.SyncDelay(1, delay2.Checked);
            }

        }
    }
}
