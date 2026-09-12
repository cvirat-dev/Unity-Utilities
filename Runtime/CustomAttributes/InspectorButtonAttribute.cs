#if UNITY_EDITOR
using UnityEditor;
#endif
using System;

namespace UUP.CustomAttributes
{
    /// <summary>
    /// This attribute allows to create a inspector-button for methods (public or private methods with no return type)
    /// !!! IMPORTANT !!!
    /// This attribute can only be used in classes that inherit from <see cref="UUP.CustomAttributes.CustomTargets.MonoBehaviourT"/> or <see cref="UUP.CustomAttributes.CustomTargets.ScriptableObjectT"/>
    /// Why ? Because it allows to avoid creating a custom editor for Monobehaviour or ScriptableObject classes which would interfere with other custom editors.
    /// Warnings:
    ///     o If this attribute is used inside a MonoBehaviour or ScriptableObject class, no inspector-button will be displayed and no erors neither
    ///     o Only serializable fields can be passed as arguments to the method
    /// </summary>

    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class InspectorButtonAttribute : Attribute, IButtonAttribute
    {
        public string Error
        {
            get { return "Selected object is a prefab, use [Prefab] tag to execute method on a prefab"; }
        }

        public bool PerformValidation(UnityEngine.Object obj)
        {
            // return true if the object is not a prefab
#if UNITY_EDITOR
            return PrefabUtility.GetPrefabAssetType(obj) == PrefabAssetType.NotAPrefab;
#else
            return true;
#endif
        }
    }
}
