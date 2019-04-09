using System.Collections.Generic;
using FilterBuilder.Enum;

namespace FilterBuilder.Helper {
    public class ValueCondition<T> {
        public Tag Tag { get; }
        public T Value { get; }

        public ValueCondition(Tag tag, T value) {
            Tag = tag;
            Value = value;
        }

        public ValueCondition(string tag, List<string> values) {
            Tag = Tag.Parse(tag);
            if (typeof(T) == typeof(bool)) Value = (T) (object) (values[0] == "True");
            else if (typeof(T) == typeof(List<string>)) Value = (T) (object) values;
            else Value = (T) (object) values[0];
        }

        public override string ToString() {
            var value = (object) Value;
            if (Value is List<string>) return $"    {Tag} \"{string.Join("\" \"", ((List<string>) value).ToArray())}\"";
            if (Value is bool) return $"    {Tag} {((bool) value ? "True" : "False")}";
            return $"    {Tag} {value}";
        }
    }
}