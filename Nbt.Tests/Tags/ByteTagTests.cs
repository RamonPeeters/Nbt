﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            tag.Read(binaryReader);
            Assert.AreEqual((sbyte)-128, tag.Data);
        }
    }
}
