using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.Utilities.DebugUtils
{
    public static class DebugDictUtils
    {
        /// <summary>
        /// Debug.Log() the content of a given <int, int> - dictionary
        /// </summary>
        /// <param name="dict"></param>
        public static void LogDictionaryIntIntContents(Dictionary<int, int> dict)
        {
            foreach (var kvp in dict)
            {
                int key = kvp.Key;
                int value = kvp.Value;

                // Use Debug.Log to print each key-value pair.
                Debug.Log("Key: " + key + ", Value: " + value);
            }
            Debug.Log("---------------------------------");
        }

        /// <summary>
        /// Debug.Log() the content of a given <int, int> - dictionary
        /// </summary>
        /// <param name="dict"></param>
        public static void LogDictionaryStringIntContents(Dictionary<string, int> dict)
        {
            foreach (var kvp in dict)
            {
                string key = kvp.Key;
                int value = kvp.Value;

                // Use Debug.Log to print each key-value pair.
                Debug.Log("Key: " + key + ", Value: " + value);
            }
            Debug.Log("---------------------------------");
        }

    }
}

