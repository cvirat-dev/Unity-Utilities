
using System.Collections;
using UnityEngine;

namespace UUP.Coroutines
{
    /// <summary>
    /// Implments the logic for a simple routine
    /// </summary>
    public class SimpleRoutine : ProgressRoutineBase
    {
        public SimpleRoutine() 
        {
            routineActionHandler = (progress) => { };
            duration = 1.0f;
            IsRunning = false;
        }

        public SimpleRoutine(ProgressRoutineHandler routineActionHandler, float duration)
        {
            ValidateParams(routineActionHandler, duration);
            base.duration = duration;
            base.routineActionHandler = routineActionHandler;
            IsRunning = false;
        }

        protected override IEnumerator RunRoutine()
        {
            IsRunning = true;
            float elapsedTime = 0.0f;

            while (elapsedTime < duration)
            {
                if (!IsRunning)
                {
                    OnRoutineStopHandler();
                    yield break;
                }

                // Calculate the fraction of time passed
                float progress = Mathf.Clamp01(elapsedTime / duration);

                // Perform specific step
                routineActionHandler?.Invoke(progress);

                // Invoke the progress event
                OnRoutineProgressHandler(progress);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            OnRoutineCompleteHandler();
            IsRunning = false;
        }
    }
}
