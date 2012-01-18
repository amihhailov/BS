using System;
using System.IO;
using System.Windows.Forms;
using Processor;

namespace UI
{
	/// <summary>
	/// UI interface to work with call's information
	/// </summary>
	internal class ucTabContent_Call : ucAbstractTabContent
	{
		public event EventHandler Execute;

		public override TabContentType TabContentType
		{
			get { return TabContentType.Calls; }
		}

		public CallDataTable CallTable
		{
			get { return (CallDataTable) Table; }
		}

		public ucTabContent_Call()
		{
			addVisibleColumn(true, "Dialed number", CallDataTable.TableColumns.DIALED_NUMBER);
			addVisibleColumn(false, "Elapsed time (seconds)", CallDataTable.TableColumns.ELAPSED_SECONDS);
			BtnExecute.Click += btnExecute_Click;
		}

		/// <summary>
		/// Detach event hundlers.
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing)
		{
			BtnExecute.Click -= btnExecute_Click;
			//
			base.Dispose(disposing);
		}

		/// <summary>
		/// Loads calls' information from provided file.
		/// </summary>
		internal override void loadData()
		{
			CallDataTable table = DataProcessor.LoadCalls(FilePath, Table as CallDataTable);
			setDataSource(table);
		}

		/// <summary>
		/// Executes generationg file with information about calls.
		/// 
		/// </summary>
		/// <param name="countriesTable"></param>
		public void execute(CountryDataTable countriesTable)
		{
			Enabled = false;
			Update();
			Form frm = FindForm();
			if (frm != null){
				frm.Cursor = Cursors.WaitCursor;
			}
			Application.DoEvents();
			//
			string inFileName = FilePath;
			string outFileName = inFileName.Substring(0, inFileName.LastIndexOf(".")) + "-bills.txt";
			bool success = false;
			
			try{
				DataProcessor.ProcessCalls(countriesTable, CallTable, outFileName, IterationsCount);
				success = true;
			}
			finally{
				Enabled = true;
				frm = FindForm();
				
				if (frm != null){
					frm.Cursor = Cursors.Default;
				}
				Application.DoEvents();
				
				if (success){
					MessageBox.Show(this, "You can observ results in file '" + Path.GetFileName(outFileName) + "'", "Execution finished",
					                MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		/// <summary>
		/// Event trigger.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnExecute_Click(object sender, EventArgs e)
		{
			if (Execute != null){
				Execute(this, EventArgs.Empty);
			}
		}
	}
}