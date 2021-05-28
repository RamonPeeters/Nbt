namespace Nbt.Tags {
    public abstract class CollectionTag : Tag {
        public abstract int Count { get; }
        public abstract bool Add(Tag tag);
        public abstract TagType GetElementType();
    }
}
