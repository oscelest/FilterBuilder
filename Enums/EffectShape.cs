namespace FilterBuilder.Enums {
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
    }
}