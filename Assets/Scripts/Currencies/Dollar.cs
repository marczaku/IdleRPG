namespace Currencies {
	public class Dollar {
		int amount;
		public Dollar(int amount) {
			this.amount = amount;
		}

		public Dollar Times(int factor) {
			return new Dollar(this.amount * factor);
		}

		public override string ToString() {
			return $"{this.amount} {GetType().Name}";
		}

		public override bool Equals(object obj) {
			if (!(obj is Dollar dollar)) {
				return false;
			}
			return dollar.amount == this.amount;
		}
	}
}