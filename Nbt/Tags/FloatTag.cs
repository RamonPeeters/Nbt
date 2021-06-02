using Nbt.Snbt;

namespace Nbt.Tags {
    public class FloatTag : Tag {
        public float Data { get; private set; }

        public FloatTag() : this(0.0f) { }

        public FloatTag(float data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.Float;
        }

        internal override void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadFloat();
        }

        internal override void Write(BinaryWriter binaryWriter) {
            binaryWriter.Write(Data);
        }

        public override void WriteSnbt(SnbtWriter snbtWriter) {
            snbtWriter.Write(Data);
        }
    }
}
