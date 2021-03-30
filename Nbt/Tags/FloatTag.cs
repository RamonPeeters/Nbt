namespace Nbt.Tags {
    public class FloatTag : Tag {
        private readonly float Data;

        public FloatTag() : this(0.0f) { }

        public FloatTag(float data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.Float;
        }
    }
}
