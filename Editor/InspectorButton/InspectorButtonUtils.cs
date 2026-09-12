#if UNITY_EDITOR
using UUP.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UUP.Editor.InspectorButton
{
    public static class InspectorButtonUtils
    {
        public static Vector4 ToVector4(this Quaternion q)
        {
            return new Vector4(q.x, q.y, q.z, q.w);
        }

        public static Quaternion ToQuaternion(this Vector4 v)
        {
            return new Quaternion(v.x, v.y, v.z, v.w);
        }

        public static bool DrawParameter(ParameterValue parameterValue, out object value)
        {
            var type = parameterValue.ParameterInfo.ParameterType;

            if (type == typeof(int))
            {
                value = EditorGUILayout.IntField(parameterValue.ParameterInfo.Name, (int)parameterValue.Value);
                return true;
            }

            if (type == typeof(bool))
            {
                value = EditorGUILayout.Toggle(parameterValue.ParameterInfo.Name, (bool)parameterValue.Value);
                return true;
            }

            if (type == typeof(float))
            {
                value = EditorGUILayout.FloatField(parameterValue.ParameterInfo.Name, (float)parameterValue.Value);
                return true;
            }

            if (type == typeof(string))
            {
                value = EditorGUILayout.TextField(parameterValue.ParameterInfo.Name, (string)parameterValue.Value);
                return true;
            }

            if (type == typeof(Color))
            {
                value = EditorGUILayout.ColorField(parameterValue.ParameterInfo.Name, (Color)parameterValue.Value);
                return true;
            }

            if (type == typeof(Object) || type.IsSubclassOf(typeof(Object)))
            {
                // var allowSceneObjects = !EditorUtility.IsPersistent((Object)parameterValue.Value);

                value = EditorGUILayout.ObjectField(
                    parameterValue.ParameterInfo.Name,
                    (Object)parameterValue.Value,
                    parameterValue.ParameterInfo.ParameterType,
                    true
                );

                return true;
            }

            if (type.IsEnum)
            {
                value = EditorGUILayout.EnumPopup(parameterValue.ParameterInfo.Name, (Enum)parameterValue.Value);
                return true;
            }

            if (type == typeof(Vector2))
            {
                value = EditorGUILayout.Vector2Field(
                    parameterValue.ParameterInfo.Name,
                    (Vector2)parameterValue.Value);
                return true;
            }

            if (type == typeof(Vector3))
            {
                value = EditorGUILayout.Vector3Field(
                    parameterValue.ParameterInfo.Name,
                    (Vector3)parameterValue.Value);
                return true;
            }

            if (type == typeof(Vector4))
            {
                value = EditorGUILayout.Vector4Field(
                    parameterValue.ParameterInfo.Name,
                    (Vector4)parameterValue.Value);
                return true;
            }

            if (type == typeof(Rect))
            {
                value = EditorGUILayout.RectField(parameterValue.ParameterInfo.Name, (Rect)parameterValue.Value);
                return true;
            }

            if (type == typeof(AnimationCurve))
            {
                value = EditorGUILayout.CurveField(
                    parameterValue.ParameterInfo.Name,
                    (AnimationCurve)parameterValue.Value ?? new AnimationCurve());
                return true;
            }

            if (type == typeof(Bounds))
            {
                value = EditorGUILayout.BoundsField(parameterValue.ParameterInfo.Name, (Bounds)parameterValue.Value);
                return true;
            }

            if (type == typeof(Quaternion))
            {
                value = EditorGUILayout
                    .Vector4Field(
                        parameterValue.ParameterInfo.Name,
                        ((Quaternion)parameterValue.Value).ToVector4())
                    .ToQuaternion();
                return true;
            }

            if (type == typeof(Vector2Int))
            {
                value = EditorGUILayout.Vector2IntField(
                    parameterValue.ParameterInfo.Name,
                    (Vector2Int)parameterValue.Value);
                return true;
            }

            if (type == typeof(Vector3Int))
            {
                value = EditorGUILayout.Vector3IntField(
                    parameterValue.ParameterInfo.Name,
                    (Vector3Int)parameterValue.Value);
                return true;
            }

            if (type == typeof(RectInt))
            {
                value = EditorGUILayout.RectIntField(
                    parameterValue.ParameterInfo.Name,
                    (RectInt)parameterValue.Value);
                return true;
            }

            if (type == typeof(BoundsInt))
            {
                value = EditorGUILayout.BoundsIntField(
                    parameterValue.ParameterInfo.Name,
                    (BoundsInt)parameterValue.Value);
                return true;
            }

            value = default(object);
            return false;
        }

        public static MethodInfo[] GetMethods(Type type)
        {
            return type.GetMethods(
                BindingFlags.Public | 
                BindingFlags.NonPublic | 
                BindingFlags.Static | 
                BindingFlags.Instance);
        }

        public static void TryAddObjectToCacheMine(
            Object targetObjectMine, 
            ref Dictionary<int, Dictionary<MethodInfo, ParameterValue[]>> cache,
            ref Dictionary<MethodInfo, ParameterValue[]> methodsParams)
        {
            var type = targetObjectMine.GetType();
            var objectID = targetObjectMine.GetInstanceID();
            
            if (cache.ContainsKey(objectID))
            {
                methodsParams = cache[objectID];
                return;
            }

            methodsParams = new Dictionary<MethodInfo, ParameterValue[]>();
            foreach(var methodInfo in GetMethods(type))
            {
                var attributes = methodInfo.GetCustomAttributes(typeof(InspectorButtonAttribute), true);

                // Skip the current iteration if the method does not have the PhiButtonAttribute
                if(!attributes.Any())
                    continue;   


                var parameterInfos = methodInfo.GetParameters();
                var parameterValues = new ParameterValue[parameterInfos.Length];

                for (var i = 0; i < parameterInfos.Length; i++)
                {
                    var parameter = parameterInfos[i];
                    var value = parameter.DefaultValue;

                    parameterValues[i] = new ParameterValue(parameter, value);
                }

                methodsParams.Add(methodInfo, parameterValues);
            }
            
            cache.Add(objectID, methodsParams);

        }

        public static void PrintReturnResult(object returnObject)
        {
            string returnResult;
            if (returnObject == null)
            {
                returnResult = "null";
            }
            else
            {
                returnResult = returnObject.ToString();
            }
            Debug.Log(returnResult);
        }

        public static bool IsTypeSerializable(Type type)
        {
            return type == typeof(int) ||
                    type == typeof(bool) ||
                    type == typeof(float) ||
                    type == typeof(string) ||
                    type == typeof(Color) ||
                    type == typeof(Object) ||
                    type.IsSubclassOf(typeof(Object)) ||
                    type.IsEnum ||
                    type == typeof(Vector2) ||
                    type == typeof(Vector3) ||
                    type == typeof(Vector4) ||
                    type == typeof(Rect) ||
                    type == typeof(AnimationCurve) ||
                    type == typeof(Bounds) ||
                    type == typeof(Quaternion) ||
                    type == typeof(Vector2Int) ||
                    type == typeof(Vector3Int) ||
                    type == typeof(RectInt) ||
                    type == typeof(BoundsInt);
        }

        public static object GetDefaultValue(this Type type)
        {
            if (type.IsValueType && Nullable.GetUnderlyingType(type) == null)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }
    }
}
#endif

