using System;
using FilterBuilder.Enums;

namespace FilterBuilder.Helper {
    public class EqualityCondition<T> {
        public EqualityOperator Operator;
        public T Value;

        public EqualityCondition(EqualityOperator op, T value) {
            Operator = op;
            Value = value;
        }

        public override string ToString() {
            return $"{Operator} {Value}";
        }
    }
}