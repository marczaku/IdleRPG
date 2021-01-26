using UnityEngine;

namespace Broker {
	public class DebugPlayerHUD : MonoBehaviour {
		// Subscribe to th event on Start
		void Start() {
			Dependencies.broker.SubscribeTo(PlayerEvents.GoldChanged, OnPlayerGoldChanged);
			Dependencies.broker.SubscribeTo(PlayerEvents.DeathChanged, OnPlayerDeathChanged);
		}

		void OnPlayerDeathChanged(object playerDeaths) {
			Debug.Log($"Player has died {playerDeaths} times.");
		}

		// Display the new Gold value only on Change; Right now: Player Gold updates on FixedUpdate, so 50 times per second
		void OnPlayerGoldChanged(object newGold) {
			Debug.Log($"Player has {newGold} gold.");
		}
	}
}