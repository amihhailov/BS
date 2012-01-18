using System;
using System.Data;

namespace Processor
{
	public class RateRow : DataRow
	{
		private readonly RateDataTable tableRate;

		internal RateRow(DataRowBuilder rb) : base(rb)
		{
			tableRate = ((RateDataTable) (Table));
		}

		public string Direction
		{
			get { return ((string) (this[tableRate.DirectionColumn])); }
			set
			{
				object currValue = this[tableRate.DirectionColumn];

				if (!Equals(currValue, value)){
					this[tableRate.DirectionColumn] = value;
				}
			}
		}


		public bool IsDirectionNull()
		{
			return IsNull(tableRate.DirectionColumn);
		}

		public void SetDirectionNull()
		{
			this[tableRate.DirectionColumn] = Convert.DBNull;
		}

		public Decimal Desk1MinPrice
		{
			get { return ((Decimal) (this[tableRate.Desk1MinPriceColumn])); }
			set
			{
				object currValue = this[tableRate.Desk1MinPriceColumn];

				if (!Equals(currValue, value)){
					this[tableRate.Desk1MinPriceColumn] = value;
				}
			}
		}


		public bool IsDesk1MinPriceNull()
		{
			return IsNull(tableRate.Desk1MinPriceColumn);
		}

		public void SetDesk1MinPriceNull()
		{
			this[tableRate.Desk1MinPriceColumn] = Convert.DBNull;
		}

		public Decimal Mobile1MinPrice
		{
			get { return ((Decimal) (this[tableRate.Mobile1MinPriceColumn])); }
			set
			{
				object currValue = this[tableRate.Mobile1MinPriceColumn];

				if (!Equals(currValue, value)){
					this[tableRate.Mobile1MinPriceColumn] = value;
				}
			}
		}


		public bool IsMobile1MinPriceNull()
		{
			return IsNull(tableRate.Mobile1MinPriceColumn);
		}

		public void SetMobile1MinPriceNull()
		{
			this[tableRate.Mobile1MinPriceColumn] = Convert.DBNull;
		}
	}
}