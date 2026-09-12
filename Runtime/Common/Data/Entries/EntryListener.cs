using UnityEngine;
using UnityEngine.Events;

namespace UUP.Common.Data.Entries
{
    public class EntryListener<TEntry, TData> : MonoBehaviour where TEntry : IEntry<TData> where TData : class
    {
        [SerializeField]
        TEntry Entry;

        public UnityEvent<TData> OnNewValueSetEvent;
        public UnityEvent<bool> OnStateChangedEvent;
        public UnityEvent<int> OnIDChangedEvent;

        private void OnEnable()
        {
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            Entry.OnValueSet += (data) => OnNewValueSetEvent.Invoke(data);
            Entry.OnStateChanged += (state) => OnStateChangedEvent.Invoke(state);
            Entry.OnIDChanged += (id) => OnIDChangedEvent.Invoke(id);
        }

        private void OnDisable()
        {
            UnregisterEvents();
        }

        private void UnregisterEvents()
        {
            Entry.OnValueSet -= (data) => OnNewValueSetEvent.Invoke(data);
            Entry.OnStateChanged -= (state) => OnStateChangedEvent.Invoke(state);
            Entry.OnIDChanged -= (id) => OnIDChangedEvent.Invoke(id);
        }

        private void OnDestroy()
        {
            UnregisterEvents();
        }
    }
}
