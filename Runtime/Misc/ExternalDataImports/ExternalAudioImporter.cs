using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace UUP.Misc.ExternalDataImports
{
    /// <summary>
    /// This class handles importing an audio file from a specified folder path within the project directory and assigns it to an AudioSource component attached to the same GameObject.
    /// Audio-Source-Component needs to be attached to same Gameobject!
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class ExternalAudioImporter : MonoBehaviourT
    {
        [Tooltip("Gesamtname der Audiodatei, ohne Endung!")]
        [SerializeField] private string soundFileName = "sound";

        [Tooltip("Audioformat der AudioDatei")]
        [SerializeField] private AudioType audioType;

        [Tooltip("Ordner-Name in dem sich die Audiodatei befindet")]
        [SerializeField] private string customSoundsPath = "CustomSounds";

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            ImportAudio();
        }

        public void OnImportAudioGE(Component sender, object data)
        {
            ImportAudio();
        }

        [InspectorButton]
        public void ImportAudio()
        {
            string customPath = Path.Combine(Application.dataPath, customSoundsPath);

            if (!Directory.Exists(customPath))
            {
                Directory.CreateDirectory(customPath);
                Debug.LogWarning("Folder created, but audio file is missing. Please add one.");
                return;
            }

            string fileNameWithEnding = soundFileName + "." + audioType.ToString().ToLower();

            string soundFileUrl = Path.Combine(customPath, fileNameWithEnding);

            Debug.Log(soundFileUrl);

            StartCoroutine(GetAudioClip(soundFileUrl));
        }

        IEnumerator GetAudioClip(string path)
        {
            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + path, audioType))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);

                    if (myClip != null)
                    {
                        _audioSource.clip = myClip;
                    }
                    else
                    {
                        Debug.LogWarning("Audio clip not found!");
                    }
                }
            }
        }
    }
}