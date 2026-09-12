using UnityEngine;

namespace UUP.CustomAttributes
{
    public class TitleAttribute : PropertyAttribute
    {
        public string Title { get; }
        public string Subtitle { get; }
        public TextAnchor Alignment { get; }
        public bool DrawLine { get; }
        public bool Bold { get; }

        public TitleAttribute(string title, string subtitle = "", TextAnchor alignment = TextAnchor.MiddleLeft, bool drawLine = true, bool bold = true)
        {
            Title = title;
            Subtitle = subtitle;
            Alignment = alignment;
            DrawLine = drawLine;
            Bold = bold;
        }
    }
}
