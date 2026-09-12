using UUP.Components.GameEvents;
using UUP.ScriptableObjects.GameEvents.Serialized;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.EventCollections
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/EventCollections/ColorEventCollection", fileName = "ColorEventCollection")]
    public sealed class ColorEventCollection : GenericCollection<ColorGameEvent, ColorGameEventListener, Color>
    {
    }
}
