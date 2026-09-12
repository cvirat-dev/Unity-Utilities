
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables.Arrays
{
    [CreateAssetMenu(menuName = "UUP/Data/Variables/Arrays/FloatArray", fileName = "FloatArray", order = 100)]
    public sealed class FloatArraySO : NotifiedArraySO<FloatVariableSO, float>
    {
        public void SetAllToValue(float value)
        {
            for (int i = 0; i < soArray.Length; i++)
            {
                soArray[i].SetValue(value);
            }
        }

        public void AddToAll(float value)
        {
            for (int i = 0; i < soArray.Length; i++)
            {
                soArray[i].SetValue(soArray[i].Value + value);
            }
        }

        public void SubtractFromAll(float value)
        {
            for (int i = 0; i < soArray.Length; i++)
            {
                soArray[i].SetValue(soArray[i].Value - value);
            }
        }

        public void MultiplyAllBy(float value)
        {
            for (int i = 0; i < soArray.Length; i++)
            {
                soArray[i].SetValue(soArray[i].Value * value);
            }
        }

        public void DivideAllBy(float value)
        {
            for (int i = 0; i < soArray.Length; i++)
            {
                soArray[i].SetValue(soArray[i].Value / value);
            }
        }

    }
}
