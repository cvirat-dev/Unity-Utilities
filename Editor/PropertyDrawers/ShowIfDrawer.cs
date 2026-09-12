using UUP.CustomAttributes;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace UUP.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ShowIfAttribute showIfAttribute = (ShowIfAttribute)attribute;

            // Get the object the property belongs to
            Object targetObject = property.serializedObject.targetObject;
            FieldInfo conditionField = targetObject.GetType().GetField(showIfAttribute.ConditionFieldName);

            if (conditionField == null)
            {
                Debug.LogError($"Field {showIfAttribute.ConditionFieldName} not found in {targetObject.GetType().Name}");
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            // Get the value of the condition field
            bool conditionValue = (bool)conditionField.GetValue(targetObject);

            if (conditionValue)
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ShowIfAttribute showIf = (ShowIfAttribute)attribute;

            // Get the object the property belongs to
            Object targetObject = property.serializedObject.targetObject;
            FieldInfo conditionField = targetObject.GetType().GetField(showIf.ConditionFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (conditionField != null)
            {
                bool conditionValue = (bool)conditionField.GetValue(targetObject);
                return conditionValue ? EditorGUI.GetPropertyHeight(property, label) : 0f;
            }

            return EditorGUI.GetPropertyHeight(property, label);
        }
    }
}
