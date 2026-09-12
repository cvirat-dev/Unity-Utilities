using UUP.Common.Data.Arrays;
using UUP.Common.Data.Variables;
using UUP.CustomAttributes;
using UUP.Debugging;
using UUP.Utilities.Collections;
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables.Arrays
{
    /// <summary>
    /// ScriptableObject that holds an array of SO-based variables and notifies when any of them change.
    /// As for SO-Variables, two main events are raised:
    /// - <see cref="OnNewValue"/>: Raised when a variable in the array changes (careful with reference types!)
    /// - <see cref="OnValueSet"/>: Raised when a variable in the array is set
    /// Important note: Due to the nature of SO-Variable which are implementing the observer pattern,
    /// The events here are raised when the variable in the array changes, not when the array itself changes.
    /// This works by a Subscription/Unsubscription mechanism that is handled by the <see cref="AttachListeners"/> and <see cref="DetachListeners"/> methods.
    /// </summary>
    /// <typeparam name="TVariable">A SO-based variable</typeparam>
    /// <typeparam name="TData">The data type of the variable</typeparam>
    public class NotifiedArraySO<TVariable, TData> : NotifiedArrayBaseSO<TData>, 
        IArrayChangeNotification<TData>,
        IDebuggable 
        where TVariable : INotifiedVariable<TData>
    {
        private EventAttachmentManager<TVariable, TData> _attachementManager;

        [SerializeField] protected TVariable[] soArray;

        public TVariable[] SOArray => soArray;
        public override int Length => soArray.Length;
        public override TData[] Value => GetAllValues();
        public TVariable GetVariableAt(int index)
        {
            CheckInitState();

            return soArray[index];
        }

        public override TData GetAt(int index)
        {
            CheckInitState();
            CollectionUtilities.CheckIndexRange(soArray, index, nameof(GetAt));
            return soArray[index].Value;
        }

        public override void SetAt(int index, TData value)
        {
            CheckInitState();
            CollectionUtilities.CheckIndexRange(soArray, index, nameof(SetAt));
            soArray[index].SetValue(value);
        }

        public override void SetAll(TData[] newValues)
        {
            CheckInitState();

            if (newValues.Length != soArray.Length)
            {
                Debug.LogWarning("Array length does not match. Will return default value");
                return;
            }

            int counter = 0;
            foreach (var soVariable in soArray)
            {
                soVariable.SetValue(newValues[counter]);
            }
        }

        public override void SetAllToSame(TData value)
        {
            CheckInitState();

            foreach (var soVariable in soArray)
            {
                soVariable.SetValue(value);
            }
        }

        public override void GetAll(TData[] values)
        {
            CheckInitState();
            if(values.Length != soArray.Length)
                throw new System.ArgumentException("The length of the given array does not match the length of the SOArray");

            for (int i = 0; i < soArray.Length; i++)
            {
                values[i] = soArray[i].Value;
            }
        }

        private TData[] GetAllValues()
        {
            CheckInitState();

            TData[] values = new TData[soArray.Length];

            for (int i = 0; i < soArray.Length; i++)
            {
                values[i] = soArray[i].Value;
            }

            return values;
        }

        /// <summary>
        /// Manage the subscription of the listeners to the events of the SO-Variables in the array.
        /// Should happen at runtime, when the array is initialized.
        /// </summary>
        public override void Subscribe()
        {
            if(soArray.Length == 0)
            {
                Debug.LogWarning("ArraySO is empty. Skipping initialization");
                return;
            }

            _attachementManager ??= new EventAttachmentManager<TVariable, TData>(this, soArray);
            _attachementManager.AttachHandlers(OnNewValueHandler);
            _isInitialized = true;
        }

        /// <summary>
        /// Manage the unsubscription of the listeners to the events of the SO-Variables in the array.
        /// </summary>
        public override void Unsubscribe()
        {
            _attachementManager ??= new EventAttachmentManager<TVariable, TData>(this, soArray);
            _attachementManager.DetachHandlers();
            _attachementManager = null; // Help GC
            _isInitialized = false;
        }

        [InspectorButton]
        public void DebugState()
        {
            Debug.Log($"ArraySO: {this.name} has {soArray.Length} elements");
            Debug.Log($"ArraySO: {this.name} is initialized: {_isInitialized}");
            if( _isInitialized)
            {
                Debug.Log(_attachementManager.GetAttachementInformations());
            }

        }
    }
}
