using UUP.Components.Operations.LogicGates;
using UnityEditor;
using UnityEngine;

namespace UUP.Editor.Components.Operations.LogicGates
{
    [CustomEditor(typeof(LogicGateController))]
    public class LogicGatesController2Editor : UnityEditor.Editor
    {
        private const string _infoMessage1 = "The bool-value of the Output-UnityEvent is the result of the logic gate operation.";
        private const string _infoMessage2 = "The bool-value of this Output-GameEvent is the result of the logic gate operation.";
        private const string _infoMessage3 = "This GameEvent raises only if the output of the logic gate is true.";

        #region Serialized Properties
        SerializedProperty GateType;
        SerializedProperty OutputBoolEvent;
        SerializedProperty InputA;
        SerializedProperty InputB;
        SerializedProperty OutputBoolGE;
        SerializedProperty OutputOnTrueGE;
        SerializedProperty UseOutputBoolGameEvent;
        SerializedProperty UseOutputOnTrueGameEvent;
        bool configBttnStyle;
        #endregion

        private void OnEnable()
        {
            GateType = serializedObject.FindProperty("gateType");
            OutputBoolEvent = serializedObject.FindProperty("outputBoolEvent");
            InputA = serializedObject.FindProperty("inputA");
            InputB = serializedObject.FindProperty("inputB");
            OutputBoolGE = serializedObject.FindProperty("outputBoolGE");
            OutputOnTrueGE = serializedObject.FindProperty("ouputOnTrueGE");
            UseOutputBoolGameEvent = serializedObject.FindProperty("useOutputBoolGameEvent");
            UseOutputOnTrueGameEvent = serializedObject.FindProperty("useOutputOnTrueGameEvent");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            LogicGateController logicGateController = (LogicGateController)target;

            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(GateType);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(InputA);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(InputB);
            EditorGUILayout.Space();
            EditorGUILayout.HelpBox(_infoMessage1, MessageType.Info);
            EditorGUILayout.PropertyField(OutputBoolEvent);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Optional Outputs", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(UseOutputBoolGameEvent);
            EditorGUILayout.Space();

            if (logicGateController.TriggerOutputGameEvent)
            {
                EditorGUILayout.BeginVertical("box");
                //EditorGUILayout.LabelField("Output Bool-GameEvent: Raises on every output", EditorStyles.boldLabel);
                EditorGUILayout.HelpBox(_infoMessage2, MessageType.Info);
                EditorGUILayout.PropertyField(OutputBoolGE);
                EditorGUILayout.Space();
                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.PropertyField(UseOutputOnTrueGameEvent);
            EditorGUILayout.Space();

            if (logicGateController.TriggerOutputOnTrueGameEvent)
            {
                EditorGUILayout.BeginVertical("box");
                //EditorGUILayout.LabelField("Output Empty GameEvent: Raises only if output is true", EditorStyles.boldLabel);
                EditorGUILayout.HelpBox(_infoMessage3, MessageType.Info);
                EditorGUILayout.PropertyField(OutputOnTrueGE);
                EditorGUILayout.Space();
                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.Space();
            if (GUILayout.Button("Trigger Logic Gate"))
            {
                logicGateController.TriggerLogicGate();
            }

            EditorGUILayout.EndVertical();
            serializedObject.ApplyModifiedProperties();
        }

    }
}
