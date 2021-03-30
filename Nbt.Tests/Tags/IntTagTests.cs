using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class IntTagTests {
        [TestMethod]
        public void IntTag_GetsCorrectTagType() {
            IntTag tag = new IntTag(0);
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.Int, tagType);
        }
    }
}
