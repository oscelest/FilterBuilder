using System;

namespace FilterBuilder.Enum {
    public sealed class Language {
        private readonly string _value;
        public static Language DANISH { get; } = new Language("da-DK");
        public static Language ENGLISH { get; } = new Language("en-GB");

        private Language(string value) {
            _value = value;
        }

        public override string ToString() {
            return _value;
        }

        public static Language Parse(string value) {
            switch (value) {
                case "da-DK":
                    return DANISH;
                case "en-US":
                    return ENGLISH;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}