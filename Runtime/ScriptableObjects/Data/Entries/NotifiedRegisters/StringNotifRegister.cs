
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Entries.NotifiedRegisters
{
    [CreateAssetMenu(
        menuName = "UUP/Data/Entries/NotifiedRegisters/StringRegister", 
        fileName = "StringRegister", 
        order = -100)]
    public sealed class StringNotifRegister : NotifiedRegisterSO<StringEntrySO, string>
    {
    }
}