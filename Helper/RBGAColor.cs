using System.Collections.Generic;
using System.Linq;

namespace FilterBuilder.Helper {
    public class RGBAColor {
        public int Red { get; }
        public int Green { get; }
        public int Blue { get; }
        public int? Alpha { get; }

        public RGBAColor(List<int> values) {
            Red = values[0];
            Green = values[1];
            Blue = values[2];
            Alpha = values[3];
        }

        public RGBAColor(List<string> values) {
            Red = int.Parse(values[0]);
            Green = int.Parse(values[1]);
            Blue = int.Parse(values[2]);
            Alpha = values.ElementAtOrDefault(1) != null ? int.Parse(values[3]) : 0;
        }

        public RGBAColor(int red, int green, int blue, int? alpha) {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        public override string ToString() {
            return $"{Red} {Green} {Blue} {Alpha ?? 0}";
        }
    }
}