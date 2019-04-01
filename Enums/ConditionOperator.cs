namespace FilterBuilder.Enums {
    public sealed class ConditionOperator {
        private readonly string _name;

        public static readonly ConditionOperator EQUAL = new ConditionOperator("=");
        public static readonly ConditionOperator LESS = new ConditionOperator("<=");
        public static readonly ConditionOperator LESSOREQUAL = new ConditionOperator("<");
        public static readonly ConditionOperator GREATER = new ConditionOperator(">");
        public static readonly ConditionOperator GREATEROREQUAL = new ConditionOperator(">=");

        private ConditionOperator(string name) {
            this._name = name;
        }

        public override string ToString() {
            return _name;
        }
    }
}