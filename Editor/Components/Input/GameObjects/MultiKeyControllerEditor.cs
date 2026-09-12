using UUP.Components.Input.GameObjects;
using UnityEditor;
using UnityEngine;

namespace UUP.Editor.Components.Input.GameObjects
{
    [CustomEditor(typeof(MultiKeyController))]
    public class MultiKeyControllerEditor : UnityEditor.Editor
    {
        SerializedProperty keysProp;
        SerializedProperty objectsProp;
        SerializedProperty activatorTypes;

        private void OnEnable()
        {
            keysProp = serializedObject.FindProperty(MultiKeyController.InputKeysPropertyName);
            objectsProp = serializedObject.FindProperty(MultiKeyController.ObjectsPropertyName);
            activatorTypes = serializedObject.FindProperty(MultiKeyController.ActivatorTypesPropertyName);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(activatorTypes);

            EditorGUILayout.LabelField("Key-Object Pairs", EditorStyles.boldLabel);

            for (int i = 0; i < Mathf.Max(keysProp.arraySize, objectsProp.arraySize); i++)
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

                if (i < objectsProp.arraySize)
                {
                    EditorGUILayout.PropertyField(objectsProp.GetArrayElementAtIndex(i), GUIContent.none);
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
            objectsProp.arraySize++;
            serializedObject.ApplyModifiedProperties();
        }

        private void RemoveEntry(int index)
        {
            if (index >= 0 && index < keysProp.arraySize && index < objectsProp.arraySize)
            {
                keysProp.DeleteArrayElementAtIndex(index);
                objectsProp.DeleteArrayElementAtIndex(index);
                serializedObject.ApplyModifiedProperties();
            }
            else
            {
                Debug.LogError("Invalid index for removal");
            }
        }
    }
}