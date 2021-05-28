using System;
using System.Runtime.Serialization;

namespace Nbt.Snbt {
    public class SnbtReaderException : Exception {
        public int Position { get; }

        public SnbtReaderException(int position) {
            Position = position;
        }

        public SnbtReaderException(int position, string message) : base(message) {
            Position = position;
        }

        public SnbtReaderException(int position, string message, Exception innerException) : base(message, innerException) {
            Position = position;
        }

        protected SnbtReaderException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}
