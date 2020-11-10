using UnityEngine;
using UnityEngine.UI;

namespace Resources {
	public class ResourceUI : MonoBehaviour {
		public Text amountText;
		public Resource resource;

		void UpdateAmountLabel() {
			this.amountText.text = this.resource.Owned.ToString($"0 {this.resource.name}");
		}

		void Update() {
			UpdateAmountLabel();
		}
	}
}
