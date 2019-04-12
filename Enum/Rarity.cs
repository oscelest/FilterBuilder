using System;

namespace FilterBuilder.Enum {
    public sealed class Rarity {
        public static readonly Rarity NORMAL = new Rarity("Normal");
        public static readonly Rarity MAGIC = new Rarity("Magic");
        public static readonly Rarity RARE = new Rarity("Rare");
        public static readonly Rarity UNIQUE = new Rarity("Unique");
        private readonly string _name;

        private Rarity(string name) {
            _name = name;
        }

        public override string ToString() {
            return _name;
        }

        public static Rarity Parse(string rarity) {
            switch (rarity) {
                case "Normal":
                    return NORMAL;
                case "Magic":
                    return MAGIC;
                case "Rare":
                    return RARE;
                case "Unique":
                    return UNIQUE;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}