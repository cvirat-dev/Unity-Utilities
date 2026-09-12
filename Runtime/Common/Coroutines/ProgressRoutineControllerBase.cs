using UUP.Coroutines;
using UUP.CustomAttributes;
using UUP.ScriptableObjects.GameEvents.Serialized;
using UnityEngine;

namespace UUP.Common.Coroutines
{
    public class ProgressRoutineControllerBase<TProgressRoutine> : RoutineSOControllerBase<TProgressRoutine, ProgressRoutineHandler>
        where TProgressRoutine : IProgressRoutineSO
    {
        [Tooltip("Set to true if a GameEvent should be raised as part of the routine handler")]
        public bool GameEventHandler = true;

        [SerializeField, ShowIf(nameof(GameEventHandler))]
        protected FloatGameEvent gameEvent;

        public override void Set()
        {
            ProgressRoutineHandler pingPongRoutineHandler = (t) =>
            {
                if (GameEventHandler)
                {
                    gameEvent.Raise(t);
                }
            };

            routineSO.Set(pingPongRoutineHandler);
        }
    }
}
