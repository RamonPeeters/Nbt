using System;
using System.IO;

namespace Nbt {
    public class NbtWriter : IDisposable {
        private readonly Stream Stream;
        private readonly bool BigEndian;

        public NbtWriter(Stream stream, bool bigEndian) {
            Stream = stream;
            BigEndian = bigEndian;
        }

        public NbtWriter(Stream stream) : this(stream, true) {}

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Write(NbtRoot nbtRoot) {
            using BinaryWriter binaryWriter = new BinaryWriter(Stream, BigEndian);
            binaryWriter.Write(nbtRoot.Data.GetTagType());
            binaryWriter.Write(nbtRoot.RootName);
            nbtRoot.Data.Write(binaryWriter);
        }

        private void Dispose(bool disposing) {
            if (disposing) {
                Stream.Dispose();
            }
        }
    }
}
