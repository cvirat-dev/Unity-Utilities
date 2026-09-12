
namespace UUP.Debugging
{
    public interface IDebuggable
    {
        /// <summary>
        /// Logs details about the current state of the object.
        /// </summary>
        public void DebugState();
    }
}