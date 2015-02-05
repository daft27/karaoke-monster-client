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
    public class Compressor
    {
        static public FMOD.System system = null;

        private Mp3Writer m2writer = null;
        private Stream m2stream = null;
        private uint lastrecordpos2 = 0;
        private FMOD.Sound sound = new FMOD.Sound();

        private int channels = 2;

        private bool enabled = false;

        public Compressor()
        {
        }

        public uint Length
        {
            get
            {
                return lastrecordpos2;
            }
        }

        public void Load(String s)
        {
            FMOD.RESULT result;

            if (!File.Exists(s))
            {                
                enabled = false;
                Console.WriteLine("Compressor.Load File doesn't exist");
                return;
            }

            enabled = true;


            if (sound != null)
            {
                sound.release();
                sound = null;
            }

            result = system.createStream(s, FMOD.MODE.UNICODE | FMOD.MODE.SOFTWARE | FMOD.MODE.OPENONLY, ref sound); //  | FMOD.MODE.LOOP_NORMAL
            if (result == FMOD.RESULT.ERR_FILE_NOTFOUND)
            {
                File.Copy(s, "cmp.mp3", true);
                result = system.createStream("cmp.mp3", FMOD.MODE.SOFTWARE | FMOD.MODE.OPENONLY, ref sound); //  | FMOD.MODE.LOOP_NORMAL
            }
            ERRCHECK(result);
        }

        public uint LengthMS
        {
            get
            {
                uint lenms = 0;
                sound.getLength(ref lenms, FMOD.TIMEUNIT.MS);
                return lenms;
            }
        }

        public bool Enabled
        {
            get
            {
                return enabled;
            }
        }

        public void Begin(Stream m2streamIn)
        {
            if (!enabled)
                return;

            sound.seekData(0);

            m2stream = m2streamIn;
            FMOD.SOUND_TYPE type = FMOD.SOUND_TYPE.UNKNOWN;
            FMOD.SOUND_FORMAT format = FMOD.SOUND_FORMAT.PCM16;
            int bits = 0;
            sound.getFormat(ref type, ref format, ref channels, ref bits);

            float freq = 0;
            float vol = 0;
            float pan = 0;
            int priority = 0;
            sound.getDefaults(ref freq, ref vol, ref pan, ref priority);
            Console.WriteLine("freq = " + freq + " type = " + type + " format = " + format + " chans = " + channels + " bits = " + bits);
            WaveLib.WaveFormat m2format = new WaveLib.WaveFormat((int) freq, bits, channels);
            WaveLib.WaveFormat m2outformat = new WaveLib.WaveFormat((int) freq, 16, 1);
            BE_CONFIG m2bconfig = new BE_CONFIG(m2outformat, BroadcastStream.LowBandwidth ? (uint) 32 : (uint) 64);
            m2writer = new Mp3Writer(m2stream, m2format, m2bconfig);

            lastrecordpos2 = 0;
        }

        public void End()
        {
            if (!enabled)
                return;
            m2writer.Close();
            m2stream.Close();
            m2stream.Dispose();
        }

        public int Channels
        {
            get
            {
                return channels;
            }
        }

        public void Update(uint trackpos)
        {
            if (!enabled)
                return;

            if (trackpos != lastrecordpos2)
            {
                FMOD.RESULT result;

                IntPtr ptr1 = IntPtr.Zero, ptr2 = IntPtr.Zero;
                int blocklength;
                uint len1 = 0;

                blocklength = (int)trackpos - (int)lastrecordpos2;

                IntPtr data = IntPtr.Zero;
                try
                {
                    data = Marshal.AllocHGlobal(blocklength);
                }
                catch (OutOfMemoryException ex)
                {
                    Console.WriteLine("Blocklength = " + blocklength + " , e = " + ex.Message);

                }
                if (data != IntPtr.Zero)
                {
                    try
                    {
                        result = sound.readData(data, (uint)blocklength, ref len1);
                        if (result == FMOD.RESULT.OK)
                        {
                            byte[] buffer = new byte[len1];
                            Marshal.Copy(data, buffer, 0, (int)len1);

                            if (channels == 2)
                            {
                                byte[] buffermono = new byte[len1 / 2];

                                for (int i = 0; i < buffer.Length; i += 4) // 2 bytes per sample
                                {
                                    if (i % 8 == 0)
                                        Buffer.BlockCopy(buffer, i, buffermono, i / 2, 2);
                                    else
                                        Buffer.BlockCopy(buffer, i + 2, buffermono, i / 2, 2);
                                }

                                m2writer.Write(buffermono, 0, (int)len1 / 2);
                            }
                            else
                            {
                                m2writer.Write(buffer, 0, (int)len1);
                            }
                        }
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine("Compression problem on update. " + ae.Message);
                    }
                    Marshal.FreeHGlobal(data);
                }
                lastrecordpos2 = trackpos;
            }

        }

        private void ERRCHECK(FMOD.RESULT result)
        {
            if (result != FMOD.RESULT.OK)
            {
                Console.WriteLine("Compressor FMOD Error! " + result + " - " + FMOD.Error.String(result)); 
                throw new Exception("FError! " + result + " - " + FMOD.Error.String(result));
            }
        }

    }
}
