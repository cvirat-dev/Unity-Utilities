using UUP.Components.GameEvents;
using UUP.ScriptableObjects.GameEvents.Serialized;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.EventCollections
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/EventCollections/IntCollection", fileName = "IntCollection")]
    public sealed class IntEventCollection : GenericCollection<IntGameEvent, IntGameEventListener, int>
    {
    }
}