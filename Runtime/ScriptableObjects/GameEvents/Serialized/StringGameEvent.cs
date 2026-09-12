
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.Serialized
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/StringGameEvent", fileName = "StringGameEvent")]
    public sealed class StringGameEvent : SerializedGameEvent<string, StringGameEventListener>
    {
    }
}
