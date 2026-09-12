using UUP.Common.Events;
using UUP.CustomAttributes.CustomTargets;
using UnityEngine;

namespace UUP.Components.GameEvents
{
    public class TGameEventController<TGameEvent, TData> : MonoBehaviourT, 
        ITGameEventController<TData> where TGameEvent : IGameEventBase1<TData>
    {
        [SerializeField]
        protected TGameEvent gameEvent;

        public void Raise(TData data)
        {
            gameEvent.Raise(data);
        }
    }
}
