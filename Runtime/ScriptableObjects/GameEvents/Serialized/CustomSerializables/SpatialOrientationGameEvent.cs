
using UUP.CustomDataTypes;
using UUP.CustomDataTypes.Serializables;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.Serialized.CustomSerializables
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/SpatialOrientationGameEvent", fileName = "SpatialOrientationGameEvent")]
    public sealed class SpatialOrientationGameEvent : GenericSerializableGameEvent<SpatialOrientationGameEventListener, SpatialOrientation,  SpatialOrientationSRZ>
    {
    }
}

