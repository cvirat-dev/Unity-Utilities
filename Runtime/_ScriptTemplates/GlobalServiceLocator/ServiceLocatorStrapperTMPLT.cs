using UnityEngine;

namespace UUP._ScriptTemplates.GlobalServiceLocator
{
    /// <summary>
    /// Strapper for the ServiceLocator.
    /// Add this script to a GameObject in your scene to instantiate the ServiceLocator automatically.
    /// </summary>
    /// <remarks>
    /// Warning: This script is a template.
    /// Do not use this script in your project.
    /// Instead, create a copy of this script and use it in your project.
    /// </remarks>
    internal sealed class ServiceLocatorStrapperTMPLT : MonoBehaviour
    {
        [SerializeField]
        GameObject globalServiceLocator;

        private void Awake()
        {
            if (GlobalServiceLocatorTMPLT.main != null)
            {
                Destroy(this.gameObject);
                return;
            }

            else
            {
                Instantiate(globalServiceLocator);
            }
        }
    }   
}

