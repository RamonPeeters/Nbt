using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Tags;

namespace Nbt.Tests.Tags {
    [TestClass]
    public class ShortTagTests {
        [TestMethod]
        public void ShortTag_GetsCorrectTagType() {
            ShortTag tag = new ShortTag(0);
            TagType tagType = tag.GetTagType();
            Assert.AreEqual(TagType.Short, tagType);
        }
    }
}
