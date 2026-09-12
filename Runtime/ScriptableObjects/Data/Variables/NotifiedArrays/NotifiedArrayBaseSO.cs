using UUP.Common.Components;
using UUP.Common.Data.Arrays;
using UUP.Common.Events;
using UUP.CustomAttributes.CustomTargets;
using System;

namespace UUP.ScriptableObjects.Data.Variables.Arrays
{
    /// <summary>
    /// Base class handling core notification functionality.
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <remarks>
    /// For performance reasons, c# events are used instead of UnityEvents.
    /// This has the cost of not being able to see the events in the inspector, but since this is a <see cref="ScriptableObject"/>, it it should not be a problem.
    /// </remarks>
    public abstract class NotifiedArrayBaseSO<TData> : ScriptableObjectT, 
        IListenerBase, 
        INotifiedArray<TData>
    {
        protected bool _isInitialized = false;

        public abstract int Length { get; }
        public abstract TData[] Value { get; }

        public event Action<int, TData> OnNewValue;

        public abstract void Subscribe();
        public abstract void Unsubscribe();
        public abstract void GetAll(TData[] destination);
        public abstract TData GetAt(int index);

        public void OnNewValueHandler(int index, TData data)
        {
            OnNewValue?.Invoke(index, data);
        }

        public abstract void SetAll(TData[] values);
        public abstract void SetAllToSame(TData value);
        public abstract void SetAt(int index, TData value);

        protected void CheckInitState()
        {
            if (!_isInitialized)
            {
                Subscribe();
            }
        }
    }
}
