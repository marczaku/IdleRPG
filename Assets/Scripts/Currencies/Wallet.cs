namespace Currencies {
	public class Wallet : IMoney {
		readonly Money a;
		readonly Money b;

		public Wallet(Money a, Money b) {
			this.a = a;
			this.b = b;
		}
	}
}