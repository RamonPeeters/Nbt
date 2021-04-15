namespace Nbt.Tags {
    public class StringTag : Tag {
        private string Data;

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
    }
}
