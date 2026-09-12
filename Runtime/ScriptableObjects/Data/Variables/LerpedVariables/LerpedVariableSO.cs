using UUP.Common.Data.Variables;
using System;
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables.LerpedVariables
{
    public abstract class LerpedVariableSO<TData> : ScriptableObjectTWithComment, ILerpedVariable<TData>
    {
        protected TData _value;

        [SerializeField]
        protected TData minLimit;

        [SerializeField]
        protected TData maxLimit;

        public TData Value 
        { 
            get => _value; 
            set
            {
                _value = value;
                OnValueSet?.Invoke(value);
            } 
        }

        public event Action<TData> OnValueSet;

        public abstract void Lerp(float t);

        public void SetValue(TData val)
        {
            Value = val;
        }
    }
}
