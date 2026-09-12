using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace UUP.Utilities.Collections
{
    public static class CollectionUtilities
    {
        /// <summary>
        /// Throws an IndexOutOfRangeException if the index is out of bounds.
        /// Works for any collection that implements IReadOnlyCollection
        /// For example : List, Array, etc.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="index"></param>
        /// <param name="nameOfMethod"></param>
        /// <param name="callerFilePath"></param>
        public static void CheckIndexRange<T>(IReadOnlyCollection<T> collection, int index, string nameOfMethod = "unknown", [CallerFilePath] string callerFilePath = "")
        {
            if (index < 0 || index >= collection.Count)
            {
                string nameOfClass = Path.GetFileNameWithoutExtension(callerFilePath);
                throw new System.IndexOutOfRangeException($"Index out of bounds in {nameOfClass}.{nameOfMethod}. Index: {index}, Length: {collection.Count}");
            }
        }

        /// <summary>
        /// Returns true if the index is out of bounds.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool IsIndexOutOfBounds<T>(IReadOnlyCollection<T> collection, int index)
        {
            return index < 0 || index >= collection.Count;
        }
    }
}
