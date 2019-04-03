using System;

namespace FilterBuilder.Enums {
    public sealed class EffectColor {
        private readonly string _name;

        public static readonly EffectColor RED = new EffectColor("Red");
        public static readonly EffectColor GREEN = new EffectColor("Green");
        public static readonly EffectColor BLUE = new EffectColor("Blue");
        public static readonly EffectColor BROWN = new EffectColor("Brown");
        public static readonly EffectColor WHITE = new EffectColor("White");
        public static readonly EffectColor YELLOW = new EffectColor("Yellow");

        private EffectColor(string name) {
            this._name = name;
        }

        public override string ToString() {
            return _name;
        }

        public static EffectColor Parse(string color) {
            switch (color) {
                case "Red":
                    return EffectColor.RED;
                case "Blue":
                    return EffectColor.BLUE;
                case "Brown":
                    return EffectColor.BROWN;
                case "Green":
                    return EffectColor.GREEN;
                case "White":
                    return EffectColor.WHITE;
                case "Yellow":
                    return EffectColor.YELLOW;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}