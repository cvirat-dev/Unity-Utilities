using UUP.Coroutines;
using System;

namespace UUP.Common.Coroutines
{
    public interface IConditionRoutineSO<TAction> : IConditionRoutine<TAction> where TAction : Delegate
    {
        /// <summary>
        /// Sets the parameters for this routine type by letting the serialized fields define the timeOutDuration and enableTimeOut
        /// </summary>
        /// <param name="condition"></param>
        public void Set(ConditionRoutineHandler condition);
    }
}
