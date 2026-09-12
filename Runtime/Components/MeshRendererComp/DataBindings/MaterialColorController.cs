using UUP.Common.Components;
using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;

namespace UUP.Components.MeshRendererComp.DataBindings
{
    public class MaterialColorController : DataBindingController<MeshRenderer, ColorVariableSO, Color>
    {
        protected override void Bind(Color data)
        {
            _component.material.color = data;
        }
    }
}
