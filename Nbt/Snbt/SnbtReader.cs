using Nbt.Tags;
using System;
using System.Collections.Generic;

namespace Nbt.Snbt {
    public class SnbtReader {
        private const string ExpectedArrayCharacter = "Expected character for array";
        private const string InvalidArrayType = "Invalid array type '{0}'";
        private const string MixedTagType = "Cannot add {0} to a collection of {1}";
        private const char CompoundOpenCharacter = '{';
        private const char CompoundCloseCharacter = '}';
        private const char CompoundKeyValueSeparator = ':';
        private const char ListOpenCharacter = '[';
        private const char ListCloseCharacter = ']';
        private const char ElementSeparator = ',';
        private const char ArraySeparator = ';';
        private readonly StringReader Reader;

        public SnbtReader(string snbt) {
            Reader = new StringReader(snbt);
        }

        public Tag ReadTag() {
            if (!Reader.CanRead()) {
                throw new SnbtReaderException(Reader.GetCursor(), "Expcted value");
            }
            char c = Reader.Peek();
            return c switch {
                CompoundOpenCharacter => ReadCompound(),
                ListOpenCharacter => ReadCollection(),
                _ => ReadValue()
            };
        }

        private CompoundTag ReadCompound() {
            Reader.Expect(CompoundOpenCharacter);
            CompoundTag result;
            if (!Reader.IsAt(CompoundCloseCharacter)) {
                result = ReadCompoundContents();
            } else {
                result = new CompoundTag();
            }
            Reader.Expect(CompoundCloseCharacter);
            return result;
        }

        private CompoundTag ReadCompoundContents() {
            Dictionary<string, Tag> result = new Dictionary<string, Tag>();
            while (true) {
                string key = Reader.ReadString();
                Reader.Expect(CompoundKeyValueSeparator);
                Tag value = ReadTag();
                result.Add(key, value);
                if (Reader.IsAt(ElementSeparator)) {
                    Reader.Skip();
                    continue;
                }
                break;
            }
            return new CompoundTag(result);
        }

        private CollectionTag ReadCollection() {
            if (Reader.CanRead(3) && Reader.Peek(1) != StringReader.QuoteCharacter && Reader.Peek(2) == ArraySeparator) {
                return ReadArray();
            }
            return ReadList();
        }

        private CollectionTag ReadArray() {
            Reader.Expect(ListOpenCharacter);
            if (!Reader.CanRead()) {
                throw new SnbtReaderException(Reader.GetCursor(), string.Format(ExpectedArrayCharacter));
            }
            char type = Reader.Read();
            Reader.Expect(ArraySeparator);
            CollectionTag result = type switch {
                'B' => new ByteArrayTag(),
                'I' => new IntArrayTag(),
                'L' => new LongArrayTag(),
                _ => throw new SnbtReaderException(Reader.GetCursor(), string.Format(InvalidArrayType, type))
            };
            if (!Reader.IsAt(ListCloseCharacter)) {
                ReadCollectionContents(result);
            }
            Reader.Expect(ListCloseCharacter);
            return result;
        }

        private CollectionTag ReadList() {
            Reader.Expect(ListOpenCharacter);
            ListTag result = new ListTag();
            if (!Reader.IsAt(ListCloseCharacter)) {
                ReadCollectionContents(result);
            }
            Reader.Expect(ListCloseCharacter);
            return result;
        }

        private void ReadCollectionContents(CollectionTag tag) {
            while (true) {
                int cursor = Reader.GetCursor();
                Tag value = ReadTag();
                if (!tag.Add(value)) {
                    throw new SnbtReaderException(cursor, string.Format(MixedTagType, value.GetTagType(), tag.GetElementType()));
                }
                if (Reader.IsAt(ElementSeparator)) {
                    Reader.Skip();
                    continue;
                }
                break;
            }
        }

        private Tag ReadValue() {
            if (Reader.IsAt(StringReader.QuoteCharacter)) {
                return new StringTag(Reader.ReadQuotedString());
            }

            string input = Reader.ReadUnquotedString();
            if (string.IsNullOrEmpty(input)) {
                throw new StringReaderException(Reader.GetCursor(), "Unquoted string was empty");
            }

            char lastCharacter = char.ToLowerInvariant(input[^1]);
            string inputWithoutSuffix = input[..^1];

            Tag result = lastCharacter switch {
                'b' => sbyte.TryParse(inputWithoutSuffix, out sbyte byteValue) ? new ByteTag(byteValue) : null,
                's' => short.TryParse(inputWithoutSuffix, out short shortValue) ? new ShortTag(shortValue) : null,
                'l' => long.TryParse(inputWithoutSuffix, out long longValue) ? new LongTag(longValue) : null,
                'f' => float.TryParse(inputWithoutSuffix, out float floatValue) ? new FloatTag(floatValue) : null,
                'd' => double.TryParse(inputWithoutSuffix, out double doubleValue) ? new DoubleTag(doubleValue) : null,
                _ => null
            };
            return result ?? GetValueWithoutSuffix(input);
        }

        private static Tag GetValueWithoutSuffix(string input) {
            if (int.TryParse(input, out int intValue)) {
                return new IntTag(intValue);
            }
            if (double.TryParse(input, out double doubleValue)) {
                return new DoubleTag(doubleValue);
            }
            if ("true".Equals(input, StringComparison.OrdinalIgnoreCase)) {
                return new ByteTag(1);
            }
            if ("false".Equals(input, StringComparison.OrdinalIgnoreCase)) {
                return new ByteTag(0);
            }
            return new StringTag(input);
        }
    }
}
