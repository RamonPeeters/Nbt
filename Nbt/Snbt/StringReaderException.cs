using System;
using System.Runtime.Serialization;

namespace Nbt.Snbt {
    public class StringReaderException : Exception {
        public int Position { get; }

        public StringReaderException(int position, string message) : base(message) {
            Position = position;
        }

        public StringReaderException(int position, string message, Exception innerException) : base(message, innerException) {
            Position = position;
        }

        protected StringReaderException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}
