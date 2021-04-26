using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;
using System.IO;

namespace Nbt.Tests {
    [TestClass]
    public class NbtReaderTests {
        [TestMethod]
        public void NbtReader_ReadsCorrectRootName() {
            byte[] data = new byte[] { 0x01, 0x00, 0x03, 0x66, 0x6F, 0x6F, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using NbtReader nbtReader = new NbtReader(memoryStream, true);

            NbtRoot root = nbtReader.Read();
            string rootName = root.RootName;
            Assert.AreEqual("foo", rootName);
        }

        [TestMethod]
        public void NbtReader_ReadsCorrectTag() {
            byte[] data = new byte[] { 0x01, 0x00, 0x00, 0x7F };
            using MemoryStream memoryStream = new MemoryStream(data);
            using NbtReader nbtReader = new NbtReader(memoryStream, true);

            NbtRoot root = nbtReader.Read();
            Tag tag = root.Data;
            Assert.AreEqual(TagType.Byte, tag.GetTagType());
        }

        [TestMethod]
        public void NbtReader_ReadingRootTagShouldThrowException_BecauseTagTypeIsInvalid() {
            byte[] data = new byte[] { 0xFF, 0x00, 0x00, 0x7F };
            using MemoryStream memoryStream = new MemoryStream(data);
            using NbtReader nbtReader = new NbtReader(memoryStream, true);
            Assert.ThrowsException<InvalidTagTypeException>(nbtReader.Read);
        }
    }
}
