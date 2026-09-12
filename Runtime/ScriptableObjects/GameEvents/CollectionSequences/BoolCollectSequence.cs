
using UUP.ScriptableObjects.GameEvents.EventCollections;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.CollectionSequences
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/CollectionSequences/BoolCollectSequence", fileName = "BoolCollectSequence")]
    public sealed class BoolCollectSequence : GenericCollectSequence<BoolEventCollection>, ISequenceable
    {
    }
}
