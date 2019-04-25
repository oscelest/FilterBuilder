using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace FilterBuilder.Helper {
    public class Keyboard {
        public char[][] Layout { get; }
        public RoutedEventHandler Callback { get; }

        public Keyboard(char[][] layout, RoutedEventHandler callback) {
            Layout = layout;
            Callback = callback;
        }

        public Grid ToElement() {
            var wrapper = new Grid();

            for (var row = 0; row < Layout.Length; row++) {
                var line = new Grid();
                Grid.SetRow(line, row);
                wrapper.RowDefinitions.Add(new RowDefinition());

                for (var column = 0; column < Layout[row].Length; column++) {
                    var button = new Button {
                        Content = Layout[row][column]
                    };
                    button.Click += Callback;
                    Grid.SetColumn(button, column);
                    line.Children.Add(button);
                    line.ColumnDefinitions.Add(new ColumnDefinition {
                        Width = new GridLength(1, GridUnitType.Star)
                    });
                }
            }

            return wrapper;
        }
    }
}
