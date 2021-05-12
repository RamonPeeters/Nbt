using System;
using System.IO;
using System.IO.Compression;

namespace Nbt {
    public class NbtWriter : IDisposable {
        private const int BufferSize = 8192;

        private readonly Stream Stream;
        private readonly NbtCompression Compression;
        private readonly bool BigEndian;

        public NbtWriter(Stream stream, bool bigEndian, NbtCompression compression) {
            Stream = stream;
            BigEndian = bigEndian;

            if (!Enum.IsDefined(compression) || compression == NbtCompression.AutoDetect) {
                throw new ArgumentOutOfRangeException(nameof(compression));
            }
            Compression = compression;
        }

        public NbtWriter(Stream stream, bool bigEndian) : this(stream, bigEndian, NbtCompression.None) {}

        public NbtWriter(Stream stream) : this(stream, true, NbtCompression.None) {}

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Write(NbtRoot nbtRoot) {
            using Stream stream = Compression switch {
                NbtCompression.GZip => new GZipStream(Stream, CompressionMode.Compress, true),
                NbtCompression.ZLib => new ZLibStream(Stream, CompressionMode.Compress, true),
                _ => Stream
            };
            using BufferedStream bufferedStream = new BufferedStream(stream, BufferSize);
            using BinaryWriter binaryWriter = new BinaryWriter(bufferedStream, BigEndian);
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
