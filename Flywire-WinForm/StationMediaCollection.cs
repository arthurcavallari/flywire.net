using System;
using System.Collections.Generic;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Flywire_WinForm
{
    public class StationMediaCollection : MediaCollection
    {
        public StationMediaCollection(EngineWrapper engine, ListView TrackDisplayList) : base(engine, "Station Media", Settings.StationMediaPath, TrackDisplayList)
        {
            UpdateTrackDisplay();
        }
    }
}
