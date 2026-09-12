
using UUP.CustomDataTypes;
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Entries.NotifiedRegisters
{
    [CreateAssetMenu(
        menuName = "UUP/Data/Entries/NotifiedRegisters/SpatialOrientationRegister", 
        fileName = "SpatialOrientationRegister", 
        order = -100)]
    public sealed class SpatialOrientationNotifRegister : NotifiedRegisterSO<SpatialOrientationEntrySO, SpatialOrientation>
    {
    }
}