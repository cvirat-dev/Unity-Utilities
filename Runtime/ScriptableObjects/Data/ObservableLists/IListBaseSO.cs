
namespace UUP.ScriptableObjects.Data.Lists
{
    public interface IListBaseSO<T>
    {
        /// <summary>
        /// Adds the specified value to the list.
        /// </summary>
        /// <param name="value"></param>
        public void AddItem(T value);

        /// <summary>
        /// Updates the value at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void UpdateItemAtIndex(int index, T value);

        /// <summary>
        /// Returns the value at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetItemAtIndex(int index);

        /// <summary>
        /// Removes the first occurrence of the specified value from the list.
        /// </summary>
        /// <param name="value"></param>
        public void RemoveItem(T value);

        /// <summary>
        /// Removes the last item from the list.
        /// </summary>
        public void RemoveLastItem();

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveItemAtIndex(int index);

        /// <summary>
        /// Removes all items from the list.
        /// </summary>
        public void Clear();

        /// <summary>
        /// Moves the item at the specified index to the new index.
        /// </summary>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        public void MoveItem(int fromIndex, int toIndex);

        /// <summary>
        /// Checks if the list contains the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value);

        /// <summary>
        /// Returns the number of items in the list.
        /// </summary>
        /// <returns></returns>
        public int GetLength();

        /// <summary>
        /// Returns the index of the first occurrence of the specified value in the list.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetIndexOf(T value);
    }
}