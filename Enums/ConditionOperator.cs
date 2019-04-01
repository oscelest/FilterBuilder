namespace FilterBuilder.Enums {
    public sealed class ConditionOperator {
        private readonly string _name;

        public static readonly ConditionOperator EQUAL = new ConditionOperator("=");
        public static readonly ConditionOperator LESS_THAN = new ConditionOperator("<=");
        public static readonly ConditionOperator LESS_THAN_OR_EQUAL = new ConditionOperator("<");
        public static readonly ConditionOperator GREATER_THAN = new ConditionOperator(">");
        public static readonly ConditionOperator GREATER_THAN_OR_EQUAL = new ConditionOperator(">=");

        private ConditionOperator(string name) {
            this._name = name;
        }

        public override string ToString() {
            return _name;
        }
    }
}