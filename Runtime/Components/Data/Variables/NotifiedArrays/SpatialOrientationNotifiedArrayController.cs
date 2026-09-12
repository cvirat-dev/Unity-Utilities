
using UUP.Common.Data.Variables.NotifiedArrays;
using UUP.CustomDataTypes;
using UUP.CustomDataTypes.Serializables;
using UUP.ScriptableObjects.Data.Variables;
using UUP.ScriptableObjects.Data.Variables.Arrays;
using UnityEngine;

namespace UUP.Components.Data.Variables.NotifiedArrays
{
    public class SpatialOrientationNotifiedArrayController : 
        NotifiedArrayController<SpatialOrientationArraySO, SpatialOrientationVariableSO, SpatialOrientationSRZ>
    {
        public void SetAt(int index, SpatialOrientation val)
        {
            SpatialOrientationSRZ valS = new SpatialOrientationSRZ(val);
            arraySO.SetAt(index, valS);
        }

        public void SetAll(SpatialOrientation[] newValues)
        {
            SpatialOrientationSRZ[] newValuesS = new SpatialOrientationSRZ[newValues.Length];
            for (int i = 0; i < newValues.Length; i++)
            {
                newValuesS[i] = new SpatialOrientationSRZ(newValues[i]);
            }
            arraySO.SetAll(newValuesS);
        }

        public void SetAllToSame(SpatialOrientation val)
        {
            SpatialOrientationSRZ valS = new SpatialOrientationSRZ(val);
            arraySO.SetAllToSame(valS);
        }

        public void SetWithLocalAt(int index, Transform val)
        {
            SpatialOrientationSRZ valS = new SpatialOrientationSRZ();
            valS.SetWithLocal(val);
            arraySO.SetAt(index, valS);
        }

        public void SetWithWorldAt(int index, Transform val)
        {
            SpatialOrientationSRZ valS = new SpatialOrientationSRZ();
            valS.SetWithWorld(val);
            arraySO.SetAt(index, valS);
        }

        public void SetPositionAt(int index, Vector3 pos)
        {
            SpatialOrientationSRZ valS = new SpatialOrientationSRZ();
            valS.SetPosition(pos);
            arraySO.SetAt(index, valS);
        }

        public void SetRotationAt(int index, Vector3 rot)
        {
            SpatialOrientationSRZ valS = new SpatialOrientationSRZ();
            valS.SetRotation(rot);
            arraySO.SetAt(index, valS);
        }

    }
}
