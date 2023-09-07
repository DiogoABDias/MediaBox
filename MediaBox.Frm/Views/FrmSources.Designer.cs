namespace MediaBox.Frm.Views
{
    partial class FrmSources
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
            LsvSources = new ListView();
            ColSource = new ColumnHeader();
            ColType = new ColumnHeader();
            ColLanguage = new ColumnHeader();
            ColPath = new ColumnHeader();
            BtnNew = new Button();
            BtnEdit = new Button();
            BtnDelete = new Button();
            BtnCancel = new Button();
            BtnSave = new Button();
            SuspendLayout();
            // 
            // LsvSources
            // 
            LsvSources.Columns.AddRange(new ColumnHeader[] { ColSource, ColType, ColLanguage, ColPath });
            LsvSources.FullRowSelect = true;
            LsvSources.GridLines = true;
            LsvSources.Location = new Point(12, 12);
            LsvSources.MultiSelect = false;
            LsvSources.Name = "LsvSources";
            LsvSources.Size = new Size(500, 250);
            LsvSources.TabIndex = 0;
            LsvSources.UseCompatibleStateImageBehavior = false;
            LsvSources.View = View.Details;
            LsvSources.SelectedIndexChanged += LsvSources_SelectedIndexChanged;
            // 
            // ColSource
            // 
            ColSource.Text = "Source";
            ColSource.Width = 100;
            // 
            // ColType
            // 
            ColType.Text = "Type";
            ColType.Width = 80;
            // 
            // ColLanguage
            // 
            ColLanguage.Text = "Language";
            ColLanguage.Width = 80;
            // 
            // ColPath
            // 
            ColPath.Text = "Path";
            ColPath.Width = 220;
            // 
            // BtnNew
            // 
            BtnNew.Location = new Point(12, 268);
            BtnNew.Name = "BtnNew";
            BtnNew.Size = new Size(75, 23);
            BtnNew.TabIndex = 1;
            BtnNew.Text = "New";
            BtnNew.UseVisualStyleBackColor = true;
            BtnNew.Click += BtnNew_Click;
            // 
            // BtnEdit
            // 
            BtnEdit.Enabled = false;
            BtnEdit.Location = new Point(93, 268);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(75, 23);
            BtnEdit.TabIndex = 1;
            BtnEdit.Text = "Edit";
            BtnEdit.UseVisualStyleBackColor = true;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Enabled = false;
            BtnDelete.Location = new Point(174, 268);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(75, 23);
            BtnDelete.TabIndex = 1;
            BtnDelete.Text = "Delete";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(437, 268);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(75, 23);
            BtnCancel.TabIndex = 1;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(356, 268);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(75, 23);
            BtnSave.TabIndex = 1;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // FrmSources
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 303);
            Controls.Add(BtnSave);
            Controls.Add(BtnCancel);
            Controls.Add(BtnDelete);
            Controls.Add(BtnEdit);
            Controls.Add(BtnNew);
            Controls.Add(LsvSources);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSources";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sources";
            Load += FrmSources_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView LsvSources;
        private Button BtnNew;
        private Button BtnEdit;
        private Button BtnDelete;
        private Button BtnCancel;
        private Button BtnSave;
        private ColumnHeader ColSource;
        private ColumnHeader ColType;
        private ColumnHeader ColLanguage;
        private ColumnHeader ColPath;
    }
}