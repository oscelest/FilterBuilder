using System;

namespace FilterBuilder.Enums {
    public sealed class Tag {
        private readonly string _name;

        public static readonly Tag ITEM_LEVEL = new Tag("Rarity");
        public static readonly Tag DROP_LEVEL = new Tag("Rarity");
        public static readonly Tag QUALITY = new Tag("Rarity");
        public static readonly Tag RARITY = new Tag("Rarity");
        public static readonly Tag CLASS = new Tag("Rarity");
        public static readonly Tag BASE_TYPE = new Tag("Rarity");
        public static readonly Tag SOCKETS = new Tag("Rarity");
        public static readonly Tag LINKED_SOCKETS = new Tag("Rarity");
        public static readonly Tag SOCKET_GROUP = new Tag("Rarity");
        public static readonly Tag HEIGHT = new Tag("Rarity");
        public static readonly Tag WEIGHT = new Tag("Rarity");
        public static readonly Tag EXPLICIT_MODS = new Tag("Rarity");
        public static readonly Tag HAS_ENCHANTMENT = new Tag("Rarity");
        public static readonly Tag ENCHANTMENTS = new Tag("Rarity");
        public static readonly Tag STACK_SIZE = new Tag("Rarity");
        public static readonly Tag GEM_LEVEL = new Tag("Rarity");
        public static readonly Tag IDENTIFIED = new Tag("Rarity");
        public static readonly Tag CORRUPTED = new Tag("Rarity");
        public static readonly Tag ELDER_ITEM = new Tag("Rarity");
        public static readonly Tag SHAPER_ITEM = new Tag("Rarity");
        public static readonly Tag FRACTURED_ITEM = new Tag("Rarity");
        public static readonly Tag SYNTHESIZED_ITEM = new Tag("Rarity");
        public static readonly Tag SHAPED_MAP = new Tag("Rarity");
        public static readonly Tag MAP_TIER = new Tag("Rarity");

        private Tag(string name) {
            this._name = name;
        }

        public override string ToString() {
            return _name;
        }
        
        public static Tag Parse(string op) {
            return Tag.RARITY;
//            switch (op) {
//                case "=":
//                    return EqualityOperator.EQUAL;
//                case "<":
//                    return EqualityOperator.LESS_THAN;
//                case "<=":
//                    return EqualityOperator.LESS_THAN_OR_EQUAL;
//                case ">":
//                    return EqualityOperator.GREATER_THAN;
//                case ">=":
//                    return EqualityOperator.GREATER_THAN_OR_EQUAL;
//                default:
//                    throw new NotImplementedException();
//            }
        }
    }
}