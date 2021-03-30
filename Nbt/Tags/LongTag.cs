namespace Nbt.Tags {
    public class LongTag : Tag {
        private readonly long Data;

        public LongTag() : this(0L) { }

        public LongTag(long data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.Long;
        }
    }
}
