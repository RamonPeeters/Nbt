using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nbt.Snbt;
using System.Collections.Generic;

namespace Nbt.Tests.Snbt {
    [TestClass]
    public class SnbtWriterTests {
        [TestMethod]
        public void SnbtWriter_ShouldWriteByteCorrectly() {
            SnbtWriter snbtWriter = new SnbtWriter();
            snbtWriter.Write((sbyte)1);
            Assert.AreEqual("1b", snbtWriter.ToString());
        }

        [TestMethod]
        public void SnbtWriter_ShouldWriteShortCorrectly() {
            SnbtWriter snbtWriter = new SnbtWriter();
            snbtWriter.Write((short)1);
            Assert.AreEqual("1s", snbtWriter.ToString());
        }

        [TestMethod]
        public void SnbtWriter_ShouldWriteIntCorrectly() {
            SnbtWriter snbtWriter = new SnbtWriter();
            snbtWriter.Write(1);
            Assert.AreEqual("1", snbtWriter.ToString());
        }

        [TestMethod]
        public void SnbtWriter_ShouldWriteLongCorrectly() {
            SnbtWriter snbtWriter = new SnbtWriter();
            snbtWriter.Write(1L);
            Assert.AreEqual("1L", snbtWriter.ToString());
        }

        [TestMethod]
        public void SnbtWriter_ShouldWriteFloatCorrectly() {
            SnbtWriter snbtWriter = new SnbtWriter();
            snbtWriter.Write(1.5f);
            Assert.AreEqual("1.5f", snbtWriter.ToString());
        }

        [TestMethod]
        public void SnbtWriter_ShouldWriteDoubleCorrectly() {
            SnbtWriter snbtWriter = new SnbtWriter();
            snbtWriter.Write(1.5d);
            Assert.AreEqual("1.5d", snbtWriter.ToString());
        }

        [TestMethod]
        public void SnbtWriter_ShouldWriteCharCorrectly() {
            SnbtWriter snbtWriter = new SnbtWriter();
            snbtWriter.Write('a');
            Assert.AreEqual("a", snbtWriter.ToString());
        }

        [TestMethod]
        public void SnbtWriter_ShouldWriteStringCorrectly() {
            SnbtWriter snbtWriter = new SnbtWriter();
            snbtWriter.Write("foo");
            Assert.AreEqual("foo", snbtWriter.ToString());
        }

        [TestMethod]
        public void SnbtWriter_ShouldWriteCollectionCorrectly() {
            SnbtWriter snbtWriter = new SnbtWriter();
            List<int> items = new List<int>() { 1, 2, 3 };

            snbtWriter.Write(items, ",", (writer, value) => {
                writer.Write(value);
            });
            Assert.AreEqual("1,2,3", snbtWriter.ToString());
        }
    }
}
