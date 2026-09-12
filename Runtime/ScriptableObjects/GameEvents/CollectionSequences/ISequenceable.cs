
namespace UUP.ScriptableObjects.GameEvents.CollectionSequences
{
    public interface ISequenceable
    {
        int CurrentIndex { get; }
        int Length { get; }
        bool StepForward();
        bool StepBackward();
        bool GoTo(int index);
        void SetIndex(int index);
        void ResetIndex();
    }
}