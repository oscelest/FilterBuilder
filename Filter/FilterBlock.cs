using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using FilterBuilder.Enums;

namespace FilterBuilder.Filter {
    public class FilterBlock {
        public bool Visibility;
        public string Name;
        public FilterCondition Condition;
        public FilterStyle Style;

        public FilterBlock(string block = "") {
            Condition = new FilterCondition();
            Style = new FilterStyle();
            
            using (var reader = new StringReader(block)) {
                var line = reader.ReadLine();
                this.Visibility = line == null || line == "Show";
                while ((line = reader.ReadLine()) != null) ParseLine(line.Trim(' '));
            }
        }

        private static void ParseLine(string line) {
            var match = new Regex(@"^(?<Tag>\w+)(?:\s(?<Values>[<=!]+|\w+)+)+$").Match(line);
            if (match.Groups["Tag"].Captures.Count == 0 || match.Groups["Values"].Captures.Count == 0) return;
            ParseTag(match.Groups["Tag"].Captures[0].Value, match.Groups["Values"].Captures.Cast<Capture>().Select(capture => capture.Value).ToList());
        }

        private static void ParseTag(string tag, List<string> values) {
            switch (tag) {
                case "LinkedSockets":
//                        Condition.SetLinkedSockets(values);
                    break;
                default:
                    break;
            }
        }
    }
}