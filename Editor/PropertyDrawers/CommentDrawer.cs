using UUP.CustomAttributes;
using UnityEditor;
using UnityEngine;

namespace UUP.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(CommentAttribute))]
    public class EditableCommentDrawer : PropertyDrawer
    {
        private bool _isEditing;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            CommentAttribute attribute = (CommentAttribute)base.attribute;

            // Use a unique key for this property to manage editing state
            string stateKey = $"{property.serializedObject.targetObject.GetHashCode()}_{property.propertyPath}_IsEditing";
            _isEditing = SessionState.GetBool(stateKey, attribute.StartInEditMode || string.IsNullOrEmpty(property.stringValue));

            if (_isEditing)
            {
                DrawEditingUI(position, property, stateKey);
            }
            else
            {
                DrawReadOnlyUI(position, property, stateKey, attribute.IconType);
            }
        }

        private void DrawEditingUI(Rect position, SerializedProperty property, string stateKey)
        {
            EditorGUI.BeginProperty(position, GUIContent.none, property);

            // Editable text field with automatic height adjustment
            Rect textFieldRect = new Rect(position.x, position.y, position.width, position.height - 20f);
            property.stringValue = EditorGUI.TextArea(textFieldRect, property.stringValue);

            // End editing button
            Rect buttonRect = new Rect(position.x, textFieldRect.yMax + 2f, position.width, 18f);
            if (GUI.Button(buttonRect, "End Editing"))
            {
                _isEditing = false;
                SessionState.SetBool(stateKey, false);
                GUI.FocusControl(null); // Deselect the field
            }

            EditorGUI.EndProperty();
        }

        private void DrawReadOnlyUI(Rect position, SerializedProperty property, string stateKey, IconType defaultIconType)
        {
            EditorGUI.BeginProperty(position, GUIContent.none, property);

            // Calculate layout
            Rect iconRect = new Rect(position.x, position.y, 20, position.height);
            Rect textRect = new Rect(position.x + 25, position.y, position.width - 25, position.height);

            // Draw icon
            IconType currentIcon = (IconType)SessionState.GetInt(stateKey + "_Icon", (int)defaultIconType);
            DrawIcon(iconRect, currentIcon);

            // Draw text
            EditorGUI.LabelField(textRect, property.stringValue);

            // Handle double-click to toggle editing mode
            Event evt = Event.current;
            if (evt.type == EventType.MouseDown && evt.clickCount == 2 && position.Contains(evt.mousePosition))
            {
                _isEditing = true;
                SessionState.SetBool(stateKey, true);
                evt.Use();
            }

            EditorGUI.EndProperty();
        }

        private void DrawIcon(Rect position, IconType iconType)
        {
            // Use Unity's built-in icons for better visuals
            GUIContent iconContent = iconType switch
            {
                IconType.Info => EditorGUIUtility.IconContent("console.infoicon"),
                IconType.Warning => EditorGUIUtility.IconContent("console.warnicon"),
                IconType.Error => EditorGUIUtility.IconContent("console.erroricon"),
                _ => EditorGUIUtility.IconContent("d_UnityEditor.ConsoleWindow"),
            };

            GUI.Label(position, iconContent);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            string stateKey = $"{property.serializedObject.targetObject.GetHashCode()}_{property.propertyPath}_IsEditing";

            if (SessionState.GetBool(stateKey, false))
            {
                // Editing mode: Dynamically calculate height based on text content
                float lineHeight = EditorGUIUtility.singleLineHeight;
                int lines = Mathf.Max(1, property.stringValue.Split('\n').Length);
                float textHeight = lines * lineHeight + 6; // Add padding

                return textHeight + 20f; // Include space for the "End Editing" button
            }
            else
            {
                // Read-only mode: Calculate height dynamically for multi-line content
                GUIStyle labelStyle = GUI.skin.label;
                float labelHeight = labelStyle.CalcHeight(new GUIContent(property.stringValue), EditorGUIUtility.currentViewWidth - 25f);
                return Mathf.Max(labelHeight, 20f); // Ensure at least one line
            }
        }

    }
}
