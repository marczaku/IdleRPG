namespace Currencies {
	public class Dollar : Money {
		public Dollar(int amount) {
			this.amount = amount;
		}

		public Money Times(int factor) {
			return new Dollar(this.amount * factor);
		}
	}
}