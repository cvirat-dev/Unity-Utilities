
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Entries.NotifiedRegisters
{
    [CreateAssetMenu(
        menuName = "UUP/Data/Entries/NotifiedRegisters/TransformRegister", 
        fileName = "TransformRegister", 
        order = -100)]
    public sealed class TransformNotifRegister : NotifiedRegisterSO<TransformEntrySO, Transform>
    {
    }
}
