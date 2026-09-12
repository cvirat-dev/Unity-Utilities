
using UUP.Components.GameEvents;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.Serialized
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/BoolGameEvent", fileName = "BoolGameEvent")]
    public sealed class BoolGameEvent : SerializedGameEvent<bool, BoolGameEventListener>
    {
    }
}

