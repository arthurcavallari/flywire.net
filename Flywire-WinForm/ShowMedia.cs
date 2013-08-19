using System;
using System.IO;
using System.Collections.Generic;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Text;
using System.Windows.Forms;

namespace Flywire_WinForm
{
    public class ShowMediaCollection
    {
        public List<string> ShowNames { get; private set; }
        public List<TrackCollection> ShowMedia { get; private set; }

        public ListView TrackDisplayList { get; private set; }
        public ComboBox ShowDisplayList { get; private set; }

        public string Location { get; private set; }

        public EngineWrapper engine { get; set; }

        public ShowMediaCollection(EngineWrapper engine, ListView TrackDisplayList, ComboBox ShowDisplayList)
        {
            this.engine = engine;
            ShowNames = new List<string>();
            ShowMedia = new List<TrackCollection>();            

            this.TrackDisplayList = TrackDisplayList;
            this.ShowDisplayList = ShowDisplayList;

            Location = Settings.ShowMediaPath;
            ReloadShowNames();
        }

        public void ReloadShowNames()
        {
            IEnumerable<string> files = null;
            try
            {
#if NOT_NET4
                files = Directory.GetDirectories(Location);
#else
                files = Directory.EnumerateDirectories(Location);
#endif
            }
            catch (Exception e)
            {
                string msg = "ShowMedia::ReloadShowNames(): Error while listing directories.\n" + e.ToString();
                Program.LogWrite(msg);
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ShowNames.Clear();
            ShowMedia.Clear();
            
            foreach (string currentFile in files)
            {
                string fileName = currentFile.Substring(Location.Length);
                //MessageBox.Show("Location = " + Location + "\n\nLength = " + Location.Length.ToString() + "\n\n" + currentFile + "\n\n" + fileName);
                
                if (!fileName.Equals("PlayLists", StringComparison.CurrentCultureIgnoreCase))
                {
                    ShowNames.Add(fileName);
                    ShowMedia.Add(new TrackCollection(engine, fileName, Location + fileName + Settings.slash));
                }
            }
        }

        public void UpdateTrackDisplay(string ShowName)
        {
            var item = ShowMedia.Find(
                delegate(TrackCollection t)
                {
                    return t.Name.Equals(ShowName);
                }
                );
            if (item == null) throw new InvalidShowNameFoundException();
            TrackDisplayList.Items.Clear();

            if (item != null)
            {
                foreach (Track t in item.Tracks)
                {
                    TrackDisplayList.Items.Add(t.Name).SubItems.Add(t.Duration);
                }
            }
        }


        public Track FindTrackByName(string ShowName, string TrackName)
        {
            var show = ShowMedia.Find(
                delegate(TrackCollection trackCollection)
                {
                    return trackCollection.Name.Equals(ShowName);
                }
                );

            if (show == null) throw new InvalidShowNameFoundException(ShowName);
#if NOT_NET4
            Track result = null;
            foreach (Track t in show.Tracks)
            {
                if (t.Name.Equals(TrackName))
                {
                    result = t;
                    break;
                }
            }
#else
            var result = show.Tracks.First(track => track.Name.Equals(TrackName));
#endif
            /*var result = show.Tracks.Find(
                delegate(Track track) 
                { 
                    return track.Name.Equals(TrackName); 
                }
                );
            */
            if (result == null) throw new InvalidTrackFoundException(ShowName + Settings.slash + TrackName);

            return result;
        }

    }

}
