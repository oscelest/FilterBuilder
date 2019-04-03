using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using FilterBuilder.Enums;
using FilterBuilder.Helper;

namespace FilterBuilder.Filter {
    public class FilterStyle {
        public RGBAColor BackgroundColor;
        public RGBAColor BorderColor;
        public RGBAColor TextColor;
        public int? FontSize;

        public MinimapIcon MinimapIcon;
        public BeamEffect BeamEffect;
        public AlertSound AlertSound;

        public override string ToString() {
            var conditions = new StringBuilder();
            if (BackgroundColor != null) conditions.AppendLine($"    SetBackgroundColor {BackgroundColor}");
            if (BorderColor != null) conditions.AppendLine($"    SetBorderColor {BorderColor}");
            if (TextColor != null) conditions.AppendLine($"    SetTextColor {TextColor}");
            if (FontSize != null) conditions.AppendLine($"    SetFontSize {FontSize}");
            if (MinimapIcon != null) conditions.AppendLine(MinimapIcon.ToString());
            if (BeamEffect != null) conditions.AppendLine(BeamEffect.ToString());
            if (AlertSound != null) conditions.AppendLine(AlertSound.ToString());
            return conditions.ToString();
        }
    }
}