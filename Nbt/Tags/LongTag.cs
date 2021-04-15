namespace Nbt.Tags {
    public class LongTag : Tag {
        private long Data;

        public LongTag() : this(0L) { }

        public LongTag(long data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.Long;
        }

        internal override void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadLong();
        }

        internal override void Write(BinaryWriter binaryWriter) {
            binaryWriter.Write(Data);
        }
    }
}
