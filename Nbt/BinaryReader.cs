using Nbt.Tags;
using System;
using System.IO;
using System.Text;

namespace Nbt {
    class BinaryReader : IDisposable {
        private readonly Stream Stream;
        private readonly bool BigEndian;
        private readonly byte[] Buffer = new byte[sizeof(long)];

        public BinaryReader(Stream stream, bool bigEndian) {
            Stream = stream;
            BigEndian = bigEndian;
        }

        public BinaryReader(Stream stream) : this(stream, true) {}

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public sbyte ReadByte() {
            FillBuffer(1);
            return (sbyte)Buffer[0];
        }

        public byte ReadUnsignedByte() {
            return (byte)ReadByte();
        }

        public short ReadShort() {
            FillBuffer(2);
            if (BigEndian) {
                return (short)(Buffer[0] << 8 | Buffer[1]);
            }
            return (short)(Buffer[1] << 8 | Buffer[0]);
        }

        public ushort ReadUnsignedShort() {
            return (ushort)ReadShort();
        }

        public int ReadInt() {
            FillBuffer(4);
            if (BigEndian) {
                return Buffer[0] << 24 | Buffer[1] << 16 | Buffer[2] << 8 | Buffer[3];
            }
            return Buffer[3] << 24 | Buffer[2] << 16 | Buffer[1] << 8 | Buffer[0];
        }

        public uint ReadUnsignedInt() {
            return (uint)ReadInt();
        }

        public long ReadLong() {
            FillBuffer(8);
            uint upper, lower;
            if (BigEndian) {
                upper = (uint)(Buffer[0] << 24 | Buffer[1] << 16 | Buffer[2] << 8 | Buffer[3]);
                lower = (uint)(Buffer[4] << 24 | Buffer[5] << 16 | Buffer[6] << 8 | Buffer[7]);
                return (long)((ulong)upper << 32 | lower);
            }
            upper = (uint)(Buffer[7] << 24 | Buffer[6] << 16 | Buffer[5] << 8 | Buffer[4]);
            lower = (uint)(Buffer[3] << 24 | Buffer[2] << 16 | Buffer[1] << 8 | Buffer[0]);
            return (long)((ulong)upper << 32 | lower);
        }

        public ulong ReadUnsignedLong() {
            return (ulong)ReadLong();
        }

        public unsafe float ReadFloat() {
            int i = ReadInt();
            return *(float*)&i;
        }

        public unsafe double ReadDouble() {
            long l = ReadLong();
            return *(double*)&l;
        }

        public TagType ReadTagType() {
            return (TagType)ReadByte();
        }

        public string ReadString() {
            ushort length = ReadUnsignedShort();
            byte[] bytes = ReadBytes(length);
            return Encoding.UTF8.GetString(bytes);
        }

        private byte[] ReadBytes(int length) {
            byte[] buffer = new byte[length];
            int bytesRead = Stream.Read(buffer, 0, length);
            if (bytesRead < length) {
                throw new EndOfStreamException();
            }
            return buffer;
        }

        private void FillBuffer(int length) {
            int bytesRead = Stream.Read(Buffer, 0, length);
            if (bytesRead < length) {
                throw new EndOfStreamException();
            }
        }

        private void Dispose(bool disposing) {
            if (disposing) {
                Stream.Dispose();
            }
        }
    }
}
