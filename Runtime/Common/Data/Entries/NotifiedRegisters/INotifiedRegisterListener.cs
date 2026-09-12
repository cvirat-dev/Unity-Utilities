using UUP.Common.Data.Arrays;
using System;

namespace UUP.Common.Data.Entries.NotifiedRegisters
{
    public interface INotifiedRegisterListener<TData> : IArrayListener<TData>
    {
        /// <summary>
        /// Notifies when a given Entry inside the Register has been emptied.
        /// </summary>
        public event Action<int> OnEmptyAt;

        /// <summary>
        /// Notifies when all Entries inside the Register have been emptied.
        /// </summary>
        public event Action OnEmptyAll;

        /// <summary>
        /// Notifies when any change has been made to the Register.
        /// </summary>
        public event Action OnAnyChange;

        /// <summary>
        /// Invokes the <see cref="OnEmptyAt"/> event.
        /// </summary>
        /// <param name="index"></param>
        public void OnEmptyAtHandler(int index);

        /// <summary>
        /// Invokes the <see cref="OnEmptyAll"/> event.
        /// </summary>
        public void OnEmptyAllHandler();

        /// <summary>
        /// Invokes the <see cref="OnAnyChange"/> event.
        /// </summary>
        public void OnAnyChangeHandler();
    }
}
