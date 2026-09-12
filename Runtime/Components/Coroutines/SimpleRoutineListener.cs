using UUP.Common.Coroutines;
using UUP.Coroutines;
using UUP.ScriptableObjects.Coroutines;
using UnityEngine.Events;

namespace UUP.Components.Coroutines
{
    public class SimpleRoutineListener : RoutineListenerBase<SimpleRoutineSO, ProgressRoutineHandler> 
    {
        public UnityEvent<float> OnProgressRoutine;

        protected override void AddMoreSubscriptions()
        {
            base.AddMoreSubscriptions();
            routine.OnRoutineProgress += OnProgressRoutine.Invoke;
        }

        protected override void AddMoreUnsubscriptions()
        {
            base.AddMoreUnsubscriptions();
            routine.OnRoutineProgress -= OnProgressRoutine.Invoke;
        }

    }
}
