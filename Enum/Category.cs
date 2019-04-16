using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace FilterBuilder.Enum {
    public sealed class Category {
        public static Category GENERAL { get; } = new Category("general", "pack://application:,,,/FilterBuilder;component/Resources/Images/General.png");
        public static Category UNIQUE_WEAPON { get; } = new Category("unique_weapon", "pack://application:,,,/FilterBuilder;component/Resources/Images/UniqueWeapon.png");
        public static Category UNIQUE_ARMOUR { get; } = new Category("unique_armour", "pack://application:,,,/FilterBuilder;component/Resources/Images/UniqueArmour.png");
        public static Category UNIQUE_ACCESSORY { get; } = new Category("unique_accessory", "pack://application:,,,/FilterBuilder;component/Resources/Images/UniqueAccessory.png");
        public static Category DIVINATION_CARD { get; } = new Category("divination_card", "pack://application:,,,/FilterBuilder;component/Resources/Images/DivinationCard.png");
        public static Category CURRENCY { get; } = new Category("currency", "pack://application:,,,/FilterBuilder;component/Resources/Images/Currency.png");
        public static Category ESSENCE { get; } = new Category("essence", "pack://application:,,,/FilterBuilder;component/Resources/Images/Essence.png");
        public static Category FOSSIL { get; } = new Category("fossil", "pack://application:,,,/FilterBuilder;component/Resources/Images/Fossil.png");
        public static Category MAP { get; } = new Category("map", "pack://application:,,,/FilterBuilder;component/Resources/Images/Map.png");
        public static Category FRAGMENT { get; } = new Category("fragment", "pack://application:,,,/FilterBuilder;component/Resources/Images/Fragment.png");
        public static Category CHANCE_BASE { get; } = new Category("chance_base", "pack://application:,,,/FilterBuilder;component/Resources/Images/ChanceBase.png");
        public static Category CRAFTING_BASE { get; } = new Category("crafting_base", "pack://application:,,,/FilterBuilder;component/Resources/Images/CraftingBase.png");
        public static Category VENDOR_RECIPE { get; } = new Category("vendor_recipe", "pack://application:,,,/FilterBuilder;component/Resources/Images/VendorRecipe.png");
        public static Category FLASK { get; } = new Category("flask", "pack://application:,,,/FilterBuilder;component/Resources/Images/Flask.png");
        public static Category SKILL_GEM { get; } = new Category("skill_gem", "pack://application:,,,/FilterBuilder;component/Resources/Images/SkillGem.png");
        public static Category LEVELING { get; } = new Category("leveling", "pack://application:,,,/FilterBuilder;component/Resources/Images/Leveling.png");

        public static List<string> Categories { get; } = typeof(Category).GetFields(BindingFlags.Public | BindingFlags.Static).Where(f => {
                Debug.WriteLine(f.FieldType);
                return f.FieldType == typeof(Category);
            })
            .Select(x => (string) x.GetValue(null)).ToList();

        public string Value { get; }
        public string Image { get; }

        private Category(string value, string image) {
            Value = value;
            Image = image;
        }

        public override string ToString() {
            return Value;
        }

        public static Category Parse(string value) {
            switch (value) {
                case "general":
                    return GENERAL;
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