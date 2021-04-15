namespace Nbt.Tags {
    public class ShortTag : Tag {
        private short Data;

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
    }
}
