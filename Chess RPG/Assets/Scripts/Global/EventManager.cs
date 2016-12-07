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
	public class EventManager<T>
	{

		/// <summary>
		/// Contains a persistent list of all events registered to the EventManager.
		/// </summary>
		private static Dictionary<string, List<Action<T>>> events = new Dictionary<string, List<Action<T>>>();
        private static Dictionary<string, List<Action>> voidEvents = new Dictionary<string, List<Action>>();

		/// <summary>
		/// Subscribes the event to the EventManager.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="eventCallback">Event callback.</param>
		public static void SubscribeEvent(string eventType, Action<T> eventCallback)
		{
			// Only subscribe the event to the EventManager if it has not been subscribed yet
			if (!events.ContainsKey(eventType))
			{
                List<Action<T>> newEvents = new List<Action<T>>();
                newEvents.Add(eventCallback);
                events.Add(eventType, newEvents);
			} 
            else
			{
                events[eventType].Add(eventCallback);
			}
		}

        /// <summary>
        /// Override for subscribing void events.
        /// </summary>
        /// <param name="eventType">Event type.</param>
        /// <param name="eventCallback">Event callback.</param>
        public static void SubscribeEvent(string eventType, Action eventCallback)
        {
            // Only subscribe the event to the EventManager if it has not been subscribed yet
            if (!voidEvents.ContainsKey(eventType))
            {
                List<Action> newEvents = new List<Action>();
                newEvents.Add(eventCallback);
                voidEvents.Add(eventType, newEvents);
            } else
            {
                voidEvents[eventType].Add(eventCallback);
            }
        }

		/// <summary>
		/// Unsubscribes the event from the EventManager.
		/// </summary>
		/// <param name="eventType">Event type.</param>
        /// <param name="eventCallback">Event callback.</param>
        public static void UnsubscribeEvent(string eventType, Action<T> eventCallback)
		{
            if (events.ContainsKey(eventType))
            {
                events[eventType].Remove(eventCallback);

                if (events[eventType].Count == 0)
                {
                    events.Remove(eventType);
                }
            }
		}

        /// <summary>
        /// Override for unsubscribing void events.
        /// </summary>
        /// <param name="eventType">Event type.</param>
        /// <param name="eventCallback">Event callback.</param>
        public static void UnsubscribeEvent(string eventType, Action eventCallback)
        {
            if (voidEvents.ContainsKey(eventType))
            {
                voidEvents[eventType].Remove(eventCallback);

                if (voidEvents[eventType].Count == 0)
                {
                    voidEvents.Remove(eventType);
                }
            }
        }

		/// <summary>
		/// Clears all events from the EventManager.
		/// </summary>
		public static void ClearAllEvents()
		{
			events.Clear();
            voidEvents.Clear();
		}

		/// <summary>
		/// Invokes the specified event with the given input data.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="input">Input.</param>
		public static void Invoke(string eventType, T input)
		{
			if (events.ContainsKey(eventType))
			{
                for (int e = 0; e < events[eventType].Count; e++)
                {
                    (events[eventType])[e].Invoke(input);
                }
			}
		}

        /// <summary>
        /// Override event call with no input data.
        /// </summary>
        /// <param name="eventType">Event type.</param>
        public static void Invoke(string eventType)
        {
            if (voidEvents.ContainsKey(eventType))
            {
                for (int e = 0; e < voidEvents[eventType].Count; e++)
                {
                    (voidEvents[eventType])[e].Invoke();
                }
            }
        }
	}
}
