using UUP.ScriptableObjects.GameEvents;
using UUP.ScriptableObjects.GameEvents.NonSerialized;
using UnityEngine.Events;

namespace UUP.Components.GameEvents
{
    public class DataGameEventListener : GameEventListenerBase1<object>
    {
        public DataGameEvent GameEvent;
        public UnityEvent<object> response; 

        private void OnEnable()
        {
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            GameEvent.UnregisterListener(this);
        }

        public override void OnEventRaised(object data)
        {
            response.Invoke(data);
        }

        public override GameEventBase0 GetGameEvent()
        {
            return GameEvent;
        }
    }
}

