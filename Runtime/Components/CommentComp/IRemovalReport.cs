using UnityEngine;

namespace UUP.Components.CommentComp
{
    public interface IRemovalReport 
    {
        void Record(GameObject gameObject);
        bool CreateMessage(out string message);
    }
}
