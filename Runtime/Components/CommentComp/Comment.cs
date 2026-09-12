using UnityEngine;

namespace UUP.Components.CommentComp
{
    /// <summary>
    /// A component which adds a text for display in the inspector.
    /// </summary>
    public sealed class Comment : MonoBehaviour
    {
        public enum IconType
        {
            None,
            Info,
            Warning
        }

        [Tooltip("The text to display.")]
        [SerializeField]
        private string text = string.Empty;

        [Tooltip("The icon to show next to the text.")]
        [SerializeField]
        private IconType iconType = IconType.None;


        public static string TextPropertyName => nameof(text);
        public static string IconTypePropertyName => nameof(iconType);
    }
}
