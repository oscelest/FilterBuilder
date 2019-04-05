using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

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
                Text_Path.Text = fileDialog.FileName;
                Filter.Filter.LoadFile(fileDialog.FileName);
                this.Title = "Filter Builder - " + Filter.Filter.FileName;
                ComboBox_Blocks.ItemsSource = Filter.Filter.Blocks.Select(x => x.Name);
            }
        }

        public void Click_SaveFile(object sender, RoutedEventArgs e) {
            Filter.Filter.SaveFile();
        }

        public void Selection_FilterBlock(object sender, SelectionChangedEventArgs selectionChangedEventArgs) {
            Debug.WriteLine(selectionChangedEventArgs.AddedItems[0]);
        }

        private void Click_AddBlock(object sender, RoutedEventArgs e) {
            Filter.Filter.Blocks.Add(new Filter.FilterBlock(""));
            ComboBox_Blocks.ItemsSource = Filter.Filter.Blocks.Select(x => x.Name);
        }
    }
}