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
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteUnsignedByteCorrectly() {
            byte value = 128;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteShortCorrectly_WithBigEndian() {
            short value = -32768;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteShortCorrectly_WithLittleEndian() {
            short value = -32768;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x00, 0x80 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteUnsignedShortCorrectly_WithBigEndian() {
            ushort value = 32768;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteUnsignedShortCorrectly_WithLittleEndian() {
            ushort value = 32768;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x00, 0x80 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteIntCorrectly_WithBigEndian() {
            int value = -2147483648;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteIntCorrectly_WithLittleEndian() {
            int value = -2147483648;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x80 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteUnsignedIntCorrectly_WithBigEndian() {
            uint value = 2147483648;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteUnsignedIntCorrectly_WithLittleEndian() {
            uint value = 2147483648;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x80 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteLongCorrectly_WithBigEndian() {
            long value = -9223372036854775808L;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteLongCorrectly_WithLittleEndian() {
            long value = -9223372036854775808L;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteUnsignedLongCorrectly_WithBigEndian() {
            ulong value = 9223372036854775808L;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteUnsignedLongCorrectly_WithLittleEndian() {
            ulong value = 9223372036854775808L;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteFloatCorrectly_WithBigEndian() {
            float value = -1.5f;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0xBF, 0xC0, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteFloatCorrectly_WithLittleEndian() {
            float value = -1.5f;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0xC0, 0xBF }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteDoubleCorrectly_WithBigEndian() {
            double value = -1.5d;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteDoubleCorrectly_WithLittleEndian() {
            double value = -1.5d;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF8, 0xBF }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteTagTypeCorrectly() {
            TagType value = TagType.Byte;
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x01 }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteStringCorrectly_WithBigEndian() {
            string value = "foo";
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x00, 0x03, 0x66, 0x6F, 0x6F }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteStringCorrectly_WithLittleEndian() {
            string value = "foo";
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x03, 0x00, 0x66, 0x6F, 0x6F }, data);
        }

        [TestMethod]
        public void BinaryWriter_ShouldWriteStringCorrectly_WithComplexUTF8() {
            string value = "föö";
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.Write(value);
            byte[] data = memoryStream.ToArray();

            CollectionAssert.AreEqual(new byte[] { 0x00, 0x05, 0x66, 0xC3, 0xB6, 0xC3, 0xB6 }, data);
        }

        [TestMethod]
        public void BinaryWriter_WriteStringShouldThrowException_BecauseStringIsTooLong() {
            string value = new string('a', 65536);
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            Assert.ThrowsException<InvalidOperationException>(() => binaryWriter.Write(value));
        }

        [TestMethod]
        public void BinaryWriter_WriteStringShouldThrowException_BecauseStringIsNull() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            Assert.ThrowsException<ArgumentNullException>(() => binaryWriter.Write(null));
        }
    }
}
