using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;
using System.IO;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class DoubleTagTests {
        [TestMethod]
        public void DoubleTag_GetsCorrectTagType() {
            DoubleTag tag = new DoubleTag(0.0d);
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.Double, tagType);
        }

        [TestMethod]
        public void DoubleTag_ReadsCorrectValue() {
            DoubleTag tag = new DoubleTag();
            byte[] data = new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            tag.Read(binaryReader);
            Assert.AreEqual(-1.5d, tag.Data);
        }

        [TestMethod]
        public void DoubleTag_WritesCorrectValue() {
            DoubleTag tag = new DoubleTag(-1.5d);
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            tag.Write(binaryWriter);
            byte[] data = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, data);
        }
    }
}
