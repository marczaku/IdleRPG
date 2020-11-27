namespace Currencies {
	public class Bank {
		public Bank(float exchangeRate) {
		}

		public Money ExchangeToDollar(IMoney money) {
			return money.ConvertToDollar(this);
		}

		public float GetDollarExchangeRate(string from) {
			if (from == "Dollar")
				return 1f;
			if (from == "SEK")
				return 0.1f;
			throw new System.Exception($"Can not convert {from} to Dollar.");
		}
		
		// TODO 3 extended version: multiply the exchangeRate from->USD with USD->to (e.g.: SEK->USD & USD->EUR ==> SEK->EUR
		public float GetExchangeRate(string from, string to) {
			throw new System.NotImplementedException();
		}
	}
}