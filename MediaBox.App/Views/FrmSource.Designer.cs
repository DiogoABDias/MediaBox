namespace MediaBox.App.Views
{
    partial class FrmSource
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
            components = new System.ComponentModel.Container();
            LblName = new Label();
            TxtName = new TextBox();
            CmbType = new ComboBox();
            LblType = new Label();
            CmbLanguage = new ComboBox();
            languageViewBindingSource = new BindingSource(components);
            LblLanguage = new Label();
            LblPath = new Label();
            TxtPath = new TextBox();
            BtnSave = new Button();
            BtnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)languageViewBindingSource).BeginInit();
            SuspendLayout();
            // 
            // LblName
            // 
            LblName.AutoSize = true;
            LblName.Location = new Point(12, 15);
            LblName.Name = "LblName";
            LblName.Size = new Size(39, 15);
            LblName.TabIndex = 0;
            LblName.Text = "Name";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(77, 12);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(200, 23);
            TxtName.TabIndex = 1;
            TxtName.TextChanged += TxtName_TextChanged;
            // 
            // CmbType
            // 
            CmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbType.FormattingEnabled = true;
            CmbType.Items.AddRange(new object[] { "Movie", "TV Show", "Cartoon" });
            CmbType.Location = new Point(77, 41);
            CmbType.Name = "CmbType";
            CmbType.Size = new Size(100, 23);
            CmbType.TabIndex = 2;
            // 
            // LblType
            // 
            LblType.AutoSize = true;
            LblType.Location = new Point(12, 44);
            LblType.Name = "LblType";
            LblType.Size = new Size(31, 15);
            LblType.TabIndex = 0;
            LblType.Text = "Type";
            // 
            // CmbLanguage
            // 
            CmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbLanguage.FormattingEnabled = true;
            CmbLanguage.Location = new Point(77, 70);
            CmbLanguage.Name = "CmbLanguage";
            CmbLanguage.Size = new Size(200, 23);
            CmbLanguage.TabIndex = 3;
            // 
            // languageViewBindingSource
            // 
            languageViewBindingSource.DataSource = typeof(LanguageView);
            // 
            // LblLanguage
            // 
            LblLanguage.AutoSize = true;
            LblLanguage.Location = new Point(12, 73);
            LblLanguage.Name = "LblLanguage";
            LblLanguage.Size = new Size(59, 15);
            LblLanguage.TabIndex = 0;
            LblLanguage.Text = "Language";
            // 
            // LblPath
            // 
            LblPath.AutoSize = true;
            LblPath.Location = new Point(12, 102);
            LblPath.Name = "LblPath";
            LblPath.Size = new Size(31, 15);
            LblPath.TabIndex = 0;
            LblPath.Text = "Path";
            // 
            // TxtPath
            // 
            TxtPath.Cursor = Cursors.Hand;
            TxtPath.Location = new Point(77, 99);
            TxtPath.Name = "TxtPath";
            TxtPath.ReadOnly = true;
            TxtPath.Size = new Size(400, 23);
            TxtPath.TabIndex = 4;
            TxtPath.Click += TxtPath_Click;
            // 
            // BtnSave
            // 
            BtnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnSave.Location = new Point(346, 157);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(75, 23);
            BtnSave.TabIndex = 5;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnCancel.Location = new Point(427, 157);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(75, 23);
            BtnCancel.TabIndex = 6;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // FrmSource
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 192);
            Controls.Add(BtnCancel);
            Controls.Add(BtnSave);
            Controls.Add(TxtPath);
            Controls.Add(LblPath);
            Controls.Add(LblLanguage);
            Controls.Add(CmbLanguage);
            Controls.Add(LblType);
            Controls.Add(CmbType);
            Controls.Add(TxtName);
            Controls.Add(LblName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSource";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Source";
            Load += FrmSourcesNew_Load;
            ((System.ComponentModel.ISupportInitialize)languageViewBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblName;
        private TextBox TxtName;
        private ComboBox CmbType;
        private Label LblType;
        private ComboBox CmbLanguage;
        private Label LblLanguage;
        private Label LblPath;
        private TextBox TxtPath;
        private Button BtnSave;
        private Button BtnCancel;
        private BindingSource languageViewBindingSource;
    }
}