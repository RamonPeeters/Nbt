using System.Collections.Generic;

namespace Nbt.Tags {
    public class ListTag : CollectionTag {
        private List<Tag> Data;
        private TagType Type;

        public ListTag() {
            Data = new List<Tag>();
            Type = TagType.End;
        }

        public override int Count { get { return Data.Count; } }

        public override TagType GetTagType() {
            return TagType.List;
        }

        public override bool Add(Tag tag) {
            if (UpdateType(tag)) {
                Data.Add(tag);
                return true;
            }
            return false;
        }

        private bool UpdateType(Tag tag) {
            if (tag == null) {
                return false;
            }
            if (tag.GetTagType() == TagType.End) {
                return false;
            }
            if (Type == TagType.End) {
                Type = tag.GetTagType();
                return true;
            }
            return Type == tag.GetTagType();
        }

        internal override void Read(BinaryReader binaryReader) {
            Type = binaryReader.ReadTagType();
            int length = binaryReader.ReadInt();

            Data = new List<Tag>(length);
            for (int i = 0; i < length; i++) {
                Tag tag = TagFactory.GetEmptyTag(Type);
                tag.Read(binaryReader);
                Data.Add(tag);
            }
        }

        internal override void Write(BinaryWriter binaryWriter) {
            binaryWriter.Write(Type);
            binaryWriter.Write(Data.Count);
            for (int i = 0; i < Data.Count; i++) {
                Data[i].Write(binaryWriter);
            }
        }
    }
}
