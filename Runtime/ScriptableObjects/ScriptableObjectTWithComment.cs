using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using UnityEngine;

namespace UUP
{
    /// <summary>
    /// Base class for scriptable objects with descriptions.
    /// <see cref="ScriptableObjectT"/> also allows for custom inspector buttons using <see cref="InspectorButtonAttribute"/>.
    /// </summary>
    public class ScriptableObjectTWithComment : ScriptableObjectT
    {
        [SerializeField, Comment(IconType.Info)]
        protected string Informations = "Add informations about this SO here. Double click to edit.";

        [SerializeField, Comment(IconType.Warning)]
        protected string Warnings = "Add warnings about this SO here. Double click to edit.";
    }
}
