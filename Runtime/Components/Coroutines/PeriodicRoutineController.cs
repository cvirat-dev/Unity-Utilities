using UUP.Common.Coroutines;
using UUP.Coroutines;
using UUP.ScriptableObjects.Coroutines;
using UUP.ScriptableObjects.GameEvents;
using UnityEngine;

namespace UUP.Components.Coroutines
{
    public sealed class PeriodicRoutineController : RoutineSOControllerBase<PeriodicRoutineSO, PeriodicRoutineHandler>
    {
        [SerializeField, Tooltip("The GameEvent to be called periodically")]
        GameEvent periodicHandlerEvent;

        public override void Set()
        {
            PeriodicRoutineHandler periodicRoutineHandler = () => periodicHandlerEvent.Raise();
            routineSO.Set(periodicRoutineHandler);
        }
    }
}