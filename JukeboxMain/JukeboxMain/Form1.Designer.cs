namespace JukeboxMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.GenreTitle_txt = new System.Windows.Forms.TextBox();
            this.Genrelist_Lst = new System.Windows.Forms.ListBox();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.PresentlyPlaying_txt = new System.Windows.Forms.TextBox();
            this.WindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.PlayList_Lst = new System.Windows.Forms.ListBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WindowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setUpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 454);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(410, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setUpToolStripMenuItem
            // 
            this.setUpToolStripMenuItem.Name = "setUpToolStripMenuItem";
            this.setUpToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.setUpToolStripMenuItem.Text = "Set Up";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Copyright © 2018 Miles Ejgierd - Waring";
            // 
            // GenreTitle_txt
            // 
            this.GenreTitle_txt.Location = new System.Drawing.Point(123, 114);
            this.GenreTitle_txt.Name = "GenreTitle_txt";
            this.GenreTitle_txt.Size = new System.Drawing.Size(164, 20);
            this.GenreTitle_txt.TabIndex = 2;
            // 
            // Genrelist_Lst
            // 
            this.Genrelist_Lst.FormattingEnabled = true;
            this.Genrelist_Lst.Location = new System.Drawing.Point(123, 140);
            this.Genrelist_Lst.Name = "Genrelist_Lst";
            this.Genrelist_Lst.Size = new System.Drawing.Size(164, 69);
            this.Genrelist_Lst.TabIndex = 3;
            this.Genrelist_Lst.DoubleClick += new System.EventHandler(this.Genrelist_Lst_DoubleClick);
            // 
            // hScrollBar
            // 
            this.hScrollBar.LargeChange = 1;
            this.hScrollBar.Location = new System.Drawing.Point(123, 212);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(164, 16);
            this.hScrollBar.TabIndex = 4;
            this.hScrollBar.ValueChanged += new System.EventHandler(this.hScrollBar_ValueChanged);
            // 
            // PresentlyPlaying_txt
            // 
            this.PresentlyPlaying_txt.Location = new System.Drawing.Point(123, 231);
            this.PresentlyPlaying_txt.Name = "PresentlyPlaying_txt";
            this.PresentlyPlaying_txt.Size = new System.Drawing.Size(164, 20);
            this.PresentlyPlaying_txt.TabIndex = 5;
            // 
            // WindowsMediaPlayer
            // 
            this.WindowsMediaPlayer.Enabled = true;
            this.WindowsMediaPlayer.Location = new System.Drawing.Point(0, -1);
            this.WindowsMediaPlayer.Name = "WindowsMediaPlayer";
            this.WindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WindowsMediaPlayer.OcxState")));
            this.WindowsMediaPlayer.Size = new System.Drawing.Size(75, 23);
            this.WindowsMediaPlayer.TabIndex = 6;
            this.WindowsMediaPlayer.Visible = false;
            this.WindowsMediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.WindowsMediaPlayer_PlayStateChange);
            // 
            // PlayList_Lst
            // 
            this.PlayList_Lst.FormattingEnabled = true;
            this.PlayList_Lst.Location = new System.Drawing.Point(123, 257);
            this.PlayList_Lst.Name = "PlayList_Lst";
            this.PlayList_Lst.Size = new System.Drawing.Size(164, 108);
            this.PlayList_Lst.TabIndex = 7;
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(410, 478);
            this.Controls.Add(this.PlayList_Lst);
            this.Controls.Add(this.WindowsMediaPlayer);
            this.Controls.Add(this.PresentlyPlaying_txt);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.Genrelist_Lst);
            this.Controls.Add(this.GenreTitle_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WindowsMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GenreTitle_txt;
        private System.Windows.Forms.ListBox Genrelist_Lst;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.TextBox PresentlyPlaying_txt;
        private AxWMPLib.AxWindowsMediaPlayer WindowsMediaPlayer;
        private System.Windows.Forms.ListBox PlayList_Lst;
        private System.Windows.Forms.Timer Timer;
    }
}

