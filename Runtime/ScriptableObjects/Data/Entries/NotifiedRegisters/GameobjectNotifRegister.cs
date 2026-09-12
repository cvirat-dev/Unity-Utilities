
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Entries.NotifiedRegisters
{
    [CreateAssetMenu(
        menuName = "UUP/Data/Entries/NotifiedRegisters/GameobjectRegister", 
        fileName = "GameobjectRegister", 
        order = -100)]
    public sealed class GameobjectNotifRegister : NotifiedRegisterSO<GameobjectEntrySO, GameObject>
    {
    }
}
