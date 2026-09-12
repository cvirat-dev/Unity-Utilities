using UUP.Components.CommentComp;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace UUP.Editor.Components.CommentComp
{
    /// <summary>
    /// Draws an inspector for the <see cref="Comment"/> component with two modes.
    /// In readonly mode, the comment is displayed with an icon and text.
    /// In edit mode a textfield and dropdown are shown to edit the comment.
    /// </summary>
    [UnityEditor.CustomEditor(typeof(Comment), isFallback = true)]
    [CanEditMultipleObjects]
    public class CommentEditor : UnityEditor.Editor
    {
        [SerializeField] // Not sure if this is necessary
        private StyleSheet _styleSheet = null;

        private EditSession _editSession;
        private SerializedProperty _textProp;
        private VisualElement _contentContainer;

        public override VisualElement CreateInspectorGUI()
        {
            var root = CreateStyledRoot();

            _textProp = serializedObject.FindProperty(Comment.TextPropertyName);

            _contentContainer = new VisualElement();
            root.Add(_contentContainer);

            _editSession = new EditSession(target);

            if (ShouldStartInEditMode())
                StartEditing();
            else
                EndEditing();

            return root;

        }
        private void StartEditing()
        {
            _editSession.IsEditing = true;
            _contentContainer.RegisterCallback<KeyUpEvent>(HandleEndEditingKeyboardInput);
            ShowEditUI();
        }
        private void EndEditing()
        {
            _editSession.IsEditing = false;
            _contentContainer.UnregisterCallback<KeyUpEvent>(HandleEndEditingKeyboardInput);
            ShowCommentDisplay();
        }
        private void ShowEditUI()
        {
            _contentContainer.Clear();

            var textField = new TextField
            {
                // name = "unity-text-input",
                bindingPath = Comment.TextPropertyName,
                multiline = true,
                label = "Comment-Content"
            };
            _contentContainer.Add(textField);

            var dropDown = new EnumField
            {
                bindingPath = Comment.IconTypePropertyName,
                label = "Icon"
            };
            _contentContainer.Add(dropDown);

            var closeButton = new Button(EndEditing) { name = "end-editing-button" };
            closeButton.Add(new Label("End Editing"));
            _contentContainer.Add(closeButton);
            _contentContainer.Bind(serializedObject);

        }
        private void HandleEndEditingKeyboardInput(KeyUpEvent evt)
        {
            // End editing when the user presses Enter
            if (evt.ctrlKey == false)
                return;
            if (evt.keyCode == KeyCode.Return || evt.keyCode == KeyCode.KeypadEnter)
                EndEditing();
        }
        private void ShowCommentDisplay()
        {
            _contentContainer.Clear();

            var container = new VisualElement { name = "comment-display" };

            AddClickable(container, StartEditing, MouseButton.LeftMouse, clickCount: 2);
            AddClickable(container, OpenContextMenu, MouseButton.RightMouse, clickCount: 1);

            container.tooltip = "Double-click to edit .\n" +
                "Press CTRL + Enter/Return to end editing.";

            var icon = new IconField
            {
                bindingPath = Comment.IconTypePropertyName
            };
            //Debug.Log(icon.bindingPath);
            container.Add(icon);

            var label = new Label
            {
                name = "comment-text",
                bindingPath = Comment.TextPropertyName
            };
            //Debug.Log(label.bindingPath);
            container.Add(label);

            _contentContainer.Add(container);
            _contentContainer.Bind(serializedObject);
        }
        private void OpenContextMenu()
        {
            var menu = new GenericMenu();
            menu.AddItem(new GUIContent("Edit"), false, StartEditing);
            menu.ShowAsContext();
        }
        private void AddClickable(VisualElement container, Action action, MouseButton mouseButton, int clickCount)
        {
            var clickable = new Clickable(action);
            clickable.activators.Clear();
            clickable.activators.Add(new ManipulatorActivationFilter 
            { 
                button = mouseButton, 
                clickCount = clickCount 
            });
            container.AddManipulator(clickable);
        }
        private VisualElement CreateStyledRoot()
        {
            var root = new VisualElement { name = "root" }; // Object-Initializer Syntax

            if (_styleSheet != null)
                root.styleSheets.Add(_styleSheet);
            else
            {
                Debug.LogWarning("Style sheet reference is not set.");
                root.Insert(0, new HelpBox("Style sheet reference is not set.", HelpBoxMessageType.Error));
            }
            return root;
        }
        private bool ShouldStartInEditMode()
        {
            // Start editing when the component is first added or has no value set
            // or when the editor is enabled after assembly reload
            return string.IsNullOrEmpty(_textProp.stringValue) || _editSession.IsEditing;
        }
    }
}
