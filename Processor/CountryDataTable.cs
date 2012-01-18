using System;
using System.Collections;
using System.Data;
using System.Runtime.Serialization;

namespace Processor {
	public class CountryDataTable : DataTable, IEnumerable {
		private DataColumn column_Code;
		private DataColumn column_FullName;
		private DataColumn column_ShortName;
		private DataColumn column_IsOutOfPlay;
		private DataColumn column_IsMobile;
		private DataColumn column_Rate;
		private DataColumn column_DirectionName;


		public DataColumn CodeColumn {
			get { return column_Code; }
		}

		public DataColumn FullNameColumn {
			get { return column_FullName; }
		}

		public DataColumn ShortNameColumn {
			get { return column_ShortName; }
		}

		public DataColumn IsOutOfPlayColumn {
			get { return column_IsOutOfPlay; }
		}

		public DataColumn IsMobileColumn {
			get { return column_IsMobile; }
		}

		public DataColumn RateColumn {
			get { return column_Rate; }
		}

		public DataColumn DirectionNameColumn {
			get { return column_DirectionName; }
		}

		public CountryDataTable() {
			TableName = "Country";
			base.BeginInit();
			InitClass();
			base.EndInit();
		}

		internal CountryDataTable(DataTable table) {
			TableName = table.TableName;
			if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
				CaseSensitive = table.CaseSensitive;
			}
			if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
				Locale = table.Locale;
			}
			if ((table.Namespace != table.DataSet.Namespace)) {
				Namespace = table.Namespace;
			}
			Prefix = table.Prefix;
			MinimumCapacity = table.MinimumCapacity;
		}

		protected CountryDataTable(SerializationInfo info, StreamingContext context) : base(info, context) {
			InitVars();
		}

		public CountryRow this[int index] {
			get { return ((CountryRow) (Rows[index])); }
		}

		#region IEnumerable Members

		public virtual IEnumerator GetEnumerator() {
			return Rows.GetEnumerator();
		}

		#endregion

		public override DataTable Clone() {
			CountryDataTable cln = (CountryDataTable) base.Clone();
			cln.InitVars();
			return cln;
		}

		protected override DataTable CreateInstance() {
			return new CountryDataTable();
		}

		public CountryRow NewCountryRow() {
			return (CountryRow) NewRow();
		}

		protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
			return new CountryRow(builder);
		}

		protected override Type GetRowType() {
			return typeof (CountryRow);
		}

		public int Count {
			get { return Rows.Count; }
		}

		internal void InitVars() {
			column_Code = Columns["Code"];
			column_FullName = Columns["FullName"];
			column_ShortName = Columns["ShortName"];
			column_IsOutOfPlay = Columns["IsOutOfPlay"];
			column_IsMobile = Columns["IsMobile"];
			column_Rate = Columns["Rate"];
			column_DirectionName = Columns["DirectionName"];
		}

		private void InitClass() {
			column_Code = new DataColumn("Code", typeof (string));
			Columns.Add(column_Code);
			//
			column_FullName = new DataColumn("FullName", typeof (string));
			Columns.Add(column_FullName);
			//
			column_ShortName = new DataColumn("ShortName", typeof (string));
			Columns.Add(column_ShortName);
			//
			column_IsOutOfPlay = new DataColumn("IsOutOfPlay", typeof (bool));
			Columns.Add(column_IsOutOfPlay);
			//
			column_IsMobile = new DataColumn("IsMobile", typeof (bool));
			Columns.Add(column_IsMobile);
			//
			column_Rate = new DataColumn("Rate", typeof (Decimal));
			Columns.Add(column_Rate);
			//
			column_DirectionName = new DataColumn("DirectionName", typeof (string));
			Columns.Add(column_DirectionName);
			//
		}
		
		#region Nested type: TableColumns

		public sealed class TableColumns {
			public const string ID = "ID";
			public const string CODE = "Code";
			public const string FULL_NAME = "FullName";
			public const string SHORT_NAME = "ShortName";
			public const string IS_OUT_OF_PLAY = "IsOutOfPlay";
			public const string IS_MOBILE = "IsMobile";
			public const string RATE = "Rate";
			public const string DIRECTION_NAME = "DirectionName";
		}

		#endregion
	}
}