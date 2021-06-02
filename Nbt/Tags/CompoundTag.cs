using Nbt.Snbt;
using System.Collections.Generic;

namespace Nbt.Tags {
    public class CompoundTag : Tag {
        private Dictionary<string, Tag> Data;

        public int Count { get { return Data.Count; } }

        public CompoundTag(Dictionary<string, Tag> data) {
            Data = new Dictionary<string, Tag>(data);
        }

        public CompoundTag() {
            Data = new Dictionary<string, Tag>();
        }

        public override TagType GetTagType() {
            return TagType.Compound;
        }

        internal override void Read(BinaryReader binaryReader) {
            Data = new Dictionary<string, Tag>();
            TagType tagType;
            while ((tagType = binaryReader.ReadTagType()) != TagType.End) {
                string key = binaryReader.ReadString();
                Tag value = TagFactory.GetEmptyTag(tagType);
                value.Read(binaryReader);
                Data[key] = value;
            }
        }

        internal override void Write(BinaryWriter binaryWriter) {
            foreach (KeyValuePair<string, Tag> pair in Data) {
                binaryWriter.Write(pair.Value.GetTagType());
                binaryWriter.Write(pair.Key);
                pair.Value.Write(binaryWriter);
            }
            binaryWriter.Write(TagType.End);
        }

        public override void WriteSnbt(SnbtWriter snbtWriter) {
            snbtWriter.Write("{");
            snbtWriter.Write(Data, ",", (writer, pair) => {
                writer.Write(pair.Key.QuoteIfRequired());
                writer.Write(':');
                pair.Value.WriteSnbt(writer);
            });
            snbtWriter.Write('}');
        }
    }
}
