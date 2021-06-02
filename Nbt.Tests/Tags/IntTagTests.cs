using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Snbt;
using Nbt.Tags;
using System.IO;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class IntTagTests {
        [TestMethod]
        public void IntTag_GetsCorrectTagType() {
            IntTag tag = new IntTag(0);
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.Int, tagType);
        }

        [TestMethod]
        public void IntTag_ReadsCorrectValue() {
            IntTag tag = new IntTag();
            byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            tag.Read(binaryReader);
            Assert.AreEqual(-2147483648, tag.Data);
        }

        [TestMethod]
        public void IntTag_WritesCorrectValue() {
            IntTag tag = new IntTag(-2147483648);
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            tag.Write(binaryWriter);
            byte[] data = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void IntTag_WritesCorrectSnbtValue() {
            IntTag tag = new IntTag(-2147483648);
            SnbtWriter snbtWriter = new SnbtWriter();

            tag.WriteSnbt(snbtWriter);
            Assert.AreEqual("-2147483648", snbtWriter.ToString());
        }
    }
}
