using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UI
{
	public partial class frmMain : Form
	{
		private ucTabContent_Country _countries;
		private ucTabContent_Rate _rates;

		public frmMain()
		{
			InitializeComponent();
			tabControl1.Selecting += tabControl1_Selecting;

			_rates = new ucTabContent_Rate();
			AddTabPage("Rates", _rates);
			//
			_countries = new ucTabContent_Country();
			AddTabPage("Countries", _countries);

			lblLoadedFiles.Text = null;
			txtFolder.Text = Application.StartupPath;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing){
				_countries = null;
				_rates = null;
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Looks for expected file and loads them in predefined order.
		/// </summary>
		/// <param name="workingFolder"></param>
		private void loadFiles(string workingFolder)
		{
			for (int i = 2, j = tabControl1.TabPages.Count - 1; j > i; --j){
				TabPage tp = tabControl1.TabPages[j];
				tabControl1.TabPages.RemoveAt(j);
				tp.Dispose();
			}

			_rates.clearData();
			_countries.clearData();

			DateTime start = DateTime.Now;
			List<string> files2load = new List<string>();
			string[] files = Directory.GetFiles(workingFolder, "rates.csv");

			if (files.Length > 0){
				files2load.Add(files[0]);
			}
			files = Directory.GetFiles(workingFolder, "country.txt");

			if (files.Length > 0){
				files2load.Add(files[0]);
			}
			files = Directory.GetFiles(workingFolder);
			const string pattern = @"^calls\d+.txt$";

			if (files.Length > 0){
				foreach (string file in files){
					if (Regex.IsMatch(Path.GetFileName(file), pattern)){
						files2load.Add(file);
					}
				}
			}

			foreach (string file in files2load){
				string fileName = Path.GetFileName(file).ToLower();

				switch (fileName){
					case "rates.csv":
						_rates.clearData();
						_rates.FilePath = file;
						break;
					case "country.txt":
						_countries.clearData();
						_countries.FilePath = file;
						break;
					default:
						ucTabContent_Call uc = new ucTabContent_Call();
						uc.FilePath = file;
						uc.Execute += contentCalls_ExecuteStarted;
						AddTabPage(Path.GetFileName(file), uc);
						break;
				}
			}

			try{
				Cursor = Cursors.WaitCursor;
				Update();

				_rates.loadData();
				
				if (_rates.RateTable != null){
					_countries.loadData(_rates.RateTable);
				}
				foreach (TabPage page in tabControl1.TabPages){
					page.Enabled = true;
					ucAbstractTabContent content = page.Controls[0] as ucAbstractTabContent;
					if (content is ucTabContent_Call){
						content.loadData();
					}
				}
			}
			finally{
				Cursor = Cursors.Default;
			}
			if (files2load.Count > 0){
				string msg = "Loaded " + files2load.Count + " files: ";
				bool addComma = false;

				foreach (string file in files2load){
					if (addComma){
						msg += ", ";
					}
					msg += Path.GetFileName(file);
					addComma = true;
				}
				lblLoadedFiles.Text = msg + Environment.NewLine + Environment.NewLine + "Elapsed time: " +
				                      (DateTime.Now - start).TotalSeconds.ToString("N2") + " sec";
			}
			else{
				lblLoadedFiles.Text = null;
			}
		}

		/// <summary>
		/// Creates new tab page and adds it.
		/// </summary>
		/// <param name="caption"></param>
		/// <param name="tabContent"></param>
		private void AddTabPage(string caption, Control tabContent)
		{
			TabPage tabPage = new TabPage();
			tabPage.Name = "tabPage" + caption;
			tabPage.Text = caption;
			tabPage.UseVisualStyleBackColor = true;
			tabPage.Enabled = false;
			tabPage.Controls.Add(tabContent);
			tabContent.Dock = DockStyle.Fill;

			tabControl1.TabPages.Add(tabPage);
		}

		/// <summary>
		/// Event trigger. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLoadFiles_Click(object sender, EventArgs e)
		{
			string folder = txtFolder.Text.Trim();

			if (folder.Length > 0){
				if (!Directory.Exists(folder)){
					MessageBox.Show(this, "Folder '" + folder + "' does not exist.");
					return;
				}
			}
			else{
				folder = Application.StartupPath;
			}

			try{
				lblLoadedFiles.Text = "Loading, please wait ...";
				btnChooseWorkingFolder.Enabled = btnLoadFiles.Enabled = false;
				Cursor = Cursors.WaitCursor;
				loadFiles(folder);
			}
			catch (Exception ex){
				MessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			btnChooseWorkingFolder.Enabled = btnLoadFiles.Enabled = true;
			btnLoadFiles.Focus();
			Cursor = Cursors.Default;
		}

		/// <summary>
		/// Verifies presence of tables countries and rates and if they
		/// are present calls method execute of tab page with calls, providing
		/// additional data.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void contentCalls_ExecuteStarted(object sender, EventArgs e)
		{
			if(_rates.RateTable == null || _rates.RateTable.Count == 0){
				MessageBox.Show(this, "There is no rates. Executing aborted.", "Some data is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if(_countries.CountryTable == null || _countries.CountryTable.Count == 0){
				MessageBox.Show(this, "There is no countries. Executing aborted.", "Some data is missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			foreach (TabPage tabPage in tabControl1.TabPages){
				tabPage.Enabled = false;
			}
			ucTabContent_Call content = (ucTabContent_Call) sender;
			
			try{
				content.execute(_countries.CountryTable);
			}
			catch (Exception ex){
				MessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			foreach (TabPage tabPage in tabControl1.TabPages){
				tabPage.Enabled = true;
			}
		}

		private void btnChooseWorkingFolder_Click(object sender, EventArgs e)
		{
			dlgFolderBrowser.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			
			if(dlgFolderBrowser.ShowDialog(this) == DialogResult.OK){
				txtFolder.Text = dlgFolderBrowser.SelectedPath;
			}
		}
	
		private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
		{
			e.Cancel = !e.TabPage.Enabled;

			if(e.TabPage.Enabled && e.TabPageIndex != 0){
				ucAbstractTabContent uc = (ucAbstractTabContent)e.TabPage.Controls[0];
				ActiveControl = uc;
				uc.GridView.Paint += GridView_Paint;
			}
		}

		/// <summary>
		/// Forces gridview focus.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void GridView_Paint(object sender, PaintEventArgs e)
		{
			Control c = (Control) sender;
			c.Paint -= GridView_Paint;
			c.Focus();
		}
	}
}