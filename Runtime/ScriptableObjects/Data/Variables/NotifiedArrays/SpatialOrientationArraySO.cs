
using UUP.CustomDataTypes.Serializables;
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Variables.Arrays
{
    [CreateAssetMenu(menuName = "UUP/Data/Variables/Arrays/SpatialOrientationArray", fileName = "SpatialOrientationArray", order = 100)]
    public sealed class SpatialOrientationArraySO : NotifiedArraySO<SpatialOrientationVariableSO, SpatialOrientationSRZ>
    {
    }
}
