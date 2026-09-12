using UUP.Common.Data.Variables;
using UUP.ScriptableObjects.Data.Variables.Arrays;
using UnityEngine;

namespace UUP.Components.LifeCycle.OnStart.Data.Variables.NotifiedArrays
{
    /// <summary>
    /// This class is used to initialize an array of SO-Variables with a single SO-Variable.
    /// </summary>
    /// <typeparam name="TArraySO"></typeparam>
    /// <typeparam name="TVariableSO"></typeparam>
    public abstract class NotifiedArrayInitializer<TArraySO, TVariableSO, TData> : MonoBehaviour 
        where TArraySO : NotifiedArraySO<TVariableSO, TData> where TVariableSO : INotifiedVariable<TData>
    {
        // SO-Array
        public TArraySO soVariableArray;
        public TVariableSO soVariable;

        // Start is called before the first frame update
        void Start()
        {
            foreach (var item in soVariableArray.SOArray)
            {
                item.SetValue(soVariable.Value);
            }
        }
    }
}