using FilterBuilder.Enum;

namespace FilterBuilder.Filter {
    public class FilterLine<TV> {
        public TV Variable { get; }
        public Tag Tag { get; }

        public override string ToString() {
            return $"    {Tag} {Variable}";
        }

        public FilterLine(Tag tag, TV variable) {
            Variable = variable;
            Tag = tag;
        }
    }
}