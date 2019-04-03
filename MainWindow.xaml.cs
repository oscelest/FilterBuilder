using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace FilterBuilder {
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();

            //Dummy Data
            FilterList.Items.Add(new FilterFile(){Name = "NeverSink - 0 SOFT", Path = "C:\\Documents\\My Games\\Path of Exile"});
            FilterList.Items.Add(new FilterFile(){Name = "NeverSink - 1 REGULAR", Path = "C:\\Documents\\My Games\\Path of Exile"});
            FilterList.Items.Add(new FilterFile(){Name = "NeverSink - 2 SEMI-SCRICT", Path = "C:\\Documents\\My Games\\Path of Exile"});
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

    class FilterFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}