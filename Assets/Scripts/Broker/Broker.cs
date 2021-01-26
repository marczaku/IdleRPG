using System.Collections.Generic;
using UnityEngine;

namespace Broker {

	public delegate void MessageDelegate(object messageContent);
	
	// keep the interface as simple as possible
	public interface IBroker {
		void SubscribeTo(string messageName, MessageDelegate @delegate);
		void UnsubscribeFrom(string messageName, MessageDelegate @delegate);
		void Publish(string messageName, object messageContent);
	}
	
	public delegate void GoldChangedDelegate(int newGold);

	public interface IMessageDelegate {
		void OnMessage(object messageContent);
	}
	
	public class Broker : MonoBehaviour, IBroker {
		readonly Dictionary<string, MessageDelegate> messageDelegates = new Dictionary<string, MessageDelegate>();
		void Awake() {
			Dependencies.broker = this;
		}

		public void SubscribeTo(string messageName, MessageDelegate messageDelegate) {
			if (this.messageDelegates.ContainsKey(messageName))
				this.messageDelegates[messageName] = this.messageDelegates[messageName] + messageDelegate;
			else
				this.messageDelegates[messageName] = messageDelegate;
		}

		public void UnsubscribeFrom(string messageName, MessageDelegate messageDelegate) {
			this.messageDelegates[messageName] -= messageDelegate;
		}

		public void Publish(string messageName, object messageContent) {
			if (this.messageDelegates.TryGetValue(messageName, out var messageDelegate)) {
				messageDelegate?.Invoke(messageContent);
			}
		}
	}
	// static class managing your "globals" (dependencies)
	public static class Dependencies {
		// to show that you're cool, only use interfaces here
		// this allows you to exchange implementations without
		// anyone noticing
		public static IBroker broker;
	}
}