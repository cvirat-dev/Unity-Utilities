using UUP.Common.Data.Variables;
using UUP.CustomDataTypes;
using UUP.CustomDataTypes.Serializables;
using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;

namespace UUP.Components.Data.Variables
{
    public class StringVariableSOController : VariableSOController<StringVariableSO, string>
    {
        // All DataTypes support by converting to string
        public void SetValue(int value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(float value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(bool value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(char value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(object value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(Vector3 value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(Vector2 value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(Vector4 value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(Quaternion value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(Color value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(Color32 value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(Rect value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(RectOffset value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(SpatialOrientation value)
        {
            variable.SetValue(value.ToString());
        }

        public void SetValue(SpatialOrientationSRZ value)
        {
            variable.SetValue(value.Get().ToString());
        }

        // Add more as needed




    }
}
