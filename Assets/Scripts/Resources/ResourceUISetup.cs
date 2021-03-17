using Clicker.ResourceProduction;
using UnityEditor;
using UnityEngine;

namespace Resources {
	public class ResourceUISetup : MonoBehaviour {

		public Resource[] resources;
		public AssetReference resourcePrefab;

		void Start() {
			foreach (var resource in this.resources) {
				var instance = Instantiate(this.resourcePrefab.Load<ResourceUI>(), this.transform);
				instance.SetUp(resource);
			}
		}
	}

	
	public abstract class AssetReference : ScriptableObject {
		public abstract T Load<T>() where T : Object;
	}
	
	#if UNITY_EDITOR
	[CreateAssetMenu]
	public class AssetReferenceEditor : AssetReference {
		public UnityEngine.Object reference;

		public override T Load<T>() {
			return this.reference as T;
		}

		// Path.Combine prevents these from happening:
		const string path = "Assets/StreamingAssets//something.png";
		const string path2 = "Assets/StreamingAssetssomething.png";
		// If you don't know, which format you get paths in:
		const string path3 = "Assets/StreamingAssets";
		const string path4 = "Assets/StreamingAssets/";
		const string path5 = "Assets\\StreamingAssets\\";
	}
	#endif
	
	/*
	 * In between is the difficult part:
	 * write a script for your build pipeline
	 * that replaces all AssetReferenceEditor with AssetReferenceBuild
	 * using this function:
	 * public static void GetPath(Object reference) {
			AssetDatabase.GetAssetPath(reference);
		}
	 */
	
	[CreateAssetMenu]
	public class AssetReferenceBuild : AssetReference {
		public string referencePath;

		public override T Load<T>() {
			return UnityEngine.Resources.Load<T>(this.referencePath);
		}
	}
}