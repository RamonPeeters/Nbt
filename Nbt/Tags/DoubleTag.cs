using Nbt.Snbt;

namespace Nbt.Tags {
    public class DoubleTag : Tag {
        public double Data { get; private set; }

        public DoubleTag() : this(0.0d) { }

        public DoubleTag(double data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.Double;
        }

        internal override void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadDouble();
        }

        internal override void Write(BinaryWriter binaryWriter) {
            binaryWriter.Write(Data);
        }

        public override void WriteSnbt(SnbtWriter snbtWriter) {
            snbtWriter.Write(Data);
        }
    }
}
