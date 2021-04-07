using Nbt.Tags;

namespace Nbt {
    public class NbtRoot {
        public string RootName { get; }
        public Tag Data { get; }

        public NbtRoot(string rootName, Tag data) {
            RootName = rootName;
            Data = data;
        }
    }
}
