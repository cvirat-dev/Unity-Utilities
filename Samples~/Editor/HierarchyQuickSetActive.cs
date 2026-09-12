using UnityEngine;
using System.Collections;
using UnityEditor;

namespace PhiCAE.Editor
{
    [InitializeOnLoad]
    public class HierarchQuickSetActive
    {
        /// <summary>
        /// Initializer  class.
        /// </summary>
        static HierarchQuickSetActive()
        {
            EditorApplication.hierarchyWindowItemOnGUI += hierarchWindowOnGUI;
        }
        /// <summary>
        /// Editor delegate callback
        /// </summary>
        /// İnstance id.
        /// Selection rect.
        static void hierarchWindowOnGUI(int instanceID, Rect selectionRect)
        {
            // make rectangle
            Rect r = new Rect(selectionRect);
            r.x = r.width + 30;
            r.width = 18;
            // get objects
            Object o = EditorUtility.InstanceIDToObject(instanceID);
            GameObject gameObject = o as GameObject;
            // drag toggle gui
            if (gameObject != null)
            {
                // Use GUI.Toggle to create a toggle button for the active state
                gameObject.SetActive(GUI.Toggle(r, gameObject.activeSelf, string.Empty));
            }
        }
    }
}