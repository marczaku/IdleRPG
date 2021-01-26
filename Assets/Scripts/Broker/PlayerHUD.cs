using UnityEngine;

namespace Broker {
	public class PlayerHUD : MonoBehaviour {
		public UnityEngine.UI.Text goldText;
		void Start() {
			Dependencies.broker.SubscribeTo("GoldChanged", OnPlayerGoldChanged);
		}
		void OnPlayerGoldChanged(object newGold) {
			this.goldText.text = newGold.ToString();
		}
	}
}