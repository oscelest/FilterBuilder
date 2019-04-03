using System;

namespace FilterBuilder.Enums {
    public sealed class Rarity {
        private readonly string _name;

        public static readonly Rarity NORMAL = new Rarity("Normal");
        public static readonly Rarity MAGIC = new Rarity("Magic");
        public static readonly Rarity RARE = new Rarity("Rare");
        public static readonly Rarity UNIQUE = new Rarity("Unique");

        private Rarity(string name) {
            this._name = name;
        }

        public override string ToString() {
            return _name;
        }
        
        public static Rarity Parse(string rarity) {
            switch (rarity) {
                case "Normal":
                    return Rarity.NORMAL;
                case "Magic":
                    return Rarity.MAGIC;
                case "Rare":
                    return Rarity.RARE;
                case "Unique":
                    return Rarity.UNIQUE;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}