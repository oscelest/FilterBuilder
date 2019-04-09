using FilterBuilder.Enum;

namespace FilterBuilder.Helper {
    public class BeamEffect {
        public EffectColor Color { get; }
        public bool Temporary { get; }

        public BeamEffect(EffectColor color, bool? temporary) {
            Color = color;
            Temporary = temporary ?? false;
        }

        public override string ToString() {
            return $"    PlayEffect {Color} {(Temporary ? "Temp" : "")}";
        }
    }
}