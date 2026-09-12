using UUP.Common.Coroutines;
using UUP.Coroutines;
using UUP.ScriptableObjects.Coroutines;
using UnityEngine.Events;

namespace UUP.Components.Coroutines
{
    public class TimerRoutineListener : RoutineListenerBase<TimerRoutineSO, TimerRoutineHandler>
    {
        public UnityEvent<int> OnEachTick;

        protected override void AddMoreSubscriptions()
        {
            base.AddMoreSubscriptions();
            routine.OnEachTick += OnEachTick.Invoke;
        }

        protected override void AddMoreUnsubscriptions()
        {
            base.AddMoreUnsubscriptions();
            routine.OnEachTick -= OnEachTick.Invoke;
        }
    }
}
