namespace Nbt.Tags {
    public class DoubleTag : Tag {
        private readonly double Data;

        public DoubleTag() : this(0.0d) { }

        public DoubleTag(double data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.Double;
        }
    }
}
