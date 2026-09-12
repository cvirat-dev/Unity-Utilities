using UUP.ScriptableObjects.Operations.IndexedArraysHandlers;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace UUP.Components.Operations.IndexedArrayEventHandlers
{
    public abstract class IndexedArrayEventController<T1, T2> : MonoBehaviour 
        where T1 : IndexedArrayEventHandlerBase<T2>
    {
        [SerializeField] protected T1 TypeArrayManagerSO;

        // Events as always
        public Action<T2> OnResult;
        public UnityEvent<T2> OnResultEvent;

        private void OnEnable()
        {
            TypeArrayManagerSO.OnResult += OnEventHandler;
        }

        private void OnDisable()
        {
            TypeArrayManagerSO.OnResult -= OnEventHandler;
        }

        public void OnHandleManagerGE(Component sender, object data)
        {
            OnHandleManager();
        }

        public void OnHandleManager()
        {
            TypeArrayManagerSO.HandleEventManagement();
        }

        protected void OnEventHandler(T2 eventData)
        {
            OnResult?.Invoke(eventData);
            OnResultEvent?.Invoke(eventData);
        }
    }
}