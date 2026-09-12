using UUP.CustomAttributes.CustomTargets;
using UUP.CustomDataTypes;
using UUP.CustomDataTypes.Serializables;
using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;

namespace UUP.Components.Data.Variables.Converters
{
    public class StringVariableConverter : MonoBehaviourT
    {
        [SerializeField]
        StringVariableSO stringVariableSO;

        public void OnInputF1(float input)
        {
            stringVariableSO.SetValue(input.ToString("F1"));
        }

        public void OnInputF2(float input)
        {
            stringVariableSO.SetValue(input.ToString("F2"));
        }

        public void OnInputF3(float input)
        {
            stringVariableSO.SetValue(input.ToString("F3"));
        }

        public void OnInputF4(float input)
        {
            stringVariableSO.SetValue(input.ToString("F4"));
        }

        public void OnInput(int input)
        {
            stringVariableSO.SetValue(input.ToString());
        }

        public void OnInput(string input)
        {
            stringVariableSO.SetValue(input);
        }

        public void OnInput(bool input)
        {
            stringVariableSO.SetValue(input.ToString());
        }

        public void OnInput(Vector2 input)
        {
            stringVariableSO.SetValue(input.ToString());
        }

        public void OnInput(Vector3 input)
        {
            stringVariableSO.SetValue(input.ToString());
        }

        public void OnInput(SpatialOrientation input)
        {
            string str1 = input.PositionMessage;
            string str2 = input.RotationMessage;
            stringVariableSO.SetValue(str1 + " " + str2);
        }

        public void OnInput(SpatialOrientationSRZ input)
        {
            string str1 = input.Get().PositionMessage;
            string str2 = input.Get().RotationMessage;
            stringVariableSO.SetValue(str1 + " " + str2);
        }

        public void OnInput(Color input)
        {
            stringVariableSO.SetValue(input.ToString());
        }

        public void OnInput(Quaternion input)
        {
            stringVariableSO.SetValue(input.ToString());
        }

        public void OnInput(Transform input)
        {
            stringVariableSO.SetValue(input.position.ToString() + " " + input.rotation.ToString());
        }

        public void OnInput(GameObject input)
        {
            stringVariableSO.SetValue(input.transform.position.ToString() + " " + input.transform.rotation.ToString());
        }

        // Add more OnInput methods for other types as needed
    }
}
