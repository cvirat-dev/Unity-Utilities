using UUP.Common.Components;
using UUP.ScriptableObjects.Data.Variables;
using UnityEngine.UI;

namespace UUP.Components.UnityUI.UiText
{
    public class UiTextController : DataBindingController<Text, StringVariableSO, string>
    {
        protected override void Bind(string data)
        {
            _component.text = data;
        }
    }
}