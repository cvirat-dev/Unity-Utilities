using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using UnityEngine;

namespace UUP.Common.Data.Arrays
{
    /// <summary>
    /// Base class for controllers of notified arrays.
    /// </summary>
    /// <typeparam name="TData">the type of the data in the array</typeparam>
    public abstract class NotifiedArrayControllerBase<TData> : MonoBehaviourT,
        IArrayController<TData>
    {
        public abstract int Length { get; }
        public abstract TData[] Value { get; }
        public abstract TData GetAt(int index);
        public abstract void SetAt(int index, TData value);
        public abstract void SetAll(TData[] values);
        public abstract void GetAll(TData[] destination);
        public abstract void SetAllToSame(TData value);

        [InspectorButton]
        private void DebugAt(int index)
        {
            var value = GetAt(index);
            Debug.Log($"Value at index {index}: {value}");
        }

        [InspectorButton]
        private void DebugAll()
        {
            var values = Value;
            for (int i = 0; i < values.Length; i++)
            {
                Debug.Log($"Value at index {i}: {values[i]}");
            }
        }
    }
}
