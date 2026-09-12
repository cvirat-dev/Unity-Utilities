
namespace UUP.Common.Events
{
    public interface ITGameEventController<TData>
    {
        void Raise(TData data);
    }
}
