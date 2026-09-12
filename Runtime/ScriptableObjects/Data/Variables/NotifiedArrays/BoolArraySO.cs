
using System;
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables.Arrays
{
    [CreateAssetMenu(menuName = "UUP/Data/Variables/Arrays/BoolArray", fileName = "BoolArray", order =100)]
    public sealed class BoolArraySO : NotifiedArraySO<BoolVariableSO, bool>
    {
        public void SetAllToFalse()
        {
            foreach (var item in soArray)
            {
                item.SetValue(false);
            }
        }
        
        public void SetAllToTrue()
        {
            foreach (var item in soArray)
            {
                item.SetValue(true);
            }
        }

        public void SetSingleTrueAtIndex(int index)
        {
            for (int i = 0; i < soArray.Length; i++)
            {
                soArray[i].SetValue(i == index);
            }
        }

        public void SetSingleFalseAtIndex(int index)
        {
            for (int i = 0; i < soArray.Length; i++)
            {
                soArray[i].SetValue(i != index);
            }
        }
    }
}
