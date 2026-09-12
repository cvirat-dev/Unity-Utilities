using System;

namespace UUP.Common.Data.Entries
{
    public interface IEntryListener
    {
        /// <summary>
        /// Raises whenever the state of the "entry" changes : isDefined or not
        /// If the entry is defined, the bool is true, otherwise it is false
        /// </summary>
        event Action<bool> OnStateChanged;

        /// <summary>
        /// Raises whenever the ID of the "entry" changes
        /// </summary>
        event Action<int> OnIDChanged;
    }
}
