using MessagePack.Internal;

namespace MessagePack.Formatters
{
    public sealed class IgnoreFormatter<T> : IMessagePackFormatter<T>
    {
        public int Serialize(TargetBuffer target, T value, IFormatterResolver formatterResolver)
        {
            return MessagePackBinary.WriteNil(target);
        }

        public T Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
            return default(T);
        }
    }
}