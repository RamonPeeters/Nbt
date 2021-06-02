using Nbt.Snbt;
using System;
using System.Collections.Generic;

namespace Nbt.Tags {
    public class LongArrayTag : CollectionTag {
        private List<long> Data;

        public override int Count { get { return Data.Count; } }

        public LongArrayTag() : this(Array.Empty<long>()) {}

        public LongArrayTag(long[] data) {
            Data = new List<long>(data);
        }

        public override TagType GetTagType() {
            return TagType.LongArray;
        }

        public override TagType GetElementType() {
            return TagType.Long;
        }

        public override bool Add(Tag tag) {
            if (tag is LongTag longTag) {
                Data.Add(longTag.Data);
                return true;
            }
            return false;
        }

        internal override void Read(BinaryReader binaryReader) {
            int length = binaryReader.ReadInt();
            Data = new List<long>(length);
            for (int i = 0; i < length; i++) {
                Data.Add(binaryReader.ReadLong());
            }
        }

        internal override void Write(BinaryWriter binaryWriter) {
            binaryWriter.Write(Data.Count);
            for (int i = 0; i < Data.Count; i++) {
                binaryWriter.Write(Data[i]);
            }
        }

        public override void WriteSnbt(SnbtWriter snbtWriter) {
            snbtWriter.Write("[L;");
            snbtWriter.Write(Data, ",", (writer, value) => {
                writer.Write(value);
            });
            snbtWriter.Write(']');
        }
    }
}
