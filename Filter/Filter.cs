using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace FilterBuilder.Filter {
    public static class Filter {
        public static string FileName;
        public static string FilePath;
        public static List<FilterBlock> Blocks;

        static Filter() {
            FileName = null;
            FilePath = null;
            Blocks = null;
        }

        public static void LoadFile(string path) {
            FilePath = path;
            FileName = Path.GetFileName(path);
            Blocks = new List<FilterBlock>();

            System.Diagnostics.Debug.WriteLine("File loaded: " + FileName);

            foreach (Match m in new Regex(@"(Show|Hide)(\r\n\s{4}[\w =]+)+").Matches(File.ReadAllText(path))) {
                Debug.WriteLine(m.Value);
                Blocks.Add(new FilterBlock(m.Value));
            }
        }
    }
}