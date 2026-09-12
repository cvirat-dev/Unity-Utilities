using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.Components.CommentComp
{
    /// <summary>
    /// Used when the report option is disabled.
    /// </summary>
    /// <remarks>
    /// Because <see cref="Record"/> might be called many times in larger projects
    /// This null object pattern implemtation can save some performance over
    /// checking agains the options in an if statement.
    /// </remarks>
    public class NullReport : IRemovalReport
    {
        public bool CreateMessage(out string message)
        {
            message = null;
            return false;
        }

        public void Record(GameObject gameObject)
        {
            // do nothing
            return;
        }
    }
}
