using System;
using System.Collections.Generic;

namespace Nbt.Tags {
    public class ByteArrayTag : CollectionTag {
        private List<sbyte> Data;

        public override int Count { get { return Data.Count; } }

        public ByteArrayTag() : this(Array.Empty<sbyte>()) {}

        public ByteArrayTag(sbyte[] data) {
            Data = new List<sbyte>(data);
        }

        public override TagType GetTagType() {
            return TagType.ByteArray;
        }

        public override TagType GetElementType() {
            return TagType.Byte;
        }

        public override bool Add(Tag tag) {
            if (tag is ByteTag byteTag) {
                Data.Add(byteTag.Data);
                return true;
            }
            return false;
        }

        internal override void Read(BinaryReader binaryReader) {
            int length = binaryReader.ReadInt();
            Data = new List<sbyte>(length);
            for (int i = 0; i < length; i++) {
                Data.Add(binaryReader.ReadByte());
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
