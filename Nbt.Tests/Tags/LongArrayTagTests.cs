using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;
using System.IO;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class LongArrayTagTests {
        [TestMethod]
        public void LongArrayTag_GetsCorrectTagType() {
            LongArrayTag tag = new LongArrayTag();
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.LongArray, tagType);
        }

        [TestMethod]
        public void LongArrayTag_ReadsCorrectValue() {
            LongArrayTag tag = new LongArrayTag();
            byte[] data = new byte[] { 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            tag.Read(binaryReader);
            Assert.AreEqual(4, tag.Count);
        }

        [TestMethod]
        public void LongArrayTag_WritesCorrectValue() {
            LongArrayTag tag = new LongArrayTag(new long[] { 0, 9223372036854775807, -9223372036854775808, -1 });
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            tag.Write(binaryWriter);
            byte[] data = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, data);
        }

        [TestMethod]
        public void LongArrayTag_AddReturnsTrue() {
            LongArrayTag tag = new LongArrayTag();
            
            bool successful = tag.Add(new LongTag(1));
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void LongArrayTag_AddReturnsFalse_BecauseTagTypeIsIncorrect() {
            LongArrayTag tag = new LongArrayTag();
            
            bool successful = tag.Add(new StringTag("foo"));
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void LongArrayTag_AddReturnsFalse_BecauseTagIsNull() {
            LongArrayTag tag = new LongArrayTag();

            bool successful = tag.Add(null);
            Assert.IsFalse(successful);
        }
    }
}
