using System;
using System.Buffers;

namespace MessagePack.Internal
{
    internal sealed class BufferPool
    {
        public static readonly ArrayPool<byte> Default = new CustomPool();

        public static void Resize(ref byte[] array, int newSize)
        {
            if (newSize < 0) throw new ArgumentOutOfRangeException("newSize");

            byte[] array2 = array;
            if (array2 == null)
            {
                array = Default.Rent(newSize);
                return;
            }

            if (array2.Length != newSize)
            {
                byte[] array3 = Default.Rent(newSize);
                Buffer.BlockCopy(array2, 0, array3, 0, (array2.Length > newSize) ? newSize : array2.Length);
                array = array3;
                Default.Return(array2);
            }
        }
    }

    internal class CustomPool : ArrayPool<byte>
    {
        private const int SmallArrayBoundary = 65536;
        private static readonly ArrayPool<byte> smallArrays = ArrayPool<byte>.Create(SmallArrayBoundary, 100);
        private static readonly ArrayPool<byte> largeArrays = ArrayPool<byte>.Create(32 * 1024 * 1024, 20);

        public override byte[] Rent(int minimumLength)
        {
            if (minimumLength <= SmallArrayBoundary)
            {
                return smallArrays.Rent(minimumLength);
            }
            else
            {
                return largeArrays.Rent(minimumLength);
            }
        }

        public override void Return(byte[] array, bool clearArray = false)
        {
            if (array.Length <= SmallArrayBoundary)
            {
                smallArrays.Return(array, clearArray);
            }
            else
            {
                largeArrays.Return(array, clearArray);
            }
        }
    }
}
