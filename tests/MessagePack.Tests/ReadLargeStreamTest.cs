using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MessagePack.Tests
{
    public class ReadLargeStreamTest
    {
        [Fact]
        public void Large()
        {
            byte[][] allArrays = new byte[99][];
            for (int j = 0; j < 33; j++)
      {
        var bytesA = new byte[1310660];
        var bytesB = new byte[31072];
        var bytesC = new byte[1310660];
        for (int i = 0; i < bytesA.Length; i++)
        {
          bytesA[i] = 1;
          // bytesB[i] = 1;
          bytesC[i] = 1;
        }
        allArrays[j * 3] = bytesA;
        allArrays[j * 3 + 1] = bytesB;
        allArrays[j * 3 + 2] = bytesC;
      }

      var bin = MessagePackSerializer.Serialize(allArrays);
      Console.WriteLine("Total length: {0}", bin.Length);
            var ms = new MemoryStream(bin, 0, bin.Length, false, false);

            var foo = MessagePackSerializer.Deserialize<byte[][]>(ms, false);

            for (int i = 0; i < foo[0].Length; i++)
            {
                foo[0][i].Is((byte)1);
                // foo[1][i].Is((byte)1);
                foo[2][i].Is((byte)1);
            }
        }
    }
}
