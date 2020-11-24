namespace Currencies {
	public class SEK {
		int amount;
		public SEK(int amount) {
			this.amount = amount;
		}

		public SEK Times(int factor) {
			return new SEK(this.amount * factor);
		}

		public override string ToString() {
			return $"{this.amount} {GetType().Name}";
		}

		public override bool Equals(object obj) {
			if (!(obj is SEK SEK)) {
				return false;
			}
			return SEK.amount == this.amount;
		}
	}
}