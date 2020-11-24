using UnityEditor;
using UnityEngine;

namespace Resources {
	[CustomPropertyDrawer(typeof(ResourceAmount))]
	public class ResourceAmountDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			EditorGUI.LabelField(new Rect(position.x, position.y, EditorGUIUtility.labelWidth, position.height), label);
			var width = (position.width - EditorGUIUtility.labelWidth);
			EditorGUI.IntField(new Rect(position.x+EditorGUIUtility.labelWidth, position.y, width*0.3f, position.height), 100);
			EditorGUI.ObjectField(new Rect(position.x+EditorGUIUtility.labelWidth+width*0.3f, position.y, width*0.7f, position.height), default(Object), typeof(Resource));
		}
	}
}