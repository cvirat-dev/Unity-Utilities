
using UUP.CustomAttributes.CustomTargets;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace UUP.ScriptableObjects.GameEvents.CollectionSequences
{
    public abstract class CollectSequenceBase : ScriptableObjectT, ISequenceable, ISequenceNotifier
    {
        [SerializeField]
        protected LoopMode _loopMode;
        protected int _currentIndex = 0;
        private UnityEvent<int> _sequenceEventNotifier = new UnityEvent<int>();
        private UnityEvent _onPostSequenceEvent = new UnityEvent();
        private UnityEvent _onPreSequenceEvent = new UnityEvent();
        private UnityEvent _onCustomConditionMet = new UnityEvent();
        private delegate bool customCondition(int index);
        private customCondition _customCondition;
        
        public int Length => GetCount();
        public int CurrentIndex => _currentIndex;
        
        /// <summary>
        /// This event is raised whenever the Raise method is called.
        /// The int parameter is the index of the current event in the sequence.
        /// </summary>
        public UnityEvent<int> SequenceEventNotifier => _sequenceEventNotifier;
        public UnityEvent OnPostSequenceEvent => _onPostSequenceEvent;
        public UnityEvent OnPreSequenceEvent => _onPreSequenceEvent;
        public UnityEvent OnCustomConditionMet => _onCustomConditionMet;
        
        /// <summary>
        /// Increments the current index by + 1 without raising the GameEvent-Collection.
        /// </summary>
        /// <returns></returns>
        public bool StepForward()
        {
            if (CurrentIndex + 1 >= Length)
            {
                OnPostSequenceEvent.Invoke();

                if (_loopMode == LoopMode.StopAtEnd)
                {
                    Debug.LogWarning($"{this.name} : " +
                        $"Sequence has reached the end. {nameof(_loopMode)} is set to {nameof(LoopMode.StopAtEnd)}. " +
                        $"Sequence will not proceed further.");
                    return false;
                }

                _currentIndex = 0;
                return true;
            }
            else
            {
                _currentIndex++;
                return true;
            }
        }
        
        /// <summary>
        /// Decrements the current index by - 1 without raising the GameEvent-Collection.
        /// </summary>
        /// <returns></returns>
        public bool StepBackward()
        {
            if (CurrentIndex - 1 < 0)
            {
                OnPreSequenceEvent.Invoke();

                if (_loopMode == LoopMode.StopAtEnd)
                {
                    Debug.LogWarning($"{this.name} : Sequence has reached the beginning. LoopMode is set to StopAtEnd. Sequence will not proceed further.");
                    return false;
                }

                _currentIndex = Length - 1;
                return true;
            }
            else
            {
                _currentIndex--;
                return true;
            }
        }
        
        /// <summary>
        /// Jumps to a specific index in the sequence without raising the GameEvent-Collection.
        /// </summary>
        /// <param name="index">The index for CurrentIndex</param>
        /// <returns></returns>
        public bool GoTo(int index)
        {
            if (index < 0 || index >= Length)
            {
                Debug.LogWarning($"{this.name} : Index out of range. Sequence will not proceed further.");
                return false;
            }

            _currentIndex = index;
            return true;
        }
        
        protected abstract int GetCount();
        
        public void SetIndex(int index)
        {
            _currentIndex = index;
        }
        
        public void ResetIndex()
        {
            _currentIndex = -1; // -1 because the first step will increment it to 0
        }
        
        /// <summary>
        /// Increments the current index by + 1 and raises the GameEvent-Collection.
        /// </summary>
        public void RaiseNext()
        {
            if(StepForward())
                Raise();
            else
                Debug.LogWarning($"{this.name} : Sequence has reached the end. LoopMode is set to StopAtEnd. Sequence will not proceed further.");
        }
        
        /// <summary>
        /// Decrements the current index by - 1 and raises the GameEvent-Collection.
        /// </summary>
        public void RaisePrevious() 
        {
            if(StepBackward())
                Raise();
            else
                Debug.LogWarning($"{this.name} : Sequence has reached the beginning. LoopMode is set to StopAtEnd. Sequence will not proceed further.");
        }
        
        /// <summary>
        /// Jumps to a specific index in the sequence and raises the GameEvent-Collection.
        /// </summary>
        /// <param name="index"></param>
        public void RaiseAt(int index)
        {
            if(GoTo(index))
                Raise();
            else
                Debug.LogWarning($"{this.name} : Index out of range. Sequence will not proceed further.");
        }
        
        public abstract void Raise();

        /// <summary>
        /// Defines a custom condition to check on each sequence step.
        /// </summary>
        /// <param name="condition"></param>
        public void DefineCustomCondition(Func<int, bool> condition)
        {
            _customCondition = condition == null ? null : new customCondition(condition);
        }
        
        protected void CheckCustomCondition()
        {
            if (_customCondition == null)
                return;

            if (_customCondition.Invoke(_currentIndex))
                _onCustomConditionMet.Invoke();
        }

        public void SetLoopMode(LoopMode loopMode)
        {
            _loopMode = loopMode;
        }
    }
}
