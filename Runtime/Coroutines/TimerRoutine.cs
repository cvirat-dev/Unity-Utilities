using System;
using System.Collections;
using UnityEngine;

namespace UUP.Coroutines
{
    public class TimerRoutine : RoutineBase<TimerRoutineHandler>, ITimerRoutine<TimerRoutineHandler>
    {
        protected int timerDurationInSeconds;
        protected TimerRoutineHandler handler;
        public event Action<int> OnEachTick;

        public TimerRoutine()
        {
            handler = (secondsLeft) => { };
            timerDurationInSeconds = 1;
            IsRunning = false;
        }

        public TimerRoutine(int timerDurationInSeconds, TimerRoutineHandler tickAction)
        {
            ValidateParameters(timerDurationInSeconds);
            handler = tickAction;
            this.timerDurationInSeconds = timerDurationInSeconds;
            IsRunning = false;
        }

        public void Set(int timerDurationInSeconds, TimerRoutineHandler tickAction)
        {
            if (IsRunning)
            {
                Debug.LogWarning("Routine is already running");
                return;
            }

            ValidateParameters(timerDurationInSeconds);
            handler = tickAction;
            this.timerDurationInSeconds = timerDurationInSeconds;
            IsRunning = false;
        }

        protected override IEnumerator RunRoutine()
        {
            IsRunning = true;
            int timer = 0;

            while (IsRunning && timer < timerDurationInSeconds)
            {
                var secondsLeft = timerDurationInSeconds - timer;
                handler?.Invoke(secondsLeft);
                OnEachTick?.Invoke(secondsLeft);
                timer++;
                yield return new WaitForSeconds(1);
            }

            handler?.Invoke(0);
            OnEachTick?.Invoke(0);

            OnRoutineCompleteHandler();
            IsRunning = false;
        }

        private void ValidateParameters(int timerDurationInSeconds)
        {
            if (timerDurationInSeconds <= 0)
            {
                throw new ArgumentException("Timer duration must be greater than 0");
            }
        }
    }
}
