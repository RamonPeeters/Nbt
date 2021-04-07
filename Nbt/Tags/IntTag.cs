﻿namespace Nbt.Tags {
    public class IntTag : Tag {
        private int Data;

        public IntTag() : this(0) { }

        public IntTag(int data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.Int;
        }

        internal override void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadInt();
        }
    }
}
