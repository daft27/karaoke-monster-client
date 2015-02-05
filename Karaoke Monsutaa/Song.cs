using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Karaoke_Monsutaa
{
    public class Song
    {
        private String owner;
        private String artist;
        private String title;
        private String source;

        private bool paused = true;
        private float pitch = 0;

        private List<Track> tracks = new List<Track>();
        private int playingTracks = 0;
        private int live = 0;
        private int length = 0;

        private int playback = 0;

        public Song(String ownerIn, String artistIn, String titleIn, String sourceIn, float pitchIn, int liveIn, int lengthIn)
        {
            owner = ownerIn;
            artist = artistIn;
            title = titleIn;
            source = sourceIn;
            pitch = pitchIn;
            live = liveIn;
            length = lengthIn;

            AddTrack(sourceIn, Track.MODE.MUSIC);

            Console.WriteLine("OWNER = " + ownerIn);
            //if (ownerIn != Login.Username && ownerIn != "")
                AddTrack(sourceIn, Track.MODE.USER);
        }

        public void BuffDelay()
        {
            uint lowbuff = 100;
            foreach (Track t in tracks)
            {
                t.CheckBuff();
                uint tbuff = t.PctBuffered;
                if (tbuff < lowbuff)
                    lowbuff = tbuff;
            }

            Console.WriteLine("Song Buff @ " + lowbuff);
            if (lowbuff < 30)
            {
                foreach (Track t in tracks)
                {
                    t.BuffDelay = true;
                }
            }
            else
            {
                foreach (Track t in tracks)
                {
                    t.BuffDelay = false;
                }
            }
        }

        public String GetSource(int trackno)
        {
            return tracks[trackno].Source;
        }

        public void SyncDelay(int tn, bool mode)
        {
            int i = 0 ;
            foreach(Track t in tracks)
            {
                if (i == tn)
                    t.SyncDelay = mode;
                i++;
            }
        }

        public bool SelfOwn
        {
            get
            {
                return (owner == Login.Username || owner == "");
            }
        }

        public void AddTrack(String sourceIn, Track.MODE mode)
        {
            Track t = new Track(sourceIn, mode, owner);
            t.EndTracked += new Track.EndTrackHandler(t_EndTracked);
            tracks.Add(t);
        }

        void t_EndTracked(Track t)
        {
            playingTracks--;
            if (playingTracks == 0)
                OnEndSong(this);
        }

        public String ToGenericName()
        {
            if (title.Length > 0)
                return title;
            else
                return System.IO.Path.GetFileNameWithoutExtension(source);
        }

        override public String ToString()
        {
            String ownerd = owner.Length > 0 ? "" + owner + " - " : "";
            String lives = live == 1 ? (owner == Login.Username ? " *REC* " : " *LIVE* ") : "";

            return lives + ownerd + ToGenericName();
        }

        #region SettersGetters

        public String Owner
        {
            get
            {
                return owner;
            }

            set
            {
                owner = value;
            }
        }

        public bool Playback
        {
            get
            {
                return playback == 1;
            }

            set
            {
                foreach (Track t in tracks)
                {
                    t.Playback = value;
                }
                playback = value ? 1 : 0; 
            }
        }

        public String Artist
        {
            get
            {
                return artist;
            }
            set
            {
                artist = value;
            }
        }
        public float Pitch
        {
            get
            {
                return pitch;
            }
            set
            {
                pitch = value;
            }
        }
        public int Live
        {
            get
            {
                return live;
            }
            set
            {
                live = value;
            }
        }

        public uint PctBuffered
        {
            get
            {
                if (tracks.Count == 0)
                    return 100;

                uint pct = 0;
                foreach (Track t in tracks)
                {
                    pct += t.PctBuffered;
                }
                pct /= (uint) tracks.Count;
                return pct;
            }
        }


        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public String Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
            }
        }

        // candidate for refactoring
        public uint LengthMS
        {
            get
            {
                uint len = tracks[0].LengthMS;
                if (len > 0)
                    length = (int) len;
                return (uint) length;
            }
        }

        public int LengthPassed
        {
            get
            {
                return length;
            }
        }

        public uint PositionMS
        {
            get
            {
                return tracks[0].PositionMS;
            }
        }

        public uint PositionPCMBytes
        {
            get
            {
                return tracks[0].PositionPCMBytes;
            }
        }

        public bool Paused
        {
            get
            {
                return paused;
            }
        }

        #endregion

        public void Load()
        {
            int i = 0;
            foreach (Track t in tracks)
            {
                i++;
                if (i == 2 && SelfOwn && !Playback)
                {

                    continue;
                }
                t.Load();
            }
            paused = true;
        }

        public bool Ready
        {
            get
            {
                Console.WriteLine("Rdy Check");
                bool ret = true;
                int i = 0;
                foreach (Track t in tracks)
                {
                    // this should never happen
                    if (t == null)
                        continue;

                    i++;
                    // skip my own track if i'm recording
                    if (i == 2 && SelfOwn && !Playback)
                    {

                        continue;
                    }

                    bool readystate = t.Ready;
                    Console.WriteLine("Rdy St = " + readystate);
                    if (readystate)
                    {
                        if (artist.Length == 0)
                            artist = t.Artist;

                        if (title.Length == 0)
                            title = t.Title;
                    }
                    ret = ret && readystate;

                }
                return ret;
            }
        }

        public void Play(FMOD.ChannelGroup group, FMOD.ChannelGroup groupb)
        {
            playingTracks = 0;
            int i = 0;
            foreach (Track t in tracks)
            {
                i++;
                if (playingTracks == 0)
                    t.Play(group);
                else
                {
                    if (i == 2 && SelfOwn && !Playback)
                        continue;

                    t.Play(groupb);
                }
                playingTracks++;
            }
            paused = false;
        }

        public void Stop()
        {
            Console.WriteLine("Song.Stop");
            int i = 0;
            foreach (Track t in tracks)
            {
                i++;
                if (i == 2 && SelfOwn && !Playback)
                    continue;

                t.Stop();
            }
            paused = true;
        }

        public delegate void EndTrackHandler(Song s);
        [Category("Action")]
        [Description("Fires when the end of the song has been reached.")]
        public event EndTrackHandler EndSonged;
        protected virtual void OnEndSong(Song s)
        {
            if (EndSonged != null)
                EndSonged(s);  // Notify Subscribers
        }

    }
}
