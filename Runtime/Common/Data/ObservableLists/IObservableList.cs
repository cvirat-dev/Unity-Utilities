
namespace UUP.Common.Data.ObservableLists
{
    /// <summary>
    /// Describes : 
    ///     - The basic operations that can be performed on a list
    ///     - The different events that can be raised when the list is changed
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public interface IObservableList<TData> : IObservableListController<TData>, IObservableListListener<TData>
    {
    }
}