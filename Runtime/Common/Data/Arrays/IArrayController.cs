
namespace UUP.Common.Data.Arrays
{
    /// <summary>
    /// Describes the basic operations that can be performed on an array
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public interface IArrayController<TData>
    {
        /// <summary>
        /// Returns the length of the array
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Returns the array
        /// </summary>
        public TData[] Value { get; }

        /// <summary>
        /// Gets the value at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TData GetAt(int index);

        /// <summary>
        /// Sets the value at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetAt(int index, TData value);

        /// <summary>
        /// Sets all elements of the array to the values in the given array
        /// </summary>
        /// <param name="values"></param>
        public void SetAll(TData[] values);

        /// <summary>
        /// Gets all elements of the array
        /// </summary>
        /// <param name="destination"></param>
        public void GetAll(TData[] destination);

        /// <summary>
        /// Sets all elements of the array to the same value
        /// </summary>
        /// <param name="value"></param>
        public void SetAllToSame(TData value);
    }
}
