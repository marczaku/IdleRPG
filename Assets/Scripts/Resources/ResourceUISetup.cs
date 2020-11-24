using Clicker.ResourceProduction;
using UnityEngine;

namespace Resources {
	public class ResourceUISetup : MonoBehaviour {

		public Resource[] resources;
		public ResourceUI prefab;

		void Start() {
			foreach (var resource in this.resources) {
				var instance = Instantiate(this.prefab, this.transform);
				instance.SetUp(resource);
			}
		}
	}
}