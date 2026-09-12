
using UUP.ScriptableObjects.GameEvents.EventCollections;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.CollectionSequences
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/CollectionSequences/SpatialOrientationEventCollection", fileName = "SpatialOrientationEventCollection")]
    public sealed class SpatialOrientationCollectionCollectSequence : GenericCollectSequence<SpatialOrientationEventCollection>, ISequenceable
    {
    }
}

