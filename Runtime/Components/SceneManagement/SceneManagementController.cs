using UnityEngine;
using UnityEngine.SceneManagement;

namespace UUP.Components.SceneManagement
{
    public class SceneManagementController : MonoBehaviour
    {
        public void GoToNextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // if only one scene, log warning
            if (SceneManager.sceneCountInBuildSettings == 1)
            {
                Debug.LogWarning("Only one scene in build settings. Cannot go to next scene.");
                return;
            }

            if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }

        public void GoToPreviousScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            // if only one scene, log warning
            if (SceneManager.sceneCountInBuildSettings == 1)
            {
                Debug.LogWarning("Only one scene in build settings. Cannot go to previous scene.");
                return;
            }
            if (currentSceneIndex > 0)
            {
                SceneManager.LoadScene(currentSceneIndex - 1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
            }
        }

        public void GoToScene(int sceneIndex)
        {
            if (sceneIndex < 0 || sceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                Debug.LogWarning("Scene index out of range. Cannot go to scene.");
                return;
            }
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
