using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using FilterBuilder.Enums;

namespace FilterBuilder.Filter {
    
    public class FilterCondition {

        public Tuple<ConditionOperator, string> LinkedSockets;
        public FilterCondition() {
            var test = ConditionOperator.GREATER; // "<"
        }

        public void SetLinkedSockets(List<string> values) {
            LinkedSockets = new Tuple<ConditionOperator, string>(ConvertOperator(values[0]), values[1]); 
        }

        private ConditionOperator ConvertOperator(string op) {
            switch (op) {
                case "=":
                    return ConditionOperator.EQUAL;
                
                default: throw new NotImplementedException();
            }
        }

    }
}