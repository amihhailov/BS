using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
	public partial class ucAbstractTabContent : UserControl
	{
		protected DataTable _table;
		private string _filePath;

		public DataGridView GridView
		{
			get { return gv; }
		}

		/// <summary>
		/// Specifies data source.
		/// </summary>
		public DataTable Table
		{
			get { return _table; }
		}

		/// <summary>
		/// Returns ile path for the tab content control
		/// </summary>
		public string FilePath
		{
			get { return _filePath; }
			set { _filePath = value; }
		}

		public Button BtnExecute
		{
			get { return btnExecute; }
		}

		public virtual TabContentType TabContentType
		{
			get
			{
				throw new MustBeOverridenException("TabContentType");
			}
		}

		/// <summary>
		/// Returns iterations count from numeric updown control.
		/// </summary>
		public int IterationsCount
		{
			get { return (int) numericUpDown1.Value; }
		}

		protected ucAbstractTabContent()
		{
			InitializeComponent();
			gv.AutoGenerateColumns = false;
		}

		/// <summary>
		/// Release resources.
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing)
		{
			if (disposing){
				if (_table != null){
					gv.DataSource = null;
					_table.Clear();
					_table.Dispose();
					_table = null;
				}
			}
			base.Dispose(disposing);
		}

		protected override void OnCreateControl()
		{
			if (!DesignMode){
				panelTop.Visible = (TabContentType == TabContentType.Calls);
			}
		}

		/// <summary>
		/// Sets data source for the gridview.
		/// </summary>
		/// <param name="table"></param>
		protected void setDataSource(DataTable table)
		{
			_table = table;
			gv.DataSource = table;
			gv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
			lblCount.Text = "Count: " + gv.Rows.Count;
		}

		/// <summary>
		/// Clear gridview's data source.
		/// </summary>
		public void clearData()
		{
			_filePath = null;

			if (_table != null){
				_table.Rows.Clear();
				lblCount.Text = "Count: 0";
			}
		}

		internal virtual void loadData(){}

		/// <summary>
		/// Adds text box column to the gridview.
		/// </summary>
		/// <param name="isFirstColumn"></param>
		/// <param name="caption"></param>
		/// <param name="fieldName"></param>
		protected DataGridViewColumn addVisibleColumn(bool isFirstColumn, string caption, string fieldName)
		{
			DataGridViewColumn col = new DataGridViewColumn();
			DataGridViewCell cell = new DataGridViewTextBoxCell();
			if (isFirstColumn){
				cell.Style.BackColor = Color.LightYellow;
			}
			col.CellTemplate = cell;
			col.HeaderText = caption;
			col.DataPropertyName = col.Name = fieldName;
			col.SortMode = DataGridViewColumnSortMode.Automatic;
			gv.Columns.Add(col);

			return col;
		}

		/// <summary>
		/// Adds check box column to the gridview.
		/// </summary>
		/// <param name="isFirstColumn"></param>
		/// <param name="caption"></param>
		/// <param name="fieldName"></param>
		protected void addCheckVisibleColumn(bool isFirstColumn, string caption, string fieldName)
		{
			DataGridViewColumn col = new DataGridViewColumn();
			DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
			cell.TrueValue = true;
			cell.FalseValue = false;
			cell.FlatStyle = FlatStyle.Standard;
			cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			if (isFirstColumn){
				cell.Style.BackColor = Color.LightYellow;
			}
			col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			col.CellTemplate = cell;
			col.HeaderText = caption;
			col.DataPropertyName = col.Name = fieldName;
			col.SortMode = DataGridViewColumnSortMode.Automatic;
			gv.Columns.Add(col);
		}
	}
}