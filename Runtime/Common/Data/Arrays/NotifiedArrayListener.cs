using UUP.Common.Components;
using UUP.Common.Data.Variables;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace UUP.Common.Data.Arrays
{
    public class NotifiedArrayListener<TArray, TVar, TData> : ListenerBase, IArrayListener<TData>
        where TArray : INotifiedArray<TData>
        where TVar : INotifiedVariable<TData>
    {
        [SerializeField]
        protected TArray arraySO;

        public event Action<int, TData> OnNewValue;
        public UnityEvent<int, TData> OnNewValueEvent;

        public void OnNewValueHandler(int index, TData data)
        {
            OnNewValue?.Invoke(index, data);
            OnNewValueEvent?.Invoke(index, data);
        }

        public override void Subscribe()
        {
            arraySO.OnNewValue += OnNewValueHandler;
        }

        public override void Unsubscribe()
        {
            arraySO.OnNewValue -= OnNewValueHandler;
        }
    }
}
