using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Snbt;
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
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            tag.Read(binaryReader);
            Assert.AreEqual(-1.5f, tag.Data);
        }

        [TestMethod]
        public void FloatTag_WritesCorrectValue() {
            FloatTag tag = new FloatTag(-1.5f);
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            tag.Write(binaryWriter);
            byte[] data = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0xBF, 0xC0, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void FloatTag_WritesCorrectSnbtValue() {
            FloatTag tag = new FloatTag(-1.5f);
            SnbtWriter snbtWriter = new SnbtWriter();

            tag.WriteSnbt(snbtWriter);
            Assert.AreEqual("-1.5f", snbtWriter.ToString());
        }
    }
}
