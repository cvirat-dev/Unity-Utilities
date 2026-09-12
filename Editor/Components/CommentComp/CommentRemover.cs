using UUP.Components.CommentComp;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UUP.Editor.Components.CommentComp
{
    /// <summary>
    /// -removes comment components during the build process
    /// </summary>
    internal class CommentRemover : IProcessSceneWithReport, IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        private readonly List<GameObject> _sceneRoots = new List<GameObject>();
        private IRemovalReport _removalReport;

        public int callbackOrder => 0;

        // interface to receive a callback for each Scene during the build process
        // explicitly implemented to avoid accidental use
        // to call this method, cast an instance of this class to IProcessSceneWithReport
        void IProcessSceneWithReport.OnProcessScene(Scene scene, BuildReport report)
        {
            // The report is only valid during builds, but not during playmode
            // and comments should be preserved while testing the editor
            if (report == null)
                return;

            scene.GetRootGameObjects(_sceneRoots); // no need for left hand side assignment because lists are reference types

            foreach (var rootGameObject in _sceneRoots)
            {
                foreach(var comment in rootGameObject.GetComponentsInChildren<Comment>(includeInactive : true))
                {
                    _removalReport.Record(comment.gameObject);
                    Object.DestroyImmediate(comment);
                }
            }
        }

        // interface to receive a callback before the Player build is started
        void IPreprocessBuildWithReport.OnPreprocessBuild(BuildReport report)
        {
            if (CommentComponentSettings.LogRemovedComponents)
                _removalReport = new RemovalReport();
            else
                _removalReport = new NullReport();
        }

        // interface to receive a callback after the build is complete
        void IPostprocessBuildWithReport.OnPostprocessBuild(BuildReport report)
        {
            if (_removalReport.CreateMessage(out var message))
                Debug.Log(message);
        }
    }
}
