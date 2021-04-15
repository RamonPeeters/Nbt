using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;
using System;
using System.IO;

namespace Nbt.Tests {
    [TestClass]
    public class BinaryWriterTests {
        [TestMethod]
        public void BinaryWriter_ShouldWriteByteCorrectly() {
            sbyte value = -128;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteUnsignedByteCorrectly() {
            byte value = 128;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteShortCorrectly() {
            short value = -32768;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteUnsignedShortCorrectly() {
            ushort value = 32768;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteIntCorrectly() {
            int value = -2147483648;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteUnsignedIntCorrectly() {
            uint value = 2147483648;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteLongCorrectly() {
            long value = -9223372036854775808L;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteUnsignedLongCorrectly() {
            ulong value = 9223372036854775808L;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteFloatCorrectly() {
            float value = -1.5f;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0xBF, 0xC0, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteDoubleCorrectly() {
            double value = -1.5d;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteTagTypeCorrectly() {
            TagType value = TagType.Byte;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x01 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteStringCorrectly() {
            string value = "foo";
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x00, 0x03, 0x66, 0x6F, 0x6F }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteStringCorrectly_WithComplexUTF8() {
            string value = "föö";
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x00, 0x05, 0x66, 0xC3, 0xB6, 0xC3, 0xB6 }, data);
        }

        [TestMethod]
        public void BinaryWriter_WriteStringShouldThrowException_BecauseStringIsTooLong() {
            string value = new string('a', 65536);
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            Assert.ThrowsException<InvalidOperationException>(() => binaryWriter.Write(value));
        }
    }
}
