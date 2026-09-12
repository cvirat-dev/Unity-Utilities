using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace UUP.ScriptableObjects.GameEvents.CollectionSequences
{
    /// <summary>
    /// This is a generic Monobehaviour controller for a sequence of a specific type.
    /// It allows to control the ScriptableObject-based Event-Collection-Sequence at runtime.
    /// Simply put, this class allows to use all the functionalities of the sequence in a Monobehaviour.
    /// </summary>
    /// <typeparam name="T">The type of the sequence to control</typeparam>
    public abstract class TypeSequenceController<T> : MonoBehaviourT, ISequenceNotifier where T : CollectSequenceBase
    {
        [SerializeField] T TypeSequenceSO;
        [SerializeField] LoopMode loopMode;   
        [SerializeField] UnityEvent<int> sequenceEventNotifier = new UnityEvent<int>();
        [SerializeField] UnityEvent onSequenceEndReached = new UnityEvent();
        [SerializeField] UnityEvent onSequenceStartReached = new UnityEvent();
        [SerializeField] UnityEvent onCustomConditionMet = new UnityEvent();

        public int CurrentIndex
        {
            get { return TypeSequenceSO.CurrentIndex; }
        }
        public int Length
        {
            get { return TypeSequenceSO.Length; }
        }

        public UnityEvent<int> SequenceEventNotifier => sequenceEventNotifier;
        public UnityEvent OnPostSequenceEvent => onSequenceEndReached;
        public UnityEvent OnPreSequenceEvent => onSequenceStartReached;
        public UnityEvent OnCustomConditionMet => onCustomConditionMet;

        private void OnValidate()
        {
            TypeSequenceSO.SetLoopMode(loopMode);
        }

        private void OnEnable()
        {
            TypeSequenceSO.SequenceEventNotifier.AddListener(OnSequenceEvent);
            TypeSequenceSO.OnPostSequenceEvent.AddListener(() => OnPostSequenceEvent.Invoke());
            TypeSequenceSO.OnPreSequenceEvent.AddListener(() => OnPreSequenceEvent.Invoke());
            TypeSequenceSO.OnCustomConditionMet.AddListener(() => OnCustomConditionMet.Invoke());
        }

        private void OnDisable()
        {
            TypeSequenceSO.SequenceEventNotifier.RemoveListener(OnSequenceEvent);
            TypeSequenceSO.OnPostSequenceEvent.RemoveListener(() => OnPostSequenceEvent.Invoke());
            TypeSequenceSO.OnPreSequenceEvent.RemoveListener(() => OnPreSequenceEvent.Invoke());
            TypeSequenceSO.OnCustomConditionMet.RemoveListener(() => OnCustomConditionMet.Invoke());
        }

        private void OnSequenceEvent(int arg0)
        {
            SequenceEventNotifier.Invoke(arg0);
        }

        public void ResetIndex()
        {
            TypeSequenceSO.ResetIndex();
        }
        
        [InspectorButton]
        public void RaiseNext()
        {
            TypeSequenceSO.RaiseNext();
        }

        [InspectorButton]
        public void RaisePrevious()
        {
            TypeSequenceSO.RaisePrevious();
        }

        [InspectorButton]
        public void RaiseAt(int index)
        {
            TypeSequenceSO.RaiseAt(index);
        }

        public void DefineCustomCondition(Func<int, bool> condition)
        {
            TypeSequenceSO.DefineCustomCondition(condition);
        }
    }
}