using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Snbt;
using Nbt.Tags;
using System.IO;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class ByteArrayTagTests {
        [TestMethod]
        public void ByteArrayTag_GetsCorrectTagType() {
            ByteArrayTag tag = new ByteArrayTag();
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.ByteArray, tagType);
        }

        [TestMethod]
        public void ByteArrayTag_ReadsCorrectValue() {
            ByteArrayTag tag = new ByteArrayTag();
            byte[] data = new byte[] { 0x00, 0x00, 0x00, 0x04, 0x00, 0x7F, 0x80, 0xFF };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            tag.Read(binaryReader);
            Assert.AreEqual(4, tag.Count);
        }

        [TestMethod]
        public void ByteArrayTag_WritesCorrectValue() {
            ByteArrayTag tag = new ByteArrayTag(new sbyte[] { 0, 127, -128, -1 });
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            tag.Write(binaryWriter);
            byte[] data = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x04, 0x00, 0x7F, 0x80, 0xFF }, data);
        }

        [TestMethod]
        public void ByteArrayTag_AddReturnsTrue() {
            ByteArrayTag tag = new ByteArrayTag();
            
            bool successful = tag.Add(new ByteTag(1));
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void ByteArrayTag_AddReturnsFalse_BecauseTagTypeIsIncorrect() {
            ByteArrayTag tag = new ByteArrayTag();

            bool successful = tag.Add(new StringTag("foo"));
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void ByteArrayTag_AddReturnsFalse_BecauseTagIsNull() {
            ByteArrayTag tag = new ByteArrayTag();

            bool successful = tag.Add(null);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void ByteArrayTag_WritesCorrectSnbtValue() {
            ByteArrayTag tag = new ByteArrayTag(new sbyte[] { 0, 127, -128, -1 });
            SnbtWriter snbtWriter = new SnbtWriter();

            tag.WriteSnbt(snbtWriter);
            Assert.AreEqual("[B;0b,127b,-128b,-1b]", snbtWriter.ToString());
        }
    }
}
