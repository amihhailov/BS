using System;
using System.Data;

namespace Processor {
	public class CountryRow : DataRow {
		private readonly CountryDataTable tableCountry;

		internal CountryRow(DataRowBuilder rb) : base(rb) {
			tableCountry = ((CountryDataTable) (Table));
		}

		public string Code {
			get { return ((string) (this[tableCountry.CodeColumn])); }
			set {
				object currValue = this[tableCountry.CodeColumn];

				if (!Equals(currValue, value)) {
					this[tableCountry.CodeColumn] = value;
				}
			}
		}


		public bool IsCodeNull() {
			return IsNull(tableCountry.CodeColumn);
		}

		public void SetCodeNull() {
			this[tableCountry.CodeColumn] = Convert.DBNull;
		}

		public string FullName {
			get { return ((string) (this[tableCountry.FullNameColumn])); }
			set {
				object currValue = this[tableCountry.FullNameColumn];

				if (!Equals(currValue, value)) {
					this[tableCountry.FullNameColumn] = value;
				}
			}
		}


		public bool IsFullNameNull() {
			return IsNull(tableCountry.FullNameColumn);
		}

		public void SetFullNameNull() {
			this[tableCountry.FullNameColumn] = Convert.DBNull;
		}

		public string ShortName {
			get { return ((string) (this[tableCountry.ShortNameColumn])); }
			set {
				object currValue = this[tableCountry.ShortNameColumn];

				if (!Equals(currValue, value)) {
					this[tableCountry.ShortNameColumn] = value;
				}
			}
		}


		public bool IsShortNameNull() {
			return IsNull(tableCountry.ShortNameColumn);
		}

		public void SetShortNameNull() {
			this[tableCountry.ShortNameColumn] = Convert.DBNull;
		}

		public bool IsOutOfPlay {
			get { return ((bool) (this[tableCountry.IsOutOfPlayColumn])); }
			set {
				object currValue = this[tableCountry.IsOutOfPlayColumn];

				if (!Equals(currValue, value)) {
					this[tableCountry.IsOutOfPlayColumn] = value;
				}
			}
		}


		public bool IsIsOutOfPlayNull() {
			return IsNull(tableCountry.IsOutOfPlayColumn);
		}

		public void SetIsOutOfPlayNull() {
			this[tableCountry.IsOutOfPlayColumn] = Convert.DBNull;
		}

		public bool IsMobile {
			get { return ((bool) (this[tableCountry.IsMobileColumn])); }
			set {
				object currValue = this[tableCountry.IsMobileColumn];

				if (!Equals(currValue, value)) {
					this[tableCountry.IsMobileColumn] = value;
				}
			}
		}


		public bool IsIsMobileNull() {
			return IsNull(tableCountry.IsMobileColumn);
		}

		public void SetIsMobileNull() {
			this[tableCountry.IsMobileColumn] = Convert.DBNull;
		}

		public Decimal Rate {
			get { return ((Decimal) (this[tableCountry.RateColumn])); }
			set {
				object currValue = this[tableCountry.RateColumn];

				if (!Equals(currValue, value)) {
					this[tableCountry.RateColumn] = value;
				}
			}
		}


		public bool IsRateNull() {
			return IsNull(tableCountry.RateColumn);
		}

		public void SetRateNull() {
			this[tableCountry.RateColumn] = Convert.DBNull;
		}

		public string DirectionName {
			get { return ((string) (this[tableCountry.DirectionNameColumn])); }
			set {
				object currValue = this[tableCountry.DirectionNameColumn];

				if (!Equals(currValue, value)) {
					this[tableCountry.DirectionNameColumn] = value;
				}
			}
		}


		public bool IsDirectionNameNull() {
			return IsNull(tableCountry.DirectionNameColumn);
		}

		public void SetDirectionNameNull() {
			this[tableCountry.DirectionNameColumn] = Convert.DBNull;
		}
	}
}