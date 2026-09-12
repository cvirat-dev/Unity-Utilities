
namespace UUP.Common.Data.Variables
{
    public interface ILerpedVariable<TData> : INotifiedVariable<TData>
    {
        void Lerp(float t);
    }
}
