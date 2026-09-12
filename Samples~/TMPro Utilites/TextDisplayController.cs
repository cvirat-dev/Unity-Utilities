using TMPro;
using UnityEngine;

namespace PhiCAE.Samples.TMProUtilities
{
    public class TextDisplayController : MonoBehaviour
    {

        [SerializeField] private bool AddStaticTextContent;
        [SerializeField] private string StaticContent = " ";

        public bool BoolStaticContent
        {
            get { return AddStaticTextContent; }
        }

        private TMP_Text _textTMP;

        private void Awake()
        {
            _textTMP = GetComponent<TMP_Text>();

            if(_textTMP == null)
            {
                Debug.LogWarning("PhiCAE-EventSystem: TextMeshProUGUI-Component not found on this Gameobject!");
            }
        }

        public void DisplayFloatInput(Component sender, object data)
        {
            if (data is float floatData)
            {
                if (AddStaticTextContent)
                {
                    _textTMP.text = StaticContent + " " + floatData.ToString("F2");
                }

                else
                {
                    _textTMP.text = floatData.ToString("F2"); 
                }
            }
        }

    }
}
