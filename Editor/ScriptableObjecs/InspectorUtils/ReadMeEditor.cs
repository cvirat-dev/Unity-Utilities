using UnityEngine;
using UnityEditor;
using UUP.ScriptableObjects.InspectorUtils;

namespace UUP.Editor.ScriptableObjects.InspectorUtils
{
    [CustomEditor(typeof(Readme))]
    [InitializeOnLoad]
    public class ReadmeEditor : UnityEditor.Editor
    {
        const float k_Space = 16f;

        const string _defaultTitle = "No content has been set yet.";
        const string _defaultBody1 = " - To add content into this ReadMe, click in the top right corner of the inspector and select 'Debug'. \n  - You can then add the content you want and when finished, simply click on 'Normal' again.";
        const string _defaultBody2 = " - The minimal requirement to 'initialize' a ReadMe is to set a value to the title. \n - This default message will then disappear.";
        const string _defaultBody3 = " - A default UUP icon can be found in the 'UUP/Runtime/InspectorUtils/Icons' folder.";

        bool m_Initialized;

        #region Style-Properties
        GUIStyle LinkStyle
        {
            get { return m_LinkStyle; }
        }

        [SerializeField]
        GUIStyle m_LinkStyle;

        GUIStyle TitleStyle
        {
            get { return m_TitleStyle; }
        }

        [SerializeField]
        GUIStyle m_TitleStyle;

        GUIStyle HeadingStyle
        {
            get { return m_HeadingStyle; }
        }

        [SerializeField]
        GUIStyle m_HeadingStyle;

        GUIStyle BodyStyle
        {
            get { return m_BodyStyle; }
        }

        [SerializeField]
        GUIStyle m_BodyStyle;

        GUIStyle ButtonStyle
        {
            get { return m_ButtonStyle; }
        }

        [SerializeField]
        GUIStyle m_ButtonStyle;
        #endregion

        public override void OnInspectorGUI()
        {
            var readme = (Readme)target;
            Init();

            if (readme == null)
            {
                Debug.LogWarning("Readme is null");
                return;
            }

            if (!HasReadMeBeenInitialized(readme))
            {
                DrawDefaultContent(readme);
                return;
            }
            
            DrawReadMeContent(readme);

        }

        void Init()
        {
            if (m_Initialized)
                return;
            m_BodyStyle = new GUIStyle(EditorStyles.label);
            m_BodyStyle.wordWrap = true;
            m_BodyStyle.fontSize = 14;
            m_BodyStyle.richText = true;

            m_TitleStyle = new GUIStyle(m_BodyStyle);
            m_TitleStyle.fontSize = 26;

            m_HeadingStyle = new GUIStyle(m_BodyStyle);
            m_HeadingStyle.fontStyle = FontStyle.Bold;
            m_HeadingStyle.fontSize = 18;

            m_LinkStyle = new GUIStyle(m_BodyStyle);
            m_LinkStyle.wordWrap = false;

            // Match selection color which works nicely for both light and dark skins
            m_LinkStyle.normal.textColor = new Color(0x00 / 255f, 0x78 / 255f, 0xDA / 255f, 1f);
            m_LinkStyle.stretchWidth = false;

            m_ButtonStyle = new GUIStyle(EditorStyles.miniButton);
            m_ButtonStyle.fontStyle = FontStyle.Bold;

            m_Initialized = true;
        }

        private bool HasReadMeBeenInitialized(Readme readme)
        {
            if (readme == null)
                return false;

            if (readme.title == null)
                return false;

            if (readme.title == "")
                return false;

            return true;
        }

        private void DrawHeader(Readme readme)
        {
            EditorGUILayout.BeginHorizontal();
            {
                if (readme.icon != null)
                {
                    var iconWidth = Mathf.Min(EditorGUIUtility.currentViewWidth / 3f - 20f, 128f); // 128f is the max width of the icon; 20f is the padding; 3f is the number of columns
                    GUILayout.Label(readme.icon, GUILayout.Width(iconWidth), GUILayout.Height(iconWidth));
                }

                GUILayout.Space(k_Space);
                EditorGUILayout.BeginVertical();
                {
                    GUILayout.FlexibleSpace();
                    GUILayout.Label(readme.title, EditorStyles.boldLabel);
                    GUILayout.FlexibleSpace();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndHorizontal();
        }

        private void DrawReadMeContent(Readme readme)
        {
            if (readme == null)
                return;

            DrawHeader(readme);
            EditorGUILayout.Space(k_Space);

            foreach (var section in readme.sections)
            {
                DrawSection(section);

                GUILayout.Space(k_Space);
            }
        }

        private void DrawSection(Readme.Section section)
        {
            if (!string.IsNullOrEmpty(section.heading))
            {
                GUILayout.Label(section.heading, HeadingStyle);
            }

            if (!string.IsNullOrEmpty(section.text))
            {
                GUILayout.Label(section.text, BodyStyle);
            }

            if (!string.IsNullOrEmpty(section.linkText))
            {
                if (LinkLabel(new GUIContent(section.linkText)))
                {
                    Application.OpenURL(section.url);
                }
            }
        }

        private void DrawDefaultContent(Readme readme)
        {
            if (readme == null)
                return;

            EditorGUILayout.BeginHorizontal();
            {
                if (readme.icon != null)
                {
                    var iconWidth = Mathf.Min(EditorGUIUtility.currentViewWidth / 3f - 20f, 128f); // 128f is the max width of the icon; 20f is the padding; 3f is the number of columns
                    GUILayout.Label(readme.icon, GUILayout.Width(iconWidth), GUILayout.Height(iconWidth));
                }

                GUILayout.Space(k_Space);
                EditorGUILayout.BeginVertical();
                {
                    GUILayout.FlexibleSpace();
                    GUILayout.Label(_defaultTitle, EditorStyles.boldLabel);
                    GUILayout.FlexibleSpace();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginVertical();
            {
                //GUILayout.FlexibleSpace();
                //GUILayout.Label(_defaultTitle, TitleStyle);
                GUILayout.Space(20);
                GUILayout.Label(_defaultBody1, BodyStyle);
                GUILayout.Space(20);
                GUILayout.Label(_defaultBody2, BodyStyle);
                GUILayout.Space(20);
                GUILayout.Label(_defaultBody3, BodyStyle);
            }
        }

        bool LinkLabel(GUIContent label, params GUILayoutOption[] options)
        {
            var position = GUILayoutUtility.GetRect(label, LinkStyle, options);

            Handles.BeginGUI();
            Handles.color = LinkStyle.normal.textColor;
            Handles.DrawLine(new Vector3(position.xMin, position.yMax), new Vector3(position.xMax, position.yMax));
            Handles.color = Color.white;
            Handles.EndGUI();

            EditorGUIUtility.AddCursorRect(position, MouseCursor.Link);

            return GUI.Button(position, label, LinkStyle);
        }
    }
}