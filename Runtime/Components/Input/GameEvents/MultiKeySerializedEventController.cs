using UUP.Common.GameEvents;

namespace UUP.Components.Input.GameEvents
{
    public class MultiKeySerializedEventController<TSerializedGE> : MultiKeyEventControllerBase<TSerializedGE> 
        where TSerializedGE : ISerializedGameEventBase, new()
    {
        protected override void EventTriggerProcessor()
        {
            for (int i = 0; i < InputKeys.Count; i++)
            {
                if (UnityEngine.Input.GetKeyDown(InputKeys[i]))
                {
                    GameEvents[i].RaiseWithData();
                }
            }
        }

    }
}
