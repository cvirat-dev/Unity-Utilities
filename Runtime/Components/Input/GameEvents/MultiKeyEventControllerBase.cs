using UUP.ScriptableObjects.GameEvents;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.Components.Input.GameEvents
{
    public abstract class MultiKeyEventControllerBase<TGE> : MonoBehaviour
    {
        public List<KeyCode> InputKeys = new();
        public List<TGE> GameEvents = new();

        public static string NameOfKeyProp => nameof(InputKeys);
        public static string NameOfGameEventProp => nameof(GameEvents);


        void Update()
        {
            EventTriggerProcessor();
        }

        protected abstract void EventTriggerProcessor();
    }
}
