using System.Threading.Tasks;
using UnityEngine;

namespace Broker {
	public static class PlayerEvents {
		public const string GoldChanged = "GoldChanged";
		public const string DeathChanged = "DeathChanged";
	}
	
	public class Player : MonoBehaviour {
		int _gold;
		public int Gold {
			get => this._gold;
			set {
				if(value >= 0)
					this._gold = value;
				Dependencies.broker.Publish(PlayerEvents.GoldChanged, this._gold);
			}
		}

		static int playerDeaths;

		void Update() {
			this.Gold++;
			if (this.Gold >= 100) {
				SpawnNewPlayer(Time.deltaTime);
				Destroy(this.gameObject);
				playerDeaths++;
				Dependencies.broker.Publish(PlayerEvents.DeathChanged, playerDeaths);
			}
		}

		async void SpawnNewPlayer(float deltaTime) {
			await Task.Delay(Mathf.FloorToInt(deltaTime*1500));
			var playerGo = new GameObject("Player");
			playerGo.AddComponent<Player>();
		}
	}
}