namespace Resources {
	[System.Serializable]
	public struct ResourceAmount {
		public int amount;
		public Resource resource;

		public override string ToString() {
			return $"{this.amount} {this.resource.name}";
		}

		public bool IsAffordable => this.resource.Owned >= this.amount;
		
		public void Create() {
			this.resource.Owned += this.amount;
		}
		
		public void Consume() {
			this.resource.Owned -= this.amount;
		}

		public ResourceAmount(int amount, Resource resource) {
			this.amount = amount;
			this.resource = resource;
		}
	}
}