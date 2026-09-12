using UUP.Common.Coroutines;
using UUP.Coroutines;
using System;
using System.Collections;
using UnityEngine;

namespace UUP.ScriptableObjects.Coroutines
{
    [CreateAssetMenu(menuName = "UUP/Coroutines/TimerRoutine", fileName = "TimerRoutine", order = 0)]
    public class TimerRoutineSO : RoutineBaseSO<TimerRoutineHandler>, ITimerRoutine<TimerRoutineHandler>
    {
        private TimerRoutine timerRoutine;

        [SerializeField]
        private int timerDurationInSeconds;

        public event Action<int> OnEachTick;

        public void Set(TimerRoutineHandler timerAction)
        {
            if (IsRunning)
            {
                Debug.LogWarning("Routine is already running");
                return;
            }

            if (timerRoutine == null)
            {
                timerRoutine = new TimerRoutine(timerDurationInSeconds, timerAction);
            }
            else
            {
                timerRoutine.Set(timerDurationInSeconds, timerAction);
            }

            timerRoutine.OnEachTick += OnEachTick;
            timerRoutine.OnRoutineStart += OnRoutineStartHandler;
            timerRoutine.OnRoutineStop += OnRoutineStopHandler;
            timerRoutine.OnRoutineComplete += OnRoutineCompleteHandler;
        }

        public void Set(int timerDurationInSeconds, TimerRoutineHandler tickAction)
        {
            if (IsRunning)
            {
                Debug.LogWarning("Routine is already running");
                return;
            }

            this.timerDurationInSeconds = timerDurationInSeconds;
            Set(tickAction);
        }

        public override void SetCoroutineIfNull(Coroutine coroutine)
        {
            if (timerRoutine == null)
            {
                throw new NullReferenceException("TimerRoutine is null");
            }

            timerRoutine.SetCoroutineIfNull(coroutine);

        }

        protected override void DetachAllEvents()
        {
            if (timerRoutine != null)
            {
                timerRoutine.OnEachTick -= OnEachTick;
                timerRoutine.OnRoutineStart -= OnRoutineStartHandler;
                timerRoutine.OnRoutineStop -= OnRoutineStopHandler;
                timerRoutine.OnRoutineComplete -= OnRoutineCompleteHandler;
            }
        }

        protected override IEventRoutineBase<TimerRoutineHandler> GetEventRoutine()
        {
            return timerRoutine;
        }

        protected override bool IsRoutineRunning()
        {
            if (timerRoutine == null)
            {
                return false;
            }

            return timerRoutine.IsRunning;
        }

        protected override IEnumerator RunRoutine(MonoBehaviour host)
        {
            timerRoutine.SetHostIfNull(host);
            return timerRoutine.GetRoutine();
        }
    }
}
