
using UUP.Common.Data.Variables.NotifiedArrays;
using UUP.CustomAttributes;
using UUP.ScriptableObjects.Data.Variables;
using UUP.ScriptableObjects.Data.Variables.Arrays;

namespace UUP.Components.Data.Variables.NotifiedArrays
{
    public class FloatNotifiedArrayController : NotifiedArrayController<FloatArraySO, FloatVariableSO, float>
    {
        [InspectorButton]
        public void ChangeSingleValueAt(int index, float value)
        {
            arraySO.GetVariableAt(index).SetValue(value);
        }

        [InspectorButton]
        public void SetAllToFloatValue(float value)
        {
            arraySO.SetAllToValue(value);
        }

        [InspectorButton]
        public void AddToAll(float value)
        {
            arraySO.AddToAll(value);
        }

        [InspectorButton]
        public void SubtractFromAll(float value)
        {
            arraySO.SubtractFromAll(value);
        }

        [InspectorButton]
        public void MultiplyAllBy(float value)
        {
            arraySO.MultiplyAllBy(value);
        }

    }
}