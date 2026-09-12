using UUP.ScriptableObjects.GameEvents;

namespace UUP.Components.Input.GameEvents
{
    public class MultiKeyEventController : MultiKeyEventControllerBase<GameEvent>
    {
        protected override void EventTriggerProcessor()
        {
            for(int i=0; i<InputKeys.Count; i++)
            {
                if (UnityEngine.Input.GetKeyDown(InputKeys[i]))
                {
                    GameEvents[i].Raise();
                }
            }
        }
    }
}