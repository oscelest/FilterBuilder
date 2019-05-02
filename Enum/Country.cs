using System;

namespace ParkingApp.Enum {
    public sealed class Country {
        private readonly string _value;

        private Country(string value) {
            _value = value;
        }

        public static Country DENMARK { get; } = new Country("DK");
        public static Country GREAT_BRITAIN { get; } = new Country("GB");

        public override string ToString() {
            return _value;
        }

        public static Country Parse(string value) {
            switch (value) {
                case "DK":
                    return DENMARK;
                case "GB":
                    return GREAT_BRITAIN;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
