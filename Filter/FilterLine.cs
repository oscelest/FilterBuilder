using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media;
using FilterBuilder.Enums;
using FilterBuilder.Helper;

namespace FilterBuilder.Filter {
    public class FilterLine<V> {
        public V Variable;
        public Tag Tag;

        public override string ToString() {
            return $"    {Tag} {Variable}";
        }

        public FilterLine(Tag tag, V variable) {
            Variable = variable;
            Tag = tag;
        }
    }
}