using UnityEngine;
using UUP.ScriptableObjects.GameEvents.Serialized;

namespace UUP.ScriptableObjects.GameEvents.EventCollections
{
    /// <summary>
    /// <typeparam name="TGameEvent">The typed GameEvent</typeparam>
    /// </summary> 
    /// <typeparam name="TGameEvent"></typeparam>
    /// <typeparam name="TListener"></typeparam>
    /// <typeparam name="TData"></typeparam>
    public class GenericCollection<TGameEvent, TListener, TData> : CollectionBase where TGameEvent: SerializedGameEventBase<TListener, TData> where TListener : GameEventListenerBase1<TData>
    {
        public TGameEvent[] TypeGameEvent;

        public override void RaiseAll()
        {
            if (TypeGameEvent == null)
            {
                Debug.LogError($"{nameof(TypeGameEvent)} : missing reference");
                return;
            }

            int i = 0;
            foreach (var gameEvent in TypeGameEvent)
            {
                gameEvent.RaiseWithData();  
                i++;
            }
        }
    }
}