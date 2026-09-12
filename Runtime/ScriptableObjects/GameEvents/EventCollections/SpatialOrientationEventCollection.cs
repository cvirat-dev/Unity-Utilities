using UUP.CustomDataTypes;
using UUP.ScriptableObjects.GameEvents.Serialized.CustomSerializables;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.EventCollections
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/EventCollections/SpatialOrientationCollection", fileName = "SpatialOrientationCollection")]
    public sealed class SpatialOrientationEventCollection : GenericCollection<SpatialOrientationGameEvent, SpatialOrientationGameEventListener, SpatialOrientation>
    {
    }
}
