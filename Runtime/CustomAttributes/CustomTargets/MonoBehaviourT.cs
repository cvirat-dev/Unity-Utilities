using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.CustomAttributes.CustomTargets
{
    /// <summary>
    /// Use this class instead of MonoBehaviour if the custom attribute [InspectorButton] should be used.
    /// This is a Workaround to avoid creating a custom editor for Monobehaviour classes which would interfere with other custom editors.
    /// For example, when the [InspectorButton] attribute is used on a Monobehaviour class, this class will be used to target it.
    /// Why is this necessary?
    ///     - Because the custom editor <see cref="MonobehaviourButtonEditor"/> takes precedence over more specific custom editors.
    ///     - This Workaround allows to use attributes like [InspectorButton] on Monobehaviour classes without interfering with other custom editors.
    /// </summary>
    public class MonoBehaviourT : MonoBehaviour
    {
    }
}
