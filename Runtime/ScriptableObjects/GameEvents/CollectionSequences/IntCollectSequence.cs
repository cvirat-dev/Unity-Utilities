
using UUP.ScriptableObjects.GameEvents.EventCollections;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.CollectionSequences
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/CollectionSequences/IntCollectSequence", fileName = "IntCollectSequence")]
    public sealed class IntCollectSequence : GenericCollectSequence<IntEventCollection>, ISequenceable
    {
    }
}