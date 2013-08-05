using System;
using System.Collections.Generic;
using System.IO;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Text;
using System.Windows.Forms;

namespace Flywire_WinForm
{

    public class PlaylistMediaCollection : MediaCollection
    {
        PlayControl PlayControl { get; set; }
        public Label TotalPlayLengthDisplay { get; private set; }
        public uint TotalPlayLength { get; set; }
        public int currentIndex
        {
            get
            {
                if (PlayControl.CurrentTrack == null) return -1;
                return MediaList.Tracks.IndexOf(PlayControl.CurrentTrack.Value);
            }
        }



        public PlaylistMediaCollection(EngineWrapper engine, ListViewEx TrackDisplayList, Label TotalPlayLengthDisplay, PlayControl PlayControl)
            : base(engine, "Playlist Media", "", TrackDisplayList, false)
        {
            this.PlayControl = PlayControl;
            this.TotalPlayLengthDisplay = TotalPlayLengthDisplay;
            PlayControl.Playlist = this;
            UpdateTrackDisplay();
        }

        public void AddTrack(Track track)
        {
            if (!File.Exists(track.Location + track.Name)) throw new FileNotFoundException("The given file was not found!", track.Location + track.Name);
            /*if (MediaList.Tracks.Exists(
                delegate(Track t)
                {
                    return t.Name == track.Name && t.Location == track.Location;
                }))
            {
                throw new TrackAlreadyExistsException(track.Location + track.Name);
            }*/
#if NOT_NET4
            TrackComparer trackComparer = new TrackComparer();
            if (MediaList.Tracks.Contains(track))
            {
                return;
                //throw new TrackAlreadyExistsException(track.Location + track.Name);
            }
#else
            TrackComparer trackComparer = new TrackComparer();
            if (MediaList.Tracks.Contains(track, trackComparer))
            {
                return;
                //throw new TrackAlreadyExistsException(track.Location + track.Name);
            }
#endif
            LinkedListNode<Track> node = new LinkedListNode<Track>(track);
            MediaList.Tracks.AddLast(node);
            if (this.MediaList.Tracks.Count == 1) PlayControl.CurrentTrack = this.MediaList.Tracks.First;
            UpdateTrackDisplay();
        }

        public override void UpdateTrackDisplay()
        {
            var item = MediaList;
            TrackDisplayList.Items.Clear();
            TotalPlayLength = 0;

            if (item != null)
            {
                foreach (Track t in item.Tracks)
                {
                    TrackDisplayList.Items.Add(t.Name).SubItems.Add(t.Duration);
                    t.PlayPosition = 0;
                    if (MediaList.Tracks.IndexOf(t) >= currentIndex)
                    {
                        this.TotalPlayLength += t.PlayLength;
                    }
                }
            }
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(TotalPlayLengthLeft());
            string answer = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            TotalPlayLengthDisplay.Text = answer;

            PlayControl.ToggleButtons();
        }

        public void UpdateTrackSelection()
        {
            if (PlayControl.CurrentTrack == null) return;

            if (currentIndex > -1)
            {
                uint playLength = PlayControl.getPlayLength();
                uint playPosition = PlayControl.getPlayPosition();
                /*if (TrackDisplayList.InvokeRequired)
                {
                    TrackDisplayList.Invoke(new MethodInvoker(delegate 
                        {
                            TrackDisplayList.Items[currentIndex].Selected = true;
                            if (PlayControl.IsPlaying)
                            {
                                TimeSpan t = TimeSpan.FromMilliseconds(playLength - playPosition);
                                string answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                                TrackDisplayList.Items[currentIndex].SubItems[1].Text = answer;
                            }
                        }));
                }
                else
                {*/
                    TrackDisplayList.Items[currentIndex].Selected = true;
                    if (PlayControl.IsPlaying)
                    {
                        TimeSpan t = TimeSpan.FromMilliseconds(playLength - playPosition);
                        string answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                        TrackDisplayList.Items[currentIndex].SubItems[1].Text = answer;
                    }
                //}
            }
        }

        public int Count()
        {
            return MediaList.Tracks.Count;
        }

        public uint TotalPlayLengthLeft()
        {
            uint totalPlayed = 0;
            foreach (Track t in MediaList.Tracks)
            {
                if (MediaList.Tracks.IndexOf(t) >= currentIndex)
                {
                    if (t.Equals(PlayControl.CurrentTrack.Value))
                    {
                        totalPlayed += PlayControl.getPlayPosition();
                        t.PlayPosition = PlayControl.getPlayPosition();
                    }
                    else
                    {
                        totalPlayed += t.PlayPosition;
                    }
                }
            }
            return this.TotalPlayLength - totalPlayed;
        }

        public override Track RemoveTrackByName(string TrackName)
        {
#if NOT_NET4
            Track result = null;
            foreach (Track t in MediaList.Tracks)
            {
                if (t.Name.Equals(TrackName))
                {
                    result = t;
                    break;
                }
            }
#else
            var result = MediaList.Tracks.First(track => track.Name.Equals(TrackName));
#endif
            if (result == null) throw new InvalidTrackFoundException(TrackName);
            if (PlayControl.CurrentTrack != null && result.Equals(PlayControl.CurrentTrack.Value))
            {
                PlayControl.StopCurrentTrack();
                PlayControl.CurrentTrack = PlayControl.CurrentTrack.Next;
            }

            MediaList.Tracks.Remove(result);
            UpdateTrackDisplay();
            return result;
        }
    } // End PlaylistMediaCollection

}
