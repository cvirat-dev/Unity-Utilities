using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace UUP.EventManagement
{
    public class ChannelEvent<TEvent> where TEvent : UnityEventBase, new()
    {
        private readonly Dictionary<string, TEvent> _map = new();

        public Dictionary<string, TEvent> Map => _map;

        public TEvent Get(string channel = "")
        {
            _map.TryAdd(channel, new TEvent());
            return _map[channel];
        }
    }

    public class ChannelEvent<TEvent, TChannel>
        where TEvent : UnityEventBase, new()
        where TChannel : Enum
    {
        private readonly Dictionary<TChannel, TEvent> _map = new();

        public Dictionary<TChannel, TEvent> Map => _map;

        public TEvent Get(TChannel channel)
        {
            if (!_map.ContainsKey(channel))
            {
                _map.Add(channel, new TEvent());
            }
            return _map[channel];
        }
    }
}