using Processor;

namespace UI {
	/// <summary>
	/// UI interface to observ rates' information
	/// </summary>
	public partial class ucTabContent_Rate : ucAbstractTabContent {
		public override TabContentType TabContentType {
			get { return TabContentType.Rates; }
		}
		
		public RateDataTable RateTable {
			get { return (RateDataTable) Table; }
		}

		public ucTabContent_Rate() {
			InitializeComponent();
			//
			addVisibleColumn(true, "Direction", RateDataTable.TableColumns.DIRECTION);
			addVisibleColumn(false, "Desk 1 min", RateDataTable.TableColumns.DESK1MIN_PRICE);
			addVisibleColumn(false, "Mobile 1 min", RateDataTable.TableColumns.MOBILE1MIN_PRICE);
		}

		internal override void loadData() {
			if(FilePath == null){
				return;
			}
			setDataSource(null);
			RateDataTable table = DataProcessor.LoadRates(FilePath, Table as RateDataTable);
			table.DefaultView.Sort = RateDataTable.TableColumns.DIRECTION + " ASC";
			setDataSource(table);
		}
	}
}