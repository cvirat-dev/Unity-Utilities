
using UUP.Components.GameEvents;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.Serialized
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/ColorGameEvent", fileName = "ColorGameEvent")]
    public sealed class ColorGameEvent : SerializedGameEvent<Color, ColorGameEventListener>
    {
    }
}
