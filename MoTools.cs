using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.IO;
using Terraria.UI;
using System.Collections.Generic;
using MoTools.Items.Consumables;
using MoTools.Items.Placeable.MusicBoxes;
using MoTools.Tiles.MusicBoxes;
using Terraria.Graphics.Shaders;
using Terraria.GameInput;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using MoTools.UI;
using Terraria.Graphics.Shaders;

namespace MoTools
{
    public class MoTools : Mod
    {
        /*public const string GOLD_BARS_GROUP = "AnyGoldBar";
        public const string EVIL_BARS_GROUP = "AnyEvilBar";
        public const string DOUBLE_JUMP_GROUP = "AnyDoubleJumpItem";
        public const string COLORED_BALLOON_GROUP = "AnyColoredBalloon";*/

        public static MoTools Instance;
        public static Mod MagicStorageMod;

        internal UserInterface The404TinkererUserInterface;

        internal static ModHotKey DevSpeedHotKey;
        internal static ModHotKey SecretHotKey;

        public override void Load()
        {
            DevSpeedHotKey = RegisterHotKey("Dev's Speed", "X");
            SecretHotKey = RegisterHotKey("Unlocalized Name", "S");

            // Register a new music box
            //AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Annihilator"), ModContent.ItemType<Items.Placeable.MusicBoxes.AnnihilatorMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.AnnihilatorMusicBox>());
            //AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/PaperCut"), ModContent.ItemType<Items.Placeable.MusicBoxes.PaperCutMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.PaperCutMusicBox>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Annihilator"), ModContent.ItemType<Items.Placeable.MusicBoxes.AnnihilatorMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.AnnihilatorMusicBox>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/PaperCut"), ModContent.ItemType<Items.Placeable.MusicBoxes.PaperCutMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.PaperCutMusicBox>());
        }

        /*#region Recipe Groups
    public override void AddRecipeGroups()
    {
        //Emblems
        RecipeGroup.RegisterGroup("Emblems", new RecipeGroup(() => Lang.misc[37] + " Emblem", new int[]
        {
                ItemID.RangerEmblem,
                ItemID.WarriorEmblem,
                ItemID.SorcererEmblem,
                ItemID.SummonerEmblem,
                //ModContent.ItemType<NullEmblem>(),
                //ModContent.ItemType<MysticEmblem>(),
                //ModContent.ItemType<NinjaEmblem>()
        }));


        //Gems
        RecipeGroup.RegisterGroup("Gems", new RecipeGroup(() => Lang.misc[37] + " Gem", new int[]
        {
                ItemID.Amethyst,
                ItemID.Topaz,
                ItemID.Ruby,
                ItemID.Sapphire,
                ItemID.Emerald,
                ItemID.Ruby,
                ItemID.Diamond,
                ItemID.Amber
        }));

        //Gold Bars
        RecipeGroup.RegisterGroup(GOLD_BARS_GROUP, new RecipeGroup(() => Lang.misc[37] + " Gold Bar", new int[]
        {
                ItemID.GoldBar,
                ItemID.PlatinumBar
        }));

        //Silver Bars
        RecipeGroup.RegisterGroup("SilverBars", new RecipeGroup(() => Lang.misc[37] + " Silver Bar", new int[]
        {
                ItemID.SilverBar,
                ItemID.TungstenBar
        }));

        //Titanium Bars
        RecipeGroup.RegisterGroup("TitaniumBars", new RecipeGroup(() => Lang.misc[37] + " Titanium Bar", new int[]
        {
                ItemID.TitaniumBar,
                ItemID.AdamantiteBar
        }));

        //Large Gems
        RecipeGroup.RegisterGroup("LargeGems", new RecipeGroup(() => Lang.misc[37] + " Large Gem", new int[]
        {
                ItemID.LargeAmethyst,
                ItemID.LargeTopaz,
                ItemID.LargeSapphire,
                ItemID.LargeEmerald,
                ItemID.LargeRuby,
                ItemID.LargeDiamond,
                ItemID.LargeAmber
        }));

        //Dungeon Tables
        RecipeGroup.RegisterGroup("DungeonTables", new RecipeGroup(() => Lang.misc[37] + " Dungeon Table", new int[]
        {
                ItemID.GothicTable, //Gothic
                ItemID.BlueDungeonTable, //Blue
                ItemID.GreenDungeonTable, //Green
                ItemID.PinkDungeonTable  //Pink
        }));

        //Evil Bars
        RecipeGroup.RegisterGroup(EVIL_BARS_GROUP, new RecipeGroup(() => Lang.misc[37] + " Evil Bar", new int[]
        {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
        }));

        //DoubleJump
        RecipeGroup.RegisterGroup(DOUBLE_JUMP_GROUP, new RecipeGroup(() => Lang.misc[37] + " Double Jump Bottle", new int[]
        {
                ItemID.CloudinaBottle,
                ItemID.SandstorminaBottle,
                ItemID.BlizzardinaBottle,
                ItemID.TsunamiInABottle
        }));

        //ColoredBalloon
        RecipeGroup.RegisterGroup(COLORED_BALLOON_GROUP, new RecipeGroup(() => Lang.misc[37] + " Colored Balloon", new int[]
        {
                ItemID.BlueHorseshoeBalloon,
                ItemID.WhiteHorseshoeBalloon,
                ItemID.YellowHorseshoeBalloon,
                ItemID.BalloonHorseshoeFart,
                ItemID.BalloonHorseshoeHoney,
                ItemID.BalloonHorseshoeSharkron,
        }));
    }
        #endregion*/

        #region Recipe Groups
        public override void AddRecipeGroups()
        {
            //Emblems
            RecipeGroup.RegisterGroup("Emblems", new RecipeGroup(() => Lang.misc[37] + " Emblem", new int[]
            {
                ItemID.RangerEmblem,
                ItemID.WarriorEmblem,
                ItemID.SorcererEmblem,
                ItemID.SummonerEmblem,
                //ModContent.ItemType<NullEmblem>(),
                //ModContent.ItemType<MysticEmblem>(),
                //ModContent.ItemType<NinjaEmblem>()
            }));


            //Gems
            RecipeGroup.RegisterGroup("Gems", new RecipeGroup(() => Lang.misc[37] + " Gem", new int[]
            {
                ItemID.Amethyst,
                ItemID.Topaz,
                ItemID.Ruby,
                ItemID.Sapphire,
                ItemID.Emerald,
                ItemID.Ruby,
                ItemID.Diamond,
                ItemID.Amber
            }));

            //Gold Bars
            RecipeGroup.RegisterGroup("GoldBars", new RecipeGroup(() => Lang.misc[37] + " Gold Bar", new int[]
            {
                ItemID.GoldBar,
                ItemID.PlatinumBar
            }));

            //Silver Bars
            RecipeGroup.RegisterGroup("SilverBars", new RecipeGroup(() => Lang.misc[37] + " Silver Bar", new int[]
            {
                ItemID.SilverBar,
                ItemID.TungstenBar
            }));

            //Titanium Bars
            RecipeGroup.RegisterGroup("TitaniumBars", new RecipeGroup(() => Lang.misc[37] + " Titanium Bar", new int[]
            {
                ItemID.TitaniumBar,
                ItemID.AdamantiteBar
            }));

            //Large Gems
            RecipeGroup.RegisterGroup("LargeGems", new RecipeGroup(() => Lang.misc[37] + " Large Gem", new int[]
            {
                ItemID.LargeAmethyst,
                ItemID.LargeTopaz,
                ItemID.LargeSapphire,
                ItemID.LargeEmerald,
                ItemID.LargeRuby,
                ItemID.LargeDiamond,
                ItemID.LargeAmber
            }));

            //Dungeon Tables
            RecipeGroup.RegisterGroup("DungeonTables", new RecipeGroup(() => Lang.misc[37] + " Dungeon Table", new int[]
            {
                ItemID.GothicTable, //Gothic
                ItemID.BlueDungeonTable, //Blue
                ItemID.GreenDungeonTable, //Green
                ItemID.PinkDungeonTable  //Pink
            }));

            //Evil Bars
            RecipeGroup.RegisterGroup("EvilBars", new RecipeGroup(() => Lang.misc[37] + " Evil Bar", new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            }));

            //DoubleJump
            RecipeGroup.RegisterGroup("DoubleJumpItems", new RecipeGroup(() => Lang.misc[37] + " Double Jump Bottle", new int[]
            {
                ItemID.CloudinaBottle,
                ItemID.SandstorminaBottle,
                ItemID.BlizzardinaBottle,
                ItemID.TsunamiInABottle
            }));

            //ColoredBalloon
            RecipeGroup.RegisterGroup("ColoredBalloons", new RecipeGroup(() => Lang.misc[37] + " Colored Balloon", new int[]
            {
                ItemID.BlueHorseshoeBalloon,
                ItemID.WhiteHorseshoeBalloon,
                ItemID.YellowHorseshoeBalloon,
                ItemID.BalloonHorseshoeFart,
                ItemID.BalloonHorseshoeHoney,
                ItemID.BalloonHorseshoeSharkron,
            }));
        }
        #endregion
    }
}