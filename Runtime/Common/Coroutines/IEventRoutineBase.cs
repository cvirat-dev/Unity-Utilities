using System;

namespace UUP.Common.Coroutines
{
    public interface IEventRoutineBase<TAction> : IRoutineBase<TAction> where TAction : Delegate
    {
        event Action OnRoutineComplete;
        event Action OnRoutineStart;
        event Action OnRoutineStop;
    }
}