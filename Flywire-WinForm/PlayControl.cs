#if NOT_NET4
extern alias NET2;
#else
extern alias NET4;
#endif
using System;
using System.Collections.Generic;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Text;
using System.Windows.Forms;


/* START SoundEngine definition */

// any changes here, make sure to update PlayControl.cs!
#if !SWIG && NOT_NET4
using SoundEngine = NET2.IrrKlang.ISoundEngine;
using Sound = NET2.IrrKlang.ISound;
using Source = NET2.IrrKlang.ISoundSource;
using SoundStopEvent = NET2.IrrKlang.ISoundStopEventReceiver;
using StopEventCause = NET2.IrrKlang.StopEventCause;
#elif !SWIG && !NOT_NET4 && !NO_ENGINE
using SoundEngine = NET4.IrrKlang.ISoundEngine;
using Sound = NET4.IrrKlang.ISound;
using Source = NET4.IrrKlang.ISoundSource;
using SoundStopEvent = NET4.IrrKlang.ISoundStopEventReceiver;
using StopEventCause = NET4.IrrKlang.StopEventCause;
using System.Diagnostics;
#endif
/* END SoundEngine definition */

namespace Flywire_WinForm
{

    public class PlayControl : SoundStopEvent
    {
        public Form1 owner { get; private set; }
        public LinkedListNode<Track> CurrentTrack { get; set; }
        public SoundWrapper CurrentSound { get; set; }
        public bool CueMode { get; set; }
        public bool IsLooping { get; set; }
        public bool IsPlaying { get; set; }
        public PlaylistMediaCollection Playlist { get; set; }
        public EngineWrapper engine { get; private set; }
        PictureBox PlayButton { get; set; }
        PictureBox StopButton { get; set; }
        PictureBox SkipButton { get; set; }
        PictureBox RecueButton { get; set; }
        TrackBar SongTracker { get; set; }
        private bool SongEnded { get; set; }



        public PlayControl(Form1 owner, EngineWrapper engine, PictureBox PlayButton, PictureBox StopButton, PictureBox SkipButton, PictureBox RecueButton, TrackBar SongTracker)
        {
            this.owner = owner;
            this.engine = engine;
            this.PlayButton = PlayButton;
            this.StopButton = StopButton;
            this.SkipButton = SkipButton;
            this.RecueButton = RecueButton;
            this.SongTracker = SongTracker;
        }

        public uint getPlayPosition()
        {            
            if (IsPlaying && SongEnded)
            {
                SkipTrack();
            }
            if (IsPlaying)
            {
                if (CurrentSound == null) return 0;
                if (CurrentSound.PlayLength == 0) return 0;
                SongTracker.Value = (int)CurrentSound.PlayPosition / (int)(Math.Ceiling((double)CurrentSound.PlayLength / 100));
                return CurrentSound.PlayPosition;
            }
            else
            {
                if (CurrentTrack == null) return 0;
                if (CurrentTrack.Value.PlayLength == 0) return 0;
                SongTracker.Value = (int)CurrentTrack.Value.PlayPosition / (int)(Math.Ceiling((double)CurrentTrack.Value.PlayLength / 100));
                return CurrentTrack.Value.PlayPosition;
            }
        }

        public uint getPlayLength()
        {
            if (IsPlaying)
            {
                if (CurrentSound == null) return 0;
                return CurrentSound.PlayLength;
            }
            else
            {
                if (CurrentTrack == null) return 0;
                return CurrentTrack.Value.PlayLength;
            }
        }

        public void ToggleButtons()
        {
            if (IsPlaying)
            {
                PlayButton.Enabled = false;
                StopButton.Enabled = true;
                SkipButton.Enabled = true;
                RecueButton.Enabled = false;
            }
            else
            {
                PlayButton.Enabled = (Playlist.Count() > 0);
                StopButton.Enabled = false;
                SkipButton.Enabled = (Playlist.Count() > 0);
                RecueButton.Enabled = (Playlist.Count() > 0);
                SongTracker.Value = 0;
            }
            Playlist.UpdateTrackSelection();
        }

        public void PlayTrack()
        {
            SongEnded = false;
            if (CurrentSound != null) CurrentSound.Stop();
            if (CurrentTrack != null)
            {
                CurrentSound = engine.PlayFile(CurrentTrack.Value.FullPath);
                if (CurrentSound != null)
                {
                    CurrentSound.setSoundStopEventReceiver(this);
                }

                CurrentTrack.Value.PlayPosition = CurrentSound.PlayPosition;
                IsPlaying = true;
            }
            else
            {
                IsPlaying = false;
                Playlist.Clear();
            }
            ToggleButtons();
        }

        public void StopCurrentTrack()
        {
            IsPlaying = false;
            if (CurrentSound != null) CurrentSound.Stop();
            if (CurrentTrack != null && CurrentTrack.Value != null) CurrentTrack.Value.PlayPosition = 0;

            ToggleButtons();
        }

        public void SkipTrack()
        {
            //CurrentTrack.Value.PlayPosition = CurrentSound.PlayPosition;
            if (CurrentTrack == null) return;
            Playlist.TotalPlayLength -= CurrentTrack.Value.PlayLength;
            CurrentTrack = CurrentTrack.Next;
            if (IsPlaying)
            {
                PlayTrack(); // plays new track
            }
            else
            {
                Playlist.UpdateTrackSelection();
                if (CurrentTrack == null)
                {
                    IsPlaying = false;
                    Playlist.Clear();
                }
            }
            //ToggleButtons();
        }

        public void RecueTracks()
        {
            // Start from the beginning, reset all times
            IsPlaying = false;
            CurrentTrack = Playlist.MediaList.Tracks.First;
            CurrentSound = null; // engine.LoadFile(CurrentTrack.Value.FullPath);
            PlayButton.Enabled = (Playlist.Count() > 0);
            StopButton.Enabled = false;
            SkipButton.Enabled = (Playlist.Count() > 0);
            RecueButton.Enabled = (Playlist.Count() > 0);
            // reset song tracker
            SongTracker.Value = 0; 
            Playlist.UpdateTrackDisplay();
        }

        // Event inherited from SoundStopEvent interface
        void SoundStopEvent.OnSoundStopped(Sound sound, StopEventCause reason, object userData)
        {
            
            /*if (this.owner.InvokeRequired)
            {
                this.owner.Invoke(new MethodInvoker(delegate
                {*/
                    // called when the sound has ended playing
                    switch (reason)
                    {
                        case StopEventCause.SoundFinishedPlaying:
                            // The sound finished playing. 
                            //this.CurrentTrack = this.CurrentTrack.Next;
                            SongEnded = true;
                            //this.PlayTrack();
                            break;
                        case StopEventCause.SoundStoppedBySourceRemoval:
                            // The sound was stopped because its sound source was removed or the engine was shut down 
                            //this.CurrentTrack = this.CurrentTrack.Next;
                            //this.PlayTrack();
                            break;
                        case StopEventCause.SoundStoppedByUser:
                            // The sound was stopped because the user called ISound::stop(). 
                            // So we do nothing
                            break;
                        default:
                            // herp derp, this should not happen.. 
                            // TODO: Log to error file, try to play next track if available
                            Program.LogWrite("PlayControl::SoundStopEvent.OnSoundStopped(): Invalid reason => " + reason.ToString());
                            break;
                    }
            /*    }));
            }*/
        }

    }
}
