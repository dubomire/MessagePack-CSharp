#if NETSTANDARD

using System;
using System.Runtime.CompilerServices;

namespace MessagePack.Internal
{
    // for string key property name write optimization.

    public static class UnsafeMemory
    {
        public static readonly bool Is32Bit = (IntPtr.Size == 4);
    }

    public static partial class UnsafeMemory32
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int WriteRaw1(TargetBuffer target, byte[] src)
        {
            target.ReserveAndCommit(src.Length, out byte[] dst, out int dstOffset);

            fixed (byte* pSrc = &src[0])
            fixed (byte* pDst = &dst[dstOffset])
            {
                *(byte*)pDst = *(byte*)pSrc;
            }

            return src.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int WriteRaw2(TargetBuffer target, byte[] src)
        {
            target.ReserveAndCommit(src.Length, out byte[] dst, out int dstOffset);

            fixed (byte* pSrc = &src[0])
            fixed (byte* pDst = &dst[dstOffset])
            {
                *(short*)pDst = *(short*)pSrc;
            }

            return src.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int WriteRaw3(TargetBuffer target, byte[] src)
        {
            target.ReserveAndCommit(src.Length, out byte[] dst, out int dstOffset);

            fixed (byte* pSrc = &src[0])
            fixed (byte* pDst = &dst[dstOffset])
            {
                *(byte*)pDst = *(byte*)pSrc;
                *(short*)(pDst + 1) = *(short*)(pSrc + 1);
            }

            return src.Length;
        }
    }

    public static partial class UnsafeMemory64
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int WriteRaw1(TargetBuffer target, byte[] src)
        {
            target.ReserveAndCommit(src.Length, out byte[] dst, out int dstOffset);

            fixed (byte* pSrc = &src[0])
            fixed (byte* pDst = &dst[dstOffset])
            {
                *(byte*)pDst = *(byte*)pSrc;
            }

            return src.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int WriteRaw2(TargetBuffer target, byte[] src)
        {
            target.ReserveAndCommit(src.Length, out byte[] dst, out int dstOffset);

            fixed (byte* pSrc = &src[0])
            fixed (byte* pDst = &dst[dstOffset])
            {
                *(short*)pDst = *(short*)pSrc;
            }

            return src.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int WriteRaw3(TargetBuffer target, byte[] src)
        {
            target.ReserveAndCommit(src.Length, out byte[] dst, out int dstOffset);

            fixed (byte* pSrc = &src[0])
            fixed (byte* pDst = &dst[dstOffset])
            {
                *(byte*)pDst = *(byte*)pSrc;
                *(short*)(pDst + 1) = *(short*)(pSrc + 1);
            }

            return src.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int WriteRaw4(TargetBuffer target, byte[] src)
        {
            target.ReserveAndCommit(src.Length, out byte[] dst, out int dstOffset);

            fixed (byte* pSrc = &src[0])
            fixed (byte* pDst = &dst[dstOffset])
            {
                *(int*)(pDst + 0) = *(int*)(pSrc + 0);
            }

            return src.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int WriteRaw5(TargetBuffer target, byte[] src)
        {
            target.ReserveAndCommit(src.Length, out byte[] dst, out int dstOffset);

            fixed (byte* pSrc = &src[0])
            fixed (byte* pDst = &dst[dstOffset])
            {
                *(int*)(pDst + 0) = *(int*)(pSrc + 0);
                *(int*)(pDst + 1) = *(int*)(pSrc + 1);
            }

            return src.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int WriteRaw6(TargetBuffer target, byte[] src)
        {
            target.ReserveAndCommit(src.Length, out byte[] dst, out int dstOffset);

            fixed (byte* pSrc = &src[0])
            fixed (byte* pDst = &dst[dstOffset])
            {
                *(int*)(pDst + 0) = *(int*)(pSrc + 0);
                *(int*)(pDst + 2) = *(int*)(pSrc + 2);
            }

            return src.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int WriteRaw7(TargetBuffer target, byte[] src)
        {
            target.ReserveAndCommit(src.Length, out byte[] dst, out int dstOffset);

            fixed (byte* pSrc = &src[0])
            fixed (byte* pDst = &dst[dstOffset])
            {
                *(int*)(pDst + 0) = *(int*)(pSrc + 0);
                *(int*)(pDst + 3) = *(int*)(pSrc + 3);
            }

            return src.Length;
        }
    }
}

#endif