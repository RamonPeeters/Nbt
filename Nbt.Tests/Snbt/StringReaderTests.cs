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
        public void StringReader_SkipShouldSkipCharacter() {
            StringReader stringReader = new StringReader("abc");

            stringReader.Skip();
            Assert.AreEqual(1, stringReader.GetCursor());
        }
    }
}
