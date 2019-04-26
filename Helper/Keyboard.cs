using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace FilterBuilder.Helper {
    public delegate void CallbackDelegate(char character);

    public class Keyboard {
        public readonly List<KeyboardRow> Layout;

        public Keyboard() {
            Layout = new List<KeyboardRow>();
        }

        public Keyboard UnshiftRow(List<char> keys, CallbackDelegate callback) {
            Layout.Insert(0, new KeyboardRow(keys, callback));
            return this;
        }

        public Keyboard InsertRow(int rowIndex, List<char> keys, CallbackDelegate callback) {
            Layout.Insert(rowIndex, new KeyboardRow(keys, callback));
            return this;
        }

        public Keyboard PushRow(List<char> keys, CallbackDelegate callback) {
            Layout.Add(new KeyboardRow(keys, callback));
            return this;
        }

        public Keyboard UnshiftKey(int rowIndex, char key, CallbackDelegate callback) {
            Layout[rowIndex].UnshiftKey(key, callback);
            return this;
        }

        public Keyboard InsertKey(int rowIndex, int keyIndex, char key, CallbackDelegate callback) {
            Layout[rowIndex].InsertKey(keyIndex, key, callback);
            return this;
        }

        public Keyboard PushKey(int rowIndex, char key, CallbackDelegate callback) {
            Layout[rowIndex].PushKey(key, callback);
            return this;
        }

        public class KeyboardRow {
            private readonly List<KeyboardKey> _keys;

            public KeyboardRow() {
                _keys = new List<KeyboardKey>();
            }

            public KeyboardRow(List<char> keys, CallbackDelegate callback) {
                _keys = new List<KeyboardKey>();
                foreach (var key in keys) PushKey(key, callback);
            }

            public KeyboardRow UnshiftKey(char key, CallbackDelegate callback) {
                _keys.Insert(0, new KeyboardKey(key, callback));
                return this;
            }

            public KeyboardRow InsertKey(int index, char key, CallbackDelegate callback) {
                _keys.Insert(index, new KeyboardKey(key, callback));
                return this;
            }

            public KeyboardRow PushKey(char key, CallbackDelegate callback) {
                _keys.Add(new KeyboardKey(key, callback));
                return this;
            }

            public Grid ToElement() {
                var grid = new Grid();
                foreach (var key in _keys) grid.Children.Add(key.ToElement());
                return grid;
            }
        }

        public class KeyboardKey {
            private readonly char _symbol;
            private readonly CallbackDelegate _callback;

            public KeyboardKey(char symbol, CallbackDelegate callback) {
                _symbol = symbol;
                _callback = callback;
            }

            public Button ToElement() {
                var button = new Button {
                    Content = _symbol
                };
                button.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler((x,o) => _callback(_symbol)), true);
                return button;
            }
        }
    }
}
