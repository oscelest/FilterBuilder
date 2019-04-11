using FilterBuilder.Enum;

namespace FilterBuilder.Helper {
    public class MinimapIcon {
        public int Size { get; }
        public EffectColor Color { get; }
        public EffectShape Shape { get; }

        public MinimapIcon(int size, EffectColor color, EffectShape shape) {
            Size = size;
            Color = color;
            Shape = shape;
        }

        public override string ToString() {
            return $"    MinimapIcon {Size} {Color} {Shape}";
        }
    }
}