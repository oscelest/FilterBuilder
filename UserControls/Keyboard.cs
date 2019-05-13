using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ParkingApp.Helper {
    public delegate void CallbackDelegate(char character);

    public partial class KeyboardControl {
        public static readonly DependencyProperty KeyboardProperty =
            DependencyProperty.Register("Keyboard", typeof(Keyboard), typeof(KeyboardControl), new PropertyMetadata(new Keyboard(), KeyboardPropertyCallback));


        public Keyboard Keyboard {
            get { return GetValue(KeyboardProperty) as Keyboard; }
            set { SetValue(KeyboardProperty, value); }
        }

        public KeyboardControl() {
            InitializeComponent();
        }


        private static void KeyboardPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs dEvent) {
            var dObject = d as KeyboardControl;
            var dValue = dEvent.NewValue as Keyboard;
            var resource = (Grid) dObject?.FindName("KeyboardControlGrid");
            dValue?.Populate(resource);
        }
    }

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
            public readonly List<KeyboardKey> Keys;

            public KeyboardRow() {
                Keys = new List<KeyboardKey>();
            }

            public KeyboardRow(List<char> keys, CallbackDelegate callback) {
                Keys = new List<KeyboardKey>();
                foreach (var key in keys) PushKey(key, callback);
            }

            public KeyboardRow(List<char> keys, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
                Keys = new List<KeyboardKey>();
                foreach (var key in keys) PushKey(key, keyStyle, callback);
            }

            public KeyboardRow UnshiftKey(char key, CallbackDelegate callback) {
                Keys.Insert(0, new KeyboardKey(key, callback));
                return this;
            }

            public KeyboardRow UnshiftKey(char key, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
                Keys.Insert(0, new KeyboardKey(key, keyStyle, callback));
                return this;
            }

            public KeyboardRow InsertKey(int index, char key, CallbackDelegate callback) {
                Keys.Insert(index, new KeyboardKey(key, callback));
                return this;
            }

            public KeyboardRow InsertKey(int index, char key, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
                Keys.Insert(index, new KeyboardKey(key, keyStyle, callback));
                return this;
            }

            public KeyboardRow PushKey(char key, CallbackDelegate callback) {
                Keys.Add(new KeyboardKey(key, callback));
                return this;
            }

            public KeyboardRow PushKey(char key, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
                Keys.Add(new KeyboardKey(key, keyStyle, callback));
                return this;
            }

            public Grid ToElement() {
                var row = new Grid();
                for (var column = 0; column < Keys.Count; column++) {
                    var button = Keys[column].ToElement();
                    row.Children.Add(button);
                    Grid.SetColumn(button, column);
                    row.ColumnDefinitions.Add(new ColumnDefinition {
                        Width = new GridLength(Keys[column].KeyStyle.Width ?? 1, GridUnitType.Star)
                    });
                }

                return row;
            }
        }

        public class KeyboardKey {
            public readonly KeyboardKeyStyle KeyStyle;
            public readonly char Symbol;
            public readonly CallbackDelegate Callback;

            public KeyboardKey(char symbol, CallbackDelegate callback) {
                Symbol = symbol;
                Callback = callback;
                KeyStyle = new KeyboardKeyStyle();
            }

            public KeyboardKey(char symbol, KeyboardKeyStyle keyStyle, CallbackDelegate callback) {
                Symbol = symbol;
                Callback = callback;
                KeyStyle = keyStyle;
            }

            public Border ToElement() {
                var button = new Button {
                    Content = Symbol,
                    Style = Application.Current.FindResource("KeyboardButtonStyle") as Style
                };
                button.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler((x, o) => Callback(Symbol)), true);
                var border = new Border {
                    Child = button,
                    Style = Application.Current.FindResource("KeyboardButtonBorderStyle") as Style,
                };

                return border;
            }
        }
    }
}
