using FilterBuilder.Enum;

namespace FilterBuilder.Helper {
    public class FontSize {
        public Tag Tag { get; }
        public int Size { get; }

        public FontSize(string tag, string value) {
            Tag = Tag.Parse(tag);
            Size = int.Parse(value);
        }

        public FontSize(Tag tag, string value) {
            Tag = tag;
            Size = int.Parse(value);
        }

        public FontSize(Tag tag, int size) {
            Tag = tag;
            Size = size;
        }

        public override string ToString() {
            return $"    {Tag} {Size}";
        }
    }
}