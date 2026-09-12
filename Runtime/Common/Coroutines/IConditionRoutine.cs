using UUP.Coroutines;
using System;

namespace UUP.Common.Coroutines
{
    public interface IConditionRoutine<TAction> : IEventRoutineBase<TAction> where TAction : Delegate
    {
        event Action OnConditionMet;
        event Action OnTimeOut;

        /// <summary>
        /// Sets the parameters for this routine type
        /// This version also sets the timeOutDuration and enableTimeOut whích are serialized fields
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="timeOutDuration"></param>
        /// <param name="disableTimeOut"></param>
        public void Set(ConditionRoutineHandler condition, float timeOutDuration = 10f, bool disableTimeOut = false);
    }
}