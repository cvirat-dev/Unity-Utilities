using UUP.Common.Coroutines;
using UUP.Coroutines;
using UUP.CustomAttributes;
using System;
using System.Collections;
using UnityEngine;

namespace UUP.ScriptableObjects.Coroutines
{
    /// <summary>
    /// ScriptableObject-based implementation of <see cref="IPeriodicRoutine{T}"/>.
    /// </summary>
    [CreateAssetMenu(menuName = "UUP/Coroutines/PeriodicRoutine", fileName = "PeriodicRoutine", order = 0)]
    public class PeriodicRoutineSO : RoutineBaseSO<PeriodicRoutineHandler>, IPeriodicRoutineSO<PeriodicRoutineHandler>
    {
        private PeriodicRoutine periodicRoutine;

        public bool limitIterations = true;    

        [SerializeField, ShowIf(nameof(limitIterations))]
        int maxIterations = 50;

        [SerializeField, Tooltip("Duration of each cycle in seconds")]
        float cycleDuration = 0.5f;

        public event Action OnEachPeriod;

        public void Set(float cycleDuration, PeriodicRoutineHandler periodAction, int maxIterations = 0, bool limitIterations = false)
        {
            if (IsRunning)
            {
                Debug.LogWarning("Routine is already running");
                return;
            }

            this.limitIterations = limitIterations;
            this.maxIterations = maxIterations;
            this.cycleDuration = cycleDuration;

            periodicRoutine ??= new PeriodicRoutine();
            periodicRoutine.Set(this.cycleDuration, periodAction, this.maxIterations, this.limitIterations);
            periodicRoutine.OnRoutineStart += OnRoutineStartHandler;
            periodicRoutine.OnRoutineStop += OnRoutineStopHandler;
            periodicRoutine.OnRoutineComplete += OnRoutineCompleteHandler;
            periodicRoutine.OnEachPeriod += OnEachPeriod;
        }

        public void Set(PeriodicRoutineHandler periodAction)
        {
            Set(cycleDuration, periodAction, maxIterations, limitIterations);
        }

        protected override IEnumerator RunRoutine(MonoBehaviour host)
        {
            periodicRoutine.SetHostIfNull(host);
            return periodicRoutine.GetRoutine();
        }

        public override void SetCoroutineIfNull(Coroutine coroutine)
        {
            if (periodicRoutine == null)
            {
                throw new NullReferenceException("PeriodicRoutine is null");
            }

            periodicRoutine.SetCoroutineIfNull(coroutine);
        }

        protected override bool IsRoutineRunning()
        {
            periodicRoutine ??= new PeriodicRoutine();
            return periodicRoutine.IsRunning;
        }

        protected override IEventRoutineBase<PeriodicRoutineHandler> GetEventRoutine()
        {
            return periodicRoutine;
        }

        protected override void DetachAllEvents()
        {
            if (periodicRoutine == null)
            {
                return;
            }

            periodicRoutine.OnRoutineStart -= OnRoutineStartHandler;
            periodicRoutine.OnRoutineStop -= OnRoutineStopHandler;
            periodicRoutine.OnRoutineComplete -= OnRoutineCompleteHandler;
            periodicRoutine.OnEachPeriod -= OnEachPeriod;
        }
    }
}
