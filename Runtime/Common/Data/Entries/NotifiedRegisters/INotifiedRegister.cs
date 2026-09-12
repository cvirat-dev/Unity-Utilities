using UUP.Common.Data.Arrays;

namespace UUP.Common.Data.Entries.NotifiedRegisters
{
    /// <summary>
    /// Represents a register of entries that can be notified of changes.
    /// </summary>
    /// <typeparam name="TEntry"></typeparam>
    /// <typeparam name="TData"></typeparam>
    public interface INotifiedRegister<TEntry, TData> : 
        INotifiedArray<TData>, 
        INotifiedRegisterController<TEntry, TData>,
        INotifiedRegisterListener<TData>
        where TEntry : IEntry<TData>
    {

    }
}