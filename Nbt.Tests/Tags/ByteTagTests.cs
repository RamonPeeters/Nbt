using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Snbt;
using Nbt.Tags;
using System.IO;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class ByteTagTests {
        [TestMethod]
        public void ByteTag_GetsCorrectTagType() {
            ByteTag tag = new ByteTag(0);
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.Byte, tagType);
        }

        [TestMethod]
        public void ByteTag_ReadsCorrectValue() {
            ByteTag tag = new ByteTag();
            byte[] data = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            tag.Read(binaryReader);
            Assert.AreEqual((sbyte)-128, tag.Data);
        }

        [TestMethod]
        public void ByteTag_WritesCorrectValue() {
            ByteTag tag = new ByteTag(-128);
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            tag.Write(binaryWriter);
            byte[] data = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80 }, data);
        }

        [TestMethod]
        public void ByteTag_WritesCorrectSnbtValue() {
            ByteTag tag = new ByteTag(-128);
            SnbtWriter snbtWriter = new SnbtWriter();

            tag.WriteSnbt(snbtWriter);
            Assert.AreEqual("-128b", snbtWriter.ToString());
        }
    }
}
