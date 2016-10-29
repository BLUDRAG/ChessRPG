using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Gamify
{

	/// <summary>
	/// A lightweight event processing manager.
	/// 
	/// The main purpose of this manager is 
	/// to send data between classes for any
	/// event of interest.
	/// 
	/// Data can be sent in any form. Utilizing
	/// a Hashtable allows for any number of
	/// data to be sent between classes.
	/// </summary>
	public class EventManager
	{

		/// <summary>
		/// Contains a persistent list of all events registered to the EventManager.
		/// 
		/// Only one event per subscriber is allowed in order to
		/// maintain clean event handling.
		/// </summary>
		private static Dictionary<string, Action<object>> events = new Dictionary<string, Action<object>>();

		/// <summary>
		/// Subscribes the event to the EventManager.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="eventCallback">Event callback.</param>
		public static void SubscribeEvent(string eventType, Action<object> eventCallback)
		{
			// Only subscribe the event to the EventManager if it has not been subscribed yet
			if (!events.ContainsKey(eventType))
			{
				events.Add(eventType, eventCallback);
			} else
			{
				Debug.LogWarning(string.Format("Subscriber for {0} already exists.", eventType));
			}
		}

		/// <summary>
		/// Unsubscribes the event from the EventManager.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		public static void UnsubscribeEvent(string eventType)
		{
			if (events.ContainsKey(eventType))
			{
				events.Remove(eventType);
			}
		}

		/// <summary>
		/// Clears all events from the EventManager.
		/// </summary>
		public static void ClearAllEvents()
		{
			events.Clear();
		}

		/// <summary>
		/// Invokes the specified event with the given input data.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="input">Input.</param>
		public static void Invoke(string eventType, object input)
		{
			if (events.ContainsKey(eventType))
			{
				events[eventType].Invoke(input);
			}
		}
	}

}
