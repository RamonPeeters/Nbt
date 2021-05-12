using Nbt.Tags;
using System;
using System.IO;
using System.IO.Compression;

namespace Nbt {
    public class NbtReader : IDisposable {
        private readonly Stream Stream;
        private readonly NbtCompression Compression;
        private readonly bool BigEndian;

        public NbtReader(Stream stream, bool bigEndian, NbtCompression compression) {
            Stream = stream;
            BigEndian = bigEndian;

            Compression = compression != NbtCompression.AutoDetect ? compression : DetectCompression();
        }

        public NbtReader(Stream stream, bool bigEndian) : this(stream, bigEndian, NbtCompression.None) { }

        public NbtReader(Stream stream) : this(stream, true) {}

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public NbtRoot Read() {
            using Stream stream = Compression switch {
                NbtCompression.GZip => new GZipStream(Stream, CompressionMode.Decompress, true),
                NbtCompression.ZLib => new ZLibStream(Stream, CompressionMode.Decompress, true),
                _ => Stream
            };
            using BinaryReader binaryReader = new BinaryReader(stream, BigEndian);
            TagType tagType = binaryReader.ReadTagType();
            string rootName = binaryReader.ReadString();
            Tag data = TagFactory.GetEmptyTag(tagType);
            data.Read(binaryReader);
            return new NbtRoot(rootName, data);
        }

        private void Dispose(bool disposing) {
            if (disposing) {
                Stream.Dispose();
            }
        }

        private NbtCompression DetectCompression() {
            int firstByte = Stream.ReadByte();
            NbtCompression compression = firstByte switch {
                -1 => throw new EndOfStreamException(),
                0x1F => NbtCompression.GZip,
                0x78 => NbtCompression.ZLib,
                _ => NbtCompression.None
            };
            Stream.Seek(-1, SeekOrigin.Current);
            return compression;
        }
    }
}
