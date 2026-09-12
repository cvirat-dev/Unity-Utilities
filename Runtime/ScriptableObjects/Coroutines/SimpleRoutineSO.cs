using UUP.Common.Coroutines;
using UUP.Coroutines;
using UnityEngine;

namespace UUP.ScriptableObjects.Coroutines
{
    [CreateAssetMenu(fileName = "SimpleRoutine", menuName = "UUP/Coroutines/SimpleRoutine")]
    public class SimpleRoutineSO : ProgressRoutineSO<SimpleRoutine, ProgressRoutineHandler>
    {
        public override void Set(ProgressRoutineHandler routineActionHandler)
        {
            if (IsRunning)
            {
                Debug.LogWarning("Routine is already running");
                return;
            }

            ValidateParams(routineActionHandler, duration);

            progressRoutine ??= new SimpleRoutine();
            progressRoutine.SetParams(routineActionHandler, duration);
            progressRoutine.OnRoutineStart += OnRoutineStartHandler;
            progressRoutine.OnRoutineProgress += OnRoutineProgressHandler;
            progressRoutine.OnRoutineStop += OnRoutineStopHandler;
            progressRoutine.OnRoutineComplete += OnRoutineCompleteHandler;
            Debug.Log($"{nameof(SimpleRoutine)}: Routine set.");
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

        protected override void DetachAllEvents()
        {
            progressRoutine.OnRoutineStart -= OnRoutineStartHandler;
            progressRoutine.OnRoutineProgress -= OnRoutineProgressHandler;
            progressRoutine.OnRoutineStop -= OnRoutineStopHandler;
            progressRoutine.OnRoutineComplete -= OnRoutineCompleteHandler;
        }

        protected override IEventRoutineBase<ProgressRoutineHandler> GetEventRoutine()
        {
            return progressRoutine;
        }
    }
}
