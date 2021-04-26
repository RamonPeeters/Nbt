using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;
using System.IO;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class LongTagTests {
        [TestMethod]
        public void LongTag_GetsCorrectTagType() {
            LongTag tag = new LongTag(0L);
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.Long, tagType);
        }

        [TestMethod]
        public void LongTag_ReadsCorrectValue() {
            LongTag tag = new LongTag();
            byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            tag.Read(binaryReader);
            Assert.AreEqual(-9223372036854775808L, tag.Data);
        }

        [TestMethod]
        public void LongTag_WritesCorrectValue() {
            LongTag tag = new LongTag(-9223372036854775808L);
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            tag.Write(binaryWriter);
            byte[] data = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, data);
        }
    }
}
