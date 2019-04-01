using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using FilterBuilder.Enums;

namespace FilterBuilder.Filter {
    public class FilterCondition {
        public Tuple<ConditionOperator, RarityCondition> LinkedSockets;
        public FilterCondition() { }

        public void SetLinkedSockets(List<string> values) {
            LinkedSockets =
                new Tuple<ConditionOperator, RarityCondition>(ConvertOperator(values[0]), ConvertRarity(values[1]));
        }

        private static RarityCondition ConvertRarity(string rarity) {
            switch (rarity) {
                case "Normal":
                    return RarityCondition.NORMAL;
                case "Magic":
                    return RarityCondition.MAGIC;
                case "Rare":
                    return RarityCondition.RARE;
                case "Unique":
                    return RarityCondition.UNIQUE;
                default:
                    throw new NotImplementedException();
            }
        }

        private static ConditionOperator ConvertOperator(string op) {
            switch (op) {
                case "=":
                    return ConditionOperator.EQUAL;
                case "<":
                    return ConditionOperator.LESS_THAN;
                case "<=":
                    return ConditionOperator.LESS_THAN_OR_EQUAL;
                case ">":
                    return ConditionOperator.GREATER_THAN;
                case ">=":
                    return ConditionOperator.GREATER_THAN_OR_EQUAL;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}