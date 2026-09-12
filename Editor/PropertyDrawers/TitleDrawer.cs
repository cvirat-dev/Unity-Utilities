using UnityEditor;
using UnityEngine;
using UUP.CustomAttributes;

namespace UUP.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(TitleAttribute))]
    public class TitleDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            TitleAttribute titleAttribute = (TitleAttribute)attribute;

            // Calc title position
            Rect titlePosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            Rect subtitleRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);
            Rect lineRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 2, position.width, 1);

            // Apply bold style if needed
            GUIStyle titleStyle = new GUIStyle(EditorStyles.boldLabel);
            if(!titleAttribute.Bold)
                titleStyle.fontStyle = FontStyle.Normal;

            // Set alignment
            titleStyle.alignment = TextAnchor.MiddleCenter;

            // Draw title
            EditorGUI.LabelField(titlePosition, titleAttribute.Title, titleStyle);

            // Draw subtitle (if any)
            if (!string.IsNullOrEmpty(titleAttribute.Subtitle))
            {
                GUIStyle subtitleStyle = new GUIStyle(EditorStyles.label) { fontSize = 10 };
                EditorGUI.LabelField(subtitleRect, titleAttribute.Subtitle, subtitleStyle);
            }

            // Draw line (if any)
            if (titleAttribute.DrawLine)
            {
                EditorGUI.DrawRect(lineRect, Color.grey);
            }

            // Move field down
            position.y += EditorGUIUtility.singleLineHeight * (string.IsNullOrEmpty(titleAttribute.Subtitle) ? 1.2f : 2.4f);
            EditorGUI.PropertyField(position, property, label, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            TitleAttribute titleAttribute = (TitleAttribute)attribute;
            float height = EditorGUIUtility.singleLineHeight * (string.IsNullOrEmpty(titleAttribute.Subtitle) ? 1.2f : 2.4f);
            return base.GetPropertyHeight(property, label) + height;
        }
    }
}
