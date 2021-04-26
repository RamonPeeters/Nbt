using Nbt.Tags;
using System;
using System.IO;

namespace Nbt {
    public class NbtReader : IDisposable {
        private readonly Stream Stream;
        private readonly bool BigEndian;

        public NbtReader(Stream stream, bool bigEndian) {
            Stream = stream;
            BigEndian = bigEndian;
        }

        public NbtReader(Stream stream) : this(stream, true) {}

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public NbtRoot Read() {
            using BinaryReader binaryReader = new BinaryReader(Stream, BigEndian);
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
    }
}
