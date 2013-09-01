using System;
using System.Collections.Generic;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Text;
using System.Windows.Forms;

namespace Flywire_WinForm
{
    public class MediaCollection
    {
        public TrackCollection MediaList { get; private set; }
        public ListView TrackDisplayList { get; private set; }
        public string Location { get; private set; }
        public EngineWrapper engine { get; set; }

        

        public MediaCollection(EngineWrapper engine, string CollectionName, string CollectionLocation, ListView TrackDisplayList, bool AutoLoadTracks = true)
        {
            this.engine = engine;
            MediaList = new TrackCollection(engine, CollectionName, CollectionLocation, AutoLoadTracks);
            this.TrackDisplayList = TrackDisplayList;
            if (AutoLoadTracks)
                UpdateTrackDisplay();
        }

        public virtual void UpdateTrackDisplay()
        {
            var item = MediaList;
            TrackDisplayList.Items.Clear();

            if (item != null)
            {
                foreach (Track t in item.Tracks)
                {
                    TrackDisplayList.Items.Add(t.Name).SubItems.Add(t.Duration);
                }
            }
        }

        public Track FindTrackByName(string TrackName)
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
            /*var result = MediaList.Tracks.Find(
                delegate(Track track)
                {
                    return track.Name.Equals(TrackName);
                }
                );
            */
            if (result == null) throw new InvalidTrackFoundException(TrackName);

            return result;
        }

        public virtual Track RemoveTrackByName(string TrackName)
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

            MediaList.Tracks.Remove(result);
            UpdateTrackDisplay();
            return result;
        }

        public void Clear()
        {
            MediaList.Tracks.Clear();
            UpdateTrackDisplay();
        }



    }
}
