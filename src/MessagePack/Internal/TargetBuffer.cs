using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MessagePack.Internal
{
    public class TargetBuffer : IDisposable
    {
        private const int BufferSize = 65536;
        private List<byte[]> buffers = new List<byte[]>();
        private List<int> offsets = new List<int>();
        private int lastBufferIndex = -1;
        private byte[] lastBuffer = null;
        private int lastOffset = 0;
        private bool reservedNotCommitted = false;

        public int TotalBytes { get; private set; } = 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReserveAndCommit(int appendLength, out byte[] bytes, out int offset)
        {
            Reserve(appendLength, out bytes, out offset);
            Commit(appendLength);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reserve(int appendLength, out byte[] bytes, out int offset)
        {
            if (reservedNotCommitted)
            {
                throw new InvalidOperationException("TargetBuffer.Reserve() method was called twice without Commit()");
            }
            if (lastBuffer == null)
            {
                AddNewBuffer(appendLength <= BufferSize ? BufferSize : appendLength);
            }
            else
            {
                // Data will not fit
                if (lastBuffer.Length - lastOffset < appendLength)
                {
                    AddNewBuffer(appendLength <= BufferSize ? BufferSize : appendLength);
                }
            }
            // Here we're sure that data will fit into the last buffer.
            bytes = lastBuffer;
            offset = lastOffset;
            reservedNotCommitted = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Commit(int appendLength)
        {
            if (!reservedNotCommitted)
            {
                throw new InvalidOperationException("TargetBuffer.Commit() method was called without preceding Reserve()");
            }
            offsets[lastBufferIndex] += appendLength;
            lastOffset += appendLength;
            TotalBytes += appendLength;
            reservedNotCommitted = false;
        }

        public void WriteTo(System.IO.Stream stream)
        {
            for (int i = 0; i <= lastBufferIndex; i++)
            {
                stream.Write(buffers[i], 0, offsets[i]);
            }
            DiscardBuffers();
        }

        public async Task WriteToAsync(System.IO.Stream stream)
        {
            for (int i = 0; i <= lastBufferIndex; i++)
            {
                await stream.WriteAsync(buffers[i], 0, offsets[i]).ConfigureAwait(false);
            }
            DiscardBuffers();
        }

        public void Append(TargetBuffer src)
        {
            // Try to append first blocks into the last block of the current TargetBuffer.
            int startBuffer = 0;
            if (lastBufferIndex != -1)
            {
                while (startBuffer <= src.lastBufferIndex && src.offsets[startBuffer] < buffers[lastBufferIndex].Length - offsets[lastBufferIndex])
                {
                    Buffer.BlockCopy(src.buffers[startBuffer], 0, buffers[lastBufferIndex], offsets[lastBufferIndex], src.offsets[startBuffer]);
                    offsets[lastBufferIndex] += src.offsets[startBuffer];
                    TotalBytes += src.offsets[startBuffer];
                    startBuffer++;
                }
            }
            // Just copy other buffers
            for (int i = startBuffer; i <= src.lastBufferIndex; i++)
            {
                lastBufferIndex++;
                buffers.Add(src.buffers[i]);
                offsets.Add(src.offsets[i]);
                TotalBytes += src.offsets[i];
            }
            src.DiscardBuffers();
        }

        public void WriteTo(ref byte[] bytes, int offset)
        {
            if (bytes.Length - offset < TotalBytes)
            {
                throw new InvalidOperationException($"Cannot fit data of {TotalBytes} bytes into rest space of {bytes.Length - offset}.");
            }
            int currentOffset = offset;
            for (int i = 0; i <= lastBufferIndex; i++)
            {
                Buffer.BlockCopy(buffers[i], 0, bytes, currentOffset, offsets[i]);
                currentOffset += offsets[i];
            }
            DiscardBuffers();
        }

        public void Dispose()
        {
            DiscardBuffers();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AddNewBuffer(int size)
        {
            lastBufferIndex++;
            lastBuffer = BufferPool.Default.Rent(size);
            buffers.Add(lastBuffer);
            lastOffset = 0;
            offsets.Add(0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void DiscardBuffers()
        {
            if (buffers != null)
            {
                foreach (var buffer in buffers)
                {
                    BufferPool.Default.Return(buffer, true);
                }
            }
            buffers = null;
            offsets = null;
            TotalBytes = 0;
            lastBufferIndex = -1;
            lastBuffer = null;
            lastOffset = 0;
        }
    }
}
