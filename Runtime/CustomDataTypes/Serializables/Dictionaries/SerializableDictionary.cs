using System;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.CustomDataTypes.Serializables.Dictionaries
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue>
    {
        [SerializeField]
        private List<SerializableKeyValuePair<TKey, TValue>> entries = new();

        public void Add(TKey key, TValue value)
        {
            entries.Add(new SerializableKeyValuePair<TKey, TValue>(key, value));
        }

        public TValue Get(TKey key) {
            foreach (var entry in entries) {
                if (entry.Key.Equals(key)) {
                    return entry.Value;
                }
            }
            return default;
        }

        /// <summary>
        /// Rebuild a dictionary for runtime usage
        /// </summary>
        /// <returns></returns>
        public Dictionary<TKey, TValue> ToDictionary()
        {
            var dictionary = new Dictionary<TKey, TValue>();
            foreach (var entry in entries)
            {
                dictionary[entry.Key] = entry.Value;
            }
            return dictionary;
        }
    }
}