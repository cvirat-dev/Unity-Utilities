using UUP.Common.Coroutines;
using UUP.Coroutines;
using UUP.CustomAttributes;
using UUP.ScriptableObjects.Coroutines;
using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;

namespace UUP.Components.Coroutines
{
    public sealed class ConditionRoutineController : RoutineSOControllerBase<ConditionRoutineSO, ConditionRoutineHandler>
    {
        [SerializeField]
        BoolVariableSO condition;

        public override void Set()
        {
            ConditionRoutineHandler conditionHandler = () =>
            {
                return condition.Value;
            };

            routineSO.Set(conditionHandler);
        }
    }
}