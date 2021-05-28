using System.Text;

namespace Nbt.Snbt {
    class StringReader {
        public const char QuoteCharacter = '"';
        private const char EscapeCharacter = '\\';
        private readonly string Input;
        private int Cursor;

        public StringReader(string input) {
            Input = input;
            Cursor = 0;
        }

        public int GetCursor() {
            return Cursor;
        }

        public bool CanRead() {
            return CanRead(1);
        }

        public bool CanRead(int length) {
            return Cursor + length <= Input.Length;
        }

        public char Read() {
            return Input[Cursor++];
        }

        public char Peek() {
            return Input[Cursor];
        }

        public char Peek(int offset) {
            return Input[Cursor + offset];
        }

        public void Skip() {
            Cursor++;
        }

        public string ReadString() {
            if (IsAt(QuoteCharacter)) {
                return ReadQuotedString();
            }
            return ReadUnquotedString();
        }

        public string ReadQuotedString() {
            Expect(QuoteCharacter);

            StringBuilder builder = new StringBuilder();
            bool escaped = false;
            while (CanRead()) {
                char c = Read();
                if (escaped) {
                    if (c == EscapeCharacter || c == QuoteCharacter) {
                        builder.Append(c);
                        escaped = false;
                        continue;
                    }
                    throw new StringReaderException(Cursor, $"Invalid escape character '{c}'");
                } else if (c == EscapeCharacter) {
                    escaped = true;
                } else if (c == QuoteCharacter) {
                    return builder.ToString();
                } else {
                    builder.Append(c);
                }
            }

            throw new StringReaderException(Cursor, "Expected end of quote");
        }

        public string ReadUnquotedString() {
            int start = Cursor;
            while (CanRead() && IsUnquotedStringPart(Peek())) {
                Skip();
            }
            return Input[start..Cursor];
        }

        public bool IsAt(char c) {
            return CanRead() && Peek() == c;
        }

        public void Expect(char c) {
            if (!IsAt(c)) {
                throw new StringReaderException(Cursor, $"Expected character '{c}'");
            }
            Skip();
        }

        private static bool IsUnquotedStringPart(char c) {
            return c >= '0' && c <= '9' ||
                c >= 'A' && c <= 'Z' ||
                c >= 'a' && c <= 'z' ||
                c == '_' || c == '-' ||
                c == '.' || c == '+';
        }
    }
}
