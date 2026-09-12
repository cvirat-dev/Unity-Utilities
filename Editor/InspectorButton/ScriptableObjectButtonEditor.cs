#if UNITY_EDITOR
using UUP.CustomAttributes.CustomTargets;
using UnityEditor;
using UnityEngine;

namespace UUP.Editor.InspectorButton
{
    [CustomEditor(typeof(ScriptableObjectT), true), CanEditMultipleObjects]
    public class ScriptableObjectButtonEditor : AbstractButtonEditor
    {
        protected override object GetTargetObject()
        {
            return (ScriptableObject)target;
        }
    }
}
#endif
