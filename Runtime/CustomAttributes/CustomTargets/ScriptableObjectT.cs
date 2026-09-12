using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.CustomAttributes.CustomTargets
{
    /// <summary>
    /// Use this class instead of <see cref="ScriptableObject"/> if the custom attribute <see cref="UUP.CustomAttributes.InspectorButtonAttribute"/> should be used.
    /// This is a Workaround to avoid creating a custom editor for ScriptableObject classes which would interfere with other custom editors.
    /// For example, when the [InspectorButton] attribute is used on a Monobehaviour class, this class will be used to target it.
    /// Why is this necessary?
    ///     - Because the custom editor <see cref="ScriptableObjectButtonEditor"/> takes precedence over more specific custom editors.
    ///     - This Workaround allows to use attributes like [InspectorButton] on ScriptableObject classes without interfering with other custom editors.
    /// </summary>
    public class ScriptableObjectT : ScriptableObject
    {
    }
}
