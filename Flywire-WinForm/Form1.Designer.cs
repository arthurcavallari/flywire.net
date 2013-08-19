using System.Windows.Forms;
namespace Flywire_WinForm
{
    
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpShowMedia = new System.Windows.Forms.GroupBox();
            this.lvShowMedia = new Flywire_WinForm.ListViewEx();
            this.lvColHeaderTrackName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvColHeaderDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbShowList = new System.Windows.Forms.ComboBox();
            this.grpStationMedia = new System.Windows.Forms.GroupBox();
            this.lvStationMedia = new Flywire_WinForm.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpScheduledMedia = new System.Windows.Forms.GroupBox();
            this.chkAutoAdd = new System.Windows.Forms.CheckBox();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.lblTimeToPlay = new System.Windows.Forms.Label();
            this.lvScheduledMedia = new Flywire_WinForm.ListViewEx();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grpPlaylist = new System.Windows.Forms.GroupBox();
            this.lvPlaylist = new Flywire_WinForm.ListViewEx();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkRepeat = new System.Windows.Forms.CheckBox();
            this.chkCue = new System.Windows.Forms.CheckBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.lblTotalPlayLength = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.tmrUpdateGUI = new System.Windows.Forms.Timer(this.components);
            this.tmrUpdateSchedule = new System.Windows.Forms.Timer(this.components);
            this.picRecueBtn = new System.Windows.Forms.PictureBox();
            this.picSkipBtn = new System.Windows.Forms.PictureBox();
            this.picStopBtn = new System.Windows.Forms.PictureBox();
            this.picPlayBtn = new System.Windows.Forms.PictureBox();
            this.grpShowMedia.SuspendLayout();
            this.grpStationMedia.SuspendLayout();
            this.grpScheduledMedia.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.grpPlaylist.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRecueBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSkipBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStopBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // grpShowMedia
            // 
            this.grpShowMedia.Controls.Add(this.lvShowMedia);
            this.grpShowMedia.Controls.Add(this.cmbShowList);
            this.grpShowMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpShowMedia.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grpShowMedia.Location = new System.Drawing.Point(3, 3);
            this.grpShowMedia.Name = "grpShowMedia";
            this.grpShowMedia.Size = new System.Drawing.Size(568, 232);
            this.grpShowMedia.TabIndex = 0;
            this.grpShowMedia.TabStop = false;
            this.grpShowMedia.Text = "Show Media";
            // 
            // lvShowMedia
            // 
            this.lvShowMedia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvShowMedia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvColHeaderTrackName,
            this.lvColHeaderDuration});
            this.lvShowMedia.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lvShowMedia.FullRowSelect = true;
            this.lvShowMedia.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvShowMedia.Location = new System.Drawing.Point(3, 58);
            this.lvShowMedia.MultiSelect = false;
            this.lvShowMedia.Name = "lvShowMedia";
            this.lvShowMedia.Size = new System.Drawing.Size(562, 171);
            this.lvShowMedia.TabIndex = 1;
            this.lvShowMedia.UseCompatibleStateImageBehavior = false;
            this.lvShowMedia.View = System.Windows.Forms.View.Details;
            this.lvShowMedia.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvShowMedia_MouseClick);
            // 
            // lvColHeaderTrackName
            // 
            this.lvColHeaderTrackName.Text = "Track Name";
            this.lvColHeaderTrackName.Width = 470;
            // 
            // lvColHeaderDuration
            // 
            this.lvColHeaderDuration.Text = "00:00:00";
            this.lvColHeaderDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lvColHeaderDuration.Width = 70;
            // 
            // cmbShowList
            // 
            this.cmbShowList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbShowList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShowList.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cmbShowList.FormattingEnabled = true;
            this.cmbShowList.Location = new System.Drawing.Point(6, 29);
            this.cmbShowList.Name = "cmbShowList";
            this.cmbShowList.Size = new System.Drawing.Size(556, 23);
            this.cmbShowList.TabIndex = 0;
            this.cmbShowList.SelectedIndexChanged += new System.EventHandler(this.cmbShowList_SelectedIndexChanged);
            this.cmbShowList.DropDownClosed += new System.EventHandler(this.cmbShowList_DropDownClosed);
            this.cmbShowList.Enter += new System.EventHandler(this.cmbShowList_Enter);
            // 
            // grpStationMedia
            // 
            this.grpStationMedia.Controls.Add(this.lvStationMedia);
            this.grpStationMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStationMedia.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grpStationMedia.Location = new System.Drawing.Point(3, 241);
            this.grpStationMedia.Name = "grpStationMedia";
            this.grpStationMedia.Size = new System.Drawing.Size(568, 232);
            this.grpStationMedia.TabIndex = 1;
            this.grpStationMedia.TabStop = false;
            this.grpStationMedia.Text = "Station Media";
            // 
            // lvStationMedia
            // 
            this.lvStationMedia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvStationMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStationMedia.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lvStationMedia.FullRowSelect = true;
            this.lvStationMedia.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvStationMedia.Location = new System.Drawing.Point(3, 26);
            this.lvStationMedia.MultiSelect = false;
            this.lvStationMedia.Name = "lvStationMedia";
            this.lvStationMedia.Size = new System.Drawing.Size(562, 203);
            this.lvStationMedia.TabIndex = 1;
            this.lvStationMedia.UseCompatibleStateImageBehavior = false;
            this.lvStationMedia.View = System.Windows.Forms.View.Details;
            this.lvStationMedia.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvStationMedia_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Track Name";
            this.columnHeader1.Width = 470;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "00:00:00";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 70;
            // 
            // grpScheduledMedia
            // 
            this.grpScheduledMedia.Controls.Add(this.chkAutoAdd);
            this.grpScheduledMedia.Controls.Add(this.btnAddAll);
            this.grpScheduledMedia.Controls.Add(this.btnReject);
            this.grpScheduledMedia.Controls.Add(this.lblTimeToPlay);
            this.grpScheduledMedia.Controls.Add(this.lvScheduledMedia);
            this.grpScheduledMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpScheduledMedia.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grpScheduledMedia.Location = new System.Drawing.Point(3, 479);
            this.grpScheduledMedia.Name = "grpScheduledMedia";
            this.grpScheduledMedia.Size = new System.Drawing.Size(568, 232);
            this.grpScheduledMedia.TabIndex = 2;
            this.grpScheduledMedia.TabStop = false;
            this.grpScheduledMedia.Text = "Scheduled Announcements";
            // 
            // chkAutoAdd
            // 
            this.chkAutoAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoAdd.AutoSize = true;
            this.chkAutoAdd.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.chkAutoAdd.Location = new System.Drawing.Point(309, 33);
            this.chkAutoAdd.Name = "chkAutoAdd";
            this.chkAutoAdd.Size = new System.Drawing.Size(84, 21);
            this.chkAutoAdd.TabIndex = 5;
            this.chkAutoAdd.Text = "Auto Add";
            this.chkAutoAdd.UseVisualStyleBackColor = true;
            // 
            // btnAddAll
            // 
            this.btnAddAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAll.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnAddAll.Location = new System.Drawing.Point(485, 26);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(80, 32);
            this.btnAddAll.TabIndex = 4;
            this.btnAddAll.Text = "Add All";
            this.btnAddAll.UseVisualStyleBackColor = true;
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnReject.Location = new System.Drawing.Point(399, 26);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(80, 32);
            this.btnReject.TabIndex = 3;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // lblTimeToPlay
            // 
            this.lblTimeToPlay.AutoSize = true;
            this.lblTimeToPlay.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeToPlay.Location = new System.Drawing.Point(9, 29);
            this.lblTimeToPlay.Name = "lblTimeToPlay";
            this.lblTimeToPlay.Size = new System.Drawing.Size(115, 29);
            this.lblTimeToPlay.TabIndex = 2;
            this.lblTimeToPlay.Text = "11:40 PM";
            // 
            // lvScheduledMedia
            // 
            this.lvScheduledMedia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvScheduledMedia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvScheduledMedia.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lvScheduledMedia.FullRowSelect = true;
            this.lvScheduledMedia.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvScheduledMedia.Location = new System.Drawing.Point(3, 64);
            this.lvScheduledMedia.MultiSelect = false;
            this.lvScheduledMedia.Name = "lvScheduledMedia";
            this.lvScheduledMedia.Size = new System.Drawing.Size(562, 165);
            this.lvScheduledMedia.TabIndex = 1;
            this.lvScheduledMedia.UseCompatibleStateImageBehavior = false;
            this.lvScheduledMedia.View = System.Windows.Forms.View.Details;
            this.lvScheduledMedia.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvScheduledMedia_MouseClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Track Name";
            this.columnHeader3.Width = 470;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "00:00:00";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 70;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.grpShowMedia, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpStationMedia, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpScheduledMedia, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1148, 774);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 842F));
            this.tableLayoutPanel3.Controls.Add(this.picRecueBtn, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.picSkipBtn, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.picStopBtn, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.picPlayBtn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.trackBar1, 5, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 717);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1142, 54);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(303, 3);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(836, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.TabStop = false;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.grpPlaylist, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(577, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.57724F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.42277F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(568, 708);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // grpPlaylist
            // 
            this.grpPlaylist.Controls.Add(this.lvPlaylist);
            this.grpPlaylist.Controls.Add(this.chkRepeat);
            this.grpPlaylist.Controls.Add(this.chkCue);
            this.grpPlaylist.Controls.Add(this.btnClearAll);
            this.grpPlaylist.Controls.Add(this.lblTotalPlayLength);
            this.grpPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPlaylist.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grpPlaylist.Location = new System.Drawing.Point(3, 169);
            this.grpPlaylist.Name = "grpPlaylist";
            this.grpPlaylist.Size = new System.Drawing.Size(562, 536);
            this.grpPlaylist.TabIndex = 3;
            this.grpPlaylist.TabStop = false;
            this.grpPlaylist.Text = "Playlist";
            // 
            // lvPlaylist
            // 
            this.lvPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPlaylist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lvPlaylist.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lvPlaylist.FullRowSelect = true;
            this.lvPlaylist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvPlaylist.HideSelection = false;
            this.lvPlaylist.Location = new System.Drawing.Point(3, 67);
            this.lvPlaylist.MultiSelect = false;
            this.lvPlaylist.Name = "lvPlaylist";
            this.lvPlaylist.Size = new System.Drawing.Size(556, 466);
            this.lvPlaylist.TabIndex = 1;
            this.lvPlaylist.UseCompatibleStateImageBehavior = false;
            this.lvPlaylist.View = System.Windows.Forms.View.Details;
            this.lvPlaylist.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvPlaylist_DrawItem);
            this.lvPlaylist.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvPlaylist_ItemSelectionChanged);
            this.lvPlaylist.Leave += new System.EventHandler(this.lvPlaylist_Leave);
            this.lvPlaylist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvPlaylist_MouseClick);
            this.lvPlaylist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvPlaylist_MouseDoubleClick);
            this.lvPlaylist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvPlaylist_MouseDown);
            this.lvPlaylist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvPlaylist_MouseDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Track Name";
            this.columnHeader5.Width = 470;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "00:00:00";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 70;
            // 
            // chkRepeat
            // 
            this.chkRepeat.AutoSize = true;
            this.chkRepeat.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.chkRepeat.Location = new System.Drawing.Point(169, 36);
            this.chkRepeat.Name = "chkRepeat";
            this.chkRepeat.Size = new System.Drawing.Size(74, 21);
            this.chkRepeat.TabIndex = 6;
            this.chkRepeat.Text = "Repeat";
            this.chkRepeat.UseVisualStyleBackColor = true;
            // 
            // chkCue
            // 
            this.chkCue.AutoSize = true;
            this.chkCue.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.chkCue.Location = new System.Drawing.Point(110, 36);
            this.chkCue.Name = "chkCue";
            this.chkCue.Size = new System.Drawing.Size(54, 21);
            this.chkCue.TabIndex = 5;
            this.chkCue.Text = "Cue";
            this.chkCue.UseVisualStyleBackColor = true;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnClearAll.Location = new System.Drawing.Point(3, 29);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(87, 32);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // lblTotalPlayLength
            // 
            this.lblTotalPlayLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPlayLength.AutoSize = true;
            this.lblTotalPlayLength.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalPlayLength.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPlayLength.Location = new System.Drawing.Point(364, 17);
            this.lblTotalPlayLength.Name = "lblTotalPlayLength";
            this.lblTotalPlayLength.Size = new System.Drawing.Size(194, 51);
            this.lblTotalPlayLength.TabIndex = 7;
            this.lblTotalPlayLength.Text = "00:00:00";
            this.lblTotalPlayLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 160);
            this.panel1.TabIndex = 4;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(274, 105);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(285, 51);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "06:00:00 PM";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmrUpdateGUI
            // 
            this.tmrUpdateGUI.Enabled = true;
            this.tmrUpdateGUI.Interval = 500;
            this.tmrUpdateGUI.Tick += new System.EventHandler(this.tmrUpdateGUI_Tick);
            // 
            // tmrUpdateSchedule
            // 
            this.tmrUpdateSchedule.Enabled = true;
            this.tmrUpdateSchedule.Interval = 1000;
            this.tmrUpdateSchedule.Tick += new System.EventHandler(this.tmrUpdateSchedule_Tick);
            // 
            // picRecueBtn
            // 
            this.picRecueBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picRecueBtn.Enabled = false;
            this.picRecueBtn.Image = global::Flywire_WinForm.Properties.Resources.recuedisabled;
            this.picRecueBtn.Location = new System.Drawing.Point(186, 3);
            this.picRecueBtn.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.picRecueBtn.Name = "picRecueBtn";
            this.picRecueBtn.Size = new System.Drawing.Size(48, 48);
            this.picRecueBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRecueBtn.TabIndex = 7;
            this.picRecueBtn.TabStop = false;
            this.picRecueBtn.EnabledChanged += new System.EventHandler(this.picRecueBtn_EnabledChanged);
            this.picRecueBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picRecueBtn_MouseClick);
            // 
            // picSkipBtn
            // 
            this.picSkipBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picSkipBtn.Enabled = false;
            this.picSkipBtn.Image = global::Flywire_WinForm.Properties.Resources.skipdisabled;
            this.picSkipBtn.Location = new System.Drawing.Point(126, 3);
            this.picSkipBtn.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.picSkipBtn.Name = "picSkipBtn";
            this.picSkipBtn.Size = new System.Drawing.Size(48, 48);
            this.picSkipBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSkipBtn.TabIndex = 6;
            this.picSkipBtn.TabStop = false;
            this.picSkipBtn.EnabledChanged += new System.EventHandler(this.picSkipBtn_EnabledChanged);
            this.picSkipBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picSkipBtn_MouseClick);
            // 
            // picStopBtn
            // 
            this.picStopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picStopBtn.Enabled = false;
            this.picStopBtn.Image = global::Flywire_WinForm.Properties.Resources.stopdisabled;
            this.picStopBtn.Location = new System.Drawing.Point(66, 3);
            this.picStopBtn.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.picStopBtn.Name = "picStopBtn";
            this.picStopBtn.Size = new System.Drawing.Size(48, 48);
            this.picStopBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picStopBtn.TabIndex = 5;
            this.picStopBtn.TabStop = false;
            this.picStopBtn.EnabledChanged += new System.EventHandler(this.picStopBtn_EnabledChanged);
            this.picStopBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picStopBtn_MouseClick);
            // 
            // picPlayBtn
            // 
            this.picPlayBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picPlayBtn.Enabled = false;
            this.picPlayBtn.Image = global::Flywire_WinForm.Properties.Resources.playdisabled;
            this.picPlayBtn.Location = new System.Drawing.Point(6, 3);
            this.picPlayBtn.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.picPlayBtn.Name = "picPlayBtn";
            this.picPlayBtn.Size = new System.Drawing.Size(48, 48);
            this.picPlayBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPlayBtn.TabIndex = 4;
            this.picPlayBtn.TabStop = false;
            this.picPlayBtn.EnabledChanged += new System.EventHandler(this.picPlayBtn_EnabledChanged);
            this.picPlayBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picPlayBtn_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 774);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flywire.NET";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpShowMedia.ResumeLayout(false);
            this.grpStationMedia.ResumeLayout(false);
            this.grpScheduledMedia.ResumeLayout(false);
            this.grpScheduledMedia.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.grpPlaylist.ResumeLayout(false);
            this.grpPlaylist.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRecueBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSkipBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStopBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpShowMedia;
        private System.Windows.Forms.ColumnHeader lvColHeaderTrackName;
        private System.Windows.Forms.ColumnHeader lvColHeaderDuration;
        private System.Windows.Forms.ComboBox cmbShowList;
        private Flywire_WinForm.ListViewEx lvShowMedia;
        private System.Windows.Forms.GroupBox grpStationMedia;
        private Flywire_WinForm.ListViewEx lvStationMedia;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox grpScheduledMedia;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Label lblTimeToPlay;
        private Flywire_WinForm.ListViewEx lvScheduledMedia;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.CheckBox chkAutoAdd;
        private System.Windows.Forms.PictureBox picPlayBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picStopBtn;
        private System.Windows.Forms.PictureBox picSkipBtn;
        private System.Windows.Forms.PictureBox picRecueBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox grpPlaylist;
        private System.Windows.Forms.CheckBox chkCue;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.CheckBox chkRepeat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalPlayLength;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer tmrUpdateGUI;
        private Flywire_WinForm.ListViewEx lvPlaylist;
        private System.Windows.Forms.Timer tmrUpdateSchedule;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}

