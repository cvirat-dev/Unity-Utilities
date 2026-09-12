
using UUP.Common.Data.Variables.NotifiedArrays;
using UUP.ScriptableObjects.Data.Variables;
using UUP.ScriptableObjects.Data.Variables.Arrays;

namespace UUP.Components.Data.Variables.NotifiedArrays
{
    public class IntNotifiedArrayController : NotifiedArrayController<IntArraySO, IntVariableSO, int>
    {
        public void SubtractFromAll(int value)
        {
            arraySO.SubtractFromAll(value);
        }

        public void MultiplyAllBy(int value)
        {
            arraySO.MultiplyAllBy(value);
        }

        public void DivideAllBy(int value)
        {
            arraySO.DivideAllBy(value);
        }
    }
}