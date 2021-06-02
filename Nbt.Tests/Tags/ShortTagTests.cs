using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Snbt;
using Nbt.Tags;
using System.IO;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class ShortTagTests {
        [TestMethod]
        public void ShortTag_GetsCorrectTagType() {
            ShortTag tag = new ShortTag(0);
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.Short, tagType);
        }

        [TestMethod]
        public void ShortTag_ReadsCorrectValue() {
            ShortTag tag = new ShortTag();
            byte[] data = new byte[] { 0x80, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            tag.Read(binaryReader);
            Assert.AreEqual((short)-32768, tag.Data);
        }

        [TestMethod]
        public void ShortTag_WritesCorrectValue() {
            ShortTag tag = new ShortTag(-32768);
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            tag.Write(binaryWriter);
            byte[] data = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00 }, data);
        }

        [TestMethod]
        public void ShortTag_WritesCorrectSnbtValue() {
            ShortTag tag = new ShortTag(-32768);
            SnbtWriter snbtWriter = new SnbtWriter();

            tag.WriteSnbt(snbtWriter);
            Assert.AreEqual("-32768s", snbtWriter.ToString());
        }
    }
}
