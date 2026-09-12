using UUP.Coroutines;
using System;

namespace UUP.Common.Coroutines
{
    public interface IProgressRoutineSO : IEventRoutineSO<ProgressRoutineHandler>
    {
        event Action<float> OnRoutineProgress;

        /// <summary>
        /// Sets the parameters for this routine type
        /// </summary>
        /// <param name="routineActionHandler"></param>
        /// <param name="duration"></param>
        public void SetWithParams(ProgressRoutineHandler routineActionHandler, float duration);
        public void Set(ProgressRoutineHandler routineActionHandler);
    }
}

