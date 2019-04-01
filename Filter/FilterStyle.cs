using System;
using System.Windows.Media;
using FilterBuilder.Enums;

namespace FilterBuilder.Filter {
    public class FilterStyle {
        public Color BackgroundColor;
        public Color BorderColor;
        public int FontSize;

        public int MinimapIconSize;
        public EffectColor MinimapIconColor;
        public EffectShape MinimapIconShape;

        public EffectColor BeamEffectColor;
        public Boolean BeamEffectTemporary;

        public int AlertSoundType;
        public int AlertSoundVolume;

        public FilterStyle() { }

        public void SetBackgroundColor(byte red, byte green, byte blue, byte alpha) {
            this.BackgroundColor.R = red;
            
        }
    }
}