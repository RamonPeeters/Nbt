using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class FloatTagTests {
        [TestMethod]
        public void FloatTag_GetsCorrectTagType() {
            FloatTag tag = new FloatTag(0.0f);
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.Float, tagType);
        }
    }
}
