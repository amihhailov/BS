using System;
using System.Data;

namespace Processor
{
	public class CallRow : DataRow
	{
		private readonly CallDataTable tableCall;

		internal CallRow(DataRowBuilder rb) : base(rb)
		{
			tableCall = ((CallDataTable) (Table));
		}

		public string DialedNumber
		{
			get { return ((string) (this[tableCall.DialedNumberColumn])); }
			set
			{
				object currValue = this[tableCall.DialedNumberColumn];

				if (!Equals(currValue, value)){
					this[tableCall.DialedNumberColumn] = value;
				}
			}
		}

		public bool IsPhoneNumberNull()
		{
			return IsNull(tableCall.DialedNumberColumn);
		}

		public void SetPhoneNumberNull()
		{
			this[tableCall.DialedNumberColumn] = Convert.DBNull;
		}


		public int ElapsedSeconds
		{
			get { return ((int) (this[tableCall.ElapsedSecondsColumn])); }
			set
			{
				object currValue = this[tableCall.ElapsedSecondsColumn];

				if (!Equals(currValue, value)){
					this[tableCall.ElapsedSecondsColumn] = value;
				}
			}
		}

		public bool IsElapsedSecondsNull()
		{
			return IsNull(tableCall.ElapsedSecondsColumn);
		}

		public void SetElapsedSecondsNull()
		{
			this[tableCall.ElapsedSecondsColumn] = Convert.DBNull;
		}
	}
}