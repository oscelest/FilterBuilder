using System;

namespace FilterBuilder.Enum {
    public sealed class View {
        private readonly string _value;

        private View(string value) {
            _value = value;
        }

        public static View HOME { get; } = new View("home");
        public static View REGISTER { get; } = new View("register");
        public static View COMPLETE { get; } = new View("complete");
        public static View PAYMENT { get; } = new View("payment");

        public override string ToString() {
            return _value;
        }

        public static View Parse(string value) {
            switch (value) {
                case "home":
                    return HOME;
                case "register":
                    return REGISTER;
                case "complete":
                    return COMPLETE;
                case "payment":
                    return PAYMENT;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}