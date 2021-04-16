using System;
using System.IO;

namespace Nbt {
    public class NbtWriter : IDisposable {
        private readonly Stream Stream;

        public NbtWriter(Stream stream) {
            Stream = stream;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Write(NbtRoot nbtRoot) {
            using BinaryWriter binaryWriter = new BinaryWriter(Stream);
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
