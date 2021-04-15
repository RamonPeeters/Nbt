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

        public void Write(sbyte value) {
            Buffer[0] = (byte)value;
            WriteBuffer(1);
        }

        public void Write(byte value) {
            Buffer[0] = value;
            WriteBuffer(1);
        }

        public void Write(short value) {
            Buffer[0] = (byte)(value >> 8 & 0xFF);
            Buffer[1] = (byte)(value & 0xFF);
            WriteBuffer(2);
        }

        public void Write(ushort value) {
            Buffer[0] = (byte)(value >> 8 & 0xFF);
            Buffer[1] = (byte)(value & 0xFF);
            WriteBuffer(2);
        }

        public void Write(int value) {
            Buffer[0] = (byte)(value >> 24 & 0xFF);
            Buffer[1] = (byte)(value >> 16 & 0xFF);
            Buffer[2] = (byte)(value >> 8 & 0xFF);
            Buffer[3] = (byte)(value & 0xFF);
            WriteBuffer(4);
        }

        public void Write(uint value) {
            Buffer[0] = (byte)(value >> 24 & 0xFF);
            Buffer[1] = (byte)(value >> 16 & 0xFF);
            Buffer[2] = (byte)(value >> 8 & 0xFF);
            Buffer[3] = (byte)(value & 0xFF);
            WriteBuffer(4);
        }

        public void Write(long value) {
            Buffer[0] = (byte)(value >> 56 & 0xFF);
            Buffer[1] = (byte)(value >> 48 & 0xFF);
            Buffer[2] = (byte)(value >> 40 & 0xFF);
            Buffer[3] = (byte)(value >> 32 & 0xFF);
            Buffer[4] = (byte)(value >> 24 & 0xFF);
            Buffer[5] = (byte)(value >> 16 & 0xFF);
            Buffer[6] = (byte)(value >> 8 & 0xFF);
            Buffer[7] = (byte)(value & 0xFF);
            WriteBuffer(8);
        }

        public void Write(ulong value) {
            Buffer[0] = (byte)(value >> 56 & 0xFF);
            Buffer[1] = (byte)(value >> 48 & 0xFF);
            Buffer[2] = (byte)(value >> 40 & 0xFF);
            Buffer[3] = (byte)(value >> 32 & 0xFF);
            Buffer[4] = (byte)(value >> 24 & 0xFF);
            Buffer[5] = (byte)(value >> 16 & 0xFF);
            Buffer[6] = (byte)(value >> 8 & 0xFF);
            Buffer[7] = (byte)(value & 0xFF);
            WriteBuffer(8);
        }

        public unsafe void Write(float value) {
            int i = *(int*)&value;
            Write(i);
        }

        public unsafe void Write(double value) {
            long l = *(long*)&value;
            Write(l);
        }

        public void Write(TagType value) {
            Write((sbyte)value);
        }

        public void Write(string value) {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
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
