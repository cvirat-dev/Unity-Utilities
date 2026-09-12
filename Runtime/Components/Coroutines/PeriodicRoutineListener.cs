using UUP.Common.Coroutines;
using UUP.Coroutines;
using UUP.ScriptableObjects.Coroutines;
using UnityEngine.Events;

namespace UUP.Components.Coroutines
{
    public class PeriodicRoutineListener : RoutineListenerBase<PeriodicRoutineSO, PeriodicRoutineHandler>
    {
        public UnityEvent OnEachPeriod;

        protected override void AddMoreSubscriptions()
        {
            base.AddMoreSubscriptions();
            routine.OnEachPeriod += OnEachPeriod.Invoke;
        }

        protected override void AddMoreUnsubscriptions()
        {
            base.AddMoreUnsubscriptions();
            routine.OnEachPeriod -= OnEachPeriod.Invoke;
        }

    }
}
