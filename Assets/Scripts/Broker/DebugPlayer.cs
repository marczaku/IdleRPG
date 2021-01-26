using UnityEngine;

namespace Broker {
	public class DebugPlayer : MonoBehaviour {
		int gold;

		public void GenerateGold() {
			this.gold += 100;
			Dependencies.broker.Publish("GoldChanged", this.gold);
		}
	}
}