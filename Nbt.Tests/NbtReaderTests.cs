using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;
using System;
using System.IO;

namespace Nbt.Tests {
    [TestClass]
    public class NbtReaderTests {
        [TestMethod]
        public void NbtReader_ReadsCorrectRootName() {
            byte[] data = new byte[] { 0x01, 0x00, 0x03, 0x66, 0x6F, 0x6F, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using NbtReader nbtReader = new NbtReader(memoryStream, true, NbtCompression.None);

            NbtRoot root = nbtReader.Read();
            string rootName = root.RootName;
            Assert.AreEqual("foo", rootName);
        }

        [TestMethod]
        public void NbtReader_ReadsCorrectTag() {
            byte[] data = new byte[] { 0x01, 0x00, 0x00, 0x7F };
            using MemoryStream memoryStream = new MemoryStream(data);
            using NbtReader nbtReader = new NbtReader(memoryStream, true, NbtCompression.None);

            NbtRoot root = nbtReader.Read();
            Tag tag = root.Data;
            Assert.AreEqual(TagType.Byte, tag.GetTagType());
        }

        [TestMethod]
        public void NbtReader_ReadingRootTagShouldThrowException_BecauseTagTypeIsInvalid() {
            byte[] data = new byte[] { 0xFF, 0x00, 0x00, 0x7F };
            using MemoryStream memoryStream = new MemoryStream(data);
            using NbtReader nbtReader = new NbtReader(memoryStream, true, NbtCompression.None);
            Assert.ThrowsException<InvalidTagTypeException>(nbtReader.Read);
        }

        [TestMethod]
        public void NbtReader_ReadsCorrectRootName_WithGZipCompression() {
            byte[] data = new byte[] { 0x1F, 0x8B, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0A, 0x62, 0x64, 0x60, 0x4E, 0xCB, 0xCF, 0x67, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x03, 0x00, 0xB0, 0xFD, 0x18, 0xC3, 0x07, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using NbtReader nbtReader = new NbtReader(memoryStream, true, NbtCompression.GZip);

            NbtRoot root = nbtReader.Read();
            string rootName = root.RootName;
            Assert.AreEqual("foo", rootName);
        }

        [TestMethod]
        public void NbtReader_ReadsCorrectRootName_WithZLibCompression() {
            byte[] data = new byte[] { 0x78, 0x9C, 0x62, 0x64, 0x60, 0x4E, 0xCB, 0xCF, 0x67, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x03, 0x00, 0x03, 0xE0, 0x01, 0x49 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using NbtReader nbtReader = new NbtReader(memoryStream, true, NbtCompression.ZLib);

            NbtRoot root = nbtReader.Read();
            string rootName = root.RootName;
            Assert.AreEqual("foo", rootName);
        }

        [TestMethod]
        public void NbtReader_ReadsCorrectRootName_WithCompressionAutoDetectionAndNoCompression() {
            byte[] data = new byte[] { 0x01, 0x00, 0x03, 0x66, 0x6F, 0x6F, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using NbtReader nbtReader = new NbtReader(memoryStream, true, NbtCompression.AutoDetect);

            NbtRoot root = nbtReader.Read();
            string rootName = root.RootName;
            Assert.AreEqual("foo", rootName);
        }

        [TestMethod]
        public void NbtReader_ReadsCorrectRootName_WithCompressionAutoDetectionAndGZipCompression() {
            byte[] data = new byte[] { 0x1F, 0x8B, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0A, 0x62, 0x64, 0x60, 0x4E, 0xCB, 0xCF, 0x67, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x03, 0x00, 0xB0, 0xFD, 0x18, 0xC3, 0x07, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using NbtReader nbtReader = new NbtReader(memoryStream, true, NbtCompression.AutoDetect);

            NbtRoot root = nbtReader.Read();
            string rootName = root.RootName;
            Assert.AreEqual("foo", rootName);
        }

        [TestMethod]
        public void NbtReader_ReadsCorrectRootName_WithCompressionAutoDetectionAndZLibCompression() {
            byte[] data = new byte[] { 0x78, 0x9C, 0x62, 0x64, 0x60, 0x4E, 0xCB, 0xCF, 0x67, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x03, 0x00, 0x03, 0xE0, 0x01, 0x49 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using NbtReader nbtReader = new NbtReader(memoryStream, true, NbtCompression.AutoDetect);

            NbtRoot root = nbtReader.Read();
            string rootName = root.RootName;
            Assert.AreEqual("foo", rootName);
        }

        [TestMethod]
        public void NbtReader_ShouldThrowException_WithCompressionAutoDetection_BecauseEndOfStreamWasReached() {
            byte[] data = Array.Empty<byte>();
            using MemoryStream memoryStream = new MemoryStream(data);

            Assert.ThrowsException<EndOfStreamException>(() => new NbtReader(memoryStream, true, NbtCompression.AutoDetect));
        }
    }
}
