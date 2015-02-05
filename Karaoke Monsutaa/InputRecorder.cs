using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using Yeti.MMedia.Mp3;
using Yeti.Lame;
using System.Windows.Forms;

namespace Karaoke_Monsutaa
{
    public class InputRecorder
    {
        static public FMOD.System system = null;

        // recording
        private FMOD.CREATESOUNDEXINFO exinfo = new FMOD.CREATESOUNDEXINFO();
        private FMOD.Sound sound = new FMOD.Sound();
        private FMOD.Channel channel = null;

        // compression
        private uint recordingdelay = 0;
        private Mp3Writer mwriter = null;
        private Stream mstream = null;
        private uint lastrecordpos = 0;
        private uint soundlength = 0;
        private uint totreclength = 0;

        // monitoring
        //private const int SPECTRUMSIZE = 64;
        private const int SPECTRUMSIZE = 8192;
        private float[] spectrum = new float[SPECTRUMSIZE];

        private bool enabled = false;
        private bool recording = false;

        // pitch detection
        private const int OUTPUTRATE = 48000 * 2;
        private const float SPECTRUMRANGE = ((float)OUTPUTRATE / 2.0f);     /* 0 to nyquist */
        private const float BINSIZE = (SPECTRUMRANGE / (float)SPECTRUMSIZE);
        private int bin = 0;
        private string lastnote;

        private string[] note =
        {
            "C 0", "C#0", "D 0", "D#0", "E 0", "F 0", "F#0", "G 0", "G#0", "A 0", "A#0", "B 0",  
            "C 1", "C#1", "D 1", "D#1", "E 1", "F 1", "F#1", "G 1", "G#1", "A 1", "A#1", "B 1",  
            "C 2", "C#2", "D 2", "D#2", "E 2", "F 2", "F#2", "G 2", "G#2", "A 2", "A#2", "B 2",  
            "C 3", "C#3", "D 3", "D#3", "E 3", "F 3", "F#3", "G 3", "G#3", "A 3", "A#3", "B 3",  
            "C 4", "C#4", "D 4", "D#4", "E 4", "F 4", "F#4", "G 4", "G#4", "A 4", "A#4", "B 4",  
            "C 5", "C#5", "D 5", "D#5", "E 5", "F 5", "F#5", "G 5", "G#5", "A 5", "A#5", "B 5",  
            "C 6", "C#6", "D 6", "D#6", "E 6", "F 6", "F#6", "G 6", "G#6", "A 6", "A#6", "B 6",  
            "C 7", "C#7", "D 7", "D#7", "E 7", "F 7", "F#7", "G 7", "G#7", "A 7", "A#7", "B 7",  
            "C 8", "C#8", "D 8", "D#8", "E 8", "F 8", "F#8", "G 8", "G#8", "A 8", "A#8", "B 8",  
            "C 9", "C#9", "D 9", "D#9", "E 9", "F 9", "F#9", "G 9", "G#9", "A 9", "A#9", "B 9"
        };

        private float[] notefreq =
        {
            16.35f,   17.32f,   18.35f,   19.45f,    20.60f,    21.83f,    23.12f,    24.50f,    25.96f,    27.50f,    29.14f,    30.87f, 
            32.70f,   34.65f,   36.71f,   38.89f,    41.20f,    43.65f,    46.25f,    49.00f,    51.91f,    55.00f,    58.27f,    61.74f, 
            65.41f,   69.30f,   73.42f,   77.78f,    82.41f,    87.31f,    92.50f,    98.00f,    103.83f,   110.00f,   116.54f,   123.47f, 
            130.81f,  138.59f,  146.83f,  155.56f,   164.81f,   174.61f,   185.00f,   196.00f,   207.65f,   220.00f,   233.08f,   246.94f, 
            261.63f,  277.18f,  293.66f,  311.13f,   329.63f,   349.23f,   369.99f,   392.00f,   415.30f,   440.00f,   466.16f,   493.88f, 
            523.25f,  554.37f,  587.33f,  622.25f,   659.26f,   698.46f,   739.99f,   783.99f,   830.61f,   880.00f,   932.33f,   987.77f, 
            1046.50f, 1108.73f, 1174.66f, 1244.51f,  1318.51f,  1396.91f,  1479.98f,  1567.98f,  1661.22f,  1760.00f,  1864.66f,  1975.53f, 
            2093.00f, 2217.46f, 2349.32f, 2489.02f,  2637.02f,  2793.83f,  2959.96f,  3135.96f,  3322.44f,  3520.00f,  3729.31f,  3951.07f, 
            4186.01f, 4434.92f, 4698.64f, 4978.03f,  5274.04f,  5587.65f,  5919.91f,  6271.92f,  6644.87f,  7040.00f,  7458.62f,  7902.13f, 
            8372.01f, 8869.84f, 9397.27f, 9956.06f,  10548.08f, 11175.30f, 11839.82f, 12543.85f, 13289.75f, 14080.00f, 14917.24f, 15804.26f
        };


        public InputRecorder()
        {
        }

        public void Init()
        {
            int numdrivers = 0;
            system.getRecordNumDrivers(ref numdrivers);
            if (numdrivers > 0)
                enabled = true;


            FMOD.RESULT result;
            exinfo.cbsize = Marshal.SizeOf(exinfo);
            exinfo.numchannels = 1;
            exinfo.format = FMOD.SOUND_FORMAT.PCM16;
            exinfo.defaultfrequency = 44100;
            exinfo.length = (uint)(exinfo.defaultfrequency * 2 * exinfo.numchannels * .5); // "* 2" removed cause i want half seconds ... " * 2" returned for full second
            recordingdelay = (uint)(exinfo.defaultfrequency * .21);
            //recordingdelay = (uint)(exinfo.defaultfrequency * .34);

            result = system.createSound((string)null, (FMOD.MODE._2D | FMOD.MODE.LOOP_NORMAL | FMOD.MODE.SOFTWARE | FMOD.MODE.OPENUSER), ref exinfo, ref sound);
            ERRCHECK(result);

            result = sound.getLength(ref soundlength, FMOD.TIMEUNIT.PCM);
            ERRCHECK(result);
        }

        public string LastNote
        {
            get
            {
                return lastnote;
            }
        }

        public uint Length
        {
            get
            {
                return totreclength;
            }
        }

        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
            }
        }

        public float GetActiveDB()
        {
            return GetActiveDB(channel);
        }

        public float GetActiveDB(FMOD.Channel channel)
        {
            double avg = 0;
            if (channel != null)
            {
                channel.getSpectrum(spectrum, SPECTRUMSIZE, 0, FMOD.DSP_FFT_WINDOW.TRIANGLE);
            }
            return ProcessSpectrum();
        }

        public float GetActiveDB(FMOD.ChannelGroup channel)
        {
            double avg = 0;
            if (channel != null)
            {
                channel.getSpectrum(spectrum, SPECTRUMSIZE, 0, FMOD.DSP_FFT_WINDOW.TRIANGLE);
            }
            return ProcessSpectrum();
        }
        private float ProcessSpectrum()
        {
            double avg = 0;
                for (int i = 0; i < SPECTRUMSIZE; i++)
                {
                    if (spectrum[i] > 0)
                        avg += (double)spectrum[i] * (double)spectrum[i];
                    //avg += Math.Abs(spectrum[i]) * 200;
                }
                avg /= (double)SPECTRUMSIZE;
                
                avg = Math.Sqrt(avg);

                // avg = root mean square of all recorded amplitudes
                avg = 20.0 * Math.Log10(avg / 0.000002);
                //Console.WriteLine("avg2 dec = " + avg);
                //avg += 85; // 36 ... 12 - 75 = -63 target
                //avg *= 3;


                // do pitch detection
                float dominanthz = 0;
                float max;
                int dominantnote = 0;
                int count = 0;

                max = 0;

                for (count = 0; count < SPECTRUMSIZE; count++)
                {
                    if (spectrum[count] > 0.01f && spectrum[count] > max)
                    {
                        max = spectrum[count];
                        bin = count;
                    }
                }

                dominanthz = (float)bin * BINSIZE;       /* dominant frequency min */

                dominantnote = 0;
                for (count = 0; count < 119; count++)
                {
                    if (dominanthz >= notefreq[count] && dominanthz < notefreq[count + 1])
                    {
                        // which is it closer to.  This note or the next note
                        if (Math.Abs(dominanthz - notefreq[count]) < Math.Abs(dominanthz - notefreq[count + 1]))
                        {
                            dominantnote = count;
                        }
                        else
                        {
                            dominantnote = count + 1;
                        }
                        break;
                    }
                }
                lastnote = note[dominantnote];
                //Console.WriteLine("Detected rate : " + dominanthz + " -> " + (((float)bin + 0.99f) * BINSIZE) + " Detected musical note : " + note[dominantnote] + " (" + notefreq[dominantnote] + ")");

            return (float) avg;
        }

        public bool Recording
        {
            get
            {
                bool recording = false;
                system.isRecording(Login.recdevice, ref recording);

                return recording;
            }
        }

        public void BeginMonitor()
        {
            if (!enabled || !recording)
                return;
            if (channel == null)
            {
                FMOD.RESULT result;
                sound.setLoopCount(-1);
                result = system.playSound(FMOD.CHANNELINDEX.FREE, sound, false, ref channel);

                uint pos = 0;
                system.getRecordPosition(Login.recdevice, ref pos);

                channel.setPosition(pos, FMOD.TIMEUNIT.PCM);
                ERRCHECK(result);

                channel.setFrequency(22050);
                channel.setVolume(0);
                //channel.setMute(true);
            }
        }

        public void EndMonitor()
        {
            if (!enabled || !recording)
                return;

            if (channel != null)
            {
                channel.stop();
                channel = null;
            }
        }

        public void Begin(Stream mstreamIn)
        {
            if (!enabled)
                return;

            if (recording)
                throw new Exception("Already recording");

            FMOD.RESULT result;

            //mstream = new FileStream("out.mp3", FileMode.Create);
            mstream = mstreamIn;
            WaveLib.WaveFormat mformat = new WaveLib.WaveFormat(exinfo.defaultfrequency, 16, exinfo.numchannels);
            BE_CONFIG mbconfig = new BE_CONFIG(mformat, BroadcastStream.LowBandwidth ? (uint) 32 : (uint) 48);
            mwriter = new Mp3Writer(mstream, mformat, mbconfig);

            totreclength = 0;
            lastrecordpos = 0;
            result = system.recordStart(Login.recdevice, sound, true); // looping
            ERRCHECK(result);
            recording = true;

            BeginMonitor();
        }

        public void Update()
        {
            if (!enabled || !recording)
                return;

            FMOD.RESULT result;

            uint recordpos = 0;
            result = system.getRecordPosition(Login.recdevice, ref recordpos);
            ERRCHECK(result);

            if (recordpos != lastrecordpos)
            {
                IntPtr ptr1 = IntPtr.Zero, ptr2 = IntPtr.Zero;
                int blocklength;
                uint len1 = 0, len2 = 0;

                blocklength = (int)recordpos - (int)lastrecordpos;
                if (blocklength < 0)
                    blocklength += (int)soundlength;

                //Console.WriteLine("BL Rec Mic = " + blocklength);

                //Console.WriteLine("Actual: " + (recordpos) + " vs RD " + RecordingDelay); 
                totreclength += (uint) blocklength;
                if (totreclength > recordingdelay)
                {
                    if (totreclength - recordingdelay < blocklength)
                        blocklength = (int) totreclength - (int)recordingdelay;


                    sound.@lock(lastrecordpos * 2 * (uint)exinfo.numchannels, (uint)blocklength * 2 * (uint)exinfo.numchannels, ref ptr1, ref ptr2, ref len1, ref len2); /* *4 = stereo 16bit.  1 sample = 4 bytes. */

                    if (ptr1 != IntPtr.Zero && len1 > 0)
                    {
                        byte[] buf = new byte[len1];
                        Marshal.Copy(ptr1, buf, 0, (int)len1);
                        mwriter.Write(buf, 0, (int)len1);
                    }
                    if (ptr2 != IntPtr.Zero && len2 > 0)
                    {
                        byte[] buf = new byte[len2];
                        Marshal.Copy(ptr2, buf, 0, (int)len2);
                        mwriter.Write(buf, 0, (int)len2);
                    }

                    sound.unlock(ptr1, ptr2, len1, len2);
                }
                lastrecordpos = recordpos;

            }

        }

        public void End()
        {
            if (!enabled || !recording)
                return;


            FMOD.RESULT result;
            result = system.recordStop(Login.recdevice);
            EndMonitor();
            recording = false;
            ERRCHECK(result);

            mwriter.Close();
            mstream.Close();
            mstream.Dispose();

        }

        private void ERRCHECK(FMOD.RESULT result)
        {
            if (result != FMOD.RESULT.OK)
            {
                throw new Exception("FMOD error! " + result + " - " + FMOD.Error.String(result));
            }
        }

    }
}
