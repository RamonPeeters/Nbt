using Nbt.Snbt;

namespace Nbt.Tags {
    public class ShortTag : Tag {
        public short Data { get; private set; }

        public ShortTag() : this(0) { }

        public ShortTag(short data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.Short;
        }

        internal override void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadShort();
        }

        internal override void Write(BinaryWriter binaryWriter) {
            binaryWriter.Write(Data);
        }

        public override void WriteSnbt(SnbtWriter snbtWriter) {
            snbtWriter.Write(Data);
        }
    }
}
