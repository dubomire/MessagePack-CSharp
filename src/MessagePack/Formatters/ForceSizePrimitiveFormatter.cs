using System;
using MessagePack.Internal;

namespace MessagePack.Formatters
{
    public sealed class ForceInt16BlockFormatter : IMessagePackFormatter<Int16>
    {
        public static readonly ForceInt16BlockFormatter Instance = new ForceInt16BlockFormatter();

        ForceInt16BlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, Int16 value, IFormatterResolver formatterResolver)
        {
            return MessagePackBinary.WriteInt16ForceInt16Block(target, value);
        }

        public Int16 Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            return MessagePackBinary.ReadInt16(bytes, offset, out readSize);
        }
    }

    public sealed class NullableForceInt16BlockFormatter : IMessagePackFormatter<Int16?>
    {
        public static readonly NullableForceInt16BlockFormatter Instance = new NullableForceInt16BlockFormatter();

        NullableForceInt16BlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, Int16? value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                return MessagePackBinary.WriteInt16ForceInt16Block(target, value.Value);
            }
        }

        public Int16? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                return MessagePackBinary.ReadInt16(bytes, offset, out readSize);
            }
        }
    }

    public sealed class ForceInt16BlockArrayFormatter : IMessagePackFormatter<Int16[]>
    {
        public static readonly ForceInt16BlockArrayFormatter Instance = new ForceInt16BlockArrayFormatter();

        ForceInt16BlockArrayFormatter()
        {

        }

        public int Serialize(TargetBuffer target, Int16[] value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                MessagePackBinary.WriteArrayHeader(target, value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    MessagePackBinary.WriteInt16ForceInt16Block(target, value[i]);
                }

                return 0;
            }
        }

        public Int16[] Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                var startOffset = offset;

                var len = MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
                offset += readSize;
                var array = new Int16[len];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = MessagePackBinary.ReadInt16(bytes, offset, out readSize);
                    offset += readSize;
                }
                readSize = offset - startOffset;
                return array;
            }
        }
    }

    public sealed class ForceInt32BlockFormatter : IMessagePackFormatter<Int32>
    {
        public static readonly ForceInt32BlockFormatter Instance = new ForceInt32BlockFormatter();

        ForceInt32BlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, Int32 value, IFormatterResolver formatterResolver)
        {
            return MessagePackBinary.WriteInt32ForceInt32Block(target, value);
        }

        public Int32 Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            return MessagePackBinary.ReadInt32(bytes, offset, out readSize);
        }
    }

    public sealed class NullableForceInt32BlockFormatter : IMessagePackFormatter<Int32?>
    {
        public static readonly NullableForceInt32BlockFormatter Instance = new NullableForceInt32BlockFormatter();

        NullableForceInt32BlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, Int32? value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                return MessagePackBinary.WriteInt32ForceInt32Block(target, value.Value);
            }
        }

        public Int32? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                return MessagePackBinary.ReadInt32(bytes, offset, out readSize);
            }
        }
    }

    public sealed class ForceInt32BlockArrayFormatter : IMessagePackFormatter<Int32[]>
    {
        public static readonly ForceInt32BlockArrayFormatter Instance = new ForceInt32BlockArrayFormatter();

        ForceInt32BlockArrayFormatter()
        {

        }

        public int Serialize(TargetBuffer target, Int32[] value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                MessagePackBinary.WriteArrayHeader(target, value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    MessagePackBinary.WriteInt32ForceInt32Block(target, value[i]);
                }

                return 0;
            }
        }

        public Int32[] Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                var startOffset = offset;

                var len = MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
                offset += readSize;
                var array = new Int32[len];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                    offset += readSize;
                }
                readSize = offset - startOffset;
                return array;
            }
        }
    }

    public sealed class ForceInt64BlockFormatter : IMessagePackFormatter<Int64>
    {
        public static readonly ForceInt64BlockFormatter Instance = new ForceInt64BlockFormatter();

        ForceInt64BlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, Int64 value, IFormatterResolver formatterResolver)
        {
            return MessagePackBinary.WriteInt64ForceInt64Block(target, value);
        }

        public Int64 Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            return MessagePackBinary.ReadInt64(bytes, offset, out readSize);
        }
    }

    public sealed class NullableForceInt64BlockFormatter : IMessagePackFormatter<Int64?>
    {
        public static readonly NullableForceInt64BlockFormatter Instance = new NullableForceInt64BlockFormatter();

        NullableForceInt64BlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, Int64? value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                return MessagePackBinary.WriteInt64ForceInt64Block(target, value.Value);
            }
        }

        public Int64? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                return MessagePackBinary.ReadInt64(bytes, offset, out readSize);
            }
        }
    }

    public sealed class ForceInt64BlockArrayFormatter : IMessagePackFormatter<Int64[]>
    {
        public static readonly ForceInt64BlockArrayFormatter Instance = new ForceInt64BlockArrayFormatter();

        ForceInt64BlockArrayFormatter()
        {

        }

        public int Serialize(TargetBuffer target, Int64[] value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                MessagePackBinary.WriteArrayHeader(target, value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    MessagePackBinary.WriteInt64ForceInt64Block(target, value[i]);
                }

                return 0;
            }
        }

        public Int64[] Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                var startOffset = offset;

                var len = MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
                offset += readSize;
                var array = new Int64[len];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = MessagePackBinary.ReadInt64(bytes, offset, out readSize);
                    offset += readSize;
                }
                readSize = offset - startOffset;
                return array;
            }
        }
    }

    public sealed class ForceUInt16BlockFormatter : IMessagePackFormatter<UInt16>
    {
        public static readonly ForceUInt16BlockFormatter Instance = new ForceUInt16BlockFormatter();

        ForceUInt16BlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, UInt16 value, IFormatterResolver formatterResolver)
        {
            return MessagePackBinary.WriteUInt16ForceUInt16Block(target, value);
        }

        public UInt16 Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            return MessagePackBinary.ReadUInt16(bytes, offset, out readSize);
        }
    }

    public sealed class NullableForceUInt16BlockFormatter : IMessagePackFormatter<UInt16?>
    {
        public static readonly NullableForceUInt16BlockFormatter Instance = new NullableForceUInt16BlockFormatter();

        NullableForceUInt16BlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, UInt16? value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                return MessagePackBinary.WriteUInt16ForceUInt16Block(target, value.Value);
            }
        }

        public UInt16? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                return MessagePackBinary.ReadUInt16(bytes, offset, out readSize);
            }
        }
    }

    public sealed class ForceUInt16BlockArrayFormatter : IMessagePackFormatter<UInt16[]>
    {
        public static readonly ForceUInt16BlockArrayFormatter Instance = new ForceUInt16BlockArrayFormatter();

        ForceUInt16BlockArrayFormatter()
        {

        }

        public int Serialize(TargetBuffer target, UInt16[] value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                MessagePackBinary.WriteArrayHeader(target, value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    MessagePackBinary.WriteUInt16ForceUInt16Block(target, value[i]);
                }

                return 0;
            }
        }

        public UInt16[] Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                var startOffset = offset;

                var len = MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
                offset += readSize;
                var array = new UInt16[len];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = MessagePackBinary.ReadUInt16(bytes, offset, out readSize);
                    offset += readSize;
                }
                readSize = offset - startOffset;
                return array;
            }
        }
    }

    public sealed class ForceUInt32BlockFormatter : IMessagePackFormatter<UInt32>
    {
        public static readonly ForceUInt32BlockFormatter Instance = new ForceUInt32BlockFormatter();

        ForceUInt32BlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, UInt32 value, IFormatterResolver formatterResolver)
        {
            return MessagePackBinary.WriteUInt32ForceUInt32Block(target, value);
        }

        public UInt32 Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            return MessagePackBinary.ReadUInt32(bytes, offset, out readSize);
        }
    }

    public sealed class NullableForceUInt32BlockFormatter : IMessagePackFormatter<UInt32?>
    {
        public static readonly NullableForceUInt32BlockFormatter Instance = new NullableForceUInt32BlockFormatter();

        NullableForceUInt32BlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, UInt32? value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                return MessagePackBinary.WriteUInt32ForceUInt32Block(target, value.Value);
            }
        }

        public UInt32? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                return MessagePackBinary.ReadUInt32(bytes, offset, out readSize);
            }
        }
    }

    public sealed class ForceUInt32BlockArrayFormatter : IMessagePackFormatter<UInt32[]>
    {
        public static readonly ForceUInt32BlockArrayFormatter Instance = new ForceUInt32BlockArrayFormatter();

        ForceUInt32BlockArrayFormatter()
        {

        }

        public int Serialize(TargetBuffer target, UInt32[] value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                MessagePackBinary.WriteArrayHeader(target, value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    MessagePackBinary.WriteUInt32ForceUInt32Block(target, value[i]);
                }

                return 0;
            }
        }

        public UInt32[] Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                var startOffset = offset;

                var len = MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
                offset += readSize;
                var array = new UInt32[len];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = MessagePackBinary.ReadUInt32(bytes, offset, out readSize);
                    offset += readSize;
                }
                readSize = offset - startOffset;
                return array;
            }
        }
    }

    public sealed class ForceUInt64BlockFormatter : IMessagePackFormatter<UInt64>
    {
        public static readonly ForceUInt64BlockFormatter Instance = new ForceUInt64BlockFormatter();

        ForceUInt64BlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, UInt64 value, IFormatterResolver formatterResolver)
        {
            return MessagePackBinary.WriteUInt64ForceUInt64Block(target, value);
        }

        public UInt64 Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            return MessagePackBinary.ReadUInt64(bytes, offset, out readSize);
        }
    }

    public sealed class NullableForceUInt64BlockFormatter : IMessagePackFormatter<UInt64?>
    {
        public static readonly NullableForceUInt64BlockFormatter Instance = new NullableForceUInt64BlockFormatter();

        NullableForceUInt64BlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, UInt64? value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                return MessagePackBinary.WriteUInt64ForceUInt64Block(target, value.Value);
            }
        }

        public UInt64? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                return MessagePackBinary.ReadUInt64(bytes, offset, out readSize);
            }
        }
    }

    public sealed class ForceUInt64BlockArrayFormatter : IMessagePackFormatter<UInt64[]>
    {
        public static readonly ForceUInt64BlockArrayFormatter Instance = new ForceUInt64BlockArrayFormatter();

        ForceUInt64BlockArrayFormatter()
        {

        }

        public int Serialize(TargetBuffer target, UInt64[] value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                MessagePackBinary.WriteArrayHeader(target, value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    MessagePackBinary.WriteUInt64ForceUInt64Block(target, value[i]);
                }

                return 0;
            }
        }

        public UInt64[] Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                var startOffset = offset;

                var len = MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
                offset += readSize;
                var array = new UInt64[len];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = MessagePackBinary.ReadUInt64(bytes, offset, out readSize);
                    offset += readSize;
                }
                readSize = offset - startOffset;
                return array;
            }
        }
    }

    public sealed class ForceByteBlockFormatter : IMessagePackFormatter<Byte>
    {
        public static readonly ForceByteBlockFormatter Instance = new ForceByteBlockFormatter();

        ForceByteBlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, Byte value, IFormatterResolver formatterResolver)
        {
            return MessagePackBinary.WriteByteForceByteBlock(target, value);
        }

        public Byte Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            return MessagePackBinary.ReadByte(bytes, offset, out readSize);
        }
    }

    public sealed class NullableForceByteBlockFormatter : IMessagePackFormatter<Byte?>
    {
        public static readonly NullableForceByteBlockFormatter Instance = new NullableForceByteBlockFormatter();

        NullableForceByteBlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, Byte? value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                return MessagePackBinary.WriteByteForceByteBlock(target, value.Value);
            }
        }

        public Byte? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                return MessagePackBinary.ReadByte(bytes, offset, out readSize);
            }
        }
    }


    public sealed class ForceSByteBlockFormatter : IMessagePackFormatter<SByte>
    {
        public static readonly ForceSByteBlockFormatter Instance = new ForceSByteBlockFormatter();

        ForceSByteBlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, SByte value, IFormatterResolver formatterResolver)
        {
            return MessagePackBinary.WriteSByteForceSByteBlock(target, value);
        }

        public SByte Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            return MessagePackBinary.ReadSByte(bytes, offset, out readSize);
        }
    }

    public sealed class NullableForceSByteBlockFormatter : IMessagePackFormatter<SByte?>
    {
        public static readonly NullableForceSByteBlockFormatter Instance = new NullableForceSByteBlockFormatter();

        NullableForceSByteBlockFormatter()
        {
        }

        public int Serialize(TargetBuffer target, SByte? value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                return MessagePackBinary.WriteSByteForceSByteBlock(target, value.Value);
            }
        }

        public SByte? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                return MessagePackBinary.ReadSByte(bytes, offset, out readSize);
            }
        }
    }

    public sealed class ForceSByteBlockArrayFormatter : IMessagePackFormatter<SByte[]>
    {
        public static readonly ForceSByteBlockArrayFormatter Instance = new ForceSByteBlockArrayFormatter();

        ForceSByteBlockArrayFormatter()
        {

        }

        public int Serialize(TargetBuffer target, SByte[] value, IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return MessagePackBinary.WriteNil(target);
            }
            else
            {
                MessagePackBinary.WriteArrayHeader(target, value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    MessagePackBinary.WriteSByteForceSByteBlock(target, value[i]);
                }

                return 0;
            }
        }

        public SByte[] Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }
            else
            {
                var startOffset = offset;

                var len = MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
                offset += readSize;
                var array = new SByte[len];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = MessagePackBinary.ReadSByte(bytes, offset, out readSize);
                    offset += readSize;
                }
                readSize = offset - startOffset;
                return array;
            }
        }
    }

}