using UnityEditor;

namespace PhiCAE.Samples.TMProUtilities
{
    [CustomEditor(typeof(TextDisplayController)) ]
    public class TextDisplayControllerEditor : UnityEditor.Editor
    {
        #region SerializedProperties
        SerializedProperty AddStaticTextContentBool;
        SerializedProperty StaticContent;
        #endregion

        bool configureButtonStyle;

        private void OnEnable()
        {
            AddStaticTextContentBool = serializedObject.FindProperty("AddStaticTextContent");
            StaticContent = serializedObject.FindProperty("StaticContent");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            TextDisplayController textDisplayController = (TextDisplayController)target;

            EditorGUILayout.BeginVertical();

            // Default-fields
            EditorGUILayout.PropertyField(AddStaticTextContentBool);
            EditorGUILayout.Space();

            if (textDisplayController.BoolStaticContent)
            {
                configureButtonStyle = EditorGUILayout.BeginFoldoutHeaderGroup(configureButtonStyle, "Custom-Configuration");

                if (configureButtonStyle)
                {
                    EditorGUILayout.Space(5);
                    EditorGUILayout.PropertyField(StaticContent);
                }

                EditorGUILayout.EndFoldoutHeaderGroup();
            }

            EditorGUILayout.EndVertical();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
