using System;

namespace Processor {
	public class DigitNode : IDisposable {
		private DigitNode[] _digits;
		private CountryRow _country;

		public CountryRow Country {
			get { return _country; }
			set { _country = value; }
		}

		public DigitNode getDigitNode(int digit) {
			return (_digits == null) ? null : _digits[digit];
		}

		public DigitNode setDigit(int digit) {
			if (_digits == null) {
				_digits = new DigitNode[10];
			}
			if (_digits[digit] == null) {
				_digits[digit] = new DigitNode();
			}
			return _digits[digit];
		}

		public void pushCountryCode(CountryRow r) {
			DigitNode node = null;

			foreach (char d in r.Code) {
				int digit = Convert.ToInt32(d.ToString());
				node = (node == null) ? setDigit(digit) : node.setDigit(digit);
			}
			if (node != null) {
				node.Country = r;
			}
		}

		public CountryRow findCountryCode(string phoneNumber) {
			DigitNode node = this;
			CountryRow country = null;

			foreach (char d in phoneNumber) {
				int digit = Convert.ToInt32(d.ToString());
				node = node.getDigitNode(digit);

				if (node == null) {
					break;
				}
				
				if (node.Country != null) {
					country = node.Country;
				}
			}
			return country;
		}

		public void Dispose() {
			if(_digits != null) {
				foreach (DigitNode node in _digits) {
					if(node != null) {
						node.Dispose();
					}
				}
				Array.Clear(_digits, 0, 10);
				_digits = null;
			}
			_country = null;
		}
	}
}