using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable] public class IntEvent : UnityEvent<int>{}
[Serializable] public class StringEvent : UnityEvent<string>{}
[Serializable] public class ColorEvent : UnityEvent<Color>{}

namespace Resources {
	
	public class ResourceUI : MonoBehaviour {

		public StringEvent AmountChanged;
		public StringEvent ResourceNameChanged;
		public ColorEvent ResourceColorChanged;
		Resource resource;

		public void SetUp(Resource resource) {
			this.resource = resource;
			// State Listener 101:
			// step 1: subscribe to state change
			this.resource.OwnedChanged.AddListener(OnOwnedChanged);
			// step 2: set current state
			OnOwnedChanged(this.resource.Owned);
			// State Listeners are used, when you want to know about the current State of Something
			// e.g.: Show Player Health. If it starts at 3, show 3. If it changes, set it to current value.
			
			// Opposed to that, Change Listeners / Event Listeners only listen to changes
			// For example, if you want to play an animation every time your Gold increases.
			
			// => StateListener = EventListener + Initial State
			
			// Bonus: You can make color and name changeable
			// using properties in Resource-Class and connect
			// the listeners the same way as for Amount.
			this.ResourceNameChanged.Invoke(resource.name);
			this.ResourceColorChanged.Invoke(this.resource.color);
		}

		void OnOwnedChanged(int value) {
			this.AmountChanged.Invoke(value.ToString());
		}

		public void Produce() {
			this.resource.Produce();
		}
	}
}
