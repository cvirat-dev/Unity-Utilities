using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UUP.Editor.Components.CommentComp
{
    internal static class CommentComponentSettings 
    {
        private const string LogRemovedComponentsKey = "UUP.InspectorUtils.CommentComp.LogRemovedComponents";

        public static bool LogRemovedComponents 
        {
            get => EditorPrefs.GetBool(LogRemovedComponentsKey, true); 
            set => EditorPrefs.SetBool(LogRemovedComponentsKey, value);
        }

        [SettingsProvider]
        public static SettingsProvider CreateProvider()
        {
            return new SettingsProvider("Preferences/UUP/InspectorUtils/Comment_Component", SettingsScope.User)
            {
                //     Use this function to implement a handler for when the user clicks on the Settings
                //     in the Settings window. You can fetch a settings Asset or set up UIElements UI
                //     from this function.
                activateHandler = CreateUI
            };
        }

        /// <summary>
        /// This method is called when the user clicks on the settings in the settings window
        /// It creates the UI for the settings window
        /// The toggle is used to enable or disable logging of removed components
        /// </summary>
        /// <param name="searchContext">The search context of the settings window</param>
        /// <param name="root">The root visual element of the settings window</param>
        private static void CreateUI(string searchContext, VisualElement root)
        {
            Debug.Log(searchContext); // searchContext is the search context of the settings window (Preferences/UUP/InspectorUtils/Comment_Component
            var toggle = new Toggle("Log Removed Components");
            toggle.SetValueWithoutNotify(LogRemovedComponents);
            toggle.RegisterValueChangedCallback(evt => LogRemovedComponents = evt.newValue); // evt.newValue is the new value of the toggle
            root.Add(toggle);   
        }
    }
}
