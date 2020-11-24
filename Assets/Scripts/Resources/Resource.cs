using UnityEngine;

namespace Resources {
	[CreateAssetMenu]
	public class Resource : ScriptableObject {
		public Color color;
		public int amountPerClick = 5;
		public IntEvent OwnedChanged;

		// increases the amount of this Resource
		public int Owned {
			get => PlayerPrefs.GetInt(this.name, 1);
			set {
				PlayerPrefs.SetInt(this.name, value);
				this.OwnedChanged.Invoke(value);
			}
		}

		public void Produce() {
			this.Owned += this.amountPerClick;
		}
	}
}