using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Observer;

namespace Observer
{
    public class EventsManager
    {
        public static EventsManager Instance
        {
            get
            {
                //Lazy singleton
                if (instance == null)
                {
                    instance = new EventsManager();
                    
                }
                return instance;
            }
        }

        private static EventsManager instance;

        private Dictionary<string, List<IListener>> simpleEvents = new();
        private List<IListener> listeners;

        public void AddListener(string eventID, IListener p_listener)
        {
            if(simpleEvents.TryGetValue(eventID, out listeners))
            {
                if (!listeners.Contains(p_listener))
                {
                    listeners.Add(p_listener);
                }
            }
           
        }

        public void RemoveListener(string eventID, IListener p_listener)
        {

            if (simpleEvents.TryGetValue(eventID, out listeners))
            {
                if (!listeners.Contains(p_listener))
                {
                    listeners.Remove(p_listener);
                }
            }
        }

        public void DispatchSimpleEvents(string eventID)
        {
            if (simpleEvents.TryGetValue(eventID, out var listeners))
            {
               for(int i = listeners.Count -1; i >= 0; i--)
                {
                    listeners[i].OnEventDispatch();
                }
            }
        }

        public void RegisterEvent(string eventID)
        {
            simpleEvents.TryAdd(eventID, new List<IListener>());
        }
    }
}


