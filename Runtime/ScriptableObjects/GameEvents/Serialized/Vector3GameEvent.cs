
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.Serialized
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/Vector3GameEvent", fileName = "Vector3GameEvent")]
    public sealed class Vector3GameEvent : SerializedGameEvent<Vector3, Vector3GameEventListener>
    {
    }
}