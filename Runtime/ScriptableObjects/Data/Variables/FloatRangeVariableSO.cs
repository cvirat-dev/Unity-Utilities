using UUP.Common.Data.Variables;
using System;
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables
{
    [CreateAssetMenu(menuName = "UUP/Data/Variables/FloatRangeVariableSO", fileName = "RangeValueSO", order = 100)]
    public class FloatRangeVariableSO : ScriptableObject, INotifiedVariable<float>
    {
        [SerializeField, Range(0f, 1f)]
        private float inputValue;

        [SerializeField]
        private float maxRange = 1f;

        public event Action<float> OnValueSet;

        public float MaxRange
        {
            get { return maxRange; }
        }

        public float Value
        {
            get { return inputValue * maxRange; }
            set
            {
                inputValue = Mathf.Clamp01(value);
                OnValueSet?.Invoke(inputValue * maxRange);

            }
        }

        private void OnValidate()
        {
            Value = inputValue;
        }

        public void SetValue(float val)
        {
            if (val is float _value)
            {
                Value = _value;
            }
            else
            {
                Debug.LogError($"Tried to set value of type {val.GetType()} to {this.GetType()}");
            }
        }

        public float GetValue()
        {
            return Value;
        }

    }
}