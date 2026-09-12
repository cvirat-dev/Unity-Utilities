using System;
using System.Collections;
using UnityEngine;

namespace UUP.Coroutines
{
    /// <summary>
    /// Implements the logic for a ping-pong routine
    /// </summary>
    public class PingPongRoutine : ProgressRoutineBase
    {
        public event Action OnRoutineMidtime;

        public PingPongRoutine() 
        {
            routineActionHandler = (progress) => { };
            duration = 1.0f;
            IsRunning = false;
        }

        public PingPongRoutine(float duration, ProgressRoutineHandler routineActionHandler)
        {
            ValidateParams(routineActionHandler, duration);
            base.duration = duration;
            base.routineActionHandler = routineActionHandler;
            IsRunning = false;
        }

        protected override IEnumerator RunRoutine()
        {
            IsRunning = true;
            var halfDuration = duration / 2;

            yield return RunHalfRoutine(halfDuration, false);
            OnRoutineMidtime?.Invoke();
            yield return RunHalfRoutine(halfDuration, true);

            OnRoutineCompleteHandler();
            IsRunning = false;
        }

        private IEnumerator RunHalfRoutine(float halfDuration, bool isReturning)
        {
            float elapsedTime = 0.0f;
            while (elapsedTime < halfDuration)
            {
                if (!IsRunning)
                {
                    OnRoutineStopHandler();
                    yield break;
                }

                float progress = (isReturning) ? 1 - Mathf.Clamp01(elapsedTime / halfDuration) : Mathf.Clamp01(elapsedTime / halfDuration);

                // Perform specific step
                routineActionHandler?.Invoke(progress);

                // Invoke the progress event
                OnRoutineProgressHandler(progress);

                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
