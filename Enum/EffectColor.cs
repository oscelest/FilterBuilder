using System;

namespace FilterBuilder.Enum {
    public sealed class EffectColor {
        public static readonly EffectColor RED = new EffectColor("Red");
        public static readonly EffectColor GREEN = new EffectColor("Green");
        public static readonly EffectColor BLUE = new EffectColor("Blue");
        public static readonly EffectColor BROWN = new EffectColor("Brown");
        public static readonly EffectColor WHITE = new EffectColor("White");
        public static readonly EffectColor YELLOW = new EffectColor("Yellow");
        private readonly string _name;

        private EffectColor(string name) {
            _name = name;
        }

        public override string ToString() {
            return _name;
        }

        public static EffectColor Parse(string color) {
            switch (color) {
                case "Red":
                    return RED;
                case "Blue":
                    return BLUE;
                case "Brown":
                    return BROWN;
                case "Green":
                    return GREEN;
                case "White":
                    return WHITE;
                case "Yellow":
                    return YELLOW;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}