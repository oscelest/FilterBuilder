using System;

namespace ParkingApp.Enum {
    public sealed class Language {
        private readonly string _value;

        private Language(string value) {
            _value = value;
        }

        public static Language DANISH { get; } = new Language("da-DK");
        public static Language ENGLISH { get; } = new Language("en-GB");
        public static Language MISSING { get; } = new Language("missing");

        public override string ToString() {
            return _value;
        }

        public static Language Parse(string value) {
            switch (value) {
                case "da-DK":
                    return DANISH;
                case "en-US":
                    return ENGLISH;
                case "missing":
                    return MISSING;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
