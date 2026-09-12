using UUP.Common.Coroutines;
using System;
using System.Collections;
using UnityEngine;

namespace UUP.ScriptableObjects.Coroutines
{
    public abstract class RoutineBaseSO<TRoutineAction> : ScriptableObjectTWithComment, 
        IEventRoutineSO<TRoutineAction> 
        where TRoutineAction : Delegate
    {
        public event Action OnRoutineComplete;
        public event Action OnRoutineStart;
        public event Action OnRoutineStop;

        protected MonoBehaviour host;
        protected Coroutine coroutine;
        protected TRoutineAction routineActionHandler;

        public bool IsRunning => IsRoutineRunning();
        public bool IsSet => GetEventRoutine() != null;

        protected abstract IEnumerator RunRoutine(MonoBehaviour host);

        public void StartRoutine(MonoBehaviour host)
        {
            GetEventRoutine().StartRoutine(host);
        }

        public void StopRoutine(MonoBehaviour host)
        {
            GetEventRoutine().StopRoutine(host);
        }

        public void RestartRoutine(MonoBehaviour host)
        {
            GetEventRoutine().RestartRoutine(host);
        }

        protected void OnRoutineStartHandler()
        {
            OnRoutineStart?.Invoke();
        }

        protected void OnRoutineCompleteHandler()
        {
            OnRoutineComplete?.Invoke();
        }

        protected void OnRoutineStopHandler()
        {
            OnRoutineStop?.Invoke();
        }

        public IEnumerator GetRoutine()
        {
            return RunRoutine(host);
        }

        private void OnDisable()
        {
            //Debug.Log("RoutineBaseSO OnDisable");
            DetachAndReset();
        }

        private void OnDestroy()
        {
            //Debug.Log("RoutineBaseSO OnDestroy");
            DetachAndReset();
        }

        public void SetHostIfNull(MonoBehaviour host)
        {
            if (host == null)
            {
                this.host = host;
            }
        }

        public abstract void SetCoroutineIfNull(Coroutine coroutine);

        protected abstract bool IsRoutineRunning();

        protected abstract IEventRoutineBase<TRoutineAction> GetEventRoutine();

        public void DetachAndReset()
        {
            var routine = GetEventRoutine();

            if (routine == null)
            {
                return;
            }

            DetachAllEvents();
            routine = null;
        }

        protected abstract void DetachAllEvents();
    }
}
