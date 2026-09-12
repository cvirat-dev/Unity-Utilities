using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables.LerpedVariables
{
    [CreateAssetMenu(menuName = "UUP/Data/Variables/Lerped/IntLerpedVariable", fileName = "IntLerpedVariable")]
    public class IntLerpedVariableSO : LerpedVariableSO<int>
    {
        public override void Lerp(float t)
        {
            // Clamp t to [0, 1]
            t = Mathf.Clamp01(t);
            Value = (int)(minLimit + (maxLimit - minLimit) * t);
        }
    }
}
