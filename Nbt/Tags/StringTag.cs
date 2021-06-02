using Nbt.Snbt;

namespace Nbt.Tags {
    public class StringTag : Tag {
        public string Data { get; private set; }

        public StringTag() : this("") {}

        public StringTag(string data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.String;
        }

        internal override void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadString();
        }

        internal override void Write(BinaryWriter binaryWriter) {
            binaryWriter.Write(Data);
        }

        public override void WriteSnbt(SnbtWriter snbtWriter) {
            snbtWriter.Write(Data);
        }
    }
}
