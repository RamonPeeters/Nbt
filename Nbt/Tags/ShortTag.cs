namespace Nbt.Tags {
    public class ShortTag : Tag {
        private readonly short Data;

        public ShortTag() : this(0) { }

        public ShortTag(short data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.Short;
        }
    }
}
