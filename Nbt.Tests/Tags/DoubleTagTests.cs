using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class DoubleTagTests {
        [TestMethod]
        public void DoubleTag_GetsCorrectTagType() {
            DoubleTag tag = new DoubleTag(0.0d);
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.Double, tagType);
        }
    }
}
