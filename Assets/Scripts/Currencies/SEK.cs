namespace Currencies {
	public class SEK : Money {
		public SEK(int amount) {
			this.amount = amount;
		}

		public Money Times(int factor) {
			return new SEK(this.amount * factor);
		}
	}
}