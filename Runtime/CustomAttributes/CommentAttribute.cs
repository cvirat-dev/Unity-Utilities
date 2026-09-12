using UnityEngine;

namespace UUP.CustomAttributes
{
    public class CommentAttribute : PropertyAttribute
    {
        public IconType IconType { get; }
        public bool StartInEditMode { get; }

        public CommentAttribute(IconType iconType = IconType.None, bool startInEditMode = false)
        {
            IconType = iconType;
            StartInEditMode = startInEditMode;
        }
    }
}
