using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class StringTagTests {
        [TestMethod]
        public void StringTag_GetsCorrectTagType() {
            StringTag tag = new StringTag("");
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.String, tagType);
        }
    }
}
