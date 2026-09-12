using UUP.Common.Coroutines;
using UUP.Coroutines;
using UUP.ScriptableObjects.Coroutines;
using System;
using System.Collections;
using UnityEngine;

namespace UUP
{
    public abstract class ProgressRoutineSO<TProgressRoutine, TRoutineAction> : RoutineBaseSO<TRoutineAction>, 
        IProgressRoutineSO 
        where TRoutineAction : Delegate
        where TProgressRoutine : IProgressRoutine, new()
    {
        protected TProgressRoutine progressRoutine;

        [SerializeField]
        protected float duration = 1f;

        public event Action<float> OnRoutineProgress;

        protected override IEnumerator RunRoutine(MonoBehaviour host)
        {
            progressRoutine.SetHostIfNull(host);
            return progressRoutine.GetRoutine();
        }

        public override void SetCoroutineIfNull(Coroutine coroutine)
        {
            if (progressRoutine == null)
            {
                throw new System.NullReferenceException("ProgressRoutine is null");
            }

            progressRoutine.SetCoroutineIfNull(coroutine);
        }

        protected override bool IsRoutineRunning()
        {
            if (progressRoutine == null)
            {
                progressRoutine = new TProgressRoutine();
            }

            return progressRoutine.IsRunning;
        }

        public abstract void SetWithParams(ProgressRoutineHandler routineActionHandler, float duration);
        public abstract void Set(ProgressRoutineHandler routineActionHandler);
        protected void OnRoutineProgressHandler(float progress) => OnRoutineProgress?.Invoke(progress);
        protected void ValidateParams(ProgressRoutineHandler routineActionHandler, float duration)
        {
            if (routineActionHandler == null)
            {
                throw new ArgumentNullException(nameof(routineActionHandler));
            }

            if (duration <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(duration));
            }
        }
    }
}
