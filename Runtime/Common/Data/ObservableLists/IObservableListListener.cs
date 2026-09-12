using System;

namespace UUP.Common.Data.ObservableLists
{
    public interface IObservableListListener<TData>
    {
        /// <summary>
        /// param1 (int): index
        /// param2 (T): item
        /// </summary>
        event Action<int, TData> OnItemAdded;

        /// <summary>
        /// param1 (int): index
        /// param2 (T): item
        /// </summary>
        event Action<int, TData> OnItemModified;

        /// <summary>
        /// param1 (int): index
        /// param2 (T): item
        /// </summary>
        event Action<int, TData> OnItemRemoved;

        /// <summary>
        /// param1 (int): old index
        /// param2 (int): new index
        /// param3 (T): item
        /// </summary>
        event Action<int, int, TData> OnItemMoved;

        /// <summary>
        /// Event raised when the list is cleared.
        /// </summary>
        event Action OnCleared;

        /// <summary>
        /// Event raised when the list is changed:
        /// - item added
        /// - item modified
        /// - item removed
        /// - item moved
        /// - list cleared
        /// </summary>
        event Action OnListChanged;

        /// <summary>
        /// Event raised when an error occurs.
        /// For example, when index is out of range.
        /// </summary>
        event Action<string> OnError;
    }
}
