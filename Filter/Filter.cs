using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace FilterBuilder.Filter {
    public static class Filter {
        public static string FileName;
        public static string FilePath;
        public static List<FilterBlock> Blocks;

        static Filter() {
            FileName = null;
            FilePath = null;
            Blocks = new List<FilterBlock>();
        }

        public static void LoadFile(string path) {
            FilePath = path;
            FileName = Path.GetFileName(path);
            Blocks = new List<FilterBlock>();
            FilterBlock.NextId = 0;

            foreach (Match m in new Regex(@"(?:(?:#@\w+ ""([\w ]+)""\r\n)+)?(?:\r\n)*(Show|Hide)(?:(?:\r\n\s{4})([\w =]+))+").Matches(File.ReadAllText(path))) {
                Blocks.Add(new FilterBlock(m.Value));
            }
        }

        public static void SaveFile() {
            var content = new StringBuilder();
            Blocks.ForEach(block => { content.AppendLine(block.ToString()); });
            Debug.Write(content);
        }
    }
}