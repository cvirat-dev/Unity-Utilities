using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables.LerpedVariables
{
    [CreateAssetMenu(menuName = "UUP/Data/Variables/Lerped/ColorLerpedVariable", fileName = "ColorLerpedVariable")]
    public class ColorLerpedVariableSO : LerpedVariableSO<Color>
    {
        public override void Lerp(float t)
        {
            // Clamp t to [0, 1]
            t = Mathf.Clamp01(t);
            Value = Color.Lerp(minLimit, maxLimit, t);
        }
    }
}
