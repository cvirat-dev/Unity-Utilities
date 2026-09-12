using UUP.Common.Data.Variables.NotifiedArrays;
using UUP.CustomAttributes;
using UUP.ScriptableObjects.Data.Variables;
using UUP.ScriptableObjects.Data.Variables.Arrays;

namespace UUP.Components.Data.Variables.NotifiedArrays
{
    public class StringNotifiedArrayController : NotifiedArrayController<StringArraySO, StringVariableSO, string>
    {
        [InspectorButton]
        public void ChangeSingleValue(int index, string value)
        {
            arraySO.GetVariableAt(index).SetValue(value);
        }

        [InspectorButton]
        public void SetAllToStringValue(string value)
        {
            arraySO.SetAllToValue(value);
        }
    }
}