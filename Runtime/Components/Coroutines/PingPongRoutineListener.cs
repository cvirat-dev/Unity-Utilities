using UUP.Common.Coroutines;
using UUP.Coroutines;
using UUP.ScriptableObjects.Coroutines;
using UnityEngine.Events;

namespace UUP.Components.Coroutines
{
    public class PingPongRoutineListener : RoutineListenerBase<PingPongRoutineSO, ProgressRoutineHandler>
    {
        public UnityEvent<float> OnRoutineProgress;
        public UnityEvent OnRoutineMidtime;

        protected override void AddMoreSubscriptions()
        {
            base.AddMoreSubscriptions();
            routine.OnRoutineProgress += OnRoutineProgress.Invoke;
            routine.OnRoutineMidtime += OnRoutineMidtime.Invoke;
        }

        protected override void AddMoreUnsubscriptions()
        {
            base.AddMoreUnsubscriptions();
            routine.OnRoutineProgress -= OnRoutineProgress.Invoke;
            routine.OnRoutineMidtime -= OnRoutineMidtime.Invoke;
        }
    }
}
