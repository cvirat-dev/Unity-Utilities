
using System;
using UnityEngine.Events;

namespace UUP.ScriptableObjects.GameEvents.CollectionSequences
{
    public interface ISequenceNotifier
    {
        /// <summary>
        /// The int parameter corresponds to the current index of the sequence.
        /// </summary>
        public UnityEvent<int> SequenceEventNotifier { get; }

        /// <summary>
        /// This event is raised when the sequence has reached the end.
        /// </summary>
        public UnityEvent OnPostSequenceEvent { get; }

        /// <summary>
        /// This event is raised when the sequence has reached the beginning.
        /// </summary>
        public UnityEvent OnPreSequenceEvent { get; }

        /// <summary>
        /// This event is raised when a custom condition is met in the sequence.
        /// The int parameter represents the current index.
        /// </summary>
        UnityEvent OnCustomConditionMet { get; }

        /// <summary>
        /// Defines a custom condition to check on each sequence step.
        /// </summary>
        /// <param name="condition"></param>
        public void DefineCustomCondition(Func<int, bool> condition);
    }
}
