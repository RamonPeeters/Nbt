using System;

namespace Nbt.Tags {
    public class InvalidTagTypeException : Exception {
        public InvalidTagTypeException(TagType tagType) : base($"Invalid tag type: {tagType}.") { }
    }
}
