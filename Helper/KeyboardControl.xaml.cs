using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ParkingApp.Helper {
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
}
