namespace FilterBuilder.Enums {
    public sealed class RarityCondition {
        private readonly string _name;

        public static readonly RarityCondition NORMAL = new RarityCondition("Normal");
        public static readonly RarityCondition MAGIC = new RarityCondition("Magic");
        public static readonly RarityCondition RARE = new RarityCondition("Rare");
        public static readonly RarityCondition UNIQUE = new RarityCondition("Unique");

        private RarityCondition(string name) {
            this._name = name;
        }

        public override string ToString() {
            return _name;
        }
    }
}