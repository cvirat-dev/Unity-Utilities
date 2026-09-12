using UUP.ScriptableObjects.Data.Variables;
using UUP.ScriptableObjects.GameEvents;
using UUP.ScriptableObjects.GameEvents.Serialized;
using UnityEngine;
using UnityEngine.Events;

namespace UUP.Components.Operations.LogicGates
{
    public enum GateTypes
    {
        Not,
        And,
        Nand,
        Or,
        Nor,
        Xor,
        Xnor
    }

    public class LogicGateController : MonoBehaviour
    {
        #region Fields
        [SerializeField] private GateTypes gateType;
        public UnityEvent<bool> outputBoolEvent;
        [SerializeField] private BoolVariableSO inputA;
        [SerializeField] private BoolVariableSO inputB;
        [SerializeField] private BoolGameEvent outputBoolGE;
        [SerializeField] private GameEvent ouputOnTrueGE;
        [SerializeField] bool useOutputBoolGameEvent = false;
        [SerializeField] bool useOutputOnTrueGameEvent = false;
        #endregion

        public GateTypes GateType { get => gateType; }
        public bool TriggerOutputGameEvent { get => useOutputBoolGameEvent; }
        public bool TriggerOutputOnTrueGameEvent { get => useOutputOnTrueGameEvent; }

        private void NotGateInputA()
        {
            bool result = !inputA.Value;
            HandleOnOutputTrueGameEvent(result);
            HandleOutputBoolGameEvent(result);
            outputBoolEvent.Invoke(result);
            Debug.Log($"Input A: {inputA.Value}, Result: {result}");
        }

        private void NotGateInputB()
        {
            bool result = !inputB.Value;
            HandleOnOutputTrueGameEvent(result);
            HandleOutputBoolGameEvent(result);
            outputBoolEvent.Invoke(result);
            Debug.Log($"Input B: {inputB.Value}, Result: {result}");
        }

        private void AndGate()
        {
            bool result = inputA.Value && inputB.Value;
            HandleOnOutputTrueGameEvent(result);
            HandleOutputBoolGameEvent(result);
            outputBoolEvent.Invoke(result);
            Debug.Log($"Input A: {inputA.Value}, Input B: {inputB.Value}, Result: {result}");
        }

        private void NandGate()
        {
            bool result = !(inputA.Value && inputB.Value);
            HandleOnOutputTrueGameEvent(result);
            HandleOutputBoolGameEvent(result);
            outputBoolEvent.Invoke(result);
            Debug.Log($"Input A: {inputA.Value}, Input B: {inputB.Value}, Result: {result}");
        }

        private void OrGate()
        {
            bool result = inputA.Value || inputB.Value;
            HandleOnOutputTrueGameEvent(result);
            HandleOutputBoolGameEvent(result);
            outputBoolEvent.Invoke(result);
            Debug.Log($"Input A: {inputA.Value}, Input B: {inputB.Value}, Result: {result}");
        }

        private void NorGate()
        {
            bool result = !(inputA.Value || inputB.Value);
            HandleOnOutputTrueGameEvent(result);
            HandleOutputBoolGameEvent(result);
            outputBoolEvent.Invoke(result);
            Debug.Log($"Input A: {inputA.Value}, Input B: {inputB.Value}, Result: {result}");
        }

        private void XorGate()
        {
            bool result = inputA.Value ^ inputB.Value;
            HandleOnOutputTrueGameEvent(result);
            HandleOutputBoolGameEvent(result);
            outputBoolEvent.Invoke(result);
            Debug.Log($"Input A: {inputA.Value}, Input B: {inputB.Value}, Result: {result}");
        }

        private void XnorGate()
        {
            bool result = !(inputA.Value ^ inputB.Value);
            HandleOnOutputTrueGameEvent(result);
            HandleOutputBoolGameEvent(result);
            outputBoolEvent.Invoke(result);
            Debug.Log($"Input A: {inputA.Value}, Input B: {inputB.Value}, Result: {result}");
        }

        private void HandleOnOutputTrueGameEvent(bool result)
        {
            if (useOutputOnTrueGameEvent)
            {
                if (ouputOnTrueGE != null)
                {
                    if (result)
                    {
                        ouputOnTrueGE.Raise();
                    }
                }
                else
                {
                    Debug.LogError("Output GameEvent is null. Please assign a GameEvent to the OutputBoolGE field.");
                }
            }
        }

        private void HandleOutputBoolGameEvent(bool result)
        {
            if (useOutputBoolGameEvent)
            {
                if (outputBoolGE != null)
                {
                    outputBoolGE.Raise(result);
                }
                else
                {
                    Debug.LogError("Output GameEvent is null. Please assign a GameEvent to the OutputBoolGE field.");
                }
            }
        }

        public void TriggerLogicGate()
        {
            switch (gateType)
            {
                case GateTypes.Not:
                    NotGateInputA();
                    break;
                case GateTypes.And:
                    AndGate();
                    break;
                case GateTypes.Nand:
                    NandGate();
                    break;
                case GateTypes.Or:
                    OrGate();
                    break;
                case GateTypes.Nor:
                    NorGate();
                    break;
                case GateTypes.Xor:
                    XorGate();
                    break;
                case GateTypes.Xnor:
                    XnorGate();
                    break;
                default:
                    break;
            }
        }

        public void OnInputGE(Component sender, object data)
        {
            TriggerLogicGate();
        }
    }
}
