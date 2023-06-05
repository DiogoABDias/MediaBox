namespace MediaBox.App
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
            BtnMovies = new Button();
            BtnTvShows = new Button();
            BtnCartoons = new Button();
            BtnSettings = new Button();
            BtnSources = new Button();
            LsvEpisodes = new ListView();
            SuspendLayout();
            // 
            // LsvMedia
            // 
            LsvMedia.Location = new Point(93, 12);
            LsvMedia.Name = "LsvMedia";
            LsvMedia.Size = new Size(695, 426);
            LsvMedia.TabIndex = 0;
            LsvMedia.UseCompatibleStateImageBehavior = false;
            LsvMedia.SelectedIndexChanged += LsvMedia_SelectedIndexChanged;
            // 
            // BtnMovies
            // 
            BtnMovies.Location = new Point(12, 12);
            BtnMovies.Name = "BtnMovies";
            BtnMovies.Size = new Size(75, 23);
            BtnMovies.TabIndex = 1;
            BtnMovies.Text = "Movies";
            BtnMovies.UseVisualStyleBackColor = true;
            BtnMovies.Click += BtnMovies_Click;
            // 
            // BtnTvShows
            // 
            BtnTvShows.Location = new Point(12, 41);
            BtnTvShows.Name = "BtnTvShows";
            BtnTvShows.Size = new Size(75, 23);
            BtnTvShows.TabIndex = 1;
            BtnTvShows.Text = "TV Shows";
            BtnTvShows.UseVisualStyleBackColor = true;
            BtnTvShows.Click += BtnTvShows_Click;
            // 
            // BtnCartoons
            // 
            BtnCartoons.Location = new Point(12, 70);
            BtnCartoons.Name = "BtnCartoons";
            BtnCartoons.Size = new Size(75, 23);
            BtnCartoons.TabIndex = 1;
            BtnCartoons.Text = "Cartoons";
            BtnCartoons.UseVisualStyleBackColor = true;
            BtnCartoons.Click += BtnCartoons_Click;
            // 
            // BtnSettings
            // 
            BtnSettings.Location = new Point(12, 415);
            BtnSettings.Name = "BtnSettings";
            BtnSettings.Size = new Size(75, 23);
            BtnSettings.TabIndex = 1;
            BtnSettings.Text = "Settings";
            BtnSettings.UseVisualStyleBackColor = true;
            BtnSettings.Click += BtnSettings_Click;
            // 
            // BtnSources
            // 
            BtnSources.Location = new Point(12, 386);
            BtnSources.Name = "BtnSources";
            BtnSources.Size = new Size(75, 23);
            BtnSources.TabIndex = 2;
            BtnSources.Text = "Sources";
            BtnSources.UseVisualStyleBackColor = true;
            BtnSources.Click += BtnSources_Click;
            // 
            // LsvEpisodes
            // 
            LsvEpisodes.Location = new Point(93, 12);
            LsvEpisodes.Name = "LsvEpisodes";
            LsvEpisodes.Size = new Size(695, 426);
            LsvEpisodes.TabIndex = 3;
            LsvEpisodes.UseCompatibleStateImageBehavior = false;
            LsvEpisodes.SelectedIndexChanged += LsvEpisodes_SelectedIndexChanged;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnSources);
            Controls.Add(BtnSettings);
            Controls.Add(BtnCartoons);
            Controls.Add(BtnTvShows);
            Controls.Add(BtnMovies);
            Controls.Add(LsvMedia);
            Controls.Add(LsvEpisodes);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMain";
            Shown += FrmMain_Shown;
            ResumeLayout(false);
        }

        #endregion

        private ListView LsvMedia;
        private Button BtnMovies;
        private Button BtnTvShows;
        private Button BtnCartoons;
        private Button BtnSettings;
        private Button BtnSources;
        private ListView LsvEpisodes;
    }
}