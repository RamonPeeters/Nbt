namespace Nbt.Tags {
    public class ByteTag : Tag {
        public sbyte Data { get; private set; }

        public ByteTag() : this(0) { }

        public ByteTag(sbyte data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.Byte;
        }

        internal override void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadByte();
        }

        internal override void Write(BinaryWriter binaryWriter) {
            binaryWriter.Write(Data);
        }
    }
}
