using UUP.ScriptableObjects.GameEvents.Serialized;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.EventCollections
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/EventCollections/StringCollection", fileName = "StringCollection")]
    public sealed class StringEventCollection : GenericCollection<StringGameEvent, StringGameEventListener, string>
    {
    }
}