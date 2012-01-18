using System;
using Processor;

namespace UI
{
	internal class ucCallTabContent : ucTabContent
	{
		public event EventHandler BtnProcessClick;

		public override TabContentType TabContentType
		{
			get { return TabContentType.Calls; }
		}
		public CallDataTable CallTable
		{
			get { return (CallDataTable)Table; }
		}

		public ucCallTabContent()
		{
			addVisibleColumn(true, "Phone number", CallDataTable.TableColumns.PHONE_NUMBER);
			addVisibleColumn(false, "Elapsed time (seconds)", CallDataTable.TableColumns.ELAPSED_SECONDS);
		}

		public override void setDataSource(string filePath)
		{
			CallDataTable table = DataProcessor.LoadCalls(filePath, Table as CallDataTable);
			setDataSource(table);
		}

		protected override void btnProcess_Click(object sender, EventArgs e)
		{
			if(BtnProcessClick != null){
				BtnProcessClick(this, EventArgs.Empty);
			}
		}
	}
}