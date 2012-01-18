using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Processor;

namespace UI
{
	/// <summary>
	/// UI interface to observ countries' information
	/// </summary>
	public class ucTabContent_Country : ucAbstractTabContent
	{
		public override TabContentType TabContentType
		{
			get { return TabContentType.Country; }
		}
		public CountryDataTable CountryTable
		{
			get { return (CountryDataTable)Table; }
		}

		public ucTabContent_Country()
		{
			addVisibleColumn(true, "Code", CountryDataTable.TableColumns.CODE);
			addVisibleColumn(false, "Full name", CountryDataTable.TableColumns.FULL_NAME);
			addVisibleColumn(false, "Short name", CountryDataTable.TableColumns.SHORT_NAME);
			addCheckVisibleColumn(false, "Mobile", CountryDataTable.TableColumns.IS_MOBILE);
			addVisibleColumn(false, "Rate", CountryDataTable.TableColumns.RATE);
			GridView.DataBindingComplete += GridView_DataBindingComplete;
		}

		/// <summary>
		/// Loads data from countries file.
		/// </summary>
		public void loadData(RateDataTable rates) {
			if(FilePath == null){
				return;
			}
			setDataSource(null);
			CountryDataTable table = DataProcessor.LoadCountries(FilePath, Table as CountryDataTable, rates);
			table.DefaultView.Sort = CountryDataTable.TableColumns.CODE + " ASC";
			setDataSource(table);
		}

		/// <summary>
		/// Paints Personal and Premium rows with Coral color.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			foreach (DataGridViewRow vr in GridView.Rows) {
				CountryRow r = (CountryRow) ((DataRowView)vr.DataBoundItem).Row;
				
				if(!r.IsIsOutOfPlayNull()) {
					for (int i = 1, j = GridView.Columns.Count; i < j; i++){
						vr.Cells[i].Style.BackColor = Color.LightCoral;
					}
				}
			}
		}
	}
}