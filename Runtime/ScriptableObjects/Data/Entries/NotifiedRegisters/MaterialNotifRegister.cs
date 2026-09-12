
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Entries.NotifiedRegisters
{
    [CreateAssetMenu(
        menuName = "UUP/Data/Entries/NotifiedRegisters/MaterialRegister", 
        fileName = "MaterialRegister", 
        order = -100)]
    public sealed class MaterialNotifRegister : NotifiedRegisterSO<MaterialEntrySO, Material>
    {
    }
}
