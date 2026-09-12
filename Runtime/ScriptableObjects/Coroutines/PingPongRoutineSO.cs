using UUP.Common.Coroutines;
using UUP.Coroutines;
using System;
using UnityEngine;

namespace UUP.ScriptableObjects.Coroutines
{
    [CreateAssetMenu(fileName = "PingPongRoutine", menuName = "UUP/Coroutines/PingPongRoutine")]
    public class PingPongRoutineSO : ProgressRoutineSO<PingPongRoutine, ProgressRoutineHandler>
    {
        public event Action OnRoutineMidtime;

        public override void Set(ProgressRoutineHandler routineActionHandler)
        {
            if (IsRunning)
            {
                Debug.LogWarning("Routine is already running");
                return;
            }

            ValidateParams(routineActionHandler, duration);

            progressRoutine ??= new PingPongRoutine();
            progressRoutine.SetParams(routineActionHandler, duration);
            progressRoutine.OnRoutineStart += OnRoutineStartHandler;
            progressRoutine.OnRoutineProgress += OnRoutineProgressHandler;
            progressRoutine.OnRoutineStop += OnRoutineStopHandler;
            progressRoutine.OnRoutineComplete += OnRoutineCompleteHandler;
            progressRoutine.OnRoutineMidtime += OnRoutineMidtimeHandler;
            Debug.Log($"{nameof(PingPongRoutine)}: Routine set.");
        }
        public override void SetWithParams(ProgressRoutineHandler routineActionHandler, float duration)
        {
            if (IsRunning)
            {
                Debug.LogWarning("Routine is already running");
                return;
            }

            ValidateParams(routineActionHandler, duration);

            this.routineActionHandler = routineActionHandler;
            this.duration = duration;
            Set(routineActionHandler);
        }
        private void OnRoutineMidtimeHandler() => OnRoutineMidtime?.Invoke();
        protected override void DetachAllEvents()
        {
            progressRoutine.OnRoutineStart -= OnRoutineStartHandler;
            progressRoutine.OnRoutineProgress -= OnRoutineProgressHandler;
            progressRoutine.OnRoutineStop -= OnRoutineStopHandler;
            progressRoutine.OnRoutineComplete -= OnRoutineCompleteHandler;
            progressRoutine.OnRoutineMidtime -= OnRoutineMidtimeHandler;
        }
        protected override IEventRoutineBase<ProgressRoutineHandler> GetEventRoutine()
        {
            return progressRoutine;
        }
    }
}

