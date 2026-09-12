using UUP.Common.Data.Variables;
using System;
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables
{
    /// <summary>
    /// ScriptableObject Variable Concept:
    /// - A scriptable object-based variable that can be set and retrieved with a value of type T.
    /// - Designed to hold serialized data that lives between the game sessions.
    /// - Implements the Obeserver pattern to notify listeners when the value changes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class VariableSO<T> : ScriptableObjectTWithComment, INotifiedVariable<T>
    {
        [Header("Value")]
        [SerializeField] private T _value = default;

        public event Action<T> OnValueSet; // For references types, this event will be called when the value is set to a new reference

        public T Value 
        {
            get { return _value; }
            set
            {
                this._value = value;
                OnValueSet?.Invoke(value);
            }
        }

        public void SetValue(T val)
        {
            Value = val;
        }

        public T GetValue()
        {
            return Value;
        }

        private void OnValidate()
        {
            Value = _value;
        }

    }
}