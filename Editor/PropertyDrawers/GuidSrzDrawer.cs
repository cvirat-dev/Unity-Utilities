using System;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UUP.CustomDataTypes.Serializables;

namespace UUP.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(GuidSRZ))]
    public class GuidSrzDrawer : PropertyDrawer
    {
        static readonly string[] GuidParts = { "Part1", "Part2", "Part3", "Part4"};

        static SerializedProperty[] GetGuidParts(SerializedProperty property)
        {
            SerializedProperty[] values = new SerializedProperty[GuidParts.Length];
            for (int i = 0; i < GuidParts.Length; i++)
            {
                values[i] = property.FindPropertyRelative(GuidParts[i]);
            }
            return values;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            if(GetGuidParts(property).All(x => x != null))
            {
                EditorGUI.LabelField(position, BuildGuidString(GetGuidParts(property)));
            }
            else
            {
                EditorGUI.SelectableLabel(position, "Invalid GUID", EditorStyles.textField);
            }

            bool hasClicked = Event.current.type == EventType.MouseUp && Event.current.button == 1;
            if (hasClicked && position.Contains(Event.current.mousePosition))
            {
                Debug.Log("Right click");
                ShowContextMenu(property);
                Event.current.Use();
            }

            EditorGUI.EndProperty();

        }

        private void ShowContextMenu(SerializedProperty property)
        {
            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("Copy GUID"), false, () => CopyGuid(property));
            menu.AddItem(new GUIContent("Reset GUID"), false, () => ResetGuid(property));
            menu.AddItem(new GUIContent("Generate New GUID"), false, () => GenerateNewGuid(property));
            menu.ShowAsContext();
        }

        private void GenerateNewGuid(SerializedProperty property)
        {
            const string warning = "Are you sure you want to generate a new GUID? This action cannot be undone.";
            if (!EditorUtility.DisplayDialog("Generate New GUID", warning, "Yes", "No"))
                return;

            byte[] bytes = Guid.NewGuid().ToByteArray();
            SerializedProperty[] parts = GetGuidParts(property);

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].intValue = BitConverter.ToInt32(bytes, i * 4);
            }

            property.serializedObject.ApplyModifiedProperties();
            Debug.Log("New GUID generated.");
        }

        private void ResetGuid(SerializedProperty property)
        {
            const string warning = "Are you sure you want to reset the GUID? This action cannot be undone.";
            if(!EditorUtility.DisplayDialog("Reset GUID", warning, "Yes", "No"))
                return;

            foreach (var part in GetGuidParts(property))
            {
                part.uintValue = 0;
            }

            property.serializedObject.ApplyModifiedProperties();
            Debug.Log("GUID reset.");
        }

        private void CopyGuid(SerializedProperty property)
        {
            if(GetGuidParts(property).Any(x => x == null))
                return;

            string guid = BuildGuidString(GetGuidParts(property));
            EditorGUIUtility.systemCopyBuffer = guid;
            Debug.Log($"GUID {guid} copied to clipboard.");
        }

        private string BuildGuidString(SerializedProperty[] guidParts)
        {
            return new StringBuilder()
                .AppendFormat("{0:X8}", guidParts[0].uintValue)
                .AppendFormat("{0:X8}", guidParts[1].uintValue)
                .AppendFormat("{0:X8}", guidParts[2].uintValue)
                .AppendFormat("{0:X8}", guidParts[3].uintValue)
                .ToString();
        }
    }
}
