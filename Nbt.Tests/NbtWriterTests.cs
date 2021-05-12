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
            using NbtWriter nbtWriter = new NbtWriter(memoryStream, true, NbtCompression.None);

            nbtWriter.Write(nbtRoot);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x01, 0x00, 0x03, 0x66, 0x6F, 0x6F, 0x7F }, data);
        }

        [TestMethod]
        public void NbtWriter_WritesCorrectly_WithGZipCompression() {
            NbtRoot nbtRoot = new NbtRoot("foo", new ByteTag(127));
            using MemoryStream memoryStream = new MemoryStream();
            using NbtWriter nbtWriter = new NbtWriter(memoryStream, true, NbtCompression.GZip);

            nbtWriter.Write(nbtRoot);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x1F, 0x8B, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0A, 0x62, 0x64, 0x60, 0x4E, 0xCB, 0xCF, 0xAF, 0x07, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x03, 0x00, 0x1D, 0x91, 0xA2, 0x03, 0x07, 0x00, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void NbtWriter_WritesCorrectly_WithZlibCompression() {
            NbtRoot nbtRoot = new NbtRoot("foo", new ByteTag(127));
            using MemoryStream memoryStream = new MemoryStream();
            using NbtWriter nbtWriter = new NbtWriter(memoryStream, true, NbtCompression.ZLib);

            nbtWriter.Write(nbtRoot);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x78, 0x9C, 0x62, 0x64, 0x60, 0x4E, 0xCB, 0xCF, 0xAF, 0x07, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x03, 0x00, 0x04, 0x5F, 0x01, 0xC8 }, data);
        }
    }
}
