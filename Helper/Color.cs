using System.Collections.Generic;
using System.Linq;
using FilterBuilder.Enum;

namespace FilterBuilder.Helper {
    public class Color {
        public Tag Tag { get; }
        public int Red { get; }
        public int Green { get; }
        public int Blue { get; }
        public int? Alpha { get; }

        public Color(string tag, List<string> values) {
            Tag = Tag.Parse(tag);
            Red = int.Parse(values[0]);
            Green = int.Parse(values[1]);
            Blue = int.Parse(values[2]);
            Alpha = values.ElementAtOrDefault(1) != null ? int.Parse(values[3]) : 0;
        }

        public Color(Tag tag, List<string> values) {
            Tag = tag;
            Red = int.Parse(values[0]);
            Green = int.Parse(values[1]);
            Blue = int.Parse(values[2]);
            Alpha = values.ElementAtOrDefault(1) != null ? int.Parse(values[3]) : 0;
        }

        public Color(Tag tag, List<int> values) {
            Tag = tag;
            Red = values[0];
            Green = values[1];
            Blue = values[2];
            Alpha = values[3];
        }

        public Color(Tag tag, int red, int green, int blue, int? alpha) {
            Tag = tag;
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        public override string ToString() {
            return $"    {Tag} {Red} {Green} {Blue} {Alpha ?? 0}";
        }
    }
}