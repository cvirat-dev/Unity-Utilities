using UUP.Common.Coroutines;
using System;
using System.Collections;
using UnityEngine;

namespace UUP.Coroutines
{
    public class PeriodicRoutine : RoutineBase<PeriodicRoutineHandler>, IPeriodicRoutine<PeriodicRoutineHandler>
    {
        protected bool limitIterations;
        protected int maxIterations;
        protected float cycleDuration;
        public event Action OnEachPeriod;

        private bool ShouldContinue(int iterations) => !limitIterations || iterations < maxIterations;

        public PeriodicRoutine() 
        {
            routineActionHandler = () => { };
            cycleDuration = 0.1f;
            limitIterations = false;
            maxIterations = 0;
        }

        public PeriodicRoutine(float cycleDurationInSec, PeriodicRoutineHandler periodAction, int maxIterations = 0, bool limitIterations = false)
        {
            ValidateParameters(cycleDurationInSec, maxIterations);
            this.limitIterations = limitIterations;
            this.maxIterations = maxIterations;
            this.cycleDuration = cycleDurationInSec;
            routineActionHandler = periodAction;
        }

        protected override IEnumerator RunRoutine()
        {
            IsRunning = true;
            int iterations = 0;

            while (IsRunning && ShouldContinue(iterations))
            {
                routineActionHandler?.Invoke();
                OnEachPeriod?.Invoke();
                iterations++;
                yield return new WaitForSeconds(cycleDuration);
            }

            OnRoutineCompleteHandler();
            IsRunning = false;

        }

        public void Set(float cycleDuration, PeriodicRoutineHandler periodAction, int maxIterations = 0, bool limitIterations = false)
        {
            if (IsRunning)
            {
                Debug.LogWarning("Routine is already running");
                return;
            }

            ValidateParameters(cycleDuration, maxIterations);

            this.limitIterations = limitIterations;
            this.maxIterations = maxIterations;
            this.cycleDuration = cycleDuration;
            routineActionHandler = periodAction;
        }

        private static void ValidateParameters(float cycleDuration, int maxIterations)
        {
            if (cycleDuration <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cycleDuration), "Cycle duration must be greater than zero.");
            }

            if (maxIterations <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxIterations), "Max iterations must be greater than zero.");
            }
        }
    }
}
