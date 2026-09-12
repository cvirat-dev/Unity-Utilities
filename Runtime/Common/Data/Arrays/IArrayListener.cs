using System;

namespace UUP.Common.Data.Arrays
{
    public interface IArrayListener<TData>
    {
        /// <summary>
        /// Notifies when a new value (a new value/reference which is not equal to the previous one) has been set inside an item of the array.
        /// </summary>
        public event Action<int, TData> OnNewValue;

        /// <summary>
        /// Invokes the <see cref="OnNewValue"/> event.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void OnNewValueHandler(int index, TData data);

    }
}
