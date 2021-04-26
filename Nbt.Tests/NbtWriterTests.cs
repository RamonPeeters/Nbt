using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;
using System.IO;

namespace Nbt.Tests {
    [TestClass]
    public class NbtWriterTests {
        [TestMethod]
        public void NbtWriter_WritesCorrectly() {
            NbtRoot nbtRoot = new NbtRoot("foo", new ByteTag(127));
            using MemoryStream memoryStream = new MemoryStream();
            using NbtWriter nbtWriter = new NbtWriter(memoryStream, true);

            nbtWriter.Write(nbtRoot);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x01, 0x00, 0x03, 0x66, 0x6F, 0x6F, 0x7F }, data);
        }
    }
}
