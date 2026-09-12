
using UUP.ScriptableObjects.GameEvents.EventCollections;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.CollectionSequences
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/CollectionSequences/FloatCollectSequence", fileName = "FloatCollectSequence")]
    public sealed class FloatCollectSequence : GenericCollectSequence<FloatEventCollection>, ISequenceable
    {
    }
}
