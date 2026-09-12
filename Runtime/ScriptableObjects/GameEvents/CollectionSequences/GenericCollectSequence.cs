
using UUP.ScriptableObjects.GameEvents.EventCollections;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.CollectionSequences
{
    /// <summary>
    /// This class holds an array of event collections and raises them in sequence.
    /// </summary>
    /// <typeparam name="T">A GameEvent-Collection</typeparam>
    public class GenericCollectSequence<T> : CollectSequenceBase where T :  ICollectionEvents
    {
        public T[] EventCollection;

        protected override int GetCount()
        {
            return EventCollection.Length;
        }

        public override void Raise()
        {
            if (CurrentIndex < 0 || CurrentIndex >= Length)
            {
                Debug.LogWarning($"{this.name} : Index out of range. Sequence will not proceed further.");
                return;
            }

            EventCollection[CurrentIndex].RaiseAll();
            SequenceEventNotifier.Invoke(CurrentIndex);
            CheckCustomCondition();
        }
    }
}