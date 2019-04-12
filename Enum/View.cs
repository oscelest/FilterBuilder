using System;

namespace FilterBuilder.Enum {
    public sealed class View {
        public static readonly View HOME = new View("home");
        public static readonly View UNIQUE_WEAPON = new View("unique_weapon");
        public static readonly View UNIQUE_ARMOUR = new View("unique_armour");
        public static readonly View UNIQUE_ACCESSORY = new View("unique_accessory");
        public static readonly View DIVINATION_CARD = new View("divination_card");
        public static readonly View CURRENCY = new View("currency");
        public static readonly View ESSENCE = new View("essence");
        public static readonly View FOSSIL = new View("fossil");
        public static readonly View MAP = new View("map");
        public static readonly View FRAGMENT = new View("fragment");
        public static readonly View CHANCE_BASE = new View("chance_base");
        public static readonly View CRAFTING_BASE = new View("crafting_base");
        public static readonly View VENDOR_RECIPE = new View("vendor_recipe");
        public static readonly View FLASK = new View("flask");
        public static readonly View SKILL_GEM = new View("skill_gem");
        public static readonly View LEVELING = new View("leveling");
        private readonly string _value;

        private View(string value) {
            _value = value;
        }

        public override string ToString() {
            return _value;
        }

        public static View Parse(string value) {
            switch (value) {
                case "home":
                    return HOME;
                case "unique_weapon":
                    return UNIQUE_WEAPON;
                case "unique_armour":
                    return UNIQUE_ARMOUR;
                case "unique_accessory":
                    return UNIQUE_ACCESSORY;
                case "divination_card":
                    return DIVINATION_CARD;
                case "currency":
                    return CURRENCY;
                case "essence":
                    return ESSENCE;
                case "fossil":
                    return FOSSIL;
                case "map":
                    return MAP;
                case "fragment":
                    return FRAGMENT;
                case "chance_base":
                    return CHANCE_BASE;
                case "crafting_base":
                    return CRAFTING_BASE;
                case "vendor_recipe":
                    return VENDOR_RECIPE;
                case "flask":
                    return FLASK;
                case "skill_gem":
                    return SKILL_GEM;
                case "leveling":
                    return LEVELING;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}