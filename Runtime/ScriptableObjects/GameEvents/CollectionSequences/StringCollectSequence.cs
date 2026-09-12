
using UUP.ScriptableObjects.GameEvents.EventCollections;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.CollectionSequences
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/CollectionSequences/StringCollectSequence", fileName = "StringCollectSequence")]
    public sealed class StringCollectSequence : GenericCollectSequence<StringEventCollection>, ISequenceable
    {
    }
}