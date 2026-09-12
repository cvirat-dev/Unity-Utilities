using System.Collections.Generic;

namespace UUP.Common.Data.Entries.NotifiedRegisters
{
    public interface INotifiedRegisterController<TEntry, TData>
    {
        /// <summary>
        /// Returns the number of non -empty entries
        /// Reminder: Empty entries are not null, but they can have a default value
        /// </summary>
        public int NumberOfDefinedEntries { get; }

        /// <summary>
        /// Returns true if all registers are set
        /// Else returns false
        /// </summary>
        public bool IsFullyDefined { get; }

        /// <summary>
        /// Adds a value to the Entry at the specified index
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="index"></param>
        public void AddAt(TData entry, int index);

        /// <summary>
        /// Empty all entries
        /// </summary>
        public void EmptyAll();

        /// <summary>
        /// Empty the entry at the specified index
        /// </summary>
        /// <param name="index"></param>
        public void EmptyAt(int index);
        public List<TEntry> GetAllEmptyEntries();
        public List<TEntry> GetAllDefinedEntries();
        public int GetIndexOfFirstDefinedEntry();
        public int GetIndexOfFirstEmptyEntry();
        public int GetIndexOfNextDefinedEntry(int startIndex, bool loopMode);
        public int[] GetIndexesOfDefinedEntries();
        public int[] GetIndexesOfEmptyEntries();
        public bool IsEmptyAt(int index);
        public void DebugAllEntries();

    }
}
