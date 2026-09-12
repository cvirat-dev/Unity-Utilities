using UUP.Components.GameEvents;
using UUP.CustomAttributes;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UUP.ScriptableObjects.GameEvents
{
    /// <summary>
    /// An empty GameEvent without any data.
    /// </summary>
    [CreateAssetMenu(menuName = "UUP/EventSystem/GameEvent", fileName = "GameEvent", order = -100)]
    public class GameEvent : GameEventBase0
    {
        private readonly List<GameEventListener> listeners = new();
        
        public event Action OnEventRaised;

        [InspectorButton]
        public void Raise()
        {
            OnEventRaised?.Invoke();
            foreach (var listener in listeners)
            {
                listener.OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}
