using UnityEngine;

namespace UUP.CustomAttributes
{
    /// <summary>
    /// Allows a field to be shown or hidden based on the value of another field of type bool.
    /// </summary>
    /// <remarks>
    /// In order to work, the boolean field must be public and have a valid value.
    /// </remarks>
    public class ShowIfAttribute : PropertyAttribute
    {
        public string ConditionFieldName { get; }

        public ShowIfAttribute(string conditionFieldName)
        {
            ConditionFieldName = conditionFieldName;
        }
    }
}
