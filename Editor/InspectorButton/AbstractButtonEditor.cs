#if UNITY_EDITOR 
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UUP.CustomAttributes;

namespace UUP.Editor.InspectorButton
{
//#if UNITY_EDITOR
    public abstract class AbstractButtonEditor : UnityEditor.Editor
    {
        protected abstract object GetTargetObject();

        private Type targetType;

        private Type GetTargetType()
        {
            return GetTargetObject().GetType();
        }

        // Cache : This will store the list of methods and their parameters for each object
        private static Dictionary<int, Dictionary<MethodInfo, ParameterValue[]>> cache = new();

        // Dictionary to store the parameters of the methods
        private Dictionary<MethodInfo, ParameterValue[]> methodsParams = new();

        private void OnEnable()
        {
            if (target == null || serializedObject == null || serializedObject.targetObject == null)
                return;

            targetType = GetTargetType();

            var objectID = serializedObject.targetObject.GetInstanceID();

            if (cache.ContainsKey(objectID))
            {
                methodsParams = cache[objectID];
                return;
            }

            // Get the methods of the target object which have the InspectorButton attribute
            // Store the methods and their parameters in the cache
            AddMethodsToCache(objectID);
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            //if (!_isValidTargetType)
            //{
            //    Debug.LogWarning($"Will not draw buttons for {targetType.Name} because it does not have the {nameof(InspectorButtonAttribute)} attribute.");
            //    return;
            //}

            // Iterates over the methods and their parameters and creates a button for each method
            AddInspectorButtons();
        }

        /// <summary>
        /// This method gets all the methods of the target object which have the InspectorButton attribute
        /// </summary>
        /// <param name="objectID">The instance ID of the target object</param>
        private void AddMethodsToCache(int objectID)
        {
            // Get all the methods of the target object
            foreach (var methodInfo in InspectorButtonUtils.GetMethods(targetType))
            {
                if (!Attribute.IsDefined(methodInfo, typeof(InspectorButtonAttribute)))
                    continue;

                var singleMethodParams = GetMethodParameters(methodInfo);
                methodsParams.Add(singleMethodParams.methodInfo, singleMethodParams.methodParameters);
            }

            // Add the methods and their parameters to the cache
            cache.Add(objectID, methodsParams);
        }

        /// <summary>
        /// Returns the method and its parameters
        /// </summary>
        /// <param name="methodInfo">The method informations</param>
        /// <returns>A Tuple containing the method and its parameters</returns>
        private (MethodInfo methodInfo, ParameterValue[] methodParameters) GetMethodParameters(MethodInfo methodInfo)
        {
            var parameterInfos = methodInfo.GetParameters();
            var parameterValues = new ParameterValue[parameterInfos.Length];

            for (int i = 0; i < parameterInfos.Length; i++)
            {
                var parameter = parameterInfos[i];
                var value = parameter.ParameterType.GetDefaultValue();

                parameterValues[i] = new ParameterValue(parameter, value);
            }

            return (methodInfo, parameterValues);
        }

        /// <summary>
        /// This method adds the buttons to the inspector
        /// It iterates over the methods and their parameters and creates a button for each method
        /// </summary>
        private void AddInspectorButtons()
        {
            foreach (var methodParams in methodsParams)
            {
                EditorGUILayout.BeginVertical("Box");

                var parameters = methodParams.Value;
                var notSerializedParameters = Array.FindAll(
                    parameters,
                    p => !InspectorButtonUtils.IsTypeSerializable(p.ParameterInfo.ParameterType));
                string errorMessage = null;

                // Check if the method has non-serializable parameters
                if (notSerializedParameters.Length > 0)
                {
                    var notSerializedParameterNames = string.Join(
                        ", ",
                        Array.ConvertAll(notSerializedParameters, p => p.ParameterInfo.Name));
                    errorMessage = $"The following parameters are not serializable: {notSerializedParameterNames}";
                    EditorGUILayout.HelpBox(errorMessage, MessageType.Error);
                }

                else
                {
                    //EditorGUI.showMixedValue = serializedObject.isEditingMultipleObjects;
                    EditorGUI.showMixedValue = serializedObject.targetObjects.Length > 1;


                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (InspectorButtonUtils.DrawParameter(parameters[i], out object value))
                        {
                            parameters[i] = new ParameterValue(parameters[i].ParameterInfo, value);
                        }
                    }

                    EditorGUI.showMixedValue = false;
                }

                var attributes = methodParams.Key.GetCustomAttributes(typeof(IButtonAttribute), true)[0] as IButtonAttribute;

                // Check if the object is a prefab: returns true if the object is not a prefab
                var performValidation = attributes.PerformValidation(serializedObject.targetObject);

                var rect = EditorGUILayout.GetControlRect();
                var currentColor = GUI.color;
                GUI.color = performValidation ? currentColor : Color.yellow;
                var buttonPressed = GUI.Button(rect, methodParams.Key.Name);

                // if prefab, show an error message
                if (string.IsNullOrEmpty(errorMessage) && !performValidation)
                {
                    errorMessage = attributes.Error;
                }

                if (buttonPressed)
                {

                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        foreach (var targetObject in serializedObject.targetObjects)
                        {
                            // this fixes a bug where duplicating objects then selecting them
                            // then clicking a button threw an error
                            // since the new objects where not in the cache until you selected them
                            InspectorButtonUtils.TryAddObjectToCacheMine(targetObject, ref cache, ref methodsParams);

                            var targetParameters = cache[targetObject.GetInstanceID()][methodParams.Key];

                            // Invoke the method
                            object methodInvokationResult = methodParams.Key.Invoke(
                                targetObject,
                                targetParameters.Select(p => p.Value).ToArray());

                            // If the method has a return type, show the result
                            if (methodParams.Key.ReturnType != typeof(void))
                            {
                                InspectorButtonUtils.PrintReturnResult(methodInvokationResult);
                            }

                        }
                    }

                    else
                    {
                        Debug.LogError(errorMessage);
                    }
                }

                EditorGUILayout.EndVertical();
            }
        }
    }
//#endif
}
#endif

