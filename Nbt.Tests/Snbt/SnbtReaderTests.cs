using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Snbt;
using Nbt.Tags;

namespace Nbt.Tests.Snbt {
    [TestClass]
    public class SnbtReaderTests {
        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnByteTag() {
            SnbtReader reader = new SnbtReader("1b");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.Byte, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnShortTag() {
            SnbtReader reader = new SnbtReader("1s");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.Short, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnIntTag() {
            SnbtReader reader = new SnbtReader("1");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.Int, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnLongTag() {
            SnbtReader reader = new SnbtReader("1L");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.Long, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnFloatTag() {
            SnbtReader reader = new SnbtReader("1.0f");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.Float, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnDoubleTag() {
            SnbtReader reader = new SnbtReader("1.0d");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.Double, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnByteTag_WithoutDoubleSuffix() {
            SnbtReader reader = new SnbtReader("1.0");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.Double, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnByteTag_WithTrueAsValue() {
            SnbtReader reader = new SnbtReader("true");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.Byte, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnByteTag_WithFalseAsValue() {
            SnbtReader reader = new SnbtReader("false");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.Byte, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnStringTag_WithUnquotedString() {
            SnbtReader reader = new SnbtReader("foo");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.String, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldThrowException_BecauseValueWasEmpty() {
            SnbtReader reader = new SnbtReader("");

            Assert.ThrowsException<SnbtReaderException>(() => reader.ReadTag());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnStringTag_WithQuotedString() {
            SnbtReader reader = new SnbtReader("\"foo bar\"");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.String, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnCompoundTag() {
            SnbtReader reader = new SnbtReader("{}");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.Compound, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnCompoundTag_WithContents() {
            SnbtReader reader = new SnbtReader("{foo:1,bar:2}");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.Compound, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldThrowException_BecauseCompoundKeyValueSeparatorWasNotPresent() {
            SnbtReader reader = new SnbtReader("{foo");

            Assert.ThrowsException<StringReaderException>(() => reader.ReadTag());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldThrowException_BecauseCompoundHasTrailingComma() {
            SnbtReader reader = new SnbtReader("{foo:1,}");

            Assert.ThrowsException<StringReaderException>(() => reader.ReadTag());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldThrowException_BecauseCompoundIsNotClosed() {
            SnbtReader reader = new SnbtReader("{");

            Assert.ThrowsException<StringReaderException>(() => reader.ReadTag());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnListTag() {
            SnbtReader reader = new SnbtReader("[]");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.List, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnListTag_WithContents() {
            SnbtReader reader = new SnbtReader("[1,2,3]");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.List, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldThrowException_BecauseListHasTrailingComma() {
            SnbtReader reader = new SnbtReader("[1,");

            Assert.ThrowsException<SnbtReaderException>(() => reader.ReadTag());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldThrowException_BecauseListIsNotClosed() {
            SnbtReader reader = new SnbtReader("[1");

            Assert.ThrowsException<StringReaderException>(() => reader.ReadTag());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnByteArray() {
            SnbtReader reader = new SnbtReader("[B;]");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.ByteArray, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnByteArray_WithContents() {
            SnbtReader reader = new SnbtReader("[B;1b,2b,3b]");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.ByteArray, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldThrowException_BecauseByteArrayHasTrailingComma() {
            SnbtReader reader = new SnbtReader("[B;1b,");

            Assert.ThrowsException<SnbtReaderException>(() => reader.ReadTag());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldThrowException_BecauseByteArrayIsNotClosed() {
            SnbtReader reader = new SnbtReader("[B;1b");

            Assert.ThrowsException<StringReaderException>(() => reader.ReadTag());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnIntArray() {
            SnbtReader reader = new SnbtReader("[I;]");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.IntArray, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnIntArray_WithContents() {
            SnbtReader reader = new SnbtReader("[I;1,2,3]");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.IntArray, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldThrowException_BecauseIntArrayHasTrailingComma() {
            SnbtReader reader = new SnbtReader("[I;1,");

            Assert.ThrowsException<SnbtReaderException>(() => reader.ReadTag());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldThrowException_BecauseIntArrayIsNotClosed() {
            SnbtReader reader = new SnbtReader("[I;1");

            Assert.ThrowsException<StringReaderException>(() => reader.ReadTag());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnLongArray() {
            SnbtReader reader = new SnbtReader("[L;]");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.LongArray, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnLongArray_WithContents() {
            SnbtReader reader = new SnbtReader("[L;1L,2L,3L]");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.LongArray, tag.GetTagType());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldThrowException_BecauseLongArrayHasTrailingComma() {
            SnbtReader reader = new SnbtReader("[L;1L,");

            Assert.ThrowsException<SnbtReaderException>(() => reader.ReadTag());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldThrowException_BecauseLongArrayIsNotClosed() {
            SnbtReader reader = new SnbtReader("[L;1L");

            Assert.ThrowsException<StringReaderException>(() => reader.ReadTag());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldThrowException_BecauseArrayHasInvalidType() {
            SnbtReader reader = new SnbtReader("[A;]");

            Assert.ThrowsException<SnbtReaderException>(() => reader.ReadTag());
        }

        [TestMethod]
        public void SnbtReader_ReadTagShouldReturnList_WithSecondCharacterAsArraySeparatorInsideString() {
            SnbtReader reader = new SnbtReader("[\";\"]");

            Tag tag = reader.ReadTag();
            Assert.AreEqual(TagType.List, tag.GetTagType());
        }
    }
}
