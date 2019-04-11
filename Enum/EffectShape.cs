using System;

namespace FilterBuilder.Enum {
    public sealed class EffectShape {
        private readonly string _name;

        public static readonly EffectShape CIRCLE = new EffectShape("Circle");
        public static readonly EffectShape DIAMOND = new EffectShape("Diamond");
        public static readonly EffectShape HEXAGON = new EffectShape("Hexagon");
        public static readonly EffectShape SQUARE = new EffectShape("Square");
        public static readonly EffectShape STAR = new EffectShape("Star");
        public static readonly EffectShape TRIANGLE = new EffectShape("Triangle");

        private EffectShape(string name) {
            this._name = name;
        }

        public override string ToString() {
            return _name;
        }

        public static EffectShape Parse(string shape) {
            switch (shape) {
                case "Star":
                    return EffectShape.STAR;
                case "Circle":
                    return EffectShape.CIRCLE;
                case "Square":
                    return EffectShape.SQUARE;
                case "Diamond":
                    return EffectShape.DIAMOND;
                case "Hexagon":
                    return EffectShape.HEXAGON;
                case "Triangle":
                    return EffectShape.TRIANGLE;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}