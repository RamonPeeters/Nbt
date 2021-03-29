using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class ByteTagTests {
        [TestMethod]
        public void ByteTag_GetsCorrectTagType() {
            ByteTag tag = new ByteTag(0);
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.Byte, tagType);
        }
    }
}
