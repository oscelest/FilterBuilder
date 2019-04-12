using System;

namespace FilterBuilder.Enum {
    public sealed class EffectShape {
        public static readonly EffectShape CIRCLE = new EffectShape("Circle");
        public static readonly EffectShape DIAMOND = new EffectShape("Diamond");
        public static readonly EffectShape HEXAGON = new EffectShape("Hexagon");
        public static readonly EffectShape SQUARE = new EffectShape("Square");
        public static readonly EffectShape STAR = new EffectShape("Star");
        public static readonly EffectShape TRIANGLE = new EffectShape("Triangle");
        private readonly string _name;

        private EffectShape(string name) {
            _name = name;
        }

        public override string ToString() {
            return _name;
        }

        public static EffectShape Parse(string shape) {
            switch (shape) {
                case "Star":
                    return STAR;
                case "Circle":
                    return CIRCLE;
                case "Square":
                    return SQUARE;
                case "Diamond":
                    return DIAMOND;
                case "Hexagon":
                    return HEXAGON;
                case "Triangle":
                    return TRIANGLE;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}