using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using UnityEngine;

namespace UUP.Common.Coroutines
{
    public abstract class RoutineSOControllerBase<TRoutineSO, TRoutineDelegate> : MonoBehaviourT, 
        IRoutineSOControllerBase
        where TRoutineSO : IEventRoutineSO<TRoutineDelegate>
        where TRoutineDelegate : System.Delegate
    {
        [SerializeField]
        protected TRoutineSO routineSO;

        [InspectorButton]
        public abstract void Set();

        private void OnEnable()
        {
            //Debug.Log($"{nameof(RoutineSOControllerBase<TRoutineSO, TRoutineDelegate>)}: Resetting routine state.");
            if (routineSO == null)
            {
                Debug.LogWarning("RoutineSO is null");
                return;
            }

            routineSO.DetachAndReset();
        }

        private void OnDisable()
        {
            //Debug.Log($"{nameof(RoutineSOControllerBase<TRoutineSO, TRoutineDelegate>)}: Resetting routine state.");
            if (routineSO == null)
            {
                Debug.LogWarning("RoutineSO is null");
                return;
            }

            routineSO.DetachAndReset();
        }

        [InspectorButton]
        public void StartRoutine()
        {
            if(!routineSO.IsSet)
            {
                Set();
            }

            if (routineSO.IsRunning)
            {
                Debug.LogWarning("Routine is already running");
                return;
            }

            routineSO.StartRoutine(this);
        }

        [InspectorButton]
        public void StopRoutine()
        {
            routineSO.StopRoutine(this);
        }

        [InspectorButton]
        public void RestartRoutine()
        {
            if (!routineSO.IsSet)
            {
                Set();
            }

            routineSO.RestartRoutine(this);
        }
    }
}
