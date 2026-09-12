using UUP.Common.Data.Entries;
using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using System;
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Entries
{
    /// <summary>
    /// Extension of a ScriptableObject based Variable:
    /// - Contains a value of type T that can be set at runtime
    /// - Contains an ID that can be set at runtime
    /// - Has a boolean state to check if the value is defined (not null)
    /// - Implements the Observer pattern to notify listeners when the value or registration status changes
    /// </summary>
    /// <typeparam name="TData">The type of the entry's value. Must be a reference type</typeparam>
    public abstract class EntrySO<TData> : ScriptableObjectT, IEntry<TData> where TData : class
    {
        private TData _value; // Not serialized to prevent direct access which would bypass the OnValueChanged event and break the Observer pattern
        private int _id = -1; // The default ID of the entry (in case it is used inside a register)
        public event Action<TData> OnValueSet;
        public event Action<int> OnIDChanged;
        public event Action<bool> OnStateChanged;

        public TData Value
        {
            get 
            {
                return _value;
            }
            set
            {
                var wasDefined = IsDefined;

                if (!object.Equals(_value, value))
                {
                    this._value = value;
                    OnValueSet?.Invoke(value);
                }

                if (wasDefined != IsDefined)
                {
                    OnStateChanged?.Invoke(IsDefined);
                }

            }
        }

        public int ID
        {
            get => _id;
            set
            {
                var oldId = _id;
                if(oldId != value)
                {
                    _id = value;
                    OnIDChanged?.Invoke(value);
                }
            }
        }

        /// <summary>
        /// A flag to check if the value of this "entry" is defined
        /// </summary>
        public bool IsDefined => _value != null;

        public void SetValue(TData val)
        {
            Value = val;
        }

        [InspectorButton]
        public void Empty()
        {
            Value = null;
        }

        [InspectorButton]
        public abstract void DebugValueContent();

        [InspectorButton]
        public void DebugState()
        {
            // Debug the state of the variable: name, value, isDefined
            Debug.Log($"Name: {name}, IsRegistered: {IsDefined}");
            DebugValueContent();
        }

        public void ResetID()
        {
            ID = -1;
        }
    }
}