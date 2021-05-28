using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Snbt;
using System;

namespace Nbt.Tests.Snbt {
    [TestClass]
    public class StringReaderTests {
        [TestMethod]
        public void StringReader_CanReadShouldReturnTrue() {
            StringReader stringReader = new StringReader("abc");

            bool successful = stringReader.CanRead();
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void StringReader_CanReadShouldReturnFalse_BecauseNoMoreCharactersCanBeRead() {
            StringReader stringReader = new StringReader("");

            bool successful = stringReader.CanRead();
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void StringReader_CanReadWithLengthShouldReturnTrue() {
            StringReader stringReader = new StringReader("abc");

            bool successful = stringReader.CanRead(2);
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void StringReader_CanReadWithLengthShouldReturnFalse_BecauseNoMoreCharactersCanBeRead() {
            StringReader stringReader = new StringReader("abc");

            bool successful = stringReader.CanRead(5);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void StringReader_ReadShouldReturnCorrectCharacter() {
            StringReader stringReader = new StringReader("abc");

            char character = stringReader.Read();
            Assert.AreEqual('a', character);
        }

        [TestMethod]
        public void StringReader_ReadShouldThrowException_BecauseEndOfStringWasReached() {
            StringReader stringReader = new StringReader("");

            Assert.ThrowsException<IndexOutOfRangeException>(() => stringReader.Read());
        }

        [TestMethod]
        public void StringReader_PeekShouldReturnCorrectCharacter() {
            StringReader stringReader = new StringReader("abc");

            char character = stringReader.Peek();
            Assert.AreEqual('a', character);
        }

        [TestMethod]
        public void StringReader_PeekShouldThrowException_BecauseEndOfStringWasReached() {
            StringReader stringReader = new StringReader("");

            Assert.ThrowsException<IndexOutOfRangeException>(() => stringReader.Peek());
        }

        [TestMethod]
        public void StringReader_PeekShouldReturnCorrectCharacter_WithOffset() {
            StringReader stringReader = new StringReader("abc");

            char character = stringReader.Peek(1);
            Assert.AreEqual('b', character);
        }

        [TestMethod]
        public void StringReader_PeekShouldThrowException_BecauseEndOfStringWasReached_WithOffset() {
            StringReader stringReader = new StringReader("");

            Assert.ThrowsException<IndexOutOfRangeException>(() => stringReader.Peek(1));
        }

        [TestMethod]
        public void StringReader_SkipShouldSkipCharacter() {
            StringReader stringReader = new StringReader("abc");

            stringReader.Skip();
            Assert.AreEqual(1, stringReader.GetCursor());
        }

        [TestMethod]
        public void StringReader_ReadString_ShouldReadCorrectUnquotedString() {
            StringReader stringReader = new StringReader("foo bar");

            string s = stringReader.ReadString();
            Assert.AreEqual("foo", s);
        }

        [TestMethod]
        public void StringReader_ReadString_ShouldReadCorrectQuotedString() {
            StringReader stringReader = new StringReader("\"foo bar\"");

            string s = stringReader.ReadString();
            Assert.AreEqual("foo bar", s);
        }

        [TestMethod]
        public void StringReader_ReadQuotedString_ShouldReadCorrectString() {
            StringReader stringReader = new StringReader("\"foo bar\"");

            string s = stringReader.ReadQuotedString();
            Assert.AreEqual("foo bar", s);
        }

        [TestMethod]
        public void StringReader_ReadQuotedString_ShouldThrowException_BecauseFirstCharacterWasNotAQuoteCharacter() {
            StringReader stringReader = new StringReader("foo");

            Assert.ThrowsException<StringReaderException>(() => stringReader.ReadQuotedString());
        }

        [TestMethod]
        public void StringReader_ReadQuotedString_ShouldReadCorrectString_WithEscapedCharacter() {
            StringReader stringReader = new StringReader("\"\\\\\\\"\"");

            string s = stringReader.ReadQuotedString();
            Assert.AreEqual("\\\"", s);
        }

        [TestMethod]
        public void StringReader_ReadQuotedString_ShouldThrowException_BecauseEscapedCharacterWasInvalid() {
            StringReader stringReader = new StringReader("\"\\foo\"");

            Assert.ThrowsException<StringReaderException>(() => stringReader.ReadQuotedString());
        }

        [TestMethod]
        public void StringReader_ReadQuotedString_ShouldThrowException_BecauseStringDidNotEndWithQuote() {
            StringReader stringReader = new StringReader("\"foo");

            Assert.ThrowsException<StringReaderException>(() => stringReader.ReadQuotedString());
        }

        [TestMethod]
        public void StringReader_ReadUnquotedString_ShouldReadCorrectString() {
            StringReader stringReader = new StringReader("fooBAR123");

            string s = stringReader.ReadUnquotedString();
            Assert.AreEqual("fooBAR123", s);
        }

        [TestMethod]
        public void StringReader_ReadUnquotedString_ShouldReadCorrectString_WithTrailingCharacters() {
            StringReader stringReader = new StringReader("fooBAR123!");

            string s = stringReader.ReadUnquotedString();
            Assert.AreEqual("fooBAR123", s);
        }

        [TestMethod]
        public void StringReader_IsAt_ShouldReturnTrue() {
            StringReader stringReader = new StringReader("a");

            bool successful = stringReader.IsAt('a');
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void StringReader_IsAt_ShouldReturnFalse() {
            StringReader stringReader = new StringReader("a");

            bool successful = stringReader.IsAt('b');
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void StringReader_Expect_ShouldSkipCharacter_BecauseCharacterWasAtCursor() {
            StringReader stringReader = new StringReader("a");

            stringReader.Expect('a');
            Assert.AreEqual(1, stringReader.GetCursor());
        }

        [TestMethod]
        public void StringReader_Expect_ShouldThrowException_BecauseCharacterWasNotAtCursor() {
            StringReader stringReader = new StringReader("a");

            Assert.ThrowsException<StringReaderException>(() => stringReader.Expect('b'));
        }
    }
}
