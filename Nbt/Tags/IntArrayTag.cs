using System;

namespace Nbt.Tags {
    public class IntArrayTag : CollectionTag {
        private int[] Data;

        public override int Count { get { return Data.Length; } }

        public IntArrayTag() : this(Array.Empty<int>()) {}

        public IntArrayTag(int[] data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.IntArray;
        }

        internal override void Read(BinaryReader binaryReader) {
            int length = binaryReader.ReadInt();
            Data = new int[length];
            for (int i = 0; i < length; i++) {
                Data[i] = binaryReader.ReadInt();
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
