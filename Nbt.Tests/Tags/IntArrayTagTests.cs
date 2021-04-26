using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;
using System.IO;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class IntArrayTagTests {
        [TestMethod]
        public void IntArrayTag_GetsCorrectTagType() {
            IntArrayTag tag = new IntArrayTag();
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.IntArray, tagType);
        }

        [TestMethod]
        public void IntArrayTag_ReadsCorrectValue() {
            IntArrayTag tag = new IntArrayTag();
            byte[] data = new byte[] { 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x7F, 0xFF, 0xFF, 0xFF, 0x80, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            tag.Read(binaryReader);
            Assert.AreEqual(4, tag.Count);
        }

        [TestMethod]
        public void IntArrayTag_WritesCorrectValue() {
            IntArrayTag tag = new IntArrayTag(new int[] { 0, 2147483647, -2147483648, -1 });
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            tag.Write(binaryWriter);
            byte[] data = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x7F, 0xFF, 0xFF, 0xFF, 0x80, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF }, data);
        }
    }
}
