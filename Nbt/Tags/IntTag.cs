namespace Nbt.Tags {
    public class IntTag : Tag {
        public int Data { get; private set; }

        public IntTag() : this(0) { }

        public IntTag(int data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.Int;
        }

        internal override void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadInt();
        }

        internal override void Write(BinaryWriter binaryWriter) {
            binaryWriter.Write(Data);
        }
    }
}
