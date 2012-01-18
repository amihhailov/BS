using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Processor;

namespace UI
{
	public class ucCountryTabContent : ucTabContent
	{
		public override TabContentType TabContentType
		{
			get { return TabContentType.Country; }
		}
		public CountryDataTable CountryTable
		{
			get { return (CountryDataTable)Table; }
		}

		public ucCountryTabContent()
		{
			addVisibleColumn(true, "Code", CountryDataTable.TableColumns.CODE);
			addVisibleColumn(false, "Full name", CountryDataTable.TableColumns.FULL_NAME);
			addVisibleColumn(false, "Short name", CountryDataTable.TableColumns.SHORT_NAME);
			addCheckVisibleColumn(false, "Mobile", CountryDataTable.TableColumns.IS_MOBILE);
			addVisibleColumn(false, "Rate", CountryDataTable.TableColumns.RATE);
			GridView.DataBindingComplete += GridView_DataBindingComplete;
		}

		public override void setDataSource(string filePath)
		{
			CountryDataTable table = DataProcessor.LoadCountries(filePath, Table as CountryDataTable);
			table.DefaultView.Sort = CountryDataTable.TableColumns.ID + " ASC";
			setDataSource(table);
		}
		public void appendRates(RateDataTable rates)
		{
			DataProcessor.AppendRates(CountryTable, rates);
		}

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