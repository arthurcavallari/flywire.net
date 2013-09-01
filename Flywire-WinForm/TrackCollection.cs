using System;
using System.Collections.Generic;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Flywire_WinForm
{
    public class TrackCollection
    {
        public EngineWrapper engine { get; set; }
        public string Name { get; private set; }
        public LinkedListExt<Track> Tracks { get; private set; }
        public ListView DisplayList { get; private set; }
        public string Location { get; private set; }

        public TrackCollection(EngineWrapper engine, string Name)
        {
            this.engine = engine;
            this.Name = Name;
            Tracks = new LinkedListExt<Track>();
        }

        public TrackCollection(EngineWrapper engine, string Name, string Location, bool AutoLoadTracks = true)
            : this(engine, Name)
        {
            this.Location = Location;
            if (AutoLoadTracks && !String.IsNullOrEmpty(Location))
                ReloadTracks();
        }

        public void ReloadTracks()
        {
            if (String.IsNullOrEmpty(Location)) return;
            // Read file name from directory
            IEnumerable<string> files = null;
            try
            {
#if NOT_NET4
                files = Directory.GetFiles(Location);
#else
                files = Directory.EnumerateFiles(Location);
#endif
            }
            catch (Exception e)
            {
                string msg = "TrackCollection::ReloadTracks(): Error while listing files at {" + this.Location + "}.\n" + e.ToString();
                Program.LogWrite(msg);
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            foreach (string currentFile in files)
            {
                try
                {
                    AddTrack(currentFile);
                }
                catch (UnknownAudioFormatException e)
                {
                    string msg = e.ToString();
                    Program.LogWrite(msg);
                    //MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        public void AddTrack(string File)
        {
            string fileName = File.Substring(Location.Length);
#if NOT_NET4
            for(int i = 0; i < Settings.IgnoredFiles.Length; ++i)
                if (Settings.IgnoredFiles[i].Equals(fileName))  return;
#else
            if (Settings.IgnoredFiles.Contains(fileName)) return;
#endif

            string extension = System.IO.Path.GetExtension(File);
#if NOT_NET4
            bool valid = false;
            for (int i = 0; i < Settings.AcceptedFiles.Length; ++i)
            {
                if (Settings.AcceptedFiles[i].Equals(extension.ToLower())) valid = true;
                if (valid) break;
            }
            if (!valid) throw new UnknownAudioFormatException(fileName);
#else
            if (!Settings.AcceptedFiles.Contains(extension.ToLower()))
            {
                throw new UnknownAudioFormatException(fileName);
            }
#endif
            Track t = new Track(fileName, Location, engine);
            LinkedListNode<Track> node = new LinkedListNode<Track>(t);
            Tracks.AddLast(node);
        }
    }



}
