using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace UI {
	public partial class ucTabContent : UserControl {
		protected DataTable _table;
		private string _filePath;
		protected DataGridView GridView {
			get { return gv; }
		}
		protected Label LabelCount {
			get { return lblCount; }
		}
		public DataTable Table
		{
			get { return _table; }
		}
    public string FilePath
		{
			get { return _filePath; }
			set { _filePath = value; }
		}

		public virtual TabContentType TabContentType
		{
			get
			{
				throw new MustBeOverridenException("TabContentType");
			}
		}

		protected ucTabContent() {
			InitializeComponent();
			gv.AutoGenerateColumns = false;
			base.Dock = DockStyle.Fill;
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing){
				_table.Clear();
				_table.Dispose();
				_table = null;
			}
			base.Dispose(disposing);
		}
		
		public void autoResizeColumns() {
			gv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
		}
		public void setRowsCount() {
			lblCount.Text = "Count: " + gv.Rows.Count;
		}
		public virtual void setDataSource(string filePath)
		{
			throw new MustBeOverridenException("setDataSource");
		}
		protected void setDataSource(DataTable table) {
			_table = table;
			gv.DataSource = table;
			autoResizeColumns();
			setRowsCount();
		}
		public void clearData()
		{
			_table.Rows.Clear();
			setRowsCount();
		}
		protected void addVisibleColumn(bool isFirstColumn, string caption, string fieldName) {
			DataGridViewColumn col = new DataGridViewColumn();
			DataGridViewCell cell = new DataGridViewTextBoxCell();
			if (isFirstColumn) {
				cell.Style.BackColor = Color.LightYellow;
			}
			col.CellTemplate = cell;
			col.HeaderText = caption;
			col.DataPropertyName = col.Name = fieldName;
			col.SortMode = DataGridViewColumnSortMode.Automatic;
			gv.Columns.Add(col);
		}
		protected void addCheckVisibleColumn(bool isFirstColumn, string caption, string fieldName) {
			DataGridViewColumn col = new DataGridViewColumn();
			DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
			cell.TrueValue = true;
			cell.FalseValue = Convert.DBNull;
			cell.FlatStyle = FlatStyle.Standard;
			cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			if (isFirstColumn) {
				cell.Style.BackColor = Color.LightYellow;
			}
			col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			col.CellTemplate = cell;
			col.HeaderText = caption;
			col.DataPropertyName = col.Name = fieldName;
			col.SortMode = DataGridViewColumnSortMode.Automatic;
			gv.Columns.Add(col);
		}

		protected virtual void btnProcess_Click(object sender, EventArgs e)
		{
		}
	}
}