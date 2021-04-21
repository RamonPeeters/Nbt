using System;

namespace Nbt.Tags {
    public class LongArrayTag : CollectionTag {
        private long[] Data;

        public override int Count { get { return Data.Length; } }

        public LongArrayTag() : this(Array.Empty<long>()) {}

        public LongArrayTag(long[] data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.LongArray;
        }

        internal override void Read(BinaryReader binaryReader) {
            int length = binaryReader.ReadInt();
            Data = new long[length];
            for (int i = 0; i < length; i++) {
                Data[i] = binaryReader.ReadLong();
            }
        }

        internal override void Write(BinaryWriter binaryWriter) {
            binaryWriter.Write(Data.Length);
            for (int i = 0; i < Data.Length; i++) {
                binaryWriter.Write(Data[i]);
            }
        }
    }
}
