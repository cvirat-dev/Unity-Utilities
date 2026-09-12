using UUP.EventManagement;
using UnityEngine;
using UnityEngine.Events;

namespace UUP._ScriptTemplates.EventManagement
{
    /// <summary>
    /// Template for creating new EventManager files.
    /// </summary>
    /// <remarks>
    /// WARNING: This is a template file! Do not use this file in your project.
    /// Only "copy" the pattern of this file and paste it into a new file in your project.
    /// <see cref="https://www.youtube.com/watch?v=SHeSM0zFx_c&t=373s"/>
    /// </remarks>
    internal static class EventManagerTMPLT
    {
        public static WebSocketClientEvents WebSocketClient = new WebSocketClientEvents();
        public static UiEvents Ui = new();

        // WebSocket-Client-Events :  The WebsocketClient - Class listens to these events
        // This could look like this: EventManager.WebSocketClient.OnConnect.AddListener(OnConnect);
        // Another class, could also invoke the event like this: EventManager.WebSocketClient.OnConnect.Invoke();
        public class WebSocketClientEvents
        {
            public class ConnectEvent : UnityEvent { }
            public ChannelEvent<ConnectEvent> OnConnect = new();

            public class DisconnectEvent : UnityEvent { }
            public ChannelEvent<DisconnectEvent> OnDisconnect = new();

            public class MessageEventArgs : UnityEvent<string> { }
            public ChannelEvent<MessageEventArgs> OnMessage = new();

            public class CloseEventArgs : UnityEvent<Component, string> { }
            public ChannelEvent<CloseEventArgs> OnClose = new();

            public class ErrorEventArgs : UnityEvent<Component, string> { }
            public ChannelEvent<ErrorEventArgs> OnError = new();

        }

        // UI-Events :  The UI - Class listens to these events
        // This could look like this: EventManager.Ui.OnMessage.Get(EventManager.UiEvents.ChannelNames.StatusMessage).Invoke("Disconnected!");
        // Another class, could also invoke the event like this: EventManager.Ui.OnMessage.Get(EventManager.UiEvents.ChannelNames.StatusMessage).Invoke("Connected!");
        public class UiEvents
        {
            public class MessageEvent : UnityEvent<string> { }
            public ChannelEvent<MessageEvent, WebsocketChannelNames> OnMessage = new();
        }
    }
}