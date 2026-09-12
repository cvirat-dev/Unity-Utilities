using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables.LerpedVariables
{
    [CreateAssetMenu(menuName = "UUP/Data/Variables/Lerped/FloatLerpedVariable", fileName = "FloatLerpedVariable")]
    public class FloatLerpedVariableSO : LerpedVariableSO<float>
    {
        public override void Lerp(float t)
        {
            // Clamp t to [0, 1]
            t = Mathf.Clamp01(t);
            Value = minLimit + (maxLimit - minLimit) * t;
        }
    }
}