using System;

namespace FilterBuilder.Enum {
    public sealed class Tag {
        public static readonly Tag ITEM_LEVEL = new Tag("ItemLevel");
        public static readonly Tag DROP_LEVEL = new Tag("DropLevel");
        public static readonly Tag QUALITY = new Tag("Quality");
        public static readonly Tag RARITY = new Tag("Rarity");
        public static readonly Tag CLASS = new Tag("Class");
        public static readonly Tag BASE_TYPE = new Tag("BaseType");
        public static readonly Tag SOCKETS = new Tag("Sockets");
        public static readonly Tag LINKED_SOCKETS = new Tag("LinkedSockets");
        public static readonly Tag SOCKET_GROUP = new Tag("SocketGroup");
        public static readonly Tag HEIGHT = new Tag("Height");
        public static readonly Tag WIDTH = new Tag("Width");
        public static readonly Tag EXPLICIT_MODS = new Tag("HasExplicitMods");
        public static readonly Tag HAS_ENCHANTMENT = new Tag("AnyEnchantment");
        public static readonly Tag ENCHANTMENTS = new Tag("HasEnchantment");
        public static readonly Tag STACK_SIZE = new Tag("StackSize");
        public static readonly Tag GEM_LEVEL = new Tag("GemLevel");
        public static readonly Tag IDENTIFIED = new Tag("Identified");
        public static readonly Tag CORRUPTED = new Tag("Corrupted");
        public static readonly Tag ELDER_ITEM = new Tag("ElderItem");
        public static readonly Tag SHAPER_ITEM = new Tag("ShaperItem");
        public static readonly Tag FRACTURED_ITEM = new Tag("FracturedItem");
        public static readonly Tag SYNTHESIZED_ITEM = new Tag("Synthesized");
        public static readonly Tag SHAPED_MAP = new Tag("ShapedMap");
        public static readonly Tag MAP_TIER = new Tag("MapTier");
        public static readonly Tag BACKGROUND_COLOR = new Tag("SetBackgroundColor");
        public static readonly Tag BORDER_COLOR = new Tag("SetBorderColor");
        public static readonly Tag TEXT_COLOR = new Tag("SetTextColor");
        public static readonly Tag FONT_SIZE = new Tag("SetFontSize");
        public static readonly Tag MINIMAP_ICON = new Tag("MinimapIcon");
        public static readonly Tag BEAM_EFFECT = new Tag("BeamEffect");
        public static readonly Tag ALERT_SOUND = new Tag("PlayAlertSound");
        public static readonly Tag ALERT_SOUND_POSITIONAL = new Tag("PlayAlertSoundPositional");
        public static readonly Tag CUSTOM_ALERT_SOUND = new Tag("CustomAlertSound");
        private readonly string _name;

        private Tag(string name) {
            _name = name;
        }

        public override string ToString() {
            return _name;
        }

        public static Tag Parse(string op) {
            switch (op) {
                case "ItemLevel":
                    return ITEM_LEVEL;
                case "DropLevel":
                    return DROP_LEVEL;
                case "Quality":
                    return QUALITY;
                case "Rarity":
                    return RARITY;
                case "Class":
                    return CLASS;
                case "BaseType":
                    return BASE_TYPE;
                case "Sockets":
                    return SOCKETS;
                case "LinkedSockets":
                    return LINKED_SOCKETS;
                case "SocketGroup":
                    return SOCKET_GROUP;
                case "Height":
                    return HEIGHT;
                case "Width":
                    return WIDTH;
                case "HasExplicitMods":
                    return EXPLICIT_MODS;
                case "AnyEnchantment":
                    return HAS_ENCHANTMENT;
                case "HasEnchantment":
                    return ENCHANTMENTS;
                case "StackSize":
                    return STACK_SIZE;
                case "GemLevel":
                    return GEM_LEVEL;
                case "Identified":
                    return IDENTIFIED;
                case "Corrupted":
                    return CORRUPTED;
                case "ElderItem":
                    return ELDER_ITEM;
                case "ShaperItem":
                    return SHAPER_ITEM;
                case "FracturedItem":
                    return FRACTURED_ITEM;
                case "Synthesized":
                    return SYNTHESIZED_ITEM;
                case "ShapedMap":
                    return SHAPED_MAP;
                case "MapTier":
                    return MAP_TIER;
                case "SetBackgroundColor":
                    return BACKGROUND_COLOR;
                case "SetBorderColor":
                    return BORDER_COLOR;
                case "SetTextColor":
                    return TEXT_COLOR;
                case "SetFontSize":
                    return FONT_SIZE;
                case "MinimapIcon":
                    return MINIMAP_ICON;
                case "BeamEffect":
                    return BEAM_EFFECT;
                case "AlertSound":
                    return ALERT_SOUND;
                case "AlertSoundPositional":
                    return ALERT_SOUND_POSITIONAL;
                case "CustomAlertSound":
                    return CUSTOM_ALERT_SOUND;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}