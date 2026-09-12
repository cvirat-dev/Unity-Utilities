using UnityEngine;

namespace UUP.ScriptableObjects.Data.ObservableLists
{
    public abstract class ListBaseSO : ScriptableObject
    {
        /// <summary>
        /// Adds the specified value to the list.
        /// </summary>
        /// <param name="value"></param>
        public abstract void AddItem(object value);

        /// <summary>
        /// Updates the value at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public abstract void UpdateItemAtIndex(int index, object value);

        /// <summary>
        /// Returns the value at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public abstract object GetItemAtIndex(int index);

        /// <summary>
        /// Removes the first occurrence of the specified value from the list.
        /// </summary>
        /// <param name="value"></param>
        public abstract void RemoveItem(object value);

        /// <summary>
        /// Removes the last item from the list.
        /// </summary>
        public abstract void RemoveLastItem();

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index"></param>
        public abstract void RemoveItemAtIndex(int index);

        /// <summary>
        /// Removes all items from the list.
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// Moves the item at the specified index to the new index.
        /// </summary>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        public abstract void MoveItem(int fromIndex, int toIndex);

        /// <summary>
        /// Checks if the list contains the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool Contains(object value);

        /// <summary>
        /// Returns the number of items in the list.
        /// </summary>
        /// <returns></returns>
        public abstract int GetLength();

        /// <summary>
        /// Returns the index of the first occurrence of the specified value in the list.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract int GetIndexOf(object value);
    }
}