using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using UUP.ScriptableObjects.GameEvents;

namespace UUP.EventManagement
{
    public abstract class AutoEventSubscriber : MonoBehaviourT
    {
        protected virtual void RegisterGameEvents()
        {
            Type type = GetType();
            IEnumerable<MethodInfo> methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Where(m => m.GetCustomAttribute<AutoSubscribeToGameEventAttribute>() != null);

            foreach (var method in methods)
            {
                AutoSubscribeToGameEventAttribute attribute = method.GetCustomAttribute<AutoSubscribeToGameEventAttribute>();
                FieldInfo eventField = type.GetField(attribute.GameEventName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                
                if(eventField == null)
                    throw new Exception($"Field {attribute.GameEventName} not found in {type.Name}");

                if (eventField.FieldType != typeof(GameEvent))
                    throw new Exception($"Field {attribute.GameEventName} is not of type {nameof(GameEvent)} in {type.Name} : {eventField.Name}");

                GameEvent gameEvent = eventField.GetValue(this) as GameEvent;
                gameEvent.OnEventRaised += (Action)Delegate.CreateDelegate(typeof(Action), this, method);
                Debug.Log($"Subscribed {method.Name} to {gameEvent.name} in { type.Name}");
            }
        }

        protected virtual void UnregisterGameEvents()
        {
            Type type = GetType();
            IEnumerable<MethodInfo> methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Where(m => m.GetCustomAttribute<AutoSubscribeToGameEventAttribute>() != null);
            foreach (var method in methods)
            {
                AutoSubscribeToGameEventAttribute attribute = method.GetCustomAttribute<AutoSubscribeToGameEventAttribute>();
                FieldInfo eventField = type.GetField(attribute.GameEventName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                if (eventField == null)
                    throw new Exception($"Field {attribute.GameEventName} not found in {type.Name}");
                if (eventField.FieldType != typeof(GameEvent))
                    throw new Exception($"Field {attribute.GameEventName} is not of type {nameof(GameEvent)} in {type.Name} : {eventField.Name}");
                GameEvent gameEvent = eventField.GetValue(this) as GameEvent;
                gameEvent.OnEventRaised -= (Action)Delegate.CreateDelegate(typeof(Action), this, method);
                Debug.Log($"Unsubscribed {method.Name} from {gameEvent.name} in { type.Name}");
            }
        }

        protected virtual void OnEnable() => RegisterGameEvents();
        protected virtual void OnDisable() => UnregisterGameEvents();
    }
}
