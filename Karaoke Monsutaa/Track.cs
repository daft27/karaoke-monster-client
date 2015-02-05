using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;


namespace Karaoke_Monsutaa
{
    public class Track
    {
        public static FMOD.System system = null;

        private FMOD.Sound sound = null;
        private FMOD.Channel channel = null;
        private FMOD.CHANNEL_CALLBACK callback = null;

        private String actualSource;
        private String source;
        private String title = "";
        private String artist = "";
        private String owner;
        float freq = 0;
        float vol = 0;
        float pan = 0;
        int priority = 0;

        private uint pctbuffered = 0;

        private bool playback = false;
        private bool syncDelay = false;
        private bool buffDelay = false;

        public enum MODE
        {
            MUSIC,
            USER
        }

        private MODE mode = MODE.MUSIC;

        public Track(String sourceIn, MODE modeIn, String ownerIn)
        {
            actualSource = sourceIn;
            source = sourceIn;
            mode = modeIn;
            callback = new FMOD.CHANNEL_CALLBACK(this.Callback);
           
            owner = ownerIn;
            if (owner == "")
                owner = Login.Username;

            CheckRemote();
        }

        public bool Playback
        {
            get
            {
                return playback;
            }
            set
            {
                playback = value;
                CheckRemote();
            }
        }

        public String Source
        {
            get
            {
                return source;
            }
        }


        public bool CheckRemote()
        {
            if (actualSource.StartsWith("http://") && mode == MODE.MUSIC)
            {
                source = actualSource;
                return true;
            }
            else
            {
                if (!File.Exists(actualSource) || mode == MODE.USER || playback)
                {
                    String modes = "";
                    switch (mode)
                    {
                        case MODE.MUSIC:
                            modes = "Music";
                            break;
                        case MODE.USER:
                            modes = "User";
                            break;
                    }

                    source = "http://" + Network.ServerAddr + ":" + Network.ServerPortRelay + "/" + HashString(owner) + " - " + modes + HashString(System.IO.Path.GetFileNameWithoutExtension(actualSource)) + ".mp3";
                    Console.WriteLine("Source remoted to " + source);
                    return true;
                }
                else
                {
                    source = actualSource;
                    Console.WriteLine("'{0}' = '{1}'", System.IO.Path.GetFileNameWithoutExtension(source), HashString(System.IO.Path.GetFileNameWithoutExtension(source)));
                }
                return false;
            }
        }

        private string HashString(string Value)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Value);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            return ret;
        }

        public void Load()
        {
            FMOD.RESULT result = FMOD.RESULT.ERR_FILE_NOTFOUND;


            Console.WriteLine("Loading " + source);


            if (File.Exists(source) || source.StartsWith("http://"))
                result = system.createStream(source, FMOD.MODE.UNICODE | FMOD.MODE.SOFTWARE | FMOD.MODE.CREATESTREAM | FMOD.MODE._2D | FMOD.MODE.NONBLOCKING | FMOD.MODE.OPENONLY, ref sound);

            //if (File.Exists(source) && s != source)
            if (result == FMOD.RESULT.ERR_FILE_NOTFOUND)
            {

                String s = source;
                s = Regex.Replace(s, @"[^\u0000-\u007F]", "");

                Console.WriteLine("Track.Load unicode workaround used");
                File.Copy(actualSource, "source.mp3", true);
                result = system.createStream("source.mp3", FMOD.MODE.SOFTWARE | FMOD.MODE.CREATESTREAM | FMOD.MODE._2D | FMOD.MODE.NONBLOCKING | FMOD.MODE.OPENONLY, ref sound);

            }
                

            ERRCHECK(result);
        }

        private void ReadTagsLocal()
        {
            try
            {
                TagLib.File file = TagLib.File.Create(source);
                if (file.Tag == null)
                    return;

                if(file.Tag.Title != null)
                    title = file.Tag.Title;

                if (file.Tag.AlbumArtists != null)
                {
                    // Some entries support multiple strings.
                    foreach (string artistI in file.Tag.AlbumArtists)
                    {
                        if (artistI != null)
                        {
                            artist = artistI;
                        }
                    }
                }

                if (artist == "" && file.Tag.Album != null)
                    artist = file.Tag.Album;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.Source);
            }

        }

        private void ReadTags()
        {
            if (File.Exists(source))
            {
                ReadTagsLocal();
                return;
            }
            
            // don't read any tags using fmod
            return;

            Console.WriteLine("Reading from " + this.actualSource);
            FMOD.TAG tag = new FMOD.TAG();
            for (; ; )
            {
                /*
                    An index of -1 means "get the first tag that's new or updated".
                    If no tags are new or updated then getTag will return FMOD_ERR_TAGNOTFOUND.
                    This is the first time we've read any tags so they'll all be new but after we've read them, 
                    they won't be new any more.
                */
                    if (sound.getTag(null, -1, ref tag) != FMOD.RESULT.OK)
                        break;

                if (tag.datatype == FMOD.TAGDATATYPE.STRING)
                {
                    String data = Marshal.PtrToStringAnsi(tag.data);

                    System.Console.WriteLine(tag.name + " = " + data + " (" + tag.datalen + " bytes)");

                    if (tag.name == "TITLE")
                        title = data;

                    if (tag.name == "ARTIST")
                        artist = data;

                    if(tag.name == "ALBUM" && artist == "")
                        artist = data;
                }

            }

        }

        public uint LengthMS
        {
            get
            {
                uint lenms = 0;
                if (sound == null)
                    return 1;

                sound.getLength(ref lenms, FMOD.TIMEUNIT.MS);
                if (lenms > 10000000)
                    lenms = 0;
                return lenms;
            }
        }

        public uint PositionMS
        {
            get
            {
                if (channel == null)
                    return 0;

                uint ms = 0;
                channel.getPosition(ref ms, FMOD.TIMEUNIT.MS);
                return ms;
            }
        }

        public uint PositionPCMBytes
        {
            get
            {
                if (channel == null)
                    return 0;

                uint ms = 0;
                channel.getPosition(ref ms, FMOD.TIMEUNIT.PCMBYTES);
                return ms;
            }
        }

        public String Title
        {
            get
            {
                return title;
            }
        }

        public String Artist
        {
            get
            {
                return artist;
            }
        }

        public void CheckBuff()
        {
            if (sound == null)
                return;

            FMOD.OPENSTATE openstate1 = 0;
            bool starving1 = false;
            sound.getOpenState(ref openstate1, ref pctbuffered, ref starving1);
        }


        public uint PctBuffered
        {
            get
            {
                return pctbuffered;
            }
        }

        public bool Ready
        {
            get
            {
                FMOD.RESULT result;
                FMOD.OPENSTATE openstate1 = 0;

                if (sound != null)
                {
                    //uint percentbuffered1 = 0;
                    bool starving1 = false;

                    result = sound.getOpenState(ref openstate1, ref pctbuffered, ref starving1);
                    if (result != FMOD.RESULT.OK)
                    {
                        Console.WriteLine("Ready state stop! " + FMOD.Error.String(result));
                        Stop();
                        return false;
                    }
                    //ERRCHECK(result);

                    if (openstate1 == FMOD.OPENSTATE.STREAMING)
                        return true;


                    if (openstate1 == FMOD.OPENSTATE.READY)
                    {
                        if (channel == null)
                        {
                            result = system.playSound(FMOD.CHANNELINDEX.REUSE, sound, true, ref channel);
                            if (result != FMOD.RESULT.OK)
                            {
                                Stop();
                                return false;
                            }

                            //result = channel.setCallback(callback);
                            if (result != FMOD.RESULT.OK)
                            {
                                Stop();
                                return false;
                            }
                            //ERRCHECK(result);

                            Console.WriteLine("Readying?");
                            //if(!File.Exists(source))
                            if(title == "" | artist == "")
                                ReadTags();
                        }

                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("Returning default ready state");
                    return true;
                }

                return false;
            }
        }

        public void UpdateDelay()
        {
            if (channel == null)
                return;

            channel.setFrequency((float)freq * (syncDelay ? .9f : 1.0f) * (buffDelay ? .6f : 1.0f));
        }

        public bool SyncDelay
        {
            set
            {
                if (syncDelay == value)
                    return;

                syncDelay = value;
                UpdateDelay();
            }
        }

        public bool BuffDelay
        {
            set
            {
                if (buffDelay == value)
                    return;

                buffDelay = value;
                UpdateDelay();
            }
           
        }

        public void Play(FMOD.ChannelGroup group)
        {
            if (channel != null)
            {
                sound.getDefaults(ref freq, ref vol, ref pan, ref priority);

                FMOD.RESULT result;
                result = channel.setPosition(0, FMOD.TIMEUNIT.PCM);

                ERRCHECK(result);

                result = channel.setChannelGroup(group);
                ERRCHECK(result);

                result = channel.setPaused(false);
                ERRCHECK(result);
            }
        }

        public void Stop()
        {
            FMOD.RESULT result;
            FMOD.OPENSTATE openstate1 = 0;

            if (sound != null)
            {
                //uint percentbuffered1 = 0;
                bool starving1 = false;

                result = sound.getOpenState(ref openstate1, ref pctbuffered, ref starving1);

                if (result != FMOD.RESULT.OK || openstate1 == FMOD.OPENSTATE.STREAMING)
                {
                    if (channel != null)
                    {
                        // automatically calls sound.release as well through callback
                        bool isplaying = false;
                        channel.isPlaying(ref isplaying);

                        if (isplaying)
                        {
                            Console.WriteLine("Track.Stop Channel stop");
                            result = channel.stop();
                            channel = null;
                        }
                        else
                        {
                            Console.WriteLine("Track.Stop Sound release 1");
                            sound.release();
                            sound = null;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Track.Stop Sound release 3");
                        sound.release();
                        sound = null;
                    }
                }
                else
                {
                    Console.WriteLine("Track.Stop Soudn release 2");

                    sound.release();
                    sound = null;
                }
                

                Console.WriteLine("Track.Stop");
            }
        }

        public FMOD.RESULT Callback(IntPtr a, FMOD.CHANNEL_CALLBACKTYPE type, IntPtr b, IntPtr c)
        {
            switch (type)
            {
                case FMOD.CHANNEL_CALLBACKTYPE.END:
                    Console.WriteLine("Track.Callback Start");
                    channel = null;
                    sound.release();
                    sound = null;

                    OnEndTrack(this);
                    Console.WriteLine("Track.Callback End");
                    break;
            }
            return FMOD.RESULT.OK;
        }

        public delegate void EndTrackHandler(Track t);
        [Category("Action")]
        [Description("Fires when the end of the track has been reached.")]
        public event EndTrackHandler EndTracked;
        protected virtual void OnEndTrack(Track t)
        {
            if (EndTracked != null)
                EndTracked(t);  // Notify Subscribers
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
