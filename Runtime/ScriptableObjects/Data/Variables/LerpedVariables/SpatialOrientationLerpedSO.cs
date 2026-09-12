using UUP.CustomDataTypes.Serializables;
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables.LerpedVariables
{
    [CreateAssetMenu(menuName = "UUP/Data/Variables/Lerped/SpatialOrientationLerpedVariable", fileName = "SpatialOrientationLerpedVariable")]
    public class SpatialOrientationLerpedVariableSO : LerpedVariableSO<SpatialOrientationSRZ>
    {
        public override void Lerp(float t)
        {
            // Clamp t to [0, 1]
            t = Mathf.Clamp01(t);

            Vector3 pos = Vector3.Lerp(minLimit.Get().Position, maxLimit.Get().Position, t);
            Vector3 rot = Quaternion.Slerp(minLimit.Get().Rotation, maxLimit.Get().Rotation, t).eulerAngles;

            Value = new SpatialOrientationSRZ(pos, rot);
        }
    }
}
