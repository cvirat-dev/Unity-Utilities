using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;

namespace UUP
{
    public class MonoBehaviourTWithComment : MonoBehaviourT
    {
        [Comment(IconType.Info)]
        protected string InfoMessage = "This is a info message";    

        [Comment(IconType.Warning)]
        protected string WarningMessage = "This is a warning message";
    }
}
