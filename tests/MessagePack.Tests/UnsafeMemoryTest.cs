using MessagePack.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MessagePack.Tests
{
    public class UnsafeMemoryTest
    {
        delegate int WriteDelegate(TargetBuffer target, byte[] ys);

        [Theory]
        [InlineData('a', 1)]
        [InlineData('b', 10)]
        [InlineData('c', 100)]
        [InlineData('d', 1000)]
        [InlineData('e', 10000)]
        [InlineData('f', 100000)]
        public void GetEncodedStringBytes(char c, int count)
        {
            var s = new string(c, count);
            var bin1 = MessagePackBinary.GetEncodedStringBytes(s);
            var bin2 = MessagePackSerializer.Serialize(s);
            int size = 0;
            byte[] bin3 = SerializeHelpers.SerializeToByte(x => size = MessagePackBinary.WriteRaw(x, bin1));
            MessagePackBinary.FastResize(ref bin3, size);

            MessagePack.Internal.ByteArrayComparer.Equals(bin1, 0, bin1.Length, bin2).IsTrue();
            MessagePack.Internal.ByteArrayComparer.Equals(bin1, 0, bin1.Length, bin3).IsTrue();
        }

        [Fact]
        public void WriteRaw()
        {
            // x86
            for (int i = 1; i <= MessagePackRange.MaxFixStringLength; i++)
            {
                var src = Enumerable.Range(0, i).Select(x => (byte)x).ToArray();
                int len = 0;
                byte[] dst = SerializeHelpers.SerializeToByte(x => len = ((typeof(UnsafeMemory32).GetMethod("WriteRaw" + i)).CreateDelegate(typeof(WriteDelegate)) as WriteDelegate).Invoke(x, src));
                len.Is(i);
                MessagePackBinary.FastResize(ref dst, len);
                MessagePack.Internal.ByteArrayComparer.Equals(src, 0, src.Length, dst).IsTrue();
            }
            // x64
            for (int i = 1; i <= MessagePackRange.MaxFixStringLength; i++)
            {
                var src = Enumerable.Range(0, i).Select(x => (byte)x).ToArray();
                int len = 0;
                byte[] dst = SerializeHelpers.SerializeToByte(x => len = ((typeof(UnsafeMemory64).GetMethod("WriteRaw" + i)).CreateDelegate(typeof(WriteDelegate)) as WriteDelegate).Invoke(x, src));
                len.Is(i);
                MessagePackBinary.FastResize(ref dst, len);
                MessagePack.Internal.ByteArrayComparer.Equals(src, 0, src.Length, dst).IsTrue();
            }
            // x86, offset
            for (int i = 1; i <= MessagePackRange.MaxFixStringLength; i++)
            {
                var src = Enumerable.Range(0, i).Select(x => (byte)x).ToArray();
                int len = 0;
                byte[] dst = SerializeHelpers.SerializeToByte(x =>
                {
                    x.ReserveAndCommit(3, out byte[] b, out int o);
                    len = ((typeof(UnsafeMemory32).GetMethod("WriteRaw" + i)).CreateDelegate(typeof(WriteDelegate)) as WriteDelegate).Invoke(x, src);
                });
                len.Is(i);
                dst = dst.Skip(3).Take(len).ToArray();
                MessagePack.Internal.ByteArrayComparer.Equals(src, 0, src.Length, dst).IsTrue();
            }
            // x64, offset
            for (int i = 1; i <= MessagePackRange.MaxFixStringLength; i++)
            {
                var src = Enumerable.Range(0, i).Select(x => (byte)x).ToArray();
                int len = 0;
                byte[] dst = SerializeHelpers.SerializeToByte(x =>
                {
                    x.ReserveAndCommit(3, out byte[] b, out int o);
                    len = ((typeof(UnsafeMemory64).GetMethod("WriteRaw" + i)).CreateDelegate(typeof(WriteDelegate)) as WriteDelegate).Invoke(x, src);
                });
                len.Is(i);
                dst = dst.Skip(3).Take(len).ToArray();
                MessagePack.Internal.ByteArrayComparer.Equals(src, 0, src.Length, dst).IsTrue();
            }
        }
    }
}
