using UUP.Components.GameEvents;
using UUP.ScriptableObjects.GameEvents.Serialized;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.EventCollections
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/EventCollections/BoolCollection", fileName = "BoolCollection")]
    public sealed class BoolEventCollection : GenericCollection<BoolGameEvent, BoolGameEventListener, bool>
    {
    }
}