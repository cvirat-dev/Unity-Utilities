using UUP.Common.Coroutines;
using System;
using System.Collections;
using UnityEngine;

namespace UUP.Coroutines
{
    public abstract class RoutineBase<TAction> : IEventRoutineBase<TAction> where TAction : Delegate
    {
        public event Action OnRoutineComplete;
        public event Action OnRoutineStart;
        public event Action OnRoutineStop;

        protected MonoBehaviour host;
        protected Coroutine coroutine;
        protected TAction routineActionHandler; // Action to be invoked during each iteration of the routine

        public bool IsRunning { get; protected set; } = false;

        protected abstract IEnumerator RunRoutine();

        public void StartRoutine(MonoBehaviour host)
        {
            if (IsRunning)
            {
                Debug.LogWarning("Routine is already running");
                return;
            }

            this.host = host;
            OnRoutineStartHandler();
            coroutine = this.host.StartCoroutine(RunRoutine());
        }

        public void StopRoutine(MonoBehaviour host)
        {
            if (coroutine == null)
            {
                Debug.LogWarning("Coroutine is null");
                IsRunning = false;
                return;
            }

            if (this.host == null)
            {
                Debug.LogWarning("Host is null");
                this.host = host;
            }

            this.host.StopCoroutine(coroutine);
            OnRoutineStopHandler();
            IsRunning = false;
        }

        public void RestartRoutine(MonoBehaviour host)
        {
            StopRoutine(host);
            StartRoutine(host);
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
            return RunRoutine();
        }

        public void SetHostIfNull(MonoBehaviour host)
        {
            if (this.host == null)
            {
                this.host = host;
            }
        }

        public void SetCoroutineIfNull(Coroutine coroutine)
        {
            this.coroutine ??= coroutine;
        }
    }
}
