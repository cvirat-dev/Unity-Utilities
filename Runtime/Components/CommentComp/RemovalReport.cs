using UUP.Extensions;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace UUP.Components.CommentComp
{
    /// <summary>
    /// Collects and logs information about removed <see cref="Comment"/>
    /// </summary>
    public class RemovalReport : IRemovalReport
    {
        private readonly Dictionary<string, List<string>> _logInfo = new();

        /// <summary>
        /// Creates a message containing the paths of the removed comments
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool CreateMessage(out string message)
        {
            if (_logInfo.Count == 0)
            {
                message = string.Empty;
                return false;
            }

            var builder = new StringBuilder();
            builder.AppendLine("The following comments were removed during the build process:");
            builder.AppendLine();

            foreach (var sceneLog in _logInfo)
            {
                var sceneName = sceneLog.Key;
                List<string> removedCommentPaths = sceneLog.Value;

                builder.AppendLine($"Scene: {sceneName}");
                foreach (var path in removedCommentPaths)
                {
                    builder.Append(":::").AppendLine(path);
                }
                builder.AppendLine();
            }

            message = builder.ToString();
            return message.Length > 0;
        }

        /// <summary>
        /// Records the path of the <paramref name="gameObject"/> in the scene
        /// by adding it to the log of the scene it is in
        /// The scene log is a list of strings representing the paths of the removed comments
        /// Each scene log is stored in a dictionary with the scene name as the key
        /// </summary>
        /// <param name="gameObject">The GameObject with the <see cref="Comment"/> as Component</param>
        public void Record(GameObject gameObject)
        {
            string sceneName = gameObject.scene.name;

            // If the scene name is not in the dictionary, add it
            if (!_logInfo.TryGetValue(sceneName, out List<string> sceneLog))
            {
                sceneLog = new List<string>(); // The scene log is a list of strings representing the paths of the removed comments
                _logInfo.Add(sceneName, sceneLog);
            }

            string path = gameObject.transform.GetHierarchyPath();
            sceneLog.Add(path);
        }

    }
}
