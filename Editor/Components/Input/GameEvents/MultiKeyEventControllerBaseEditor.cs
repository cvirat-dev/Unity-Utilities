using UUP.Components.Input.GameEvents;
using UnityEditor;
using UnityEngine;

namespace UUP.Editor.ScriptableObjectBased.GameEvents.InputKeyEvents
{
    [CustomEditor(typeof(MultiKeyEventControllerBase<>), true)]
    public class MultiKeyEventControllerBaseEditor : UnityEditor.Editor
    {
        SerializedProperty keysProp;
        SerializedProperty gameEventsProp;

        private void OnEnable()
        {
            keysProp = serializedObject.FindProperty("InputKeys");
            gameEventsProp = serializedObject.FindProperty("GameEvents");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.Separator();

            EditorGUILayout.LabelField("Key-GameEvents Pairs", EditorStyles.boldLabel);

            for (int i = 0; i < Mathf.Max(keysProp.arraySize, gameEventsProp.arraySize); i++)
            {
                EditorGUILayout.BeginHorizontal();

                if (i < keysProp.arraySize)
                {
                    EditorGUILayout.PropertyField(keysProp.GetArrayElementAtIndex(i), GUIContent.none);
                }
                else
                {
                    EditorGUILayout.LabelField("", GUILayout.Width(EditorGUIUtility.labelWidth));
                }

                if (i < gameEventsProp.arraySize)
                {
                    EditorGUILayout.PropertyField(gameEventsProp.GetArrayElementAtIndex(i), GUIContent.none);
                }
                else
                {
                    EditorGUILayout.LabelField("", GUILayout.Width(EditorGUIUtility.labelWidth));
                }

                if (GUILayout.Button("-", GUILayout.Width(20)))
                {
                    RemoveEntry(i);
                    break;
                }

                EditorGUILayout.EndHorizontal();
            }

            GUILayout.Space(10);

            if (GUILayout.Button("Add Pair"))
            {
                AddEntry();
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void AddEntry()
        {
            keysProp.arraySize++;
            gameEventsProp.arraySize++;
            serializedObject.ApplyModifiedProperties();
        }

        private void RemoveEntry(int index)
        {
            if (index >= 0 && index < keysProp.arraySize && index < gameEventsProp.arraySize)
            {
                keysProp.DeleteArrayElementAtIndex(index);
                gameEventsProp.DeleteArrayElementAtIndex(index);
                serializedObject.ApplyModifiedProperties();
            }
            else
            {
                Debug.LogError("Invalid index for removal");
            }
        }
    }
}