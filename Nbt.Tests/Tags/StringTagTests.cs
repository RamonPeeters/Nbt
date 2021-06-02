using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Snbt;
using Nbt.Tags;
using System.IO;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class StringTagTests {
        [TestMethod]
        public void StringTag_GetsCorrectTagType() {
            StringTag tag = new StringTag("");
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.String, tagType);
        }

        [TestMethod]
        public void StringTag_ReadsCorrectValue() {
            StringTag tag = new StringTag();
            byte[] data = new byte[] { 0x00, 0x03, 0x66, 0x6F, 0x6F };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            tag.Read(binaryReader);
            Assert.AreEqual("foo", tag.Data);
        }

        [TestMethod]
        public void StringTag_WritesCorrectValue() {
            StringTag tag = new StringTag("foo");
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            tag.Write(binaryWriter);
            byte[] data = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x03, 0x66, 0x6F, 0x6F }, data);
        }

        [TestMethod]
        public void ByteTag_WritesCorrectSnbtValue() {
            StringTag tag = new StringTag("föö!");
            SnbtWriter snbtWriter = new SnbtWriter();

            tag.WriteSnbt(snbtWriter);
            Assert.AreEqual("\"föö!\"", snbtWriter.ToString());
        }

        [TestMethod]
        public void ByteTag_WritesCorrectSnbtValue_EvenWithSimpleString() {
            StringTag tag = new StringTag("foo");
            SnbtWriter snbtWriter = new SnbtWriter();

            tag.WriteSnbt(snbtWriter);
            Assert.AreEqual("\"foo\"", snbtWriter.ToString());
        }
    }
}
