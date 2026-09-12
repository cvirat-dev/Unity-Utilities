#if UNITY_EDITOR
using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using System;
using UnityEditor;
using UnityEngine;

namespace UUP.Editor.InspectorButton
{
    [CustomEditor(typeof(MonoBehaviourT), true), CanEditMultipleObjects]
    public class MonobehaviourButtonEditor : AbstractButtonEditor
    {
        protected override object GetTargetObject()
        {
            return (MonoBehaviour)target;
        }

        public override bool HasPreviewGUI()
        {
            // Only return true for components with the specific attribute
            var targetType = GetTargetObject().GetType();
            return Attribute.IsDefined(targetType, typeof(InspectorButtonAttribute));
        }

    }
}
#endif
