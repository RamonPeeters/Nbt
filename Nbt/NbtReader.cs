using Nbt.Tags;
using System;
using System.IO;

namespace Nbt {
    public class NbtReader : IDisposable {
        private readonly Stream Stream;

        public NbtReader(Stream stream) {
            Stream = stream;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public NbtRoot Read() {
            using BinaryReader binaryReader = new BinaryReader(Stream);
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
