using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class LongTagTests {
        [TestMethod]
        public void LongTag_GetsCorrectTagType() {
            LongTag tag = new LongTag(0L);
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.Long, tagType);
        }
    }
}
