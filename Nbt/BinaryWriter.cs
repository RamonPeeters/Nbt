using Nbt.Tags;
using System;
using System.IO;
using System.Text;

namespace Nbt {
    class BinaryWriter : IDisposable {
        private readonly Stream Stream;
        private readonly byte[] Buffer = new byte[sizeof(long)];

        public BinaryWriter(Stream stream) {
            Stream = stream;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Write(sbyte b) {
            Buffer[0] = (byte)b;
            WriteBuffer(1);
        }

        public void Write(byte b) {
            Buffer[0] = b;
            WriteBuffer(1);
        }

        public void Write(short s) {
            Buffer[0] = (byte)(s >> 8 & 0xFF);
            Buffer[1] = (byte)(s & 0xFF);
            WriteBuffer(2);
        }

        public void Write(ushort s) {
            Buffer[0] = (byte)(s >> 8 & 0xFF);
            Buffer[1] = (byte)(s & 0xFF);
            WriteBuffer(2);
        }

        public void Write(int i) {
            Buffer[0] = (byte)(i >> 24 & 0xFF);
            Buffer[1] = (byte)(i >> 16 & 0xFF);
            Buffer[2] = (byte)(i >> 8 & 0xFF);
            Buffer[3] = (byte)(i & 0xFF);
            WriteBuffer(4);
        }

        public void Write(uint i) {
            Buffer[0] = (byte)(i >> 24 & 0xFF);
            Buffer[1] = (byte)(i >> 16 & 0xFF);
            Buffer[2] = (byte)(i >> 8 & 0xFF);
            Buffer[3] = (byte)(i & 0xFF);
            WriteBuffer(4);
        }

        public void Write(long l) {
            Buffer[0] = (byte)(l >> 56 & 0xFF);
            Buffer[1] = (byte)(l >> 48 & 0xFF);
            Buffer[2] = (byte)(l >> 40 & 0xFF);
            Buffer[3] = (byte)(l >> 32 & 0xFF);
            Buffer[4] = (byte)(l >> 24 & 0xFF);
            Buffer[5] = (byte)(l >> 16 & 0xFF);
            Buffer[6] = (byte)(l >> 8 & 0xFF);
            Buffer[7] = (byte)(l & 0xFF);
            WriteBuffer(8);
        }

        public void Write(ulong l) {
            Buffer[0] = (byte)(l >> 56 & 0xFF);
            Buffer[1] = (byte)(l >> 48 & 0xFF);
            Buffer[2] = (byte)(l >> 40 & 0xFF);
            Buffer[3] = (byte)(l >> 32 & 0xFF);
            Buffer[4] = (byte)(l >> 24 & 0xFF);
            Buffer[5] = (byte)(l >> 16 & 0xFF);
            Buffer[6] = (byte)(l >> 8 & 0xFF);
            Buffer[7] = (byte)(l & 0xFF);
            WriteBuffer(8);
        }

        public unsafe void Write(float f) {
            int i = *(int*)&f;
            Write(i);
        }

        public unsafe void Write(double d) {
            long l = *(long*)&d;
            Write(l);
        }

        public void Write(TagType tagType) {
            Write((sbyte)tagType);
        }

        public void Write(string s) {
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            if (bytes.Length > ushort.MaxValue) {
                throw new InvalidOperationException("The number of bytes in the string was larger than the maximum (65535)");
            }
            Write((ushort)bytes.Length);
            Write(bytes);
        }

        private void Write(byte[] bytes) {
            Stream.Write(bytes, 0, bytes.Length);
        }

        private void WriteBuffer(int length) {
            Stream.Write(Buffer, 0, length);
        }

        private void Dispose(bool disposing) {
            if (disposing) {
                Stream.Dispose();
            }
        }
    }
}
