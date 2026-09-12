using UUP.Coroutines;
using System;

namespace UUP.Common.Coroutines
{
    public interface IPeriodicRoutineSO<TAction> : IPeriodicRoutine<TAction> where TAction : Delegate
    {
        void Set(PeriodicRoutineHandler periodAction);
    }
}
