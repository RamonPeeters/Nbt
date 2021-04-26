using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;
using System;
using System.IO;

namespace Nbt.Tests {
    [TestClass]
    public class BinaryReaderTests {
        [TestMethod]
        public void BinaryReader_ShouldReadByteCorrectly() {
            byte[] data = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            sbyte result = binaryReader.ReadByte();
            Assert.AreEqual((sbyte)-128, result);
        }

        [TestMethod]
        public void BinaryReader_ReadByteShouldThrowException_BecauseEndOfStreamWasReached() {
            byte[] data = Array.Empty<byte>();
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadByte());
        }

        [TestMethod]
        public void BinaryReader_ShouldReadUnsignedByteCorrectly() {
            byte[] data = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            byte result = binaryReader.ReadUnsignedByte();
            Assert.AreEqual((byte)128, result);
        }

        [TestMethod]
        public void BinaryReader_ReadUnsignedByteShouldThrowException_BecauseEndOfStreamWasReached() {
            byte[] data = Array.Empty<byte>();
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadUnsignedByte());
        }

        [TestMethod]
        public void BinaryReader_ShouldReadShortCorrectly_WithBigEndian() {
            byte[] data = new byte[] { 0x80, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            short result = binaryReader.ReadShort();
            Assert.AreEqual((short)-32768, result);
        }

        [TestMethod]
        public void BinaryReader_ShouldReadShortCorrectly_WithLittleEndian() {
            byte[] data = new byte[] { 0x00, 0x80 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            short result = binaryReader.ReadShort();
            Assert.AreEqual((short)-32768, result);
        }

        [TestMethod]
        public void BinaryReader_ReadShortShouldThrowException_BecauseEndOfStreamWasReached() {
            byte[] data = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadShort());
        }

        [TestMethod]
        public void BinaryReader_ShouldReadUnsignedShortCorrectly_WithBigEndian() {
            byte[] data = new byte[] { 0x80, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            ushort result = binaryReader.ReadUnsignedShort();
            Assert.AreEqual((ushort)32768, result);
        }

        [TestMethod]
        public void BinaryReader_ShouldReadUnsignedShortCorrectly_WithLittleEndian() {
            byte[] data = new byte[] { 0x00, 0x80 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            ushort result = binaryReader.ReadUnsignedShort();
            Assert.AreEqual((ushort)32768, result);
        }

        [TestMethod]
        public void BinaryReader_ReadUnsignedShortShouldThrowException_BecauseEndOfStreamWasReached() {
            byte[] data = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadUnsignedShort());
        }

        [TestMethod]
        public void BinaryReader_ShouldReadIntCorrectly_WithBigEndian() {
            byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            int result = binaryReader.ReadInt();
            Assert.AreEqual(-2147483648, result);
        }

        [TestMethod]
        public void BinaryReader_ShouldReadIntCorrectly_WithLittleEndian() {
            byte[] data = new byte[] { 0x00, 0x00, 0x00, 0x80 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            int result = binaryReader.ReadInt();
            Assert.AreEqual(-2147483648, result);
        }

        [TestMethod]
        public void BinaryReader_ReadIntShouldThrowException_BecauseEndOfStreamWasReached() {
            byte[] data = new byte[] { 0x80, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadInt());
        }

        [TestMethod]
        public void BinaryReader_ShouldReadUnsignedIntCorrectly_WithBigEndian() {
            byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            uint result = binaryReader.ReadUnsignedInt();
            Assert.AreEqual(2147483648, result);
        }

        [TestMethod]
        public void BinaryReader_ShouldReadUnsignedIntCorrectly_WithLittleEndian() {
            byte[] data = new byte[] { 0x00, 0x00, 0x00, 0x80 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            uint result = binaryReader.ReadUnsignedInt();
            Assert.AreEqual(2147483648, result);
        }

        [TestMethod]
        public void BinaryReader_ReadUnsignedIntShouldThrowException_BecauseEndOfStreamWasReached() {
            byte[] data = new byte[] { 0x80, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadUnsignedInt());
        }

        [TestMethod]
        public void BinaryReader_ShouldReadLongCorrectly_WithBigEndian() {
            byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            long result = binaryReader.ReadLong();
            Assert.AreEqual(-9223372036854775808L, result);
        }

        [TestMethod]
        public void BinaryReader_ShouldReadLongCorrectly_WithLittleEndian() {
            byte[] data = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            long result = binaryReader.ReadLong();
            Assert.AreEqual(-9223372036854775808L, result);
        }

        [TestMethod]
        public void BinaryReader_ReadLongShouldThrowException_BecauseEndOfStreamWasReached() {
            byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadLong());
        }

        [TestMethod]
        public void BinaryReader_ShouldReadUnsignedLongCorrectly_WithBigEndian() {
            byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            ulong result = binaryReader.ReadUnsignedLong();
            Assert.AreEqual(9223372036854775808L, result);
        }

        [TestMethod]
        public void BinaryReader_ShouldReadUnsignedLongCorrectly_WithLittleEndian() {
            byte[] data = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            ulong result = binaryReader.ReadUnsignedLong();
            Assert.AreEqual(9223372036854775808L, result);
        }

        [TestMethod]
        public void BinaryReader_ReadUnsignedLongShouldThrowException_BecauseEndOfStreamWasReached() {
            byte[] data = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadUnsignedLong());
        }

        [TestMethod]
        public void BinaryReader_ShouldReadFloatCorrectly_WithBigEndian() {
            byte[] data = new byte[] { 0xBF, 0xC0, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            float result = binaryReader.ReadFloat();
            Assert.AreEqual(-1.5f, result);
        }

        [TestMethod]
        public void BinaryReader_ShouldReadFloatCorrectly_WithLittleEndian() {
            byte[] data = new byte[] { 0x00, 0x00, 0xC0, 0xBF };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            float result = binaryReader.ReadFloat();
            Assert.AreEqual(-1.5f, result);
        }

        [TestMethod]
        public void BinaryReader_ReadFloatShouldThrowException_BecauseEndOfStreamWasReached() {
            byte[] data = new byte[] { 0xBF, 0xC0, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadFloat());
        }

        [TestMethod]
        public void BinaryReader_ShouldReadDoubleCorrectly_WithBigEndian() {
            byte[] data = new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            double result = binaryReader.ReadDouble();
            Assert.AreEqual(-1.5d, result);
        }

        [TestMethod]
        public void BinaryReader_ShouldReadDoubleCorrectly_WithLittleEndian() {
            byte[] data = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF8, 0xBF };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            double result = binaryReader.ReadDouble();
            Assert.AreEqual(-1.5d, result);
        }

        [TestMethod]
        public void BinaryReader_ReadDoubleShouldThrowException_BecauseEndOfStreamWasReached() {
            byte[] data = new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadDouble());
        }

        [TestMethod]
        public void BinaryReader_ShouldReadTagTypeCorrectly() {
            byte[] data = new byte[] { 0x01 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            TagType result = binaryReader.ReadTagType();
            Assert.AreEqual(TagType.Byte, result);
        }

        [TestMethod]
        public void BinaryReader_ReadTagTypeShouldThrowException_BecauseEndOfStreamWasReached() {
            byte[] data = Array.Empty<byte>();
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadTagType());
        }

        [TestMethod]
        public void BinaryReader_ShouldReadStringCorrectly_WithBigEndian() {
            byte[] data = new byte[] { 0x00, 0x03, 0x66, 0x6F, 0x6F };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            string result = binaryReader.ReadString();
            Assert.AreEqual("foo", result);
        }

        [TestMethod]
        public void BinaryReader_ShouldReadStringCorrectly_WithLittleEndian() {
            byte[] data = new byte[] { 0x03, 0x00, 0x66, 0x6F, 0x6F };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            string result = binaryReader.ReadString();
            Assert.AreEqual("foo", result);
        }

        [TestMethod]
        public void BinaryReader_ShouldReadStringCorrectly_WithComplexUTF8() {
            byte[] data = new byte[] { 0x00, 0x05, 0x66, 0xC3, 0xB6, 0xC3, 0xB6 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            string result = binaryReader.ReadString();
            Assert.AreEqual("föö", result);
        }

        [TestMethod]
        public void BinaryReader_ReadStringShouldThrowException_BecauseEndOfStreamWasReached() {
            byte[] data = new byte[] { 0x00, 0x05 };
            using MemoryStream memoryStream = new MemoryStream(data);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadString());
        }
    }
}
