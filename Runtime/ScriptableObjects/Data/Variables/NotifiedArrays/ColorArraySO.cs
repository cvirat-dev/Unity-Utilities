
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables.Arrays
{
    [CreateAssetMenu(menuName = "UUP/Data/Variables/Arrays/ColorArray", fileName = "ColorArray", order = 100)]
    public sealed class ColorArraySO : NotifiedArraySO<ColorVariableSO, Color>
    {
    }
}
