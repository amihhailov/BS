namespace UI
{
	partial class ucAbstractTabContent
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
            this.btnExecute = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.gv.Location = new System.Drawing.Point(2, 38);
            this.gv.Name = "gv";
            this.gv.ReadOnly = true;
            this.gv.RowHeadersWidth = 30;
            this.gv.RowTemplate.Height = 20;
            this.gv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv.Size = new System.Drawing.Size(545, 324);
            this.gv.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 362);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 22);
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
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Count";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(166, 6);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(64, 23);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.numericUpDown1);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.btnExecute);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(2, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(545, 36);
            this.panelTop.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(100, 7);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Iterations count";
            // 
            // ucAbstractTabContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gv);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panel1);
            this.Name = "ucAbstractTabContent";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(549, 386);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gv;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
	}
}
