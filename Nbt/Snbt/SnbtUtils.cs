using System.Text;

namespace Nbt.Snbt {
    static class SnbtUtils {
        public static string Escape(this string value, char escapedCharacter) {
            StringBuilder builder = new StringBuilder(value.Length);
            foreach (char c in value) {
                if (c == '\\' || c == escapedCharacter) {
                    builder.Append('\\');
                }
                builder.Append(c);
            }
            return builder.ToString();
        }

        public static string QuoteIfRequired(this string s) {
            for (int i = 0; i < s.Length; i++) {
                if (!StringReader.IsUnquotedStringPart(s[i])) {
                    return $"\"{s.Escape('"')}\"";
                }
            }
            return s;
        }
    }
}
