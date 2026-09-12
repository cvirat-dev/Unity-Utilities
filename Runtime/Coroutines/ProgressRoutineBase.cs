using UUP.Common.Coroutines;
using System;
using UnityEngine;

namespace UUP.Coroutines
{
    public abstract class ProgressRoutineBase: RoutineBase<ProgressRoutineHandler>, IProgressRoutine
    {
        protected float duration;
        public event Action<float> OnRoutineProgress;

        public void SetParams(ProgressRoutineHandler routineActionHandler, float duration)
        {
            if (IsRunning)
            {
                Debug.LogWarning("Routine is already running");
                return;
            }

            ValidateParams(routineActionHandler, duration);

            this.routineActionHandler = routineActionHandler;
            this.duration = duration;
        }

        protected static void ValidateParams(ProgressRoutineHandler routineActionHandler, float duration)
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

        protected void OnRoutineProgressHandler(float progress)
        {
            OnRoutineProgress?.Invoke(progress);
        }
    }
}
