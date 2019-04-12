using System;

namespace FilterBuilder.Enum {
    public sealed class EqualityOperator {
        public static readonly EqualityOperator EQUAL = new EqualityOperator("=");
        public static readonly EqualityOperator LESS_THAN = new EqualityOperator("<=");
        public static readonly EqualityOperator LESS_THAN_OR_EQUAL = new EqualityOperator("<");
        public static readonly EqualityOperator GREATER_THAN = new EqualityOperator(">");
        public static readonly EqualityOperator GREATER_THAN_OR_EQUAL = new EqualityOperator(">=");
        private readonly string _name;

        private EqualityOperator(string name) {
            _name = name;
        }

        public override string ToString() {
            return _name;
        }

        public static EqualityOperator Parse(string op) {
            switch (op) {
                case "=":
                    return EQUAL;
                case "<":
                    return LESS_THAN;
                case "<=":
                    return LESS_THAN_OR_EQUAL;
                case ">":
                    return GREATER_THAN;
                case ">=":
                    return GREATER_THAN_OR_EQUAL;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}