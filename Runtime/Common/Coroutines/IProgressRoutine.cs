using UUP.Coroutines;
using System;

namespace UUP.Common.Coroutines
{
    public interface IProgressRoutine : IEventRoutineBase<ProgressRoutineHandler>
    {
        event Action<float> OnRoutineProgress;

        /// <summary>
        /// Sets the parameters for this routine type
        /// </summary>
        /// <param name="routineActionHandler"></param>
        /// <param name="duration"></param>
        public void SetParams(ProgressRoutineHandler routineActionHandler, float duration);
    }
}
