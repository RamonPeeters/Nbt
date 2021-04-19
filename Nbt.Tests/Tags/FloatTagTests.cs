using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;
using System.IO;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class FloatTagTests {
        [TestMethod]
        public void FloatTag_GetsCorrectTagType() {
            FloatTag tag = new FloatTag(0.0f);
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.Float, tagType);
        }

        [TestMethod]
        public void FloatTag_ReadsCorrectValue() {
            FloatTag tag = new FloatTag();
            byte[] data = new byte[] { 0xBF, 0xC0, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            tag.Read(binaryReader);
            Assert.AreEqual(-1.5f, tag.Data);
        }
    }
}
