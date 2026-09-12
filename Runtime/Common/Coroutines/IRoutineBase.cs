
using System;
using System.Collections;
using UnityEngine;

namespace UUP.Common.Coroutines
{
    public interface IRoutineBase<TAction> where TAction : Delegate
    {
        bool IsRunning { get; }
        void StopRoutine(MonoBehaviour host);
        void StartRoutine(MonoBehaviour host);
        void RestartRoutine(MonoBehaviour host);
        public IEnumerator GetRoutine();
        public void SetHostIfNull(MonoBehaviour host);
        public void SetCoroutineIfNull(Coroutine coroutine);
    }
}
