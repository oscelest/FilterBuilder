using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace ParkingApp.Helper {
    public delegate void CallbackDelegate(char character);

    public class KeyboardKeyStyle {
        public double? Width { get; set; }
    }

    public class Keyboard {
        public readonly List<KeyboardRow> Layout;

        public Keyboard() {
            Layout = new List<KeyboardRow>();
        }

        public Keyboard UnshiftRow(List<char> keys, CallbackDelegate callback) {
            Layout.Insert(0, new KeyboardRow(keys, callback));
            return this;
        }

        public Keyboard UnshiftRow(List<char> keys, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
            Layout.Insert(0, new KeyboardRow(keys, keyStyle, callback));
            return this;
        }

        public Keyboard InsertRow(int rowIndex, List<char> keys, CallbackDelegate callback) {
            Layout.Insert(rowIndex, new KeyboardRow(keys, callback));
            return this;
        }

        public Keyboard InsertRow(int rowIndex, List<char> keys, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
            Layout.Insert(rowIndex, new KeyboardRow(keys, keyStyle, callback));
            return this;
        }

        public Keyboard PushRow(List<char> keys, CallbackDelegate callback) {
            Layout.Add(new KeyboardRow(keys, callback));
            return this;
        }

        public Keyboard PushRow(List<char> keys, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
            Layout.Add(new KeyboardRow(keys, keyStyle, callback));
            return this;
        }

        public Keyboard UnshiftKey(int rowIndex, char key, CallbackDelegate callback) {
            Layout[rowIndex].UnshiftKey(key, callback);
            return this;
        }

        public Keyboard UnshiftKey(int rowIndex, char key, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
            Layout[rowIndex].UnshiftKey(key, keyStyle, callback);
            return this;
        }

        public Keyboard InsertKey(int rowIndex, int keyIndex, char key, CallbackDelegate callback) {
            Layout[rowIndex].InsertKey(keyIndex, key, callback);
            return this;
        }

        public Keyboard InsertKey(int rowIndex, int keyIndex, char key, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
            Layout[rowIndex].InsertKey(keyIndex, key, keyStyle, callback);
            return this;
        }

        public Keyboard PushKey(int rowIndex, char key, CallbackDelegate callback) {
            Layout[rowIndex].PushKey(key, callback);
            return this;
        }

        public Keyboard PushKey(int rowIndex, char key, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
            Layout[rowIndex].PushKey(key, keyStyle, callback);
            return this;
        }

        public void Populate(Grid frame) {
            frame.Children.Clear();
            frame.Margin = new Thickness(0, 0, 10, 10);
            for (var row = 0; row < Layout.Count; row++) {
                var line = Layout[row].ToElement();
                Grid.SetRow(line, row);
                frame.RowDefinitions.Add(new RowDefinition());
                frame.Children.Add(line);
            }
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

            public KeyboardRow(List<char> keys, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
                _keys = new List<KeyboardKey>();
                foreach (var key in keys) PushKey(key, keyStyle, callback);
            }

            public KeyboardRow UnshiftKey(char key, CallbackDelegate callback) {
                _keys.Insert(0, new KeyboardKey(key, callback));
                return this;
            }

            public KeyboardRow UnshiftKey(char key, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
                _keys.Insert(0, new KeyboardKey(key, keyStyle, callback));
                return this;
            }

            public KeyboardRow InsertKey(int index, char key, CallbackDelegate callback) {
                _keys.Insert(index, new KeyboardKey(key, callback));
                return this;
            }

            public KeyboardRow InsertKey(int index, char key, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
                _keys.Insert(index, new KeyboardKey(key, keyStyle, callback));
                return this;
            }

            public KeyboardRow PushKey(char key, CallbackDelegate callback) {
                _keys.Add(new KeyboardKey(key, callback));
                return this;
            }

            public KeyboardRow PushKey(char key, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
                _keys.Add(new KeyboardKey(key, keyStyle, callback));
                return this;
            }

            public Grid ToElement() {
                var row = new Grid();
                for (var column = 0; column < _keys.Count; column++) {
                    var button = _keys[column].ToElement();
                    row.Children.Add(button);
                    Grid.SetColumn(button, column);
                    row.ColumnDefinitions.Add(new ColumnDefinition {
                        Width = new GridLength(_keys[column].KeyStyle.Width ?? 1, GridUnitType.Star)
                    });
                }

                return row;
            }
        }

        public class KeyboardKey {
            public readonly KeyboardKeyStyle KeyStyle;
            private readonly char _symbol;
            private readonly CallbackDelegate _callback;

            public KeyboardKey(char symbol, CallbackDelegate callback) {
                _symbol = symbol;
                _callback = callback;
                KeyStyle = new KeyboardKeyStyle();
            }

            public KeyboardKey(char symbol, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
                _symbol = symbol;
                _callback = callback;
                KeyStyle = keyStyle;
            }

            public Border ToElement() {
                var button = new Button {
                    Content = _symbol,
                    Style = Application.Current.FindResource("KeyboardButtonStyle") as Style
                };
                button.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler((x, o) => _callback(_symbol)), true);
                var border = new Border {
                    Child = button,
                    Style = Application.Current.FindResource("KeyboardButtonBorderStyle") as Style,
                };

                return border;
            }
        }
    }
}
