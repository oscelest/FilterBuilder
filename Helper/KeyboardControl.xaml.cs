using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace FilterBuilder.Helper {

    public partial class KeyboardControl {
        public char[][] Keyboard {
            get { return (char[][]) GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public static readonly DependencyProperty KeyboardProperty = DependencyProperty.Register("Keyboard", typeof(char[][]), typeof(KeyboardControl), new PropertyMetadata(new char[0][], TestPropertyCallback));

        public KeyboardControl() {
            InitializeComponent();
        }

        private static void TestPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs dEvent) {
            var dObject = d as KeyboardControl;
            var dValue = dEvent.NewValue as char[][];
            var resource = (Grid) dObject?.FindName("KeyboardControlGrid");
            resource?.Children.Clear();
            
            Debug.WriteLine(dValue);

            for (var row = 0; row < dValue?.Length; row++) {
                Debug.WriteLine("Handling row " + row);
                var line = new Grid();
                Grid.SetRow(line, row);
                resource?.RowDefinitions.Add(new RowDefinition());

                for (var column = 0; column < dValue?[row].Length; column++) {
                    Debug.WriteLine("Handling column " + column);
                    Debug.WriteLine(dValue[row][column]);
                    var button = new Button {
                        Content = dValue[row][column]
                    };
                    Grid.SetColumn(button, column);
                    line.Children.Add(button);
                    line.ColumnDefinitions.Add(new ColumnDefinition {
                        Width = new GridLength(1, GridUnitType.Star)
                    });
                }
                resource?.Children.Add(line);
            }
            
            
            
        }
    }
}
