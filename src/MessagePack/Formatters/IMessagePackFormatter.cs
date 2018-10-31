
using MessagePack.Internal;

namespace MessagePack.Formatters
{
    // marker
    public interface IMessagePackFormatter
    {

    }

    public interface IMessagePackFormatter<T> : IMessagePackFormatter
    {
        int Serialize(TargetBuffer target, T value, IFormatterResolver formatterResolver);
        T Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize);
    }
}
