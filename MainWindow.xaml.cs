using System;
using System.IO;
using System.Windows;

namespace FilterBuilder {
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
        }

        public void Click_LoadFile(object sender, RoutedEventArgs e) {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

            fileDialog.Filter = "filter files (*.filter)|*.filter";
            fileDialog.InitialDirectory = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", "My Games", "Path of Exile");
            
            bool? fileSelected = fileDialog.ShowDialog();
            
            System.Diagnostics.Debug.WriteLine("Dialog closed");
            
            if (fileSelected == true) {
                System.Diagnostics.Debug.WriteLine("File found");
                Filter.Filter.LoadFile(fileDialog.FileName);
            }
        }
    }
}