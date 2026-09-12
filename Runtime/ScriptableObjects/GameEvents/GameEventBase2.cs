using System.Collections.Generic;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents
{
    /// <summary>
    /// Base class for Game Events (ScriptableObject-based Event Emitters)
    /// </summary>
    public abstract class GameEventBase2<TListener, TData> : GameEventBase1<TData> where TListener : GameEventListenerBase1<TData>
    {
        protected readonly List<TListener> listeners = new();

        public override void Raise(TData data)
        {
            foreach (var listener in listeners)
            {
                listener.OnEventRaised(data);
            }
        }

        public override void RegisterListener(Component listener)
        {
            if(listener is TListener tListener)
            {
                RegisterListener(tListener);
            }
            else
            {
                Debug.LogError($"Listener of type {listener.GetType()} is not of type {typeof(TListener)}");
            }
        }

        public override void UnregisterListener(Component listener)
        {
            if (listener is TListener tListener)
            {
                UnregisterListener(tListener);
            }
            else
            {
                Debug.LogError($"Listener of type {listener.GetType()} is not of type {typeof(TListener)}");
            }
        }

        public void RegisterListener(TListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void UnregisterListener(TListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}
