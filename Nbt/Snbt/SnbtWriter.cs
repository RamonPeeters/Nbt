using System.Globalization;
using System.Text;

namespace Nbt.Snbt {
    public class SnbtWriter {
        private static readonly NumberFormatInfo NbtNumberFormatInfo = new NumberFormatInfo() {
            NumberDecimalSeparator = ".",
            PositiveInfinitySymbol = "Infinity",
            NegativeInfinitySymbol = "-Infinity",
            NegativeSign = "-",
            PositiveSign = "+",
            NaNSymbol = "NaN"
        };
        private readonly StringBuilder Builder;

        public SnbtWriter() {
            Builder = new StringBuilder();
        }

        public void Write(sbyte value) {
            Builder.Append(value.ToString(NbtNumberFormatInfo)).Append('b');
        }

        public void Write(short value) {
            Builder.Append(value.ToString(NbtNumberFormatInfo)).Append('s');
        }

        public void Write(int value) {
            Builder.Append(value.ToString(NbtNumberFormatInfo));
        }

        public void Write(long value) {
            Builder.Append(value.ToString(NbtNumberFormatInfo)).Append('L');
        }

        public void Write(float value) {
            Builder.Append(value.ToString(NbtNumberFormatInfo)).Append('f');
        }

        public void Write(double value) {
            Builder.Append(value.ToString(NbtNumberFormatInfo)).Append('d');
        }

        public void Write(char value) {
            Builder.Append(value);
        }

        public void Write(string value) {
            Builder.Append(value);
        }

        public override string ToString() {
            return Builder.ToString();
        }

        public int Length {
            get {
                return Builder.Length;
            }
            set {
                Builder.Length = value;
            }
        }
    }
}
