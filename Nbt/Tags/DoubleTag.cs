namespace Nbt.Tags {
    public class DoubleTag : Tag {
        private double Data;

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
    }
}
