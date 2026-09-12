using UUP.Common.Components;
using UUP.CustomDataTypes.Serializables;
using UUP.Enums;
using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;

namespace UUP.Components.TransformComp.DataBindings
{
    public class SpatialOrientationController : DataBindingController<Transform, SpatialOrientationVariableSO, SpatialOrientationSRZ>
    {
        [SerializeField]
        WorldType worldType = WorldType.Global;

        protected override void Bind(SpatialOrientationSRZ data)
        {
            switch(worldType)
            {
                case WorldType.Global:
                    _component.position = data.Get().Position;
                    _component.rotation = data.Get().Rotation;
                    break;
                case WorldType.Local:
                    _component.localPosition = data.Get().Position;
                    _component.localRotation = data.Get().Rotation;
                    break;
            }
        }
    }
}
