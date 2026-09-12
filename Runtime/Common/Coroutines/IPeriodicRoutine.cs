
using UUP.Coroutines;
using System;

namespace UUP.Common.Coroutines
{
    public interface IPeriodicRoutine<TAction> : IEventRoutineBase<TAction> where TAction : Delegate
    {
        /// <summary>
        /// Event that triggers every period
        /// </summary>
        event Action OnEachPeriod;
        void Set(float cycleDuration, PeriodicRoutineHandler periodAction, int maxIterations = 0, bool limitIterations = false);
    }
}
