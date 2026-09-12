
using UUP.ScriptableObjects.GameEvents.EventCollections;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.CollectionSequences
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/CollectionSequences/ColorCollectSequence", fileName = "ColorCollectSequence")]
    public sealed class ColorCollectSequence : GenericCollectSequence<ColorEventCollection>, ISequenceable
    {
    }
}
