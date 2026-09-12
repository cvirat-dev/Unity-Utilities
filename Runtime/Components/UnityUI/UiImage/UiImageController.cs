using UUP.Common.Components;
using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace UUP.Controllers.UnityUI.UiImage
{
    /// <summary>
    /// Useful for dynamic ui color changes
    /// </summary>
    public class UiImageController : DataBindingController<Image, ColorVariableSO, Color>
    {
        protected override void Bind(Color data)
        {
            _component.color = data;
        }
    }
}