using UUP.ScriptableObjects.GameEvents;
using UnityEngine;
using UnityEngine.Events;

namespace UUP.Components.GameEvents
{
    public class GameEventListener : GameEventListenerBase0
    {
        [SerializeField] GameEvent GameEvent;
        public UnityEvent Response;

        private void OnEnable()
        {
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            GameEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }

        public override GameEventBase0 GetGameEvent()
        {
            return GameEvent;
        }
    }
}
