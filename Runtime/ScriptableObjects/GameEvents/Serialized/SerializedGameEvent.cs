using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.Serialized
{
    /// <summary>
    /// Generic Game Event
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TListener"></typeparam>
    public class SerializedGameEvent<TData, TListener> : SerializedGameEventBase<TListener, TData>  where TListener : GameEventListenerBase1<TData>
    {
        [SerializeField] TData data; 
        
        public override void RaiseWithData()
        {
            Raise(data);
        }

        public override void Raise(TData value)
        {
            this.data = value;
            foreach (var listener in listeners)
            {
                listener.OnEventRaised(data);
            }
        }
    }
}
