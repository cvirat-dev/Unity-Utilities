using UUP.Common.Data.Variables;
using UUP.CustomDataTypes;
using UUP.CustomDataTypes.Serializables;
using UUP.ScriptableObjects.Data.Variables;

namespace UUP.Components.Data.Variables
{
    public class SpatialOrientationVariableSOController : VariableSOController<SpatialOrientationVariableSO, SpatialOrientationSRZ>
    {
        public void SetValue(SpatialOrientation value)
        {
            SpatialOrientationSRZ s = new(value);
            SetValue(s);
        }
    }
}
