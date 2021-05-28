using System;
using System.Collections.Generic;

namespace Nbt.Tags {
    public class IntArrayTag : CollectionTag {
        private List<int> Data;

        public override int Count { get { return Data.Count; } }

        public IntArrayTag() : this(Array.Empty<int>()) {}

        public IntArrayTag(int[] data) {
            Data = new List<int>(data);
        }

        public override TagType GetTagType() {
            return TagType.IntArray;
        }

        public override bool Add(Tag tag) {
            if (tag is IntTag intTag) {
                Data.Add(intTag.Data);
                return true;
            }
            return false;
        }

        internal override void Read(BinaryReader binaryReader) {
            int length = binaryReader.ReadInt();
            Data = new List<int>(length);
            for (int i = 0; i < length; i++) {
                Data.Add(binaryReader.ReadInt());
            }
        }

        internal override void Write(BinaryWriter binaryWriter) {
            binaryWriter.Write(Data.Count);
            for (int i = 0; i < Data.Count; i++) {
                binaryWriter.Write(Data[i]);
            }
        }
    }
}
