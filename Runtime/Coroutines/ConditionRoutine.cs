using UUP.Common.Coroutines;
using System;
using System.Collections;
using UnityEngine;

namespace UUP.Coroutines
{
    public class ConditionRoutine : RoutineBase<ConditionRoutineHandler>, IConditionRoutine<ConditionRoutineHandler>
    {
        protected bool disableTimeOut;
        protected float timeOutDuration;
        public event Action OnConditionMet;
        public event Action OnTimeOut;

        public ConditionRoutine() 
        {
            routineActionHandler = () => false;
            timeOutDuration = 0.1f;
            disableTimeOut = false;
            IsRunning = false;
        }

        public ConditionRoutine(ConditionRoutineHandler condition, float timeOutDuration = 10f, bool disableTimeOut = false)
        {
            if(condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            routineActionHandler = condition;
            this.timeOutDuration = timeOutDuration;
            this.disableTimeOut = disableTimeOut;
            IsRunning = false;
        }

        public void Set(ConditionRoutineHandler condition, float timeOutDuration = 10, bool disableTimeOut = false)
        {
            if (IsRunning)
            {
                throw new InvalidOperationException("Cannot set condition while routine is running");
            }

            ValidateParameters(timeOutDuration);

            routineActionHandler = condition;
            this.timeOutDuration = timeOutDuration;
            this.disableTimeOut = disableTimeOut;
        }

        private static void ValidateParameters(float timeOutDuration)
        {
            if (timeOutDuration < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(timeOutDuration));
            }
        }

        protected override IEnumerator RunRoutine()
        {
            IsRunning = true;

            Coroutine timeOutCoroutine = null;
            if (!disableTimeOut)
            {
                timeOutCoroutine = host.StartCoroutine(TimeOutRoutine());
            }

            yield return new WaitUntil(() => routineActionHandler());
            OnConditionMet?.Invoke();
            OnRoutineCompleteHandler();

            if (timeOutCoroutine != null)
            {
                host.StopCoroutine(timeOutCoroutine);
            }
        }

        protected IEnumerator TimeOutRoutine()
        {
            yield return new WaitForSeconds(timeOutDuration);

            if (IsRunning)
            {
                Debug.LogWarning("ConditionRoutine timed out");
                OnTimeOut?.Invoke();
                StopRoutine(host);
            }
        }
    }
}
