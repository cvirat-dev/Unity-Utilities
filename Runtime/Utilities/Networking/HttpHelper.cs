using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace UUP.Utilities.Networking
{
    /// <summary>
    /// A static helper class for making HTTP requests using UnityWebRequest.
    /// </summary>
    public static class HttpHelper
    {
        /// <summary>
        /// Sends a GET request to the specified URI and invokes the callback with the response.
        /// </summary>
        /// <param name="uri">The URI to send the GET request to.</param>
        /// <param name="callback">The callback to invoke with the response text or an error message.</param>
        /// <returns>An IEnumerator for use with Unity's coroutine system.</returns>
        public static IEnumerator Get(string uri, System.Action<string> callback)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"GET Error: {webRequest.error}");
                    callback?.Invoke("error");
                }
                else
                {
                    callback?.Invoke(webRequest.downloadHandler.text);
                }
            }
        }

        /// <summary>
        /// Sends a POST request to the specified URI with the provided JSON data.
        /// </summary>
        /// <param name="uri">The URI to send the POST request to.</param>
        /// <param name="jsonData">The JSON data to include in the POST request body.</param>
        /// <param name="callback">The callback to invoke with the response text or an error message.</param>
        /// <returns>An IEnumerator for use with Unity's coroutine system.</returns>
        public static IEnumerator Post(string uri, string jsonData, System.Action<string> callback)
        {
            using (UnityWebRequest webRequest = new UnityWebRequest(uri, "POST"))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
                webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
                webRequest.downloadHandler = new DownloadHandlerBuffer();
                webRequest.SetRequestHeader("Content-Type", "application/json");

                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"POST Error: {webRequest.error}");
                }
                else
                {
                    callback?.Invoke(webRequest.downloadHandler.text);
                }
            }
        }

        /// <summary>
        /// Sends a PUT request to the specified URI with the provided JSON data.
        /// </summary>
        /// <param name="uri">The URI to send the PUT request to.</param>
        /// <param name="jsonData">The JSON data to include in the PUT request body.</param>
        /// <param name="callback">The callback to invoke with the response text or an error message.</param>
        /// <returns>An IEnumerator for use with Unity's coroutine system.</returns>
        public static IEnumerator Put(string uri, string jsonData, System.Action<string> callback)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Put(uri, jsonData))
            {
                webRequest.SetRequestHeader("Content-Type", "application/json");

                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"PUT Error: {webRequest.error}");
                }
                else
                {
                    callback?.Invoke(webRequest.downloadHandler.text);
                }
            }
        }

        /// <summary>
        /// Sends a DELETE request to the specified URI.
        /// </summary>
        /// <param name="uri">The URI to send the DELETE request to.</param>
        /// <param name="callback">The callback to invoke with the response text or an error message.</param>
        /// <returns>An IEnumerator for use with Unity's coroutine system.</returns>
        public static IEnumerator Delete(string uri, System.Action<string> callback)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Delete(uri))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"DELETE Error: {webRequest.error}");
                }
                else
                {
                    callback?.Invoke(webRequest.downloadHandler.text);
                }
            }
        }
    }
}
