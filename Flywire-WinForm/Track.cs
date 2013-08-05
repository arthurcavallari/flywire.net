using System;
using System.IO;
using System.Collections.Generic;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace Flywire_WinForm
{
    public class Track
    {
        public SourceWrapper SoundSource { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Duration { get; private set; }
        public uint PlayLength {get; private set; }
        public uint PlayPosition { get; set; }
        public string FullPath { get{return Location + Name;} }

        public Track(string Name, string Location, EngineWrapper engine)
        {
            this.Name = Name;
            this.Location = Location;
            SoundSource = engine.LoadFile(FullPath);
            PlayLength = SoundSource.PlayLength;
            PlayPosition = 0;
            
            TimeSpan t = TimeSpan.FromMilliseconds(PlayLength);
            string answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
            Duration = answer;
            
        }
    }

    
}
