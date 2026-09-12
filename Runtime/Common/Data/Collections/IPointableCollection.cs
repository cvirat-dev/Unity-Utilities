
namespace UUP.Common.Data.Collections
{
    public interface IPointableCollection<T>
    {
        public int PointerIndex { get; }
        public bool HasErrorState { get; }

        /// <summary>
        /// Sets the pointer to the specified index.
        /// </summary>
        /// <param name="index"></param>
        public void SetPointer(int index);

        /// <summary>
        /// Returns the pointed element.
        /// </summary>
        /// <returns></returns>
        public T GetPointedElement();

        /// <summary>
        /// Moves the pointer to the next element.
        /// If Loop is true, the pointer will go back to the first element if it reaches the end of the array.
        /// </summary>
        /// <param name="loop"></param>
        public void MovePointerToNext(bool loop = true);

        /// <summary>
        /// Moves the pointer to the previous element.
        /// If Loop is true, the pointer will go back to the last element if it reaches the beginning of the array.
        /// </summary>
        /// <param name="loop"></param>
        public void MovePointerToPrevious(bool loop = true);

        /// <summary>
        /// Resets the pointer to the default value.
        /// </summary>
        public void ResetPointer();
    }
}