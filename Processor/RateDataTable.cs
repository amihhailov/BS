using System;
using System.Collections;
using System.Data;
using System.Runtime.Serialization;

namespace Processor
{
	public class RateDataTable : DataTable, IEnumerable
	{
		private DataColumn column_Direction;
		private DataColumn column_Desk1MinPrice;
		private DataColumn column_Mobile1MinPrice;

		public DataColumn DirectionColumn
		{
			get { return column_Direction; }
		}

		public DataColumn Desk1MinPriceColumn
		{
			get { return column_Desk1MinPrice; }
		}

		public DataColumn Mobile1MinPriceColumn
		{
			get { return column_Mobile1MinPrice; }
		}

		public RateDataTable()
		{
			TableName = "Rate";
			base.BeginInit();
			InitClass();
			base.EndInit();
		}

		internal RateDataTable(DataTable table)
		{
			TableName = table.TableName;
			if ((table.CaseSensitive != table.DataSet.CaseSensitive)){
				CaseSensitive = table.CaseSensitive;
			}
			if ((table.Locale.ToString() != table.DataSet.Locale.ToString())){
				Locale = table.Locale;
			}
			if ((table.Namespace != table.DataSet.Namespace)){
				Namespace = table.Namespace;
			}
			Prefix = table.Prefix;
			MinimumCapacity = table.MinimumCapacity;
		}

		protected RateDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			InitVars();
		}

		public RateRow this[int index]
		{
			get { return ((RateRow) (Rows[index])); }
		}

		#region IEnumerable Members

		public virtual IEnumerator GetEnumerator()
		{
			return Rows.GetEnumerator();
		}

		#endregion

		public override DataTable Clone()
		{
			RateDataTable cln = (RateDataTable) base.Clone();
			cln.InitVars();
			return cln;
		}

		protected override DataTable CreateInstance()
		{
			return new RateDataTable();
		}

		public RateRow NewRateRow()
		{
			return (RateRow) NewRow();
		}

		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new RateRow(builder);
		}

		protected override Type GetRowType()
		{
			return typeof (RateRow);
		}

		public int Count
		{
			get { return Rows.Count; }
		}

		internal void InitVars()
		{
			column_Direction = Columns["Direction"];
			column_Desk1MinPrice = Columns["Desk1MinPrice"];
			column_Mobile1MinPrice = Columns["Mobile1MinPrice"];
		}

		private void InitClass()
		{
			column_Direction = new DataColumn("Direction", typeof (string));
			Columns.Add(column_Direction);
			//
			column_Desk1MinPrice = new DataColumn("Desk1MinPrice", typeof (Decimal));
			Columns.Add(column_Desk1MinPrice);
			//
			column_Mobile1MinPrice = new DataColumn("Mobile1MinPrice", typeof (Decimal));
			Columns.Add(column_Mobile1MinPrice);
			//
		}

		#region Nested type: TableColumns

		public sealed class TableColumns
		{
			public const string DIRECTION = "Direction";
			public const string DESK1MIN_PRICE = "Desk1MinPrice";
			public const string MOBILE1MIN_PRICE = "Mobile1MinPrice";
		}

		#endregion
	}
}