using UUP.Common.Coroutines;
using UUP.Coroutines;
using System;

namespace UUP
{
    public interface ITimerRoutine<TAction> : IEventRoutineBase<TAction> where TAction : Delegate
    {
        event Action<int> OnEachTick;
        void Set(int timerDurationInSeconds, TimerRoutineHandler tickAction);
    }
}
