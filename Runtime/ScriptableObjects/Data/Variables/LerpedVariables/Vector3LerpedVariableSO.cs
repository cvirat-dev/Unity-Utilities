using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables.LerpedVariables
{
    [CreateAssetMenu(menuName = "UUP/Data/Variables/Lerped/Vector3LerpedVariable", fileName = "Vector3LerpedVariable")]
    public class Vector3LerpedVariableSO : LerpedVariableSO<Vector3>
    {
        public override void Lerp(float t)
        {
            // Clamp t to [0, 1]
            t = Mathf.Clamp01(t);
            Value = Vector3.Lerp(minLimit, maxLimit, t);
        }
    }
}
