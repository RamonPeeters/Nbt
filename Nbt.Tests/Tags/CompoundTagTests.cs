using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Snbt;
using Nbt.Tags;
using System.Collections.Generic;
using System.IO;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class CompoundTagTests {
        [TestMethod]
        public void CompoundTag_GetsCorrectTagType() {
            CompoundTag tag = new CompoundTag();
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.Compound, tagType);
        }

        [TestMethod]
        public void CompoundTag_ReadsCorrectValue() {
            CompoundTag tag = new CompoundTag();
            byte[] data = new byte[] { 0x01, 0x00, 0x03, 0x66, 0x6F, 0x6F, 0x7F, 0x01, 0x00, 0x03, 0x62, 0x61, 0x72, 0x80, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            tag.Read(binaryReader);
            Assert.AreEqual(2, tag.Count);
        }

        [TestMethod]
        public void CompoundTag_WritesCorrectValue() {
            Dictionary<string, Tag> tags = new Dictionary<string, Tag>() { { "foo", new ByteTag(127) }, { "bar", new ByteTag(-128) } };
            CompoundTag tag = new CompoundTag(tags);
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            tag.Write(binaryWriter);
            byte[] data = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x01, 0x00, 0x03, 0x66, 0x6F, 0x6F, 0x7F, 0x01, 0x00, 0x03, 0x62, 0x61, 0x72, 0x80, 0x00 }, data);
        }

        [TestMethod]
        public void CompoundTag_WritesCorrectSnbtValue() {
            CompoundTag tag = new CompoundTag(new Dictionary<string, Tag>() {
                { "foo", new ByteTag(0) },
                { "bar", new IntTag(2147483647) },
                { "baz", new LongTag(-1L) }
            });
            SnbtWriter snbtWriter = new SnbtWriter();

            tag.WriteSnbt(snbtWriter);
            Assert.AreEqual("{foo:0b,bar:2147483647,baz:-1L}", snbtWriter.ToString());
        }
    }
}
