using UUP.Common.Components;
using UUP.Debugging;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace UUP.Common.Data.ObservableLists
{
    public class ObservableListSOListener<TList, TData> : ListenerBase,
        IObservableListListener<TData>
        where TList : IObservableList<TData>
    {

        [SerializeField]
        TList observableListSO;

        public event Action<int, TData> OnItemAdded;
        public UnityEvent<int, TData> OnItemAddedEvent;
        public event Action<int, TData> OnItemModified;
        public UnityEvent<int, TData> OnItemModifiedEvent;
        public event Action<int, TData> OnItemRemoved;
        public UnityEvent<int, TData> OnItemRemovedEvent;
        public event Action<int, int, TData> OnItemMoved;
        public UnityEvent<int, int, TData> OnItemMovedEvent;
        public event Action OnCleared;
        public UnityEvent OnClearedEvent;
        public event Action OnListChanged;
        public UnityEvent OnListChangedEvent;
        public event Action<string> OnError;
        public UnityEvent<string> OnErrorEvent;

        public override void Subscribe()
        {
            observableListSO.OnItemAdded += (index, item) =>
            {
                OnItemAdded?.Invoke(index, item);
                OnItemAddedEvent?.Invoke(index, item);
            };
            observableListSO.OnItemModified += (index, item) =>
            {
                OnItemModified?.Invoke(index, item);
                OnItemModifiedEvent?.Invoke(index, item);
            };
            observableListSO.OnItemRemoved += (index, item) =>
            {
                OnItemRemoved?.Invoke(index, item);
                OnItemRemovedEvent?.Invoke(index, item);
            };
            observableListSO.OnItemMoved += (oldIndex, newIndex, item) =>
            {
                OnItemMoved?.Invoke(oldIndex, newIndex, item);
                OnItemMovedEvent?.Invoke(oldIndex, newIndex, item);
            };
            observableListSO.OnCleared += () =>
            {
                OnCleared?.Invoke();
                OnClearedEvent?.Invoke();
            };
            observableListSO.OnListChanged += () =>
            {
                OnListChanged?.Invoke();
                OnListChangedEvent?.Invoke();
            };
            observableListSO.OnError += (error) =>
            {
                OnError?.Invoke(error);
                OnErrorEvent?.Invoke(error);
            };

        }

        public override void Unsubscribe()
        {
            observableListSO.OnItemAdded -= (index, item) =>
            {
                OnItemAdded?.Invoke(index, item);
                OnItemAddedEvent?.Invoke(index, item);
            };
            observableListSO.OnItemModified -= (index, item) =>
            {
                OnItemModified?.Invoke(index, item);
                OnItemModifiedEvent?.Invoke(index, item);
            };
            observableListSO.OnItemRemoved -= (index, item) =>
            {
                OnItemRemoved?.Invoke(index, item);
                OnItemRemovedEvent?.Invoke(index, item);
            };
            observableListSO.OnItemMoved -= (oldIndex, newIndex, item) =>
            {
                OnItemMoved?.Invoke(oldIndex, newIndex, item);
                OnItemMovedEvent?.Invoke(oldIndex, newIndex, item);
            };
            observableListSO.OnCleared -= () =>
            {
                OnCleared?.Invoke();
                OnClearedEvent?.Invoke();
            };
            observableListSO.OnListChanged -= () =>
            {
                OnListChanged?.Invoke();
                OnListChangedEvent?.Invoke();
            };
            observableListSO.OnError -= (error) =>
            {
                OnError?.Invoke(error);
                OnErrorEvent?.Invoke(error);
            };
        }
    }
}
