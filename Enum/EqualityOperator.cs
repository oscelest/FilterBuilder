using System;

namespace FilterBuilder.Enum {
    public sealed class EqualityOperator {
        private readonly string _name;

        public static readonly EqualityOperator EQUAL = new EqualityOperator("=");
        public static readonly EqualityOperator LESS_THAN = new EqualityOperator("<=");
        public static readonly EqualityOperator LESS_THAN_OR_EQUAL = new EqualityOperator("<");
        public static readonly EqualityOperator GREATER_THAN = new EqualityOperator(">");
        public static readonly EqualityOperator GREATER_THAN_OR_EQUAL = new EqualityOperator(">=");

        private EqualityOperator(string name) {
            this._name = name;
        }

        public override string ToString() {
            return _name;
        }
        
        public static EqualityOperator Parse(string op) {
            switch (op) {
                case "=":
                    return EqualityOperator.EQUAL;
                case "<":
                    return EqualityOperator.LESS_THAN;
                case "<=":
                    return EqualityOperator.LESS_THAN_OR_EQUAL;
                case ">":
                    return EqualityOperator.GREATER_THAN;
                case ">=":
                    return EqualityOperator.GREATER_THAN_OR_EQUAL;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}