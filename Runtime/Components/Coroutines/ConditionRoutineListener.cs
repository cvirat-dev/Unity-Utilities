using UUP.Common.Coroutines;
using UUP.Coroutines;
using UUP.ScriptableObjects.Coroutines;
using UnityEngine.Events;

namespace UUP.Components.Coroutines
{
    public class ConditionRoutineListener : RoutineListenerBase<ConditionRoutineSO, ConditionRoutineHandler>
    {
        public UnityEvent OnConditionMet;
        public UnityEvent OnTimeOut;

        protected override void AddMoreSubscriptions()
        {
            base.AddMoreSubscriptions();
            routine.OnConditionMet += OnConditionMet.Invoke;
            routine.OnTimeOut += OnTimeOut.Invoke;
        }

        protected override void AddMoreUnsubscriptions()
        {
            base.AddMoreUnsubscriptions();
            routine.OnConditionMet -= OnConditionMet.Invoke;
            routine.OnTimeOut -= OnTimeOut.Invoke;
        }

    }
}
