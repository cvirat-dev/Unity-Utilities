using UUP.Common.Data.Arrays;
using UnityEngine;

namespace UUP.Common.Data.Variables.NotifiedArrays
{
    public class NotifiedArrayController<TArray, TVar, TData> : NotifiedArrayControllerBase<TData>
        where TArray : INotifiedArray<TData> 
        where TVar : INotifiedVariable<TData>
    {
        [SerializeField] protected TArray arraySO;

        private void Awake()
        {
            if (arraySO == null)
                throw new System.Exception("ArraySO is null");
        }

        public override int Length => arraySO.Length;

        public override TData[] Value => arraySO.Value;

        public override TData GetAt(int index)
        {
            return arraySO.GetAt(index);
        }

        public override void SetAll(TData[] values)
        {
            arraySO.SetAll(values);
        }

        public override void SetAllToSame(TData value)
        {
            arraySO.SetAllToSame(value);
        }

        public override void SetAt(int index, TData value)
        {
            arraySO.SetAt(index, value);
        }
        
        public override void GetAll(TData[] values)
        {
            arraySO.GetAll(values);
        }

    }
}