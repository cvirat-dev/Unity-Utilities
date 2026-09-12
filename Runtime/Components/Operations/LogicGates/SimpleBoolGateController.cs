using UUP.ScriptableObjects.Data.Variables;
using UUP.ScriptableObjects.GameEvents;
using UnityEngine;

namespace UUP.Components.Operations.LogicGates
{
    public enum SimpleBoolCondition
    {
        PassOnTrue,
        PassOnFalse
    }

    public class SimpleBoolGateController : MonoBehaviour
    {
        [SerializeField] private SimpleBoolCondition condition;
        [SerializeField] private BoolVariableSO boolVariable;
        [SerializeField] private GameEvent passEvent;

        public void OnCheckConditionGE(Component sender, object data) => CheckCondition();   

        public void CheckCondition()
        {
            if(passEvent == null)
            {
                Debug.LogError("No pass event assigned to " + name);
                return;
            }

            if (boolVariable == null)
            {
                Debug.LogError("No bool variable assigned to " + name);
                return;
            }

            if (condition == SimpleBoolCondition.PassOnTrue && boolVariable.Value)
            {
                passEvent.Raise();
            }
            else if (condition == SimpleBoolCondition.PassOnFalse && !boolVariable.Value)
            {
                passEvent.Raise();
            }
        }
    }
}