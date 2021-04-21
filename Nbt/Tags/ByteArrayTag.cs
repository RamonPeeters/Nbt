using System;

namespace Nbt.Tags {
    public class ByteArrayTag : CollectionTag {
        private sbyte[] Data;

        public override int Count { get { return Data.Length; } }

        public ByteArrayTag() : this(Array.Empty<sbyte>()) {}

        public ByteArrayTag(sbyte[] data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.ByteArray;
        }

        internal override void Read(BinaryReader binaryReader) {
            int length = binaryReader.ReadInt();
            Data = new sbyte[length];
            for (int i = 0; i < length; i++) {
                Data[i] = binaryReader.ReadByte();
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
