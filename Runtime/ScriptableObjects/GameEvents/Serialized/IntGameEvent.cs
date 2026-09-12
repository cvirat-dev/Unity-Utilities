
using UUP.Components.GameEvents;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.Serialized
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/IntGameEvent", fileName = "IntGameEvent")]
    public sealed class IntGameEvent : SerializedGameEvent<int, IntGameEventListener>
    {
    }
}
