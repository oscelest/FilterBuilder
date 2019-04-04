using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Media;
using FilterBuilder.Enums;
using FilterBuilder.Helper;

namespace FilterBuilder.Filter {
    public class FilterCondition {
        public EqualityCondition<Rarity> Rarity { get; set; }
        public EqualityCondition<int> ItemLevel { get; set; }
        public EqualityCondition<int> DropLevel { get; set; }
        public EqualityCondition<int> Quality { get; set; }
        public EqualityCondition<int> Sockets { get; set; }
        public EqualityCondition<int> LinkedSockets { get; set; }
        public EqualityCondition<int> Height { get; set; }
        public EqualityCondition<int> Width { get; set; }
        public EqualityCondition<int> StackSize { get; set; }
        public EqualityCondition<int> GemLevel { get; set; }
        public EqualityCondition<int> MapTier { get; set; }
        public ValueCondition<string> SocketGroup { get; set; }
        public ValueCondition<List<string>> Class { get; set; }
        public ValueCondition<List<string>> BaseType { get; set; }
        public ValueCondition<List<string>> ExplicitMods { get; set; }
        public ValueCondition<List<string>> Enchantments { get; set; }
        public ValueCondition<bool> HasEnchantment { get; set; }
        public ValueCondition<bool> Identified { get; set; }
        public ValueCondition<bool> Corrupted { get; set; }
        public ValueCondition<bool> ElderItem { get; set; }
        public ValueCondition<bool> ShaperItem { get; set; }
        public ValueCondition<bool> FracturedItem { get; set; }
        public ValueCondition<bool> SynthesizedItem { get; set; }
        public ValueCondition<bool> ShapedMap { get; set; }

        public override string ToString() {
            var conditions = new StringBuilder();
            foreach (var line in GetType().GetProperties().Where((prop) => prop.GetValue(this) != null).Select((prop) => prop.GetValue(this))) conditions.AppendLine(line.ToString());
            return conditions.ToString();
        }
    }
}