
using UUP.Components.GameEvents;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.Serialized
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/FloatGameEvent", fileName = "FloatGameEvent")]
    public sealed class FloatGameEvent : SerializedGameEvent<float, FloatGameEventListener>
    {
    }
}