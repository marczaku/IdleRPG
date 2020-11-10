using Resources;
using UnityEngine;

namespace Clicker.ResourceProduction {
	[CreateAssetMenu(menuName = "Clicker/ResourceProduction/Data", fileName = "ResourceProductionData")] // "ResourceProductionData"
	public class Data : ScriptableObject {
		[SerializeField] ResourceAmount costs;
		[SerializeField] float costMultiplier = 1.1f;
		public float productionTime = 1f;
		[SerializeField] ResourceAmount production;
		[SerializeField] float productionMultiplier = 1.05f;

		public ResourceAmount GetActualCosts(int amount) {
			var result = this.costs;
			result.amount = Mathf.RoundToInt(result.amount * Mathf.Pow(this.costMultiplier, amount));
			return result;
		}

		public ResourceAmount GetProductionAmount(int upgradeAmount, int unitCount) {
			var result = this.production;
			result.amount = Mathf.RoundToInt(result.amount * Mathf.Pow(this.productionMultiplier, upgradeAmount) * unitCount);
			return result;
		}
	}
}