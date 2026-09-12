
namespace UUP.Coroutines
{
    public delegate void ProgressRoutineHandler(float duration);
    public delegate void PeriodicRoutineHandler();
    public delegate bool ConditionRoutineHandler();
    public delegate void TimerRoutineHandler(int timeLeftInSeconds);
}
