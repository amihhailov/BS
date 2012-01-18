using System;
using System.Collections;
using System.Data;
using System.Runtime.Serialization;

namespace Processor
{
	public class CallDataTable : DataTable, IEnumerable
	{
		private DataColumn column_DialedNumber;
		private DataColumn column_ElapsedSeconds;

		public DataColumn DialedNumberColumn
		{
			get { return column_DialedNumber; }
		}

		public DataColumn ElapsedSecondsColumn
		{
			get { return column_ElapsedSeconds; }
		}

		public CallDataTable()
		{
			TableName = "Call";
			base.BeginInit();
			InitClass();
			base.EndInit();
		}

		internal CallDataTable(DataTable table)
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

		protected CallDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			InitVars();
		}

		public CallRow this[int index]
		{
			get { return ((CallRow) (Rows[index])); }
		}

		#region IEnumerable Members

		public virtual IEnumerator GetEnumerator()
		{
			return Rows.GetEnumerator();
		}

		#endregion

		public override DataTable Clone()
		{
			CallDataTable cln = (CallDataTable) base.Clone();
			cln.InitVars();
			return cln;
		}

		protected override DataTable CreateInstance()
		{
			return new CallDataTable();
		}

		public CallRow NewCallRow()
		{
			return (CallRow) NewRow();
		}

		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new CallRow(builder);
		}

		protected override Type GetRowType()
		{
			return typeof (CallRow);
		}

		public int Count
		{
			get { return Rows.Count; }
		}

		internal void InitVars()
		{
			column_DialedNumber = Columns["PhoneNumber"];
			column_ElapsedSeconds = Columns["ElapsedSeconds"];
		}

		private void InitClass()
		{
			column_DialedNumber = new DataColumn("DialedNumber", typeof (string));
			Columns.Add(column_DialedNumber);
			//
			column_ElapsedSeconds = new DataColumn("ElapsedSeconds", typeof (int));
			Columns.Add(column_ElapsedSeconds);
			//
		}

		#region Nested type: TableColumns

		public sealed class TableColumns
		{
			public const string DIALED_NUMBER = "DialedNumber";
			public const string ELAPSED_SECONDS = "ElapsedSeconds";
		}

		#endregion
	}
}