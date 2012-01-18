using Processor;

namespace UI
{
	internal class ucRateTabContent : ucTabContent
	{
		public override TabContentType TabContentType
		{
			get { return TabContentType.Rates; }
		}
		public RateDataTable RateTable
		{
			get { return (RateDataTable)Table; }
		}

		public ucRateTabContent()
		{
			addVisibleColumn(true, "Direction", RateDataTable.TableColumns.DIRECTION);
			addVisibleColumn(false, "Desk 1 min", RateDataTable.TableColumns.DESK1MIN_PRICE);
			addVisibleColumn(false, "Mobile 1 min", RateDataTable.TableColumns.MOBILE1MIN_PRICE);
		}

		public override void setDataSource(string filePath)
		{
			RateDataTable table = DataProcessor.LoadRates(filePath, Table as RateDataTable);
			setDataSource(table);
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// ucRateTabContent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "ucRateTabContent";
			this.Size = new System.Drawing.Size(1251, 845);
			this.ResumeLayout(false);

		}
	}
}