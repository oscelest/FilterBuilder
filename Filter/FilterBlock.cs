using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using FilterBuilder.Enums;
using FilterBuilder.Helper;

namespace FilterBuilder.Filter {
    public class FilterBlock {
        public bool Visibility;
        public string Name;
        public FilterCondition Conditions;
        public FilterStyle Styling;

        public FilterBlock(string block = "") {
            Conditions = new FilterCondition();
            Styling = new FilterStyle();

            using (var reader = new StringReader(block)) {
                var line = reader.ReadLine();
                this.Visibility = line == null || line == "Show";
                while ((line = reader.ReadLine()) != null) ParseLine(line.Trim(' '));
            }
        }

        public void ResetCondition() {
            Conditions = new FilterCondition();
        }

        public void ResetStyle() {
            Styling = new FilterStyle();
        }

        public override string ToString() {
            var content = new StringBuilder();
            content.AppendLine(Visibility ? "Show" : "Hide");
            content.Append(Conditions.ToString());
            content.Append(Styling.ToString());
            return content.ToString();
        }

        private void ParseLine(string line) {
            var match = new Regex(@"^(?<Tag>\w+)(?:\s(?<Values>[<=!]+|[\w""-]+)+)+$").Match(line);
            if (match.Groups["Tag"].Captures.Count == 0 || match.Groups["Values"].Captures.Count == 0) return;
            ParseTag(match.Groups["Tag"].Captures[0].Value, match.Groups["Values"].Captures.Cast<Capture>().Select(capture => capture.Value).ToList());
        }

        private object ParseTag(string tag, List<string> values) {
            switch (tag) {
                case "ItemLevel":
                    return Conditions.ItemLevel = new EqualityCondition<int>(EqualityOperator.Parse(values[0]), int.Parse(values[1]));
                case "DropLevel":
                    return Conditions.DropLevel = new EqualityCondition<int>(EqualityOperator.Parse(values[0]), int.Parse(values[1]));
                case "Quality":
                    return Conditions.Quality = new EqualityCondition<int>(EqualityOperator.Parse(values[0]), int.Parse(values[1]));
                case "Sockets":
                    return Conditions.Sockets = new EqualityCondition<int>(EqualityOperator.Parse(values[0]), int.Parse(values[1]));
                case "LinkedSockets":
                    return Conditions.LinkedSockets = new EqualityCondition<int>(EqualityOperator.Parse(values[0]), int.Parse(values[1]));
                case "Height":
                    return Conditions.Height = new EqualityCondition<int>(EqualityOperator.Parse(values[0]), int.Parse(values[1]));
                case "Width":
                    return Conditions.Width = new EqualityCondition<int>(EqualityOperator.Parse(values[0]), int.Parse(values[1]));
                case "StackSize":
                    return Conditions.StackSize = new EqualityCondition<int>(EqualityOperator.Parse(values[0]), int.Parse(values[1]));
                case "GemLevel":
                    return Conditions.GemLevel = new EqualityCondition<int>(EqualityOperator.Parse(values[0]), int.Parse(values[1]));
                case "MapTier":
                    return Conditions.MapTier = new EqualityCondition<int>(EqualityOperator.Parse(values[0]), int.Parse(values[1]));
                case "Rarity":
                    return Conditions.Rarity = new EqualityCondition<Rarity>(EqualityOperator.Parse(values[0]), Rarity.Parse(values[1]));
                case "Class":
                    return Conditions.Class = values;
                case "BaseType":
                    return Conditions.BaseType = values;
                case "HasExplicitMod":
                    return Conditions.ExplicitMods = values;
                case "HasEnchantment":
                    return Conditions.Enchantments = values;
                case "SocketGroup":
                    return Conditions.SocketGroup = values[0];
                case "AnyEnchantment":
                    return Conditions.HasEnchantment = values[0] == "True";
                case "Identified":
                    return Conditions.Identified = values[0] == "True";
                case "Corrupted":
                    return Conditions.Corrupted = values[0] == "True";
                case "ElderItem":
                    return Conditions.ElderItem = values[0] == "True";
                case "ShaperItem":
                    return Conditions.ShaperItem = values[0] == "True";
                case "FracturedItem":
                    return Conditions.FracturedItem = values[0] == "True";
                case "SynthesizedItem":
                    return Conditions.SynthesizedItem = values[0] == "True";
                case "ShapedMap":
                    return Conditions.ShapedMap = values[0] == "True";
                case "SetBackgroundColor":
                    return Styling.BackgroundColor = new RGBAColor(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));
                case "SetBorderColor":
                    return Styling.BorderColor = new RGBAColor(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));
                case "SetTextColor":
                    return Styling.TextColor = new RGBAColor(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));
                case "SetFontSize":
                    return Styling.FontSize = int.Parse(values[0]);
                case "PlayAlertSound":
                    return Styling.AlertSound = new AlertSound(int.Parse(values[0]), int.Parse(values[1]), false, null);
                case "PlayAlertSoundPositional":
                    return Styling.AlertSound = new AlertSound(int.Parse(values[0]), int.Parse(values[1]), true, null);
                case "CustomAlertSound":
                    return Styling.AlertSound = new AlertSound(null, null, false, values[0]);
                case "MinimapIcon":
                    return Styling.MinimapIcon = new MinimapIcon(int.Parse(values[0]), EffectColor.Parse(values[1]), EffectShape.Parse(values[2]));
                case "PlayEffect":
                    return Styling.BeamEffect = new BeamEffect(EffectColor.Parse(values[0]), values.ElementAtOrDefault(1) != null && (values[1] == "True"));
                default:
                    throw new NotImplementedException();
            }
        }
    }
}