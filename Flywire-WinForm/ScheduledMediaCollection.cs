using System;
using System.Collections.Generic;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace Flywire_WinForm
{

    public class ScheduledMediaCollection : MediaCollection
    {
        List<ScheduledMediaInfo> Schedule { get; set; }
        public DateTime announcementDateTime { get; private set; }

        public ScheduledMediaCollection(EngineWrapper engine, ListView TrackDisplayList)
            : base(engine, "Scheduled Media", Settings.ScheduledMediaPath, TrackDisplayList, false)
        {
            Schedule = new List<ScheduledMediaInfo>();
            FindScheduledTracks();
        }

        public void FindScheduledTracks()
        {
            if (String.IsNullOrEmpty(Settings.SchedulePath)) return;
#if NOT_NET4
            string[] scheduleFiles = null;
#else
            IEnumerable<string> scheduleFiles = null;
#endif

            // Read file name from directory
            Regex re = new Regex(@"^\d{4}-\d{2}-\d{2} \d{2}-\d{2}-\d{2};.*", RegexOptions.Compiled);
            try
            {
#if NOT_NET4
            scheduleFiles = Directory.GetFiles(Settings.SchedulePath);
            for (int i = 0; i < scheduleFiles.Length; ++i)
            {
                scheduleFiles[i] = Path.GetFileName(scheduleFiles[i]);
               
                if (!re.IsMatch(scheduleFiles[i]))
                {
                    scheduleFiles[i] = "";
                }
            }
#else
                scheduleFiles = Directory.EnumerateFiles(Settings.SchedulePath).Where(f => re.IsMatch(Path.GetFileName(f))).ToList();
#endif
            }
            catch (Exception e)
            {
                string msg = "ScheduledMediaCollection::FindScheduledTracks(): Error while listing files at {" + Settings.SchedulePath + "}.\n" + e.ToString();
                Program.LogWrite(msg);
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Regex reFilename = new Regex(@";.*");
            Regex reDateTime = new Regex(@"^\d{4}-\d{2}-\d{2} \d{2}-\d{2}-\d{2};.*");


            foreach (string currentFile in scheduleFiles)
            {
                if (!String.IsNullOrEmpty(currentFile))
                {
                    try
                    {
                        // Format: yyyy-mm-dd hh-mm-ss;filename.extension
                        string fileName = Path.GetFileName(currentFile);
                        string TrackName = fileName.Split(';')[1];
                        DateTime scheduledDateTime = DateTime.ParseExact(fileName.Split(';')[0], "yyyy'-'MM'-'dd' 'HH'-'mm'-'ss", null);
                        Schedule.Add(new ScheduledMediaInfo() { Name = TrackName, ScheduledDateTime = scheduledDateTime });
                        //scheduledDateTime.ToString("hh:mm:ss tt dd/MM/yyyy"));
                    }
                    catch (Exception e)
                    {
                        string msg = "ScheduledMediaCollection::FindScheduledTracks(): " + e.ToString();
                        Program.LogWrite(msg);
                        MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //MediaList.AddTrack(currentFile);
            }
#if NOT_NET4
            var files = Directory.GetFiles(Settings.ScheduledMediaPath);
#else
            var files = Directory.EnumerateFiles(Settings.ScheduledMediaPath);
#endif

            //foreach (KeyValuePair<DateTime, ScheduledMediaInfo> scheduledMedia in Schedule)

            Schedule.Sort(CompareByDateTimeDesc);
            Schedule.ForEach(
                delegate(ScheduledMediaInfo scheduledMedia)
                {
#if NOT_NET4
                    int index = -1, res = 0;
                    for (int i = 0; i < files.Length; ++i)
                    {
                        if (Path.GetFileName(files[i]) == scheduledMedia.Name)
                        {
                            if (res == 0) index = i;
                            res++;
                        }
                    }
                    if (res > 0)
                    {
                        MediaList.AddTrack(files[index]);
                    }
#else
                    var result = files.Where(f => Path.GetFileName(f) == scheduledMedia.Name);
                    if (result.Count() > 0)
                    {
                        MediaList.AddTrack(result.First());
                    }
#endif
                }
            );

            UpdateTrackDisplay();
        }

        public override void UpdateTrackDisplay()
        {
            base.UpdateTrackDisplay();
            try
            {
#if NOT_NET4
                if (Schedule.Count > 0)
                    announcementDateTime = Schedule[0].ScheduledDateTime;
                else
                    announcementDateTime = DateTime.MinValue;
#else
                if (Schedule.Count > 0)
                    announcementDateTime = Schedule.First().ScheduledDateTime;
                else
                    announcementDateTime = DateTime.MinValue;
#endif
            }
            catch (Exception e)
            {
                string msg = "ScheduledMediaCollection::UpdateTrackDisplay(): " + e.ToString();
                Program.LogWrite(msg);
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CompareByDateTimeDesc(ScheduledMediaInfo x, ScheduledMediaInfo y)
        {
            // use the default comparer to do the original comparison for datetimes
            int ascendingResult = Comparer<DateTime>.Default.Compare(x.ScheduledDateTime, y.ScheduledDateTime);

            // turn the result around
            return ascendingResult;
        }
    }

}
