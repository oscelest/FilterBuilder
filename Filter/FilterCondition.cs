using System;
using System.Collections.Generic;
using System.Text;
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
        public string SocketGroup { get; set; }
        public List<string> Class { get; set; }
        public List<string> BaseType { get; set; }
        public List<string> ExplicitMods { get; set; }
        public List<string> Enchantments { get; set; }
        public bool? HasEnchantment { get; set; }
        public bool? Identified { get; set; }
        public bool? Corrupted { get; set; }
        public bool? ElderItem { get; set; }
        public bool? ShaperItem { get; set; }
        public bool? FracturedItem { get; set; }
        public bool? SynthesizedItem { get; set; }
        public bool? ShapedMap { get; set; }

        public override string ToString() {
            var conditions = new StringBuilder();
            if (Rarity != null) conditions.AppendLine(Rarity.ToString());

            if (ItemLevel != null) conditions.AppendLine($"    ItemLevel {ItemLevel}");
            if (DropLevel != null) conditions.AppendLine($"    DropLevel {DropLevel}");
            if (Quality != null) conditions.AppendLine($"    Quality {Quality}");
            if (Sockets != null) conditions.AppendLine($"    Sockets {Sockets}");
            if (LinkedSockets != null) conditions.AppendLine($"    LinkedSockets {LinkedSockets}");
            if (Height != null) conditions.AppendLine($"    Height {Height}");
            if (Width != null) conditions.AppendLine($"    Width {Width}");
            if (StackSize != null) conditions.AppendLine($"    StackSize {StackSize}");
            if (GemLevel != null) conditions.AppendLine($"    GemLevel {GemLevel}");
            if (MapTier != null) conditions.AppendLine($"    MapTier {MapTier}");

            if (SocketGroup != null) conditions.AppendLine($"    SocketGroup {SocketGroup}");

            if (Class != null) conditions.AppendLine($"    Class \"{string.Join("\" \"", Class.ToArray())}\"");
            if (BaseType != null) conditions.AppendLine($"    BaseType \"{string.Join("\" \"", BaseType.ToArray())}\"");
            if (ExplicitMods != null) conditions.AppendLine($"    HasExplicitMod \"{string.Join("\" \"", ExplicitMods.ToArray())}\"");
            if (Enchantments != null) conditions.AppendLine($"    HasEnchantment \"{string.Join("\" \"", Enchantments.ToArray())}\"");

            if (HasEnchantment != null) conditions.AppendLine($"    AnyEnchantment {(Identified == true ? "True" : "False")}");
            if (Identified != null) conditions.AppendLine($"    Identified {(Identified == true ? "True" : "False")}");
            if (Corrupted != null) conditions.AppendLine($"    Corrupted {(Corrupted == true ? "True" : "False")}");
            if (ElderItem != null) conditions.AppendLine($"    ElderItem {(ElderItem == true ? "True" : "False")}");
            if (ShaperItem != null) conditions.AppendLine($"    ShaperItem {(ShaperItem == true ? "True" : "False")}");
            if (FracturedItem != null) conditions.AppendLine($"    FracturedItem {(FracturedItem == true ? "True" : "False")}");
            if (SynthesizedItem != null) conditions.AppendLine($"    SynthesizedItem {(SynthesizedItem == true ? "True" : "False")}");
            if (ShapedMap != null) conditions.AppendLine($"    ShapedMap {(ShapedMap == true ? "True" : "False")}");
            return conditions.ToString();
        }
    }
}