namespace MediaBox.Frm.Views
{
    partial class FrmMain
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
            LsvMedia = new ListView();
            ColName = new ColumnHeader();
            BtnMovies = new Button();
            BtnTvShows = new Button();
            BtnCartoons = new Button();
            BtnSettings = new Button();
            BtnSources = new Button();
            BtnAll = new Button();
            SuspendLayout();
            // 
            // LsvMedia
            // 
            LsvMedia.Columns.AddRange(new ColumnHeader[] { ColName });
            LsvMedia.FullRowSelect = true;
            LsvMedia.GridLines = true;
            LsvMedia.Location = new Point(93, 12);
            LsvMedia.Name = "LsvMedia";
            LsvMedia.Size = new Size(695, 426);
            LsvMedia.TabIndex = 5;
            LsvMedia.UseCompatibleStateImageBehavior = false;
            LsvMedia.View = View.Details;
            LsvMedia.SelectedIndexChanged += LsvMedia_SelectedIndexChanged;
            LsvMedia.DoubleClick += LsvMedia_DoubleClick;
            // 
            // ColName
            // 
            ColName.Text = "Name";
            ColName.Width = 400;
            // 
            // BtnMovies
            // 
            BtnMovies.Location = new Point(12, 41);
            BtnMovies.Name = "BtnMovies";
            BtnMovies.Size = new Size(75, 23);
            BtnMovies.TabIndex = 2;
            BtnMovies.Text = "Movies";
            BtnMovies.UseVisualStyleBackColor = true;
            BtnMovies.Click += BtnMovies_Click;
            // 
            // BtnTvShows
            // 
            BtnTvShows.Location = new Point(12, 70);
            BtnTvShows.Name = "BtnTvShows";
            BtnTvShows.Size = new Size(75, 23);
            BtnTvShows.TabIndex = 3;
            BtnTvShows.Text = "TV Shows";
            BtnTvShows.UseVisualStyleBackColor = true;
            BtnTvShows.Click += BtnTvShows_Click;
            // 
            // BtnCartoons
            // 
            BtnCartoons.Location = new Point(12, 99);
            BtnCartoons.Name = "BtnCartoons";
            BtnCartoons.Size = new Size(75, 23);
            BtnCartoons.TabIndex = 4;
            BtnCartoons.Text = "Cartoons";
            BtnCartoons.UseVisualStyleBackColor = true;
            BtnCartoons.Click += BtnCartoons_Click;
            // 
            // BtnSettings
            // 
            BtnSettings.Location = new Point(12, 415);
            BtnSettings.Name = "BtnSettings";
            BtnSettings.Size = new Size(75, 23);
            BtnSettings.TabIndex = 7;
            BtnSettings.Text = "Settings";
            BtnSettings.UseVisualStyleBackColor = true;
            BtnSettings.Click += BtnSettings_Click;
            // 
            // BtnSources
            // 
            BtnSources.Location = new Point(12, 386);
            BtnSources.Name = "BtnSources";
            BtnSources.Size = new Size(75, 23);
            BtnSources.TabIndex = 6;
            BtnSources.Text = "Sources";
            BtnSources.UseVisualStyleBackColor = true;
            BtnSources.Click += BtnSources_Click;
            // 
            // BtnAll
            // 
            BtnAll.Location = new Point(12, 12);
            BtnAll.Name = "BtnAll";
            BtnAll.Size = new Size(75, 23);
            BtnAll.TabIndex = 1;
            BtnAll.Text = "All";
            BtnAll.UseVisualStyleBackColor = true;
            BtnAll.Click += BtnAll_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnAll);
            Controls.Add(BtnSources);
            Controls.Add(BtnSettings);
            Controls.Add(BtnCartoons);
            Controls.Add(BtnTvShows);
            Controls.Add(BtnMovies);
            Controls.Add(LsvMedia);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MediaBox";
            Load += FrmMain_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView LsvMedia;
        private Button BtnMovies;
        private Button BtnTvShows;
        private Button BtnCartoons;
        private Button BtnSettings;
        private Button BtnSources;
        private Button BtnAll;
        private ColumnHeader ColName;
    }
}