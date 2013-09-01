#if NOT_NET4
extern alias NET2;
#else
extern alias NET4;
#endif
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
#endif
using System.IO;
using System.Diagnostics;

namespace Flywire_WinForm
{

    public partial class Form1 : Form
    {
        //[DllImport("test.so")]
        //private static extern int sum(int x, int y);

        ShowMediaCollection ShowMedia;
        StationMediaCollection StationMedia;
        ScheduledMediaCollection ScheduledMedia;
        PlaylistMediaCollection PlaylistMedia;
        PlayControl PlayerControl;
        // start up the engine
        EngineWrapper engine;
        int gListView1LostFocusItem = -1; 
        
        
        public Form1()
        {
            InitializeComponent();

#if !SWIG && NOT_NET4 && !NO_ENGINE
            this.Text += " - Engine: NET2.IrrKlang - .NET Version: " + Environment.Version.ToString();
#elif !SWIG && !NOT_NET4 && !NO_ENGINE
            this.Text += " - Engine: NET4.IrrKlang - .NET Version: " + Environment.Version.ToString();
#elif NO_ENGINE
            this.Text += " - Engine: NO ENGINE - .NET Version: " + Environment.Version.ToString();
#elif SWIG && NOT_NET4
            this.Text += " - Engine: SWIG / NET2.IrrKlang - .NET Version: " + Environment.Version.ToString();
#elif SWIG && !NOT_NET4
            this.Text += " - Engine: SWIG / NET4.IrrKlang - .NET Version: " + Environment.Version.ToString();
#endif

            try
            {
                engine = new EngineWrapper();
                //Console.WriteLine(example.My_variable);
                //Console.WriteLine(example.fact(5));
                //Console.WriteLine(example.get_time());
                

            }
            catch (Exception e)
            {
                Exception inner = e;
                MessageBox.Show(inner.ToString());
                while (inner.InnerException != null)
                {
                    inner = inner.InnerException;
                    MessageBox.Show(inner.ToString());
                }
                throw inner;
                //Exception ex = SwigEnginePINVOKE.SWIGPendingException.Retrieve();
                //throw ex;
            }

            
            
            //engine.LoadPlugins(Settings.PluginsPath);
            
            ShowMedia = new ShowMediaCollection(engine, lvShowMedia, cmbShowList);
            StationMedia = new StationMediaCollection(engine, lvStationMedia);
            ScheduledMedia = new ScheduledMediaCollection(engine, lvScheduledMedia);
            PlayerControl = new PlayControl(this, engine, picPlayBtn, picStopBtn, picSkipBtn, picRecueBtn, trackBar1);
            PlaylistMedia = new PlaylistMediaCollection(engine, lvPlaylist, lblTotalPlayLength, PlayerControl);
            
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
            updateGUI();
            updateSchedule();
            lvShowMedia.Resize += ResizeMediaGrid;
            lvStationMedia.Resize += ResizeMediaGrid;
            lvScheduledMedia.Resize += ResizeMediaGrid;
            lvPlaylist.Resize += ResizeMediaGrid;

            lvShowMedia.ItemSelectionChanged += MediaGridItemSelectionChanged;
            lvStationMedia.ItemSelectionChanged += MediaGridItemSelectionChanged;
            lvScheduledMedia.ItemSelectionChanged += MediaGridItemSelectionChanged;


            cmbShowList.MouseWheel += new MouseEventHandler(cmbShowList_MouseWheel);
            //lvPlaylist.ItemSelectionChanged += MediaGridItemSelectionChanged;

            /*
            lvShowMedia.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.None);
            lvStationMedia.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.None);
            lvScheduledMedia.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.None);
            lvPlaylist.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.None);
            */
            grpShowMedia.Anchor |= (AnchorStyles.Right | AnchorStyles.Bottom);
            grpStationMedia.Anchor |= (AnchorStyles.Right | AnchorStyles.Bottom);
            grpScheduledMedia.Anchor |= (AnchorStyles.Right | AnchorStyles.Bottom);
            grpPlaylist.Anchor |= (AnchorStyles.Right | AnchorStyles.Bottom);

            cmbShowList.DataSource = ShowMedia.ShowNames;

            
           
        }

        private void cmbShowList_MouseWheel(object sender, EventArgs e)
        {

            HandledMouseEventArgs ee = (HandledMouseEventArgs)e;

            ee.Handled = true;

        }


        private void lvShowMedia_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lvShowMedia.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                Track selectedTrack = ShowMedia.FindTrackByName(cmbShowList.SelectedItem.ToString(), item.Text);
                PlaylistMedia.AddTrack(selectedTrack);
            }
            lvPlaylist.Select();
        }

        private void MediaGridItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                e.Item.Selected = false;                
            }
            lvPlaylist.Select();
        }

        private void ResizeMediaGrid(object sender, EventArgs e)
        {
            ListViewEx lv = (ListViewEx)sender;
            lv.Columns[0].Width = (int)(lv.Width - lv.Columns[1].Width - 25); 
            // TODO: Fix width, it's showing elipses.. see AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        
        private void btnReject_Click(object sender, EventArgs e)
        {
            // TODO: Decide whether we keep this... 
        }
        #region Bottom Toolbar Buttons
        private void picPlayBtn_MouseClick(object sender, MouseEventArgs e)
        {
            PlayerControl.PlayTrack();
        }

        private void picStopBtn_MouseClick(object sender, MouseEventArgs e)
        {
            PlayerControl.StopCurrentTrack();
        }

        private void picSkipBtn_MouseClick(object sender, MouseEventArgs e)
        {
            PlayerControl.SkipTrack();
        }

        private void picRecueBtn_MouseClick(object sender, MouseEventArgs e)
        {
            PlayerControl.RecueTracks();
        }

        private void picPlayBtn_EnabledChanged(object sender, EventArgs e)
        {
            if (!picPlayBtn.Enabled)
            {
                picPlayBtn.Image = Properties.Resources.playdisabled;
            }
            else
            {
                picPlayBtn.Image = Properties.Resources.play;
            }
        }
        
        private void picStopBtn_EnabledChanged(object sender, EventArgs e)
        {
            if (!picStopBtn.Enabled)
            {
                picStopBtn.Image = Properties.Resources.stopdisabled;
            }
            else
            {
                picStopBtn.Image = Properties.Resources.stop;
            }
        }

        private void picSkipBtn_EnabledChanged(object sender, EventArgs e)
        {
            if (!picSkipBtn.Enabled)
            {
                picSkipBtn.Image = Properties.Resources.skipdisabled;
            }
            else
            {
                picSkipBtn.Image = Properties.Resources.skip;
            }
        }

        private void picRecueBtn_EnabledChanged(object sender, EventArgs e)
        {
            if (!picRecueBtn.Enabled)
            {
                picRecueBtn.Image = Properties.Resources.recuedisabled;
            }
            else
            {
                picRecueBtn.Image = Properties.Resources.recue;
            }
        }
        #endregion

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            //var x = lvPlaylist.Items[0].SubItems[1].Text;
            //int res = sum(5, 4);
            //MessageBox.Show("result = " + res.ToString());

            //s.PlayFile("01 - Cochise.mp3");
            
            PlaylistMedia.Clear();   
        }

        #region GUI Handling
        private void tmrUpdateGUI_Tick(object sender, EventArgs e)
        {
            updateGUI();
        }

        private void updateGUI()
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");

            if (PlaylistMedia != null && PlaylistMedia.currentIndex >= 0)
            {
                string answer;
                try
                {
                    TimeSpan t = TimeSpan.FromMilliseconds(PlayerControl.getPlayLength() - PlayerControl.getPlayPosition());
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                    lvPlaylist.Items[PlaylistMedia.currentIndex].SubItems[1].Text = answer;

                    t = TimeSpan.FromMilliseconds(PlaylistMedia.TotalPlayLengthLeft());
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                }
                catch (Exception e)
                {
                    // TODO: Log error to file
                    Program.LogWrite("MainForm::updateGUI(): " + e.ToString());
                    answer = "00:00:00";
                }
                lblTotalPlayLength.Text = answer;

            }
        }
        #endregion

        private void lvPlaylist_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lvPlaylist.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                Track selectedTrack = PlaylistMedia.RemoveTrackByName(item.Text);
            }
        }

        private void cmbShowList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMedia.UpdateTrackDisplay(cmbShowList.SelectedItem.ToString());
        }

        private void lvStationMedia_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lvStationMedia.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                Track selectedTrack = StationMedia.FindTrackByName(item.Text);
                PlaylistMedia.AddTrack(selectedTrack);
            }
            lvPlaylist.Select();
        }

        private void lvScheduledMedia_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lvScheduledMedia.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                Track selectedTrack = ScheduledMedia.FindTrackByName(item.Text);
                PlaylistMedia.AddTrack(selectedTrack);
            }
            lvPlaylist.Select();
            // TODO: Add a .played file for the schedule once it has been played
        }

        #region Timers
        private void tmrUpdateSchedule_Tick(object sender, EventArgs e)
        {
            updateSchedule();
        }

        private void updateSchedule()
        {
            if (lblTimeToPlay == null) return;
            if (ScheduledMedia == null) return;

            if (ScheduledMedia.announcementDateTime == DateTime.MinValue)
            {
                lblTimeToPlay.ForeColor = Color.Black;
                lblTimeToPlay.Text = "No announcements";
            }
            else
            {
                if (lblTimeToPlay.ForeColor == Color.Black)
                {
                    lblTimeToPlay.ForeColor = Color.Red;
                }
                else
                {
                    lblTimeToPlay.ForeColor = Color.Black;
                }
                lblTimeToPlay.Text = ScheduledMedia.announcementDateTime.ToString("hh:mm tt");
            }
        }
        #endregion




        private void lvPlaylist_MouseClick(object sender, MouseEventArgs e)
        {
            maintainPlaylistSelection();
            if (Settings.IsLinux)
            {
                lvPlaylist_MouseDoubleClick(sender, e);
            }
        }

        private void maintainPlaylistSelection()
        {
            if (lvPlaylist.Items.Count > 0)
            {
                if (!lvPlaylist.SelectedIndices.Contains(PlaylistMedia.currentIndex))
                {
                    lvPlaylist.Items[PlaylistMedia.currentIndex].Selected = true;
                    lvPlaylist.Select(); // attempting to make the new selection show... for some reason its not repainting
                    lvPlaylist.Refresh();
                }
            }
        }

        private void lvPlaylist_MouseDown(object sender, MouseEventArgs e)
        {
            maintainPlaylistSelection();
        }

        private void lvPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lvPlaylist_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //if (PlaylistMedia.currentIndex < 0) return;
            //if (lvPlaylist.Items[PlaylistMedia.currentIndex].Selected == false) lvPlaylist.Items[PlaylistMedia.currentIndex].Selected = true;
        }

        private void lvPlaylist_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            
            // If this item is the selected item
            if (e.Item.Selected)
            {
                // If the selected item just lost the focus
                if (gListView1LostFocusItem == e.Item.Index)
                {
                    // Set the colors to whatever you want (I would suggest
                    // something less intense than the colors used for the
                    // selected item when it has focus)
                    //e.Item.ForeColor = Color.Black;
                    //e.Item.BackColor = Color.LightBlue;
                    e.Item.ForeColor = SystemColors.HighlightText;
                    e.Item.BackColor = SystemColors.Highlight;

                    // Indicate that this action does not need to be performed
                    // again (until the next time the selected item loses focus)
                    gListView1LostFocusItem = -1;
                }
                else if (lvPlaylist.Focused)  // If the selected item has focus
                {
                    // Set the colors to the normal colors for a selected item
                    //e.Item.ForeColor = Color.Black;
                    //e.Item.BackColor = Color.LightBlue;
                    
                    e.Item.ForeColor = SystemColors.HighlightText;
                    e.Item.BackColor = SystemColors.Highlight;
                }
            }
            else
            {
                // Set the normal colors for items that are not selected
                e.Item.ForeColor = lvPlaylist.ForeColor;
                e.Item.BackColor = lvPlaylist.BackColor;
            }

            e.DrawBackground();
            e.DrawText();
        }

        private void lvPlaylist_Leave(object sender, EventArgs e)
        {
            
            // Set the global int variable (gListView1LostFocusItem) to
            // the index of the selected item that just lost focus
            if (lvPlaylist.FocusedItem != null)
                gListView1LostFocusItem = lvPlaylist.FocusedItem.Index;
        }

        private void cmbShowList_Enter(object sender, EventArgs e)
        {
            
        }



        private void cmbShowList_DropDownClosed(object sender, EventArgs e)
        {
            lvPlaylist.Select();
        }

       

       
    }

}
