using UUP.Common.Coroutines;
using UUP.Coroutines;
using UUP.CustomAttributes;
using System;
using System.Collections;
using UnityEngine;

namespace UUP.ScriptableObjects.Coroutines
{
    /// <summary>
    /// ScriptableObject-based implementation of <see cref="IConditionRoutine{T}"/>.
    /// </summary>
    [CreateAssetMenu(menuName = "UUP/Coroutines/ConditionRoutine", fileName = "ConditionRoutine", order = 0)]
    public class ConditionRoutineSO : RoutineBaseSO<ConditionRoutineHandler>, IConditionRoutineSO<ConditionRoutineHandler>
    {
        private ConditionRoutine conditionRoutine;

        public bool EnableTimeOut = true;

        [SerializeField, ShowIf(nameof(EnableTimeOut)), Tooltip("The duration in seconds before the routine times out if the condition is not met.")]
        float timeOutDuration = 10f;

        public event Action OnConditionMet;
        public event Action OnTimeOut;

        public void Set(ConditionRoutineHandler condition, float timeOutDuration = 10, bool disableTimeOut = true)
        {
            if (IsRunning)
            {
                Debug.LogWarning("Routine is already running");
                return;
            }

            this.timeOutDuration = timeOutDuration;
            EnableTimeOut = !disableTimeOut;

            conditionRoutine ??= new ConditionRoutine(); // Lazy initialization: create a new instance only if it's null
            conditionRoutine.Set(condition, timeOutDuration, disableTimeOut);
            conditionRoutine.OnRoutineStart += OnRoutineStartHandler;
            conditionRoutine.OnRoutineComplete += OnRoutineCompleteHandler;
            conditionRoutine.OnRoutineStop += OnRoutineStopHandler;
            conditionRoutine.OnConditionMet += OnConditionMet;
            conditionRoutine.OnTimeOut += OnTimeOut;
        }

        public void Set(ConditionRoutineHandler condition)
        {
            Set(condition, timeOutDuration, !EnableTimeOut);
        }

        protected override IEnumerator RunRoutine(MonoBehaviour host)
        {
            conditionRoutine.SetHostIfNull(host);
            return conditionRoutine.GetRoutine();
        }

        public override void SetCoroutineIfNull(Coroutine coroutine)
        {
            if (conditionRoutine == null)
            {
                throw new NullReferenceException("ConditionRoutine is null");
            }

            conditionRoutine.SetCoroutineIfNull(coroutine);
        }

        protected override bool IsRoutineRunning()
        {
            if (conditionRoutine == null)
            {
                conditionRoutine = new ConditionRoutine();
            }

            return conditionRoutine.IsRunning;
        }

        protected override IEventRoutineBase<ConditionRoutineHandler> GetEventRoutine()
        {
            return conditionRoutine;
        }

        protected override void DetachAllEvents()
        {
            if (conditionRoutine != null)
            {
                conditionRoutine.OnRoutineStart -= OnRoutineStartHandler;
                conditionRoutine.OnRoutineComplete -= OnRoutineCompleteHandler;
                conditionRoutine.OnRoutineStop -= OnRoutineStopHandler;
                conditionRoutine.OnConditionMet -= OnConditionMet;
                conditionRoutine.OnTimeOut -= OnTimeOut;
            }
        }

    }
}
