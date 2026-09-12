using UUP.Components.GameEvents;
using UUP.ScriptableObjects.GameEvents.Serialized;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.EventCollections
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/EventCollections/FloatCollection", fileName = "FloatCollection")]
    public sealed class FloatEventCollection : GenericCollection<FloatGameEvent, FloatGameEventListener, float>
    {
    }
}
