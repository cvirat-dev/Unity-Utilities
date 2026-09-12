using UUP.ScriptableObjects.GameEvents;
using UnityEngine;
using UnityEngine.Events;

namespace UUP.Components.GameEvents
{
    public class SerializedEventListener<TGameEvent, TData> : GameEventListenerBase1<TData> where TGameEvent : GameEventBase1<TData>
    {
        [SerializeField] TGameEvent GameEvent;
        public UnityEvent<TData> Response;

        private void OnEnable()
        {
            if (GameEvent == null)
            {
                Debug.LogError("Game Event is not assigned");
                return;
            }

            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (GameEvent == null)
            {
                Debug.LogError("Game Event is not assigned");
                return;
            }

            GameEvent.UnregisterListener(this);
        }

        public override void OnEventRaised(TData data)
        {
            Response.Invoke(data);
        }

        public override GameEventBase0 GetGameEvent()
        {
            return GameEvent;
        }
    }
}
