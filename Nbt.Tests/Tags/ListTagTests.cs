using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Snbt;
using Nbt.Tags;
using System.IO;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class ListTagTests {
        [TestMethod]
        public void ListTag_GetsCorrectTagType() {
            ListTag tag = new ListTag();
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.List, tagType);
        }

        [TestMethod]
        public void ListTag_ReadsCorrectValue() {
            ListTag tag = new ListTag();
            byte[] data = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x01, 0x7F };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            tag.Read(binaryReader);
            Assert.AreEqual(1, tag.Count);
        }

        [TestMethod]
        public void ListTag_WritesCorrectValue() {
            ListTag tag = new ListTag();
            tag.Add(new ByteTag(127));
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            tag.Write(binaryWriter);
            byte[] data = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x01, 0x00, 0x00, 0x00, 0x01, 0x7F }, data);
        }

        [TestMethod]
        public void ListTag_AddReturnsTrue() {
            ListTag tag = new ListTag();
            tag.Add(new ByteTag(0));

            bool successful = tag.Add(new ByteTag(127));
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void ListTag_AddReturnsFalse_BecauseTagTypeIsIncorrect() {
            ListTag tag = new ListTag();
            tag.Add(new ByteTag(0));

            bool successful = tag.Add(new IntTag(1));
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void ListTag_AddReturnsFalse_BecauseTagIsNull() {
            ListTag tag = new ListTag();

            bool successful = tag.Add(null);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void ListTag_WritesCorrectSnbtValue() {
            ListTag tag = new ListTag();
            tag.Add(new ByteTag(127));
            tag.Add(new ByteTag(-128));
            SnbtWriter snbtWriter = new SnbtWriter();

            tag.WriteSnbt(snbtWriter);
            Assert.AreEqual("[127b,-128b]", snbtWriter.ToString());
        }
    }
}
