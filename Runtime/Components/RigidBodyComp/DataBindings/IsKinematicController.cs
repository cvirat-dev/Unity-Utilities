using UUP.Common.Components;
using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;

namespace UUP.Components.RigidBodyComp.DataBindings
{
    public class IsKinematicController : DataBindingController<Rigidbody, BoolVariableSO, bool>
    {
        protected override void Bind(bool data)
        {
            _component.isKinematic = data;
        }
    }
}
