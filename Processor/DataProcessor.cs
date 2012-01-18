using System;
using System.Data;
using System.IO;

namespace Processor {
	public static class DataProcessor {
		//public static delegate void IterationFinishedEventHandler(int number);

		/// <summary>
		/// Reads countries data from the file and imports some additional data from rates to
		/// achieve higher performance.
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="table"></param>
		/// <param name="rates"></param>
		/// <returns></returns>
		public static CountryDataTable LoadCountries(string filePath, CountryDataTable table, RateDataTable rates) {
			StreamReader reader = File.OpenText(filePath);
			table = table ?? new CountryDataTable();

			if (table.Constraints["code"] == null) {
				table.Constraints.Add("code", table.Columns[CountryDataTable.TableColumns.CODE], false);
			}
			const string Mobile = "Mobile";
			const string Premium = "Premium";
			const string Personal = "Personal";
			DataView dvRates = new DataView(rates);

			try {
				string str;
				while ((str = reader.ReadLine()) != null) {
					str = str.Trim();
					if (str.Length == 0) {
						continue;
					}
					string[] values = str.Split(',');

					if (values.Length != 3) {
						throw new DataException("Parsing country text line encountered an issue: file has invalid format.");
					}
					for (int i = 0, j = values.Length; i < j; i++) {
						values[i] = values[i].Trim();
					}
					//
					CountryRow row = table.NewCountryRow();
					row.Code = values[0];
					string fullName = row.FullName = values[1];
					string shortName = row.ShortName = values[2];
					row.IsMobile = (shortName.IndexOf(Mobile) > -1);

					if (fullName.IndexOf(Premium) == -1 && fullName.IndexOf(Personal) == -1) {
						if (row.IsMobile) {
							shortName = shortName.Replace("Mobile", "").Trim();
						}
						dvRates.RowFilter = string.Format("{0}='{1}'", RateDataTable.TableColumns.DIRECTION, shortName);

						if (dvRates.Count > 0) {
							foreach (DataRowView rv in dvRates) {
								RateRow r = (RateRow) rv.Row;
								row.Rate = row.IsMobile ? r.Mobile1MinPrice : r.Desk1MinPrice;
								row.DirectionName = r.Direction;
							}
						}
					}
					else {
						row.IsOutOfPlay = true;
					}
					//
					try {
						table.Rows.Add(row);
					}
					catch (ConstraintException) {
						// Duplicated code
						continue;
					}
				}
			}
			finally {
				reader.Close();
				dvRates.Table = null;
				dvRates.Dispose();
			}

			return table;
		}

		/// <summary>
		/// Reads rates data from the file.
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="table"></param>
		/// <returns></returns>
		public static RateDataTable LoadRates(string filePath, RateDataTable table) {
			StreamReader reader = File.OpenText(filePath);
			table = table ?? new RateDataTable();

			if (!table.Constraints.Contains("direction")) {
				table.Constraints.Add("direction", table.Columns[RateDataTable.TableColumns.DIRECTION], false);
			}
			try {
				string str;
				while ((str = reader.ReadLine()) != null) {
					str = str.Trim();

					if (str.Length == 0) {
						continue;
					}
					string[] values = str.Split(';');

					if (values.Length != 3) {
						throw new DataException("Parsing rates text line encountered an issue: file has invalid format.");
					}

					for (int i = 0, j = values.Length; i < j; i++) {
						values[i] = values[i].Trim();
					}
					//
					RateRow row = table.NewRateRow();
					row.Direction = values[0];
					try {
						row.Desk1MinPrice = decimal.Parse(values[1]);
					}
					catch (Exception) {
						row.Desk1MinPrice = 0;
					}

					try {
						row.Mobile1MinPrice = decimal.Parse(values[2]);
					}
					catch (Exception) {
						row.Mobile1MinPrice = 0;
					}
					//
					try {
						table.Rows.Add(row);
					}
					catch (ConstraintException) {
						// Duplicated direction
						continue;
					}
				}
			}
			finally {
				reader.Close();
			}

			return table;
		}

		/// <summary>
		/// Reads calls from the file.
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="table"></param>
		/// <returns></returns>
		public static CallDataTable LoadCalls(string filePath, CallDataTable table) {
			StreamReader reader = File.OpenText(filePath);
			string str;
            table = table ?? new CallDataTable();//table = (table == null) ? new CallDataTable() : table;

			while ((str = reader.ReadLine()) != null) {
				str = str.Trim();

				if (str.Length == 0) {
					continue;
				}
				string[] values = str.Split(',');

				if (values.Length != 2) {
					throw new DataException("Parsing call text line encountered an issue: file has invalid format.");
				}
				for (int i = 0, j = values.Length; i < j; i++) {
					values[i] = values[i].Trim();
				}
				//
				CallRow row = table.NewCallRow();
				row.DialedNumber = values[0];
				row.ElapsedSeconds = int.Parse(values[1]);
				//
				table.Rows.Add(row);
			}
			reader.Close();

			return table;
		}

		/// <summary>
		/// Formats a string with detailed information about call
		/// </summary>
		/// <param name="country"></param>
		/// <param name="call"></param>
		/// <returns></returns>
		private static string GetCallDetailedInfo(CountryRow country, CallRow call) {
			int seconds = call.ElapsedSeconds;

			if (seconds < 60) {
				seconds = 60;
			}
			else {
				int step = country.IsMobile ? 30 : 10;
				int remainder = (seconds - 60)%step;
				if (remainder > 0) {
					seconds += step - remainder;
				}
			}
			decimal cost = seconds*country.Rate/60;
			string strCost = cost.ToString("N3");
			return string.Format("{0,-14} {1,-8} {2,-30} {3,-22} {4,-4} {5,-7} {6,-6} {7}",
			                           call.DialedNumber, 
																 country.Code, 
																 country.FullName, 
																 country.ShortName, 
																 call.ElapsedSeconds, 
																 seconds,
			                           strCost,
			                           country.DirectionName);
		}

		/// <summary>
		/// Finds direction code for the phone call. Calculates talk's rounded seconds and
		/// cost then writes call's summary information to the file.
		/// </summary>
		/// <param name="countries"></param>
		/// <param name="calls"></param>
		/// <param name="outFile"></param>
		/// <param name="iterationsCount"></param>
		public static void ProcessCalls(CountryDataTable countries, CallDataTable calls, string outFile, int iterationsCount) {
		}
	}
}
