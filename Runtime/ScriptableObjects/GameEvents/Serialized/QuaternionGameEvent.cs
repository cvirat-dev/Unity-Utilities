
using UUP.Components.GameEvents;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.Serialized
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/QuaternionGameEvent", fileName = "QuaternionGameEvent")]
    public sealed class QuaternionGameEvent : SerializedGameEvent<Quaternion, QuaternionEventListener>
    {
    }
}