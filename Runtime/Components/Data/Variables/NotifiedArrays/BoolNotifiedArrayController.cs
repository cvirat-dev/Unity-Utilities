
using UUP.Common.Data.Variables.NotifiedArrays;
using UUP.CustomAttributes;
using UUP.ScriptableObjects.Data.Variables;
using UUP.ScriptableObjects.Data.Variables.Arrays;

namespace UUP.Components.Data.Variables.NotifiedArrays
{
    public class BoolNotifiedArrayController : NotifiedArrayController<BoolArraySO, BoolVariableSO, bool>
    {
        [InspectorButton]
        public void SetAllToFalse()
        {
            arraySO.SetAllToFalse();
        }

        [InspectorButton]
        public void SetAllToTrue()
        {
            arraySO.SetAllToTrue();
        }

        [InspectorButton]
        public void SetSingleTrueAtIndex(int index)
        {
            arraySO.SetSingleTrueAtIndex(index);
        }

        [InspectorButton]
        public void SetSingleFalseAtIndex(int index)
        {
            arraySO.SetSingleFalseAtIndex(index);
        }
    }
}