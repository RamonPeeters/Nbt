using Nbt.Snbt;

namespace Nbt.Tags {
    public abstract class Tag {
        public abstract TagType GetTagType();
        internal abstract void Read(BinaryReader binaryReader);
        internal abstract void Write(BinaryWriter binaryWriter);
        public abstract void WriteSnbt(SnbtWriter snbtWriter);
    }
}
