using System;
using UnityEngine;

namespace UUP.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AutoSubscribeToGameEventAttribute : Attribute
    {
        public string GameEventName { get; }
        public AutoSubscribeToGameEventAttribute(string gameEventName)
        {
            GameEventName = gameEventName;
        }
    }
}
