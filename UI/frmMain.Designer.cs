namespace UI
{
	partial class frmMain
	{
		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.label1 = new System.Windows.Forms.Label();
			this.btnChooseWorkingFolder = new System.Windows.Forms.Button();
			this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageLoadFiles = new System.Windows.Forms.TabPage();
			this.txtFolder = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnLoadFiles = new System.Windows.Forms.Button();
			this.lblLoadedFiles = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPageLoadFiles.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.label1.Location = new System.Drawing.Point(17, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(248, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "Choose a directoctory where data files reside. By default it\'s current directory";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnChooseWorkingFolder
			// 
			this.btnChooseWorkingFolder.Location = new System.Drawing.Point(609, 31);
			this.btnChooseWorkingFolder.Name = "btnChooseWorkingFolder";
			this.btnChooseWorkingFolder.Size = new System.Drawing.Size(81, 23);
			this.btnChooseWorkingFolder.TabIndex = 2;
			this.btnChooseWorkingFolder.Text = "Choose ...";
			this.btnChooseWorkingFolder.UseVisualStyleBackColor = true;
			this.btnChooseWorkingFolder.Click += new System.EventHandler(this.btnChooseWorkingFolder_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageLoadFiles);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(752, 695);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPageLoadFiles
			// 
			this.tabPageLoadFiles.Controls.Add(this.txtFolder);
			this.tabPageLoadFiles.Controls.Add(this.label3);
			this.tabPageLoadFiles.Controls.Add(this.label1);
			this.tabPageLoadFiles.Controls.Add(this.btnLoadFiles);
			this.tabPageLoadFiles.Controls.Add(this.btnChooseWorkingFolder);
			this.tabPageLoadFiles.Controls.Add(this.lblLoadedFiles);
			this.tabPageLoadFiles.Controls.Add(this.label4);
			this.tabPageLoadFiles.Location = new System.Drawing.Point(4, 22);
			this.tabPageLoadFiles.Name = "tabPageLoadFiles";
			this.tabPageLoadFiles.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLoadFiles.Size = new System.Drawing.Size(744, 669);
			this.tabPageLoadFiles.TabIndex = 0;
			this.tabPageLoadFiles.Text = "-- Start page --";
			this.tabPageLoadFiles.UseVisualStyleBackColor = true;
			// 
			// txtFolder
			// 
			this.txtFolder.Location = new System.Drawing.Point(283, 33);
			this.txtFolder.Name = "txtFolder";
			this.txtFolder.Size = new System.Drawing.Size(314, 20);
			this.txtFolder.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point(18, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(680, 2);
			this.label3.TabIndex = 3;
			this.label3.Text = "label3";
			// 
			// btnLoadFiles
			// 
			this.btnLoadFiles.Location = new System.Drawing.Point(283, 98);
			this.btnLoadFiles.Name = "btnLoadFiles";
			this.btnLoadFiles.Size = new System.Drawing.Size(81, 23);
			this.btnLoadFiles.TabIndex = 5;
			this.btnLoadFiles.Text = "Load";
			this.btnLoadFiles.UseVisualStyleBackColor = true;
			this.btnLoadFiles.Click += new System.EventHandler(this.btnLoadFiles_Click);
			// 
			// lblLoadedFiles
			// 
			this.lblLoadedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.lblLoadedFiles.ForeColor = System.Drawing.Color.MediumBlue;
			this.lblLoadedFiles.Location = new System.Drawing.Point(40, 134);
			this.lblLoadedFiles.Name = "lblLoadedFiles";
			this.lblLoadedFiles.Size = new System.Drawing.Size(225, 117);
			this.lblLoadedFiles.TabIndex = 4;
			this.lblLoadedFiles.Text = "Loaded files";
			this.lblLoadedFiles.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.label4.Location = new System.Drawing.Point(40, 92);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(225, 35);
			this.label4.TabIndex = 4;
			this.label4.Text = "Load static files: country.txt, rates.csv and files proper to template calls*.txt" +
					"";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(752, 695);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CSC test task";
			this.tabControl1.ResumeLayout(false);
			this.tabPageLoadFiles.ResumeLayout(false);
			this.tabPageLoadFiles.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnChooseWorkingFolder;
		private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageLoadFiles;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnLoadFiles;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblLoadedFiles;
		private System.Windows.Forms.TextBox txtFolder;
	}
}

