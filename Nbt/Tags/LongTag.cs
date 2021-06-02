using Nbt.Snbt;

namespace Nbt.Tags {
    public class LongTag : Tag {
        public long Data { get; private set; }

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

        public override void WriteSnbt(SnbtWriter snbtWriter) {
            snbtWriter.Write(Data);
        }
    }
}
