using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Media;
using FilterBuilder.Enums;
using FilterBuilder.Helper;
using Color = FilterBuilder.Helper.Color;

namespace FilterBuilder.Filter {
    public class FilterStyle {
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
        public Color TextColor { get; set; }
        public FontSize FontSize { get; set; }
        public MinimapIcon MinimapIcon { get; set; }
        public BeamEffect BeamEffect { get; set; }
        public AlertSound AlertSound { get; set; }

        public override string ToString() {
            var styling = new StringBuilder();
            foreach (var line in GetType().GetProperties().Where((prop) => prop.GetValue(this) != null).Select((prop) => prop.GetValue(this))) styling.AppendLine(line.ToString());
            return styling.ToString();
        }
    }
}