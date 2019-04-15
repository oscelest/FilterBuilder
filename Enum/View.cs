using System;

namespace FilterBuilder.Enum {
    public sealed class View {
        public static View HOME { get; } = new View("home");
        public static View EDITOR { get; } = new View("editor");
        private readonly string _value;

        private View(string value) {
            _value = value;
        }

        public override string ToString() {
            return _value;
        }

        public static View Parse(string value) {
            switch (value) {
                case "home":
                    return HOME;
                case "editor":
                    return EDITOR;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}