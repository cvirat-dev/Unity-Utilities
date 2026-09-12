using System.Reflection;

namespace UUP.Editor.InspectorButton
{
    public struct ParameterValue
    {
        public readonly ParameterInfo ParameterInfo;
        public readonly object Value;

        public ParameterValue(ParameterInfo parameterInfo, object value)
        {
            ParameterInfo = parameterInfo;
            Value = value;
        }
    }
}

