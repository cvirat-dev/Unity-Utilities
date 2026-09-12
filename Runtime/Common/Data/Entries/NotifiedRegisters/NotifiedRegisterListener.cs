using UUP.Common.Components;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace UUP.Common.Data.Entries.NotifiedRegisters
{
    public class NotifiedRegisterListener<TNotifRegister, TEntry, TData> : ListenerBase,
        INotifiedRegisterListener<TData>
        where TNotifRegister : INotifiedRegister<TEntry, TData>
        where TEntry : IEntry<TData>
    {
        [SerializeField] protected TNotifRegister registerSO;

        public event Action<int> OnEmptyAt;
        public UnityEvent<int> OnEmptyAtEvent;
        public event Action OnEmptyAll;
        public UnityEvent OnEmptyAllEvent;
        public event Action<int, TData> OnNewValue;
        public UnityEvent<int, TData> OnNewValueEvent;
        public event Action OnAnyChange;
        public UnityEvent OnAnyChangeEvent;

        public void OnEmptyAllHandler()
        {
            OnEmptyAll?.Invoke();
            OnEmptyAllEvent?.Invoke();
        }

        public void OnEmptyAtHandler(int index)
        {
            OnEmptyAt?.Invoke(index);
            OnEmptyAtEvent?.Invoke(index);
        }

        public void OnNewValueHandler(int index, TData data)
        {
            OnNewValue?.Invoke(index, data);
            OnNewValueEvent?.Invoke(index, data);
        }

        public override void Subscribe()
        {
            registerSO.OnEmptyAll += OnEmptyAllHandler;
            registerSO.OnEmptyAt += OnEmptyAtHandler;
            registerSO.OnNewValue += OnNewValueHandler;
            registerSO.OnAnyChange += OnAnyChangeHandler;
        }

        public override void Unsubscribe()
        {
            registerSO.OnEmptyAll -= OnEmptyAllHandler;
            registerSO.OnEmptyAt -= OnEmptyAtHandler;
            registerSO.OnNewValue -= OnNewValueHandler;
            registerSO.OnAnyChange -= OnAnyChangeHandler;
        }

        public void OnAnyChangeHandler()
        {
            OnAnyChange?.Invoke();
            OnAnyChangeEvent?.Invoke();
        }
    }
}
