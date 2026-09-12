
using UUP.Common.Data.Variables;
using System;

namespace UUP.Common.Data.Entries
{
    /// <summary>
    /// Represents an "entry" in analogy to an entry inside a Register or a Database
    /// The main informations are:
    ///  - The value of the entry
    ///  - The state of the entry (isDefined)
    ///  - The ID of the entry
    /// </summary>
    public interface IEntry<T> : INotifiedVariable<T>, IEntryControl, IEntryListener
    {
    }
}