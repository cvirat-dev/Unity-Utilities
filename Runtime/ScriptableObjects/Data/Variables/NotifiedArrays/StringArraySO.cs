
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables.Arrays
{
    [CreateAssetMenu(menuName = "UUP/Data/Variables/Arrays/StringArray", fileName = "StringArray", order = 100)]
    public sealed class StringArraySO : NotifiedArraySO<StringVariableSO, string>
    {
        public void SetAllToValue(string value)
        {
            for (int i = 0; i < soArray.Length; i++)
            {
                soArray[i].SetValue(value);
            }
        }
    }
}
