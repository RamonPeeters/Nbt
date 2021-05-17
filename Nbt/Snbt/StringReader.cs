namespace Nbt.Snbt {
    class StringReader {
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

        public void Skip() {
            Cursor++;
        }
    }
}
