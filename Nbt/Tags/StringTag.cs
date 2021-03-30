namespace Nbt.Tags {
    public class StringTag : Tag {
        private readonly string Data;

        public StringTag() : this("") {}

        public StringTag(string data) {
            Data = data;
        }

        public override TagType GetTagType() {
            return TagType.String;
        }
    }
}
