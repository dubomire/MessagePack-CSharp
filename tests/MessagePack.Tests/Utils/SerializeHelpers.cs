using System;
using System.IO;
using MessagePack.Internal;

namespace MessagePack.Tests
{
    public static class SerializeHelpers
    {
        public static byte[] SerializeToByte(Action<TargetBuffer> s)
        {
            using (var target = new TargetBuffer())
            {
                s(target);
                var m = new MemoryStream();
                target.WriteTo(m);
                return m.ToArray();
            }
        }
    }
}
