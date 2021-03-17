using System;
using Heroes;
using UnityEngine;
using UnityEngine.Networking;

namespace Broker {
	
	public interface IEnemySpawner {
		Enemy SpawnEnemy();
	}

	public interface IAnalytics {
		
	}

	public class ServiceConfiguration {
		public enum Analytics {
			None,
			SingularSDK,
			DeltaDNA
		}

		public Analytics analytics;

		public IAnalytics CreateAnalytics() {
			switch (this.analytics) {
				case Analytics.DeltaDNA:
					return new DeltaDNAAnalytics();
				case Analytics.None:
					return new EmptyAnalytics();
				default:
					throw new SystemException();
			}
		}
	}

	public class EmptyAnalytics : IAnalytics {
	}

	public class DeltaDNAAnalytics : IAnalytics {
	}

	// Main or Dependency Injection
	public class Main {
		public ServiceConfiguration services;

		int Awake() {
			var array = new int[]{1, 2, 3, 4}                                               ; 
			return array[2];
		}
	}

	public class GameLogic : MonoBehaviour {
		public IEnemySpawner enemySpawner;

		public void Update() {
			this.enemySpawner.SpawnEnemy();
		}
	}
	
	public class DebugPlayer : MonoBehaviour {
		int gold;

		public void GenerateGold() {
			this.gold += 100;
			Dependencies.broker.Publish("GoldChanged", this.gold);
		}
	}
}