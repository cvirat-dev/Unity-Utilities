using UUP.Debugging;
using UUP.CustomAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;
using UUP.CustomAttributes.CustomTargets;
using UUP.Common.Data.ObservableLists;

namespace UUP.ScriptableObjects.Data.ObervableLists
{
    public class OberservableListSO<T> : ScriptableObjectT, IObservableList<T>, IDebuggable
    {
        private List<T> _itemList = new List<T>();

        [SerializeField] bool debugStateAllItems = false;

        public int Count => _itemList.Count;

        public List<T> Value => _itemList;

        public event Action<int, T> OnItemAdded;
        public event Action<int, T> OnItemModified;
        public event Action<int, T> OnItemRemoved;
        public event Action<int, int, T> OnItemMoved;
        public event Action OnCleared;
        public event Action OnListChanged;
        public event Action<string> OnError;
        public void Add(T item)
        {
            if (item == null)
            {
                OnError?.Invoke("Item is null");
                return;
            }

            _itemList.Add(item);

            var index = IndexOf(item);
            OnItemAdded?.Invoke(index, item);
            OnListChanged?.Invoke();
        }

        public void Clear()
        {
            _itemList.Clear();

            OnCleared?.Invoke();
            OnListChanged?.Invoke();
        }

        public bool Contains(T item)
        {
            return _itemList.Contains(item);
        }

        [InspectorButton]
        public void DebugState()
        {
            // Info1 : List count;
            string debugMessage1 = $"List count: {_itemList.Count}";
            Debug.Log(debugMessage1);

            if (!debugStateAllItems)
            {
                return;
            }

            foreach (var item in _itemList)
            {
                //item.DebugState();
                Debug.Log(item.ToString());
            }
        }

        public T GetAt(int index)
        {
            if (index < 0 || index >= _itemList.Count)
            {
                OnError?.Invoke("Index out of range");
                return default;
            }

            return _itemList[index];
        }

        public int IndexOf(T item)
        {
            if (_itemList.Contains(item))
            {
                return _itemList.IndexOf(item);
            }
            else
            {
                OnError?.Invoke("Item not found");
                return -1;
            }
        }

        public void ModifyItem(int index, T item)
        {
            if (index < 0 || index >= _itemList.Count)
            {
                OnError?.Invoke("Index out of range");
                return;
            }

            _itemList[index] = item;

            OnItemModified?.Invoke(index, item);
        }

        public void MoveItem(int oldIndex, int newIndex)
        {
            if (oldIndex < 0 || oldIndex >= _itemList.Count)
            {
                OnError?.Invoke("Index out of range");
                return;
            }

            if (newIndex < 0 || newIndex >= _itemList.Count)
            {
                OnError?.Invoke("Index out of range");
                return;
            }

            var item = _itemList[oldIndex];
            _itemList.RemoveAt(oldIndex);
            _itemList.Insert(newIndex, item);

            OnItemMoved?.Invoke(oldIndex, newIndex, item);
            OnListChanged?.Invoke();
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _itemList.Count)
            {
                OnError?.Invoke("Index out of range");
                return;
            }

            var item = _itemList[index];
            _itemList.RemoveAt(index);

            OnItemRemoved?.Invoke(index, item);
            OnListChanged?.Invoke();
        }

        public void Set(List<T> items)
        {
            Clear();

            foreach (var item in items)
            {
                Add(item);
            }
        }
    }

}