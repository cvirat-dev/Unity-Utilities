using UUP.Common.Data.Variables;
using UUP.ScriptableObjects.Data.Variables;
using UUP.ScriptableObjects.Data.Variables.Arrays;
using UnityEngine;

namespace UUP.ScriptableObjects.Operations.IndexedArraysHandlers
{
    /// <summary>
    /// This class is used to handle the event management of a TypeArraySO.
    /// Simply put, it is used to get the value of a SO-Variable inside a TypeArraySO and invoke an event which contains the value of the given variable.
    /// </summary>
    /// <typeparam name="TArraySO">The Type of the array</typeparam>
    /// <typeparam name="TVariableSO">The SO-Variable inside <see cref="TArraySO"/> </typeparam>
    /// <typeparam name="TData">The type of the value inside <see cref="TVariableSO"/> ></typeparam>
    public abstract class IndexedArrayEventHandlerSO<TArraySO, TVariableSO, TData> : IndexedArrayEventHandlerBase<TData> 
        where TArraySO : NotifiedArraySO<TVariableSO, TData> where TVariableSO : INotifiedVariable<TData>
    {
        [SerializeField] protected IntVariableSO rowIndex;
        [SerializeField] protected IntVariableSO columnIndex;

        [SerializeField] private TArraySO[] typeArraySO;
        protected TArraySO typeArrayElement;

        public void OnHandleManagerGE(Component sender, object data)
        {
            HandleEventManagement();
        }

        public override void HandleEventManagement()
        {
            if (rowIndex.Value < 0 || columnIndex.Value < 0)
            {
                Debug.LogError("Index is out of bounds");
                return;
            }

            if(rowIndex.Value >= typeArraySO.Length)
            {
                Debug.LogError("Index is out of bounds");
                return;
            }

            if (columnIndex.Value >= typeArraySO[rowIndex.Value].Length)
            {
                Debug.LogError("Index is out of bounds");
                return;
            }

            var selectedVariable = typeArraySO[rowIndex.Value].GetVariableAt(columnIndex.Value);

            var result = selectedVariable.Value;
            InvokeEvent(result);
        }
    }
}