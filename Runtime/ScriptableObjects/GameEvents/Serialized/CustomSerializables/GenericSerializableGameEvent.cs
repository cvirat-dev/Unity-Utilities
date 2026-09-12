using UUP.CustomDataTypes.Serializables;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.Serialized.CustomSerializables
{
    /// <summary>
    /// Generic GameEvent class for custom serializable data.
    /// </summary>
    /// <typeparam name="TListener"></typeparam>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TCustomSerializable"></typeparam>
    /// <remarks>
    /// The custom serializable data type allows to edit the data in the inspector before manually raising the event.
    /// </remarks>
    public class GenericSerializableGameEvent<TListener, TData, TCustomSerializable> : SerializedGameEventBase<TListener, TData> 
        where TListener : GameEventListenerBase1<TData> 
        where TCustomSerializable : IConvertible<TData>
    {
        [SerializeField] TCustomSerializable customSerializable;
        //public List<TListener> listeners = new();

        public override void RaiseWithData()
        {
            Raise(customSerializable.Get());
        }

        public override void Raise(TData value)
        {
            customSerializable.Set(value);
            foreach (var listener in listeners)
            {
                listener.OnEventRaised(customSerializable.Get());
            }
        }
    }
}
