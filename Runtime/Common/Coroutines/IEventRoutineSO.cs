
namespace UUP.Common.Coroutines
{
    public interface IEventRoutineSO<TRoutineAction> : IEventRoutineBase<TRoutineAction> where TRoutineAction : System.Delegate
    {
        bool IsSet { get; }
        void DetachAndReset();
    }
}
