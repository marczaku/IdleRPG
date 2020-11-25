namespace Currencies {
	public class Money {
		protected int amount;

		public override string ToString() {
			return $"{this.amount} {GetType().Name}";
		}

		public override bool Equals(object obj) {
			if (GetType() != obj?.GetType()) {
				return false;
			}
			var money = (Money) obj;
			return money.amount == this.amount;
		}
	}
}