using System;
using System.Collections.Generic;
using FilterBuilder.Enum;
using FilterBuilder.Interface;
using FilterBuilder.ViewModel;

namespace FilterBuilder.Model {
    public class Filter {
        public bool UnsavedChanges { get; set; } = false;
        public string Name { get; set; } = "";
        public string Path { get; set; } = System.IO.Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", "My Games", "Path of Exile");

        public List<FilterCategory> Categories { get; } = new List<FilterCategory>();

        public Filter() {
            Categories.Add(new FilterCategory());
        }
    }
}
