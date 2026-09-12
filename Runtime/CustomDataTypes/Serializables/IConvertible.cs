
namespace UUP.CustomDataTypes.Serializables
{
    public interface IConvertible<T>
    {
        public T Get();

        public void Set(T data);
    }
}
