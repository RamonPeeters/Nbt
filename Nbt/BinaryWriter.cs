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
            Write((sbyte)value);
        }

        public void Write(short value) {
            Buffer[0] = (byte)(value >> 8 & 0xFF);
            Buffer[1] = (byte)(value & 0xFF);
            WriteBuffer(2);
        }

        public void Write(ushort value) {
            Write((short)value);
        }

        public void Write(int value) {
            for (int i = 0; i < 4; i++) {
                Buffer[i] = (byte)(value >> ((3 - i) * 8) & 0xFF);
            }
            WriteBuffer(4);
        }

        public void Write(uint value) {
            Write((int)value);
        }

        public void Write(long value) {
            for (int i = 0; i < 8; i++) {
                Buffer[i] = (byte)(value >> ((7 - i) * 8) & 0xFF);
            }
            WriteBuffer(8);
        }

        public void Write(ulong value) {
            Write((long)value);
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
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            byte[] bytes = Encoding.UTF8.GetBytes(value);
            if (bytes.Length > ushort.MaxValue) {
                throw new InvalidOperationException($"The number of bytes in the string was larger than the maximum ({ushort.MaxValue})");
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
