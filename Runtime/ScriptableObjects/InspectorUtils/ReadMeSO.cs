using System;
using UnityEngine;

namespace UUP.ScriptableObjects.InspectorUtils
{
    [CreateAssetMenu(menuName = "UUP/ReadMe", fileName = "ReadMe", order = 1)]
    public class Readme : ScriptableObject
    {
        public Texture2D icon;
        public string title;
        public Section[] sections;
        public bool loadedLayout;

        [Serializable]
        public class Section
        {
            public string heading, text, linkText, url;
        }
    }
}