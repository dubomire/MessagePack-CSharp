using System;
using Xunit;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedData;
using MessagePack.Internal;

namespace MessagePack.Tests
{
    public class MessagePackBinaryStream
    {
        delegate void RefAction(TargetBuffer target);

        [Fact]
        public void Write()
        {
            void Check(Action<Stream> streamAction, RefAction bytesAction)
            {
                const int CheckOffset = 10;

                var ms = new MemoryStream();
                ms.Position = CheckOffset;
                streamAction(ms);

                byte[] bytes = SerializeHelpers.SerializeToByte(x =>
                {
                    x.ReserveAndCommit(10, out byte[] b, out int o);
                    bytesAction(x);
                });

                ms.ToArray().Is(bytes);
            }

            Check(
                      (x) => MessagePackBinary.WriteArrayHeader(x, 999),
    (TargetBuffer target) => MessagePackBinary.WriteArrayHeader(target, 999));

            Check(
                      (x) => MessagePackBinary.WriteArrayHeaderForceArray32Block(x, 999),
    (TargetBuffer target) => MessagePackBinary.WriteArrayHeaderForceArray32Block(target, 999));

            Check(
                      (x) => MessagePackBinary.WriteBoolean(x, true),
    (TargetBuffer target) => MessagePackBinary.WriteBoolean(target, true));

            Check(
                      (x) => MessagePackBinary.WriteByte(x, (byte)100),
    (TargetBuffer target) => MessagePackBinary.WriteByte(target, (byte)100));

            Check(
                      (x) => MessagePackBinary.WriteByteForceByteBlock(x, (byte)11),
    (TargetBuffer target) => MessagePackBinary.WriteByteForceByteBlock(target, (byte)11));

            Check(
                      (x) => MessagePackBinary.WriteBytes(x, new byte[] { 1, 10, 100 }),
    (TargetBuffer target) => MessagePackBinary.WriteBytes(target, new byte[] { 1, 10, 100 }));

            Check(
                      (x) => MessagePackBinary.WriteChar(x, 'z'),
    (TargetBuffer target) => MessagePackBinary.WriteChar(target, 'z'));

            var now = DateTime.UtcNow;
            Check(
                      (x) => MessagePackBinary.WriteDateTime(x, now),
    (TargetBuffer target) => MessagePackBinary.WriteDateTime(target, now));

            Check(
                      (x) => MessagePackBinary.WriteDouble(x, 10.31231f),
    (TargetBuffer target) => MessagePackBinary.WriteDouble(target, 10.31231f));

            Check(
                      (x) => MessagePackBinary.WriteExtensionFormat(x, 10, new byte[] { 1, 10, 100 }),
    (TargetBuffer target) => MessagePackBinary.WriteExtensionFormat(target, 10, new byte[] { 1, 10, 100 }));

            Check(
                      (x) => MessagePackBinary.WriteFixedArrayHeaderUnsafe(x, 'z'),
    (TargetBuffer target) => MessagePackBinary.WriteFixedArrayHeaderUnsafe(target, 'z'));

            Check(
                      (x) => MessagePackBinary.WriteFixedMapHeaderUnsafe(x, 'z'),
    (TargetBuffer target) => MessagePackBinary.WriteFixedMapHeaderUnsafe(target, 'z'));

            Check(
                      (x) => MessagePackBinary.WriteFixedStringUnsafe(x, "aaa", Encoding.UTF8.GetByteCount("aaa")),
    (TargetBuffer target) => MessagePackBinary.WriteFixedStringUnsafe(target, "aaa", Encoding.UTF8.GetByteCount("aaa")));

            Check(
                      (x) => MessagePackBinary.WriteInt16(x, 321),
    (TargetBuffer target) => MessagePackBinary.WriteInt16(target, 321));

            Check(
                      (x) => MessagePackBinary.WriteInt16ForceInt16Block(x, 321),
    (TargetBuffer target) => MessagePackBinary.WriteInt16ForceInt16Block(target, 321));

            Check(
                      (x) => MessagePackBinary.WriteInt32(x, 321),
    (TargetBuffer target) => MessagePackBinary.WriteInt32(target, 321));

            Check(
                      (x) => MessagePackBinary.WriteInt32ForceInt32Block(x, 321),
    (TargetBuffer target) => MessagePackBinary.WriteInt32ForceInt32Block(target, 321));

            Check(
                      (x) => MessagePackBinary.WriteInt64(x, 321),
    (TargetBuffer target) => MessagePackBinary.WriteInt64(target, 321));

            Check(
                      (x) => MessagePackBinary.WriteInt64ForceInt64Block(x, 321),
    (TargetBuffer target) => MessagePackBinary.WriteInt64ForceInt64Block(target, 321));

            Check(
                      (x) => MessagePackBinary.WriteMapHeader(x, 321),
    (TargetBuffer target) => MessagePackBinary.WriteMapHeader(target, 321));

            Check(
                      (x) => MessagePackBinary.WriteMapHeaderForceMap32Block(x, 321),
    (TargetBuffer target) => MessagePackBinary.WriteMapHeaderForceMap32Block(target, 321));

            Check(
                      (x) => MessagePackBinary.WriteNil(x),
    (TargetBuffer target) => MessagePackBinary.WriteNil(target));

            Check(
                      (x) => MessagePackBinary.WritePositiveFixedIntUnsafe(x, 12),
    (TargetBuffer target) => MessagePackBinary.WritePositiveFixedIntUnsafe(target, 12));

            Check(
                      (x) => MessagePackBinary.WriteSByte(x, 12),
    (TargetBuffer target) => MessagePackBinary.WriteSByte(target, 12));

            Check(
                      (x) => MessagePackBinary.WriteSByteForceSByteBlock(x, 12),
    (TargetBuffer target) => MessagePackBinary.WriteSByteForceSByteBlock(target, 12));

            Check(
                      (x) => MessagePackBinary.WriteSingle(x, 123),
    (TargetBuffer target) => MessagePackBinary.WriteSingle(target, 123));

            Check(
                      (x) => MessagePackBinary.WriteString(x, "aaa"),
    (TargetBuffer target) => MessagePackBinary.WriteString(target, "aaa"));

            Check(
                      (x) => MessagePackBinary.WriteStringBytes(x, new byte[] { 1, 10 }),
    (TargetBuffer target) => MessagePackBinary.WriteStringBytes(target, new byte[] { 1, 10 }));

            Check(
                      (x) => MessagePackBinary.WriteStringForceStr32Block(x, "zzz"),
    (TargetBuffer target) => MessagePackBinary.WriteStringForceStr32Block(target, "zzz"));

            Check(
                      (x) => MessagePackBinary.WriteStringUnsafe(x, "zzz", Encoding.UTF8.GetByteCount("zzz")),
    (TargetBuffer target) => MessagePackBinary.WriteStringUnsafe(target, "zzz", Encoding.UTF8.GetByteCount("zzz")));

            Check(
                      (x) => MessagePackBinary.WriteUInt16(x, 31),
    (TargetBuffer target) => MessagePackBinary.WriteUInt16(target, 31));

            Check(
                      (x) => MessagePackBinary.WriteUInt16ForceUInt16Block(x, 32),
    (TargetBuffer target) => MessagePackBinary.WriteUInt16ForceUInt16Block(target, 32));

            Check(
                      (x) => MessagePackBinary.WriteUInt32(x, 11),
    (TargetBuffer target) => MessagePackBinary.WriteUInt32(target, 11));

            Check(
                      (x) => MessagePackBinary.WriteUInt32ForceUInt32Block(x, 11),
    (TargetBuffer target) => MessagePackBinary.WriteUInt32ForceUInt32Block(target, 11));

            Check(
                      (x) => MessagePackBinary.WriteUInt64(x, 11),
    (TargetBuffer target) => MessagePackBinary.WriteUInt64(target, 11));

            Check(
                      (x) => MessagePackBinary.WriteUInt64ForceUInt64Block(x, 11),
    (TargetBuffer target) => MessagePackBinary.WriteUInt64ForceUInt64Block(target, 11));
        }


        [Fact]
        public void Read()
        {
            void Check1<T, T2>(T data, T2 result, Func<Stream, T2> streamRead)
            {
                const int CheckOffset = 10;

                byte[] bytes = SerializeHelpers.SerializeToByte(x =>
                {
                    x.ReserveAndCommit(10, out byte[] b, out int o);
                    MessagePack.Resolvers.StandardResolver.Instance.GetFormatter<T>().Serialize(x, data, MessagePack.Resolvers.StandardResolver.Instance);
                });

                var ms = new MemoryStream(bytes);
                ms.Position = CheckOffset;

                streamRead(ms).Is(result);
            }

            void Check2<T>(T data, Func<Stream, T> streamRead)
            {
                const int CheckOffset = 10;

                byte[] bytes = SerializeHelpers.SerializeToByte(x =>
                {
                    x.ReserveAndCommit(10, out byte[] b, out int o);
                    MessagePack.Resolvers.StandardResolver.Instance.GetFormatter<T>().Serialize(x, data, MessagePack.Resolvers.StandardResolver.Instance);
                });

                var ms = new MemoryStream(bytes);
                ms.Position = CheckOffset;

                streamRead(ms).Is(data);
            }

            Check1(new[] { 1, 10, 100, 1000, 10000, short.MaxValue, int.MaxValue }, 7, x => MessagePackBinary.ReadArrayHeader(x));
            Check1(new[] { 1, 10, 100, 1000, 10000, short.MaxValue, int.MaxValue }, (uint)7, x => MessagePackBinary.ReadArrayHeaderRaw(x));
            Check1(Nil.Default, true, x => MessagePackBinary.IsNil((x)));
            Check2(true, x => MessagePackBinary.ReadBoolean(x));
            Check2((byte)100, x => MessagePackBinary.ReadByte(x));
            Check2(new byte[] { 1, 10, 100, 245 }, x => MessagePackBinary.ReadBytes(x));
            Check2('あ', x => MessagePackBinary.ReadChar(x));
            Check2(DateTime.UtcNow, x => MessagePackBinary.ReadDateTime(x));
            Check2(132, x => MessagePackBinary.ReadInt16(x));
            Check2(423, x => MessagePackBinary.ReadInt32(x));
            Check2(64332, x => MessagePackBinary.ReadInt64(x));
            Check2(Nil.Default, x => MessagePackBinary.ReadNil(x));
            Check2(11, x => MessagePackBinary.ReadSByte(x));
            Check2(10.31231f, x => MessagePackBinary.ReadSingle(x));
            Check2("foobar", x => MessagePackBinary.ReadString(x));
            Check2(124, x => MessagePackBinary.ReadUInt16(x));
            Check2((uint)432, x => MessagePackBinary.ReadUInt32(x));
            Check2((ulong)432, x => MessagePackBinary.ReadUInt64(x));


            Check1(new Dictionary<int, int>() { { 1, 2 } }, 1, x => MessagePackBinary.ReadMapHeader(x));
            Check1(new Dictionary<int, int>() { { 1, 2 } }, (uint)1, x => MessagePackBinary.ReadMapHeaderRaw(x));

            {
                var block = new object[] { 1, new[] { 1, 10, 100 }, 100 };
                var bytes = MessagePackSerializer.Serialize(block);
                var stream = new MemoryStream(bytes);
                MessagePackBinary.ReadNext(stream); // array(first)
                MessagePackBinary.ReadNext(stream); // int
                MessagePackBinary.ReadNextBlock(stream); // skip array
                MessagePackBinary.ReadInt32(stream).Is(100);
            }
            {
                var block = new object[] { 1, new Dictionary<int, int> { { 1, 10 }, { 111, 200 } }, 100 };
                var bytes = MessagePackSerializer.Serialize(block);
                var stream = new MemoryStream(bytes);
                MessagePackBinary.ReadNext(stream);
                MessagePackBinary.ReadNext(stream);
                MessagePackBinary.ReadNextBlock(stream);
                MessagePackBinary.ReadInt32(stream).Is(100);
            }
        }

        [Fact]
        public void Standard()
        {
            var o = new SimpleIntKeyData()
            {
                Prop1 = 100,
                Prop2 = ByteEnum.C,
                Prop3 = "abcde",
                Prop4 = new SimlpeStringKeyData
                {
                    Prop1 = 99999,
                    Prop2 = ByteEnum.E,
                    Prop3 = 3
                },
                Prop5 = new SimpleStructIntKeyData
                {
                    X = 100,
                    Y = 300,
                    BytesSpecial = new byte[] { 9, 99, 122 }
                },
                Prop6 = new SimpleStructStringKeyData
                {
                    X = 9999,
                    Y = new[] { 1, 10, 100 }
                },
                BytesSpecial = new byte[] { 1, 4, 6 }
            };


            var bytes = MessagePackSerializer.Serialize(o);
            var ms = new MemoryStream(bytes);

            MessagePackBinary.ReadArrayHeader(ms).Is(7);
            MessagePackBinary.ReadInt32(ms).Is(100);
            MessagePackBinary.ReadByte(ms).Is((byte)ByteEnum.C);
            MessagePackBinary.ReadString(ms).Is("abcde");

            MessagePackBinary.ReadMapHeader(ms).Is(3);
            MessagePackBinary.ReadString(ms).Is("Prop1");
            MessagePackBinary.ReadInt32(ms).Is(99999);
            MessagePackBinary.ReadString(ms).Is("Prop2");
            MessagePackBinary.ReadByte(ms).Is((byte)ByteEnum.E);
            MessagePackBinary.ReadString(ms).Is("Prop3");
            MessagePackBinary.ReadInt32(ms).Is(3);

            MessagePackBinary.ReadArrayHeader(ms).Is(3);
            MessagePackBinary.ReadInt32(ms).Is(100);
            MessagePackBinary.ReadInt32(ms).Is(300);
            MessagePackBinary.ReadBytes(ms).Is(new byte[] { 9, 99, 122 });

            MessagePackBinary.ReadMapHeader(ms).Is(2);
            MessagePackBinary.ReadString(ms).Is("key-X");
            MessagePackBinary.ReadInt32(ms).Is(9999);
            MessagePackBinary.ReadString(ms).Is("key-Y");
            MessagePackBinary.ReadArrayHeader(ms).Is(3);
            MessagePackBinary.ReadInt32(ms).Is(1);
            MessagePackBinary.ReadInt32(ms).Is(10);
            MessagePackBinary.ReadInt32(ms).Is(100);

            MessagePackBinary.ReadBytes(ms).Is(new byte[] { 1, 4, 6 });
        }

        [Fact]
        public void ReadStrictDeserialize()
        {
            var ms = new MemoryStream();
            MessagePackSerializer.Serialize(ms, new SimlpeStringKeyData
            {
                Prop1 = 99999,
                Prop2 = ByteEnum.E,
                Prop3 = 3
            });
            MessagePackSerializer.Serialize(ms, new SimpleStructStringKeyData
            {
                X = 9999,
                Y = new[] { 1, 10, 100 }
            });

            ms.Position = 0;

            var d = MessagePackSerializer.Deserialize<SimlpeStringKeyData>(ms, readStrict: true);
            d.Prop1.Is(99999); d.Prop2.Is(ByteEnum.E); d.Prop3.Is(3);

            var d2 = (SimpleStructStringKeyData)MessagePackSerializer.NonGeneric.Deserialize(typeof(SimpleStructStringKeyData), ms, readStrict: true);
            d2.X.Is(9999); d2.Y.Is(new[] { 1, 10, 100 });
        }

        [Fact]
        public void ReadStrictDeserializeLZ4()
        {
            var ms = new MemoryStream();
            LZ4MessagePackSerializer.Serialize(ms, new SimlpeStringKeyData
            {
                Prop1 = 99999,
                Prop2 = ByteEnum.E,
                Prop3 = 3
            });
            LZ4MessagePackSerializer.Serialize(ms, new string('a', 100000));
            LZ4MessagePackSerializer.Serialize(ms, new SimpleStructStringKeyData
            {
                X = 9999,
                Y = new[] { 1, 10, 100 }
            });

            ms.Position = 0;

            var d = LZ4MessagePackSerializer.Deserialize<SimlpeStringKeyData>(ms, readStrict: true);
            d.Prop1.Is(99999); d.Prop2.Is(ByteEnum.E); d.Prop3.Is(3);

            var ds = LZ4MessagePackSerializer.Deserialize<string>(ms, readStrict: true);
            ds.Is(new string('a', 100000));

            var d2 = (SimpleStructStringKeyData)LZ4MessagePackSerializer.NonGeneric.Deserialize(typeof(SimpleStructStringKeyData), ms, readStrict: true);
            d2.X.Is(9999); d2.Y.Is(new[] { 1, 10, 100 });
        }
    }
}
