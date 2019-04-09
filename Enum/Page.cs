using System;

namespace FilterBuilder.Enum {
    public sealed class Page {
        private readonly string _value;

        public static readonly Page HOME = new Page("home");
        public static readonly Page UNIQUES = new Page("uniques");

        private Page(string value) {
            this._value = value;
        }

        public override string ToString() {
            return _value;
        }

        public static Page Parse(string value) {
            switch (value) {
                case "home":
                    return Page.HOME;
                case "uniques":
                    return Page.UNIQUES;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}