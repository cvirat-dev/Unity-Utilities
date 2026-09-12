
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables.Arrays
{
    [CreateAssetMenu(menuName = "UUP/Data/Variables/Arrays/IntArray", fileName = "IntArray", order = 100)]
    public sealed class IntArraySO : NotifiedArraySO<IntVariableSO, int>
    {
        public void SetAllToValue(int value)
        {
            for (int i = 0; i < soArray.Length; i++)
            {
                soArray[i].SetValue(value);
            }
        }

        public void AddToAll(int value)
        {
            for (int i = 0; i < soArray.Length; i++)
            {
                soArray[i].SetValue(soArray[i].Value + value);
            }
        }

        public void SubtractFromAll(int value)
        {
            for (int i = 0; i < soArray.Length; i++)
            {
                soArray[i].SetValue(soArray[i].Value - value);
            }
        }

        public void MultiplyAllBy(int value)
        {
            for (int i = 0; i < soArray.Length; i++)
            {
                soArray[i].SetValue(soArray[i].Value * value);
            }
        }

        public void DivideAllBy(int value)
        {
            for (int i = 0; i < soArray.Length; i++)
            {
                soArray[i].SetValue(soArray[i].Value / value);
            }
        }
    }
}