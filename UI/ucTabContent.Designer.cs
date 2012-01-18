namespace UI
{
	partial class ucTabContent
	{
		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.gv = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblCount = new System.Windows.Forms.Label();
			this.btnProcess = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gv
			// 
			this.gv.AllowUserToAddRows = false;
			this.gv.AllowUserToDeleteRows = false;
			this.gv.BackgroundColor = System.Drawing.SystemColors.ControlDark;
			this.gv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gv.Location = new System.Drawing.Point(2, 2);
			this.gv.Name = "gv";
			this.gv.ReadOnly = true;
			this.gv.RowHeadersWidth = 30;
			this.gv.RowTemplate.Height = 20;
			this.gv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gv.Size = new System.Drawing.Size(545, 342);
			this.gv.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnProcess);
			this.panel1.Controls.Add(this.lblCount);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(2, 344);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(545, 40);
			this.panel1.TabIndex = 2;
			// 
			// lblCount
			// 
			this.lblCount.AutoSize = true;
			this.lblCount.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblCount.Location = new System.Drawing.Point(0, 0);
			this.lblCount.Name = "lblCount";
			this.lblCount.Padding = new System.Windows.Forms.Padding(5, 4, 0, 2);
			this.lblCount.Size = new System.Drawing.Size(40, 19);
			this.lblCount.TabIndex = 2;
			this.lblCount.Text = "Count";
			// 
			// btnProcess
			// 
			this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnProcess.Location = new System.Drawing.Point(445, 9);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(92, 23);
			this.btnProcess.TabIndex = 3;
			this.btnProcess.Text = "Process";
			this.btnProcess.UseVisualStyleBackColor = true;
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// ucTabContent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gv);
			this.Controls.Add(this.panel1);
			this.Name = "ucTabContent";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Size = new System.Drawing.Size(549, 386);
			((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gv;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.Label lblCount;
	}
}
