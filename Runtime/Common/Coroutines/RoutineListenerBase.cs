using UUP.Common.Components;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace UUP.Common.Coroutines
{
    public class RoutineListenerBase<TRoutineSO, TAction> : ListenerBase 
        where TRoutineSO : IEventRoutineBase<TAction>
        where TAction : Delegate
    {
        [SerializeField]
        protected TRoutineSO routine;

        public UnityEvent OnRoutineStart;
        public UnityEvent OnRoutineStop;
        public UnityEvent OnRoutineComplete;

        public bool IsRunning => routine.IsRunning;

        public override void Subscribe()
        {
            routine.OnRoutineStart += OnRoutineStart.Invoke;
            routine.OnRoutineStop += OnRoutineStop.Invoke;
            routine.OnRoutineComplete += OnRoutineComplete.Invoke;
            AddMoreSubscriptions();
        }

        protected virtual void AddMoreSubscriptions()
        {
        }

        public override void Unsubscribe()
        {
            routine.OnRoutineStart -= OnRoutineStart.Invoke;
            routine.OnRoutineStop -= OnRoutineStop.Invoke;
            routine.OnRoutineComplete -= OnRoutineComplete.Invoke;
            AddMoreUnsubscriptions();
        }

        protected virtual void AddMoreUnsubscriptions()
        {
        }

        //protected virtual void OnEnable()
        //{
        //    routine.OnRoutineStart += OnRoutineStart.Invoke;
        //    routine.OnRoutineStop += OnRoutineStop.Invoke;
        //    routine.OnRoutineComplete += OnRoutineComplete.Invoke;
        //}

        //protected virtual void OnDisable()
        //{
        //    routine.OnRoutineStart -= OnRoutineStart.Invoke;
        //    routine.OnRoutineStop -= OnRoutineStop.Invoke;
        //    routine.OnRoutineComplete -= OnRoutineComplete.Invoke;
        //}
    }
}
