namespace Nbt.Tags {
    public class ByteTag : Tag {
        private readonly sbyte Data;

        public ByteTag() : this(0) { }

        public ByteTag(sbyte data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.Byte;
        }
    }
}
