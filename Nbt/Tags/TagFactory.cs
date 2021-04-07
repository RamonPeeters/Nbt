namespace Nbt.Tags {
    static class TagFactory {
        public static Tag GetEmptyTag(TagType tagType) {
            return tagType switch {
                TagType.Byte => new ByteTag(),
                TagType.Short => new ShortTag(),
                TagType.Int => new IntTag(),
                TagType.Long => new LongTag(),
                TagType.Float => new FloatTag(),
                TagType.Double => new DoubleTag(),
                TagType.String => new StringTag(),
                _ => throw new InvalidTagTypeException(tagType)
            };
        }
    }
}
