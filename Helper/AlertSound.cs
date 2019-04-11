using FilterBuilder.Enum;

namespace FilterBuilder.Helper {
    public class AlertSound {
        public int? Id { get; }
        public int? Volume { get; }
        public bool? Positional { get; }
        public string CustomFile { get; }

        public AlertSound(int? id, int? volume, bool positional, string customFile) {
            Id = id;
            Volume = volume;
            Positional = positional;
            CustomFile = customFile;
        }

        public override string ToString() {
            return CustomFile != null ? $"    CustomAlertSound {CustomFile}" : $"    {(Positional == true ? "PlayAlertSoundPositional" : "PlayAlertSound")} {Id} {Volume}";
        }
    }
}