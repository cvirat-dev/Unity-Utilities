using UUP.Common.Coroutines;
using UUP.Coroutines;
using UUP.ScriptableObjects.Coroutines;
using UUP.ScriptableObjects.GameEvents.Serialized;
using UnityEngine;

namespace UUP.Components.Coroutines
{
    public sealed class TimerRoutineController : RoutineSOControllerBase<TimerRoutineSO, TimerRoutineHandler>
    {
        [SerializeField, Tooltip("The GameEvent on each tick")]
        IntGameEvent onEachTickEvent;

        public override void Set()
        {
            TimerRoutineHandler timerRoutineHandler = (tick) => onEachTickEvent.Raise(tick);
            routineSO.Set(timerRoutineHandler);
        }
    }
}
