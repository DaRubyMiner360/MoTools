using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using MoTools.Items.Dyes;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using MoTools.Items;
using MoTools.Items.Weapons;
//using MoTools.Items.Weapons.Whips;
//using MoTools.Items.Weapons.Yoyos;
using MoTools.Prefixes.Accessories;
using MoTools.Rarities;
using MoTools.UI;
using Microsoft.Xna.Framework.Input;
using ReLogic.Graphics;
using System.Linq;
using Terraria.IO;
using Terraria.Social;
using Terraria.UI.Chat;
using static Terraria.ID.Colors;
using MoTools.NPCs.TheAnnihilator;
using MoTools.NPCs.PaperCut;
using MoTools.NPCs.TheCelestial;
using MoTools.NPCs.The404Celestial;
using MoTools.Items.MythicDamageClass;

namespace MoTools
{
    public class MoTools : Mod
    {
        /*public const string GOLD_BARS_GROUP = "AnyGoldBar";
        public const string EVIL_BARS_GROUP = "AnyEvilBar";
        public const string DOUBLE_JUMP_GROUP = "AnyDoubleJumpItem";
        public const string COLORED_BALLOON_GROUP = "AnyColoredBalloon";*/

        public static MoTools Instance;
        public static Mod MagicStorageMod = ModLoader.GetMod("MagicStorage");
        public static Mod yabhb = ModLoader.GetMod("FKBossHealthBar");
        public static Mod MoToolsSound = ModLoader.GetMod("MoToolsSound");

        internal UserInterface The404TinkererUserInterface;

        internal static ModHotKey DevSpeedHotKey;
        internal static ModHotKey SecretHotKey;

        public static Dictionary<int, Color> _rarities = new Dictionary<int, Color>();
        public static Dictionary<int, Color> _dynamicRaritiesColor = new Dictionary<int, Color>();
        public static List<int> _usesDiscoRGB = new List<int>();
        public static List<int> _isFixedRarity = new List<int>();
        public static int MaxRarity = 11;
        public static Dictionary<int, int> _itemTextRarities = new Dictionary<int, int>();

        public Dictionary<int, bool> mentalModeWlds = new Dictionary<int, bool>();
        public static Dictionary<string, bool> worldInfo = new Dictionary<string, bool>();
        public bool usesVanillaWorldGen = false;
        public static List<int> meleePrefixes = new List<int>();
        public List<string> wldId = new List<string>();

        public static float ColorCounter = 0f;
        private static bool directionOfChange = false;

        private UserInterface _mythicResourceBarUserInterface;
        internal MythicResourceBar MythicResourceBar;

        public override void Load()
        {
            Init();

            meleePrefixes.Add(PrefixType("Mental"));

            if (!Main.dedServ)
            {
                // Mythic Resource Bar
                MythicResourceBar = new MythicResourceBar();
                _mythicResourceBarUserInterface = new UserInterface();
                _mythicResourceBarUserInterface.SetState(MythicResourceBar);
            }

            Mundane.AddHacks();

            DevSpeedHotKey = RegisterHotKey("Dev's Speed", "X");
            SecretHotKey = RegisterHotKey("Unlocalized Name", "S");

            // Register a new music box
            //AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Annihilator"), ModContent.ItemType<Items.Placeable.MusicBoxes.AnnihilatorMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.AnnihilatorMusicBox>());
            //AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/PaperCut"), ModContent.ItemType<Items.Placeable.MusicBoxes.PaperCutMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.PaperCutMusicBox>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Annihilator"), ModContent.ItemType<Items.Placeable.MusicBoxes.AnnihilatorMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.AnnihilatorMusicBox>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/PaperCut"), ModContent.ItemType<Items.Placeable.MusicBoxes.PaperCutMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.PaperCutMusicBox>());

            if (yabhb != null)
            {
                #region The Annihilator
                yabhb.Call("RegisterMechHealthBarMulti",
                    ModContent.NPCType<TheAnnihilator>(),
                    ModContent.NPCType<TheAnnihilatorStage2>(),
                    ModContent.NPCType<TheAnnihilatorStage3>(),
                    ModContent.NPCType<TheAnnihilatorStage3_2>());
                #endregion

                #region Paper Cut
                yabhb.Call("hbStart");
                // Set custom textures for the standard health bar
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTexture",
                    GetTexture("UI/Health Bars/PaperHealthBarStart"),
                    GetTexture("UI/Health Bars/PaperHealthBarMiddle"),
                    GetTexture("UI/Health Bars/PaperHealthBarEnd"),
                    GetTexture("UI/Health Bars/PaperHealthBarFill"));

                /*// Set custom textures for the standard health bar in expert mode
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureExpert",
                    GetTexture("UI/Health Bars/CustomLeftBar_Expert"),
                    GetTexture("UI/Health Bars/CustomMidBar_Expert"),
                    GetTexture("UI/Health Bars/CustomRightBar_Expert"));*/

                /*// Set custom textures for the small health bar
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureSmall",
                    GetTexture("UI/Health Bars/CustomLeftBar_Small"),
                    GetTexture("UI/Health Bars/CustomMidBar_Small"),
                    GetTexture("UI/Health Bars/CustomRightBar_Small"),
                    GetTexture("UI/Health Bars/CustomMidFill_Small"));*/

                /*// Set custom textures for the small health bar in expert mode
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureSmallExpert",
                    GetTexture("UI/Health Bars/CustomLeftBar_Small_Expert"),
                    GetTexture("UI/Health Bars/CustomMidBar_Small_Expert"),
                    GetTexture("UI/Health Bars/CustomRightBar_Small_Expert"));*/
                // Methods for setting the offsets. See part 1 of the tutorial for more information.
                yabhb.Call("hbSetMidBarOffsetY", 10);
                yabhb.Call("hbSetMidBarOffset", 30, 10);
                yabhb.Call("hbSetBossHeadCentre", 80, 32);
                yabhb.Call("hbSetBossHeadCentreSmall", 14, 14);
                yabhb.Call("hbSetFillDecoOffset", 10);
                yabhb.Call("hbSetFillDecoOffsetSmall", 10);
                // Set the three colours the bar will change colours between. Defaults to (Green -> Yellow -> Red)
                yabhb.Call("hbSetColours",
                    new Color(0f, 1f, 0f), // 100%
                    new Color(1f, 1f, 0f), // 50%
                    new Color(1f, 0f, 0f));// 0%

                // Force the health bar to use a custom texture as the boss head icon.
                // A useful array to grab textures from is Main.npcHeadBossTexture[]
                yabhb.Call("hbSetBossHeadTexture", GetTexture("NPCs/PaperCut/PaperCut_Head_Boss"));
                // Registers the health bar for multiple NPCs in a group
                yabhb.Call("hbFinishMultiple",
                    ModContent.NPCType<PaperCut>(),
                    ModContent.NPCType<PaperCutStage2>(),
                    ModContent.NPCType<PaperCutStage3>(),
                    ModContent.NPCType<PaperCutStage3_2>());
                #endregion

                #region The Celestials
                #region The Celestial Lord
                yabhb.Call("hbStart");
                // Set custom textures for the standard health bar
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTexture",
                    GetTexture("UI/Health Bars/TheCelestialHealthBarStart"),
                    GetTexture("UI/Health Bars/TheCelestialHealthBarMiddle"),
                    GetTexture("UI/Health Bars/TheCelestialHealthBarEnd"),
                    GetTexture("UI/Health Bars/TheCelestialHealthBarFill"));

                /*// Set custom textures for the standard health bar in expert mode
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureExpert",
                    GetTexture("UI/Health Bars/TheCelestialLeftBar_Expert"),
                    GetTexture("UI/Health Bars/TheCelestialMidBar_Expert"),
                    GetTexture("UI/Health Bars/TheCelestialRightBar_Expert"));*/

                /*// Set custom textures for the small health bar
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureSmall",
                    GetTexture("UI/Health Bars/TheCelestialLeftBar_Small"),
                    GetTexture("UI/Health Bars/TheCelestialMidBar_Small"),
                    GetTexture("UI/Health Bars/TheCelestialRightBar_Small"),
                    GetTexture("UI/Health Bars/TheCelestialMidFill_Small"));*/

                /*// Set custom textures for the small health bar in expert mode
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureSmallExpert",
                    GetTexture("UI/Health Bars/TheCelestialLeftBar_Small_Expert"),
                    GetTexture("UI/Health Bars/TheCelestialMidBar_Small_Expert"),
                    GetTexture("UI/Health Bars/TheCelestialRightBar_Small_Expert"));*/
                // Methods for setting the offsets. See part 1 of the tutorial for more information.
                yabhb.Call("hbSetMidBarOffsetY", 10);
                yabhb.Call("hbSetMidBarOffset", 30, 10);
                yabhb.Call("hbSetBossHeadCentre", 80, 32);
                yabhb.Call("hbSetBossHeadCentreSmall", 14, 14);
                yabhb.Call("hbSetFillDecoOffset", 10);
                yabhb.Call("hbSetFillDecoOffsetSmall", 10);
                // Set the three colours the bar will change colours between. Defaults to (Red -> Orange -> Yellow -> Green -> Blue -> Purple)
                yabhb.Call("hbSetColours",
                    new Color(1f, 0f, 0f), // 100%
                    Color.Red, // 80%
                    Color.Orange, // 60%
                    Color.Yellow, // 40%
                    Color.Green, // 20%
                    Color.Blue, // 20%
                    Color.Purple);// 0%

                // Force the health bar to use a custom texture as the boss head icon.
                // A useful array to grab textures from is Main.npcHeadBossTexture[]
                yabhb.Call("hbSetBossHeadTexture", GetTexture("NPCs/TheCelestial/TheCelestial_Head_Boss"));
                // Registers the health bar for multiple NPCs in a group
                yabhb.Call("hbFinishMultiple",
                    ModContent.NPCType<TheCelestial>(),
                    ModContent.NPCType<TheCelestialClone>());
                #endregion
#if false
                #region The Celestial Enemies
                yabhb.Call("hbStart");
                // Set custom textures for the standard health bar
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTexture",
                    GetTexture("UI/Health Bars/TheCelestialHealthBarStart"),
                    GetTexture("UI/Health Bars/TheCelestialHealthBarMiddle"),
                    GetTexture("UI/Health Bars/TheCelestialHealthBarEnd"),
                    GetTexture("UI/Health Bars/TheCelestialHealthBarFill"));
                
                /*// Set custom textures for the standard health bar in expert mode
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureExpert",
                    GetTexture("UI/Health Bars/TheCelestialLeftBar_Expert"),
                    GetTexture("UI/Health Bars/TheCelestialMidBar_Expert"),
                    GetTexture("UI/Health Bars/TheCelestialRightBar_Expert"));*/
                
                /*// Set custom textures for the small health bar
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureSmall",
                    GetTexture("UI/Health Bars/TheCelestialLeftBar_Small"),
                    GetTexture("UI/Health Bars/TheCelestialMidBar_Small"),
                    GetTexture("UI/Health Bars/TheCelestialRightBar_Small"),
                    GetTexture("UI/Health Bars/TheCelestialMidFill_Small"));*/
                
                /*// Set custom textures for the small health bar in expert mode
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureSmallExpert",
                    GetTexture("UI/Health Bars/TheCelestialLeftBar_Small_Expert"),
                    GetTexture("UI/Health Bars/TheCelestialMidBar_Small_Expert"),
                    GetTexture("UI/Health Bars/TheCelestialRightBar_Small_Expert"));*/
                // Methods for setting the offsets. See part 1 of the tutorial for more information.
                yabhb.Call("hbSetMidBarOffsetY", 10);
                yabhb.Call("hbSetMidBarOffset", 30, 10);
                yabhb.Call("hbSetBossHeadCentre", 80, 32);
                yabhb.Call("hbSetBossHeadCentreSmall", 14, 14);
                yabhb.Call("hbSetFillDecoOffset", 10);
                yabhb.Call("hbSetFillDecoOffsetSmall", 10);
                // Set the three colours the bar will change colours between. Defaults to (Green -> Yellow -> Red)
                yabhb.Call("hbSetColours",
                    new Color(0f, 1f, 0f), // 100%
                    new Color(1f, 1f, 0f), // 50%
                    new Color(1f, 0f, 0f));// 0%
                
                // Force the health bar to use a custom texture as the boss head icon.
                // A useful array to grab textures from is Main.npcHeadBossTexture[]
                yabhb.Call("hbSetBossHeadTexture", GetTexture("NPCs/TheCelestial/TheCelestialClone_Head_Boss"));
                // Registers the health bar for multiple NPCs in a group
                yabhb.Call("hbFinishMultiple",
                    ModContent.NPCType<WhiteCelestial>(),
                    ModContent.NPCType<BlackCelestial>(),
                    ModContent.NPCType<BlueCelestial>(),
                    ModContent.NPCType<PurpleCelestial>(),
                    ModContent.NPCType<YellowCelestial>(),
                    ModContent.NPCType<RainbowCelestialNPC>());
                #endregion*/
#endif
                #endregion

                #region The 404 Infused Celestials
                #region The 404 Infused Celestial Lord
                yabhb.Call("hbStart");
                // Set custom textures for the standard health bar
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTexture",
                    GetTexture("UI/Health Bars/The404CelestialHealthBarStart"),
                    GetTexture("UI/Health Bars/The404CelestialHealthBarMiddle"),
                    GetTexture("UI/Health Bars/The404CelestialHealthBarEnd"),
                    GetTexture("UI/Health Bars/The404CelestialHealthBarFill"));

                /*// Set custom textures for the standard health bar in expert mode
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureExpert",
                    GetTexture("UI/Health Bars/The404CelestialLeftBar_Expert"),
                    GetTexture("UI/Health Bars/The404CelestialMidBar_Expert"),
                    GetTexture("UI/Health Bars/The404CelestialRightBar_Expert"));*/

                /*// Set custom textures for the small health bar
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureSmall",
                    GetTexture("UI/Health Bars/The404CelestialLeftBar_Small"),
                    GetTexture("UI/Health Bars/The404CelestialMidBar_Small"),
                    GetTexture("UI/Health Bars/The404CelestialRightBar_Small"),
                    GetTexture("UI/Health Bars/The404CelestialMidFill_Small"));*/

                /*// Set custom textures for the small health bar in expert mode
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureSmallExpert",
                    GetTexture("UI/Health Bars/The404CelestialLeftBar_Small_Expert"),
                    GetTexture("UI/Health Bars/The404CelestialMidBar_Small_Expert"),
                    GetTexture("UI/Health Bars/The404CelestialRightBar_Small_Expert"));*/
                // Methods for setting the offsets. See part 1 of the tutorial for more information.
                yabhb.Call("hbSetMidBarOffsetY", 10);
                yabhb.Call("hbSetMidBarOffset", 30, 10);
                yabhb.Call("hbSetBossHeadCentre", 80, 32);
                yabhb.Call("hbSetBossHeadCentreSmall", 14, 14);
                yabhb.Call("hbSetFillDecoOffset", 10);
                yabhb.Call("hbSetFillDecoOffsetSmall", 10);
                // Set the three colours the bar will change colours between. Defaults to (Red -> Orange -> Yellow -> Green -> Blue -> Purple)
                yabhb.Call("hbSetColours",
                    new Color(1f, 0f, 0f), // 100%
                    Color.Red, // 80%
                    Color.Orange, // 60%
                    Color.Yellow, // 40%
                    Color.Green, // 20%
                    Color.Blue, // 20%
                    Color.Purple);// 0%

                // Force the health bar to use a custom texture as the boss head icon.
                // A useful array to grab textures from is Main.npcHeadBossTexture[]
                yabhb.Call("hbSetBossHeadTexture", GetTexture("NPCs/The404Celestial/The404Celestial_Head_Boss"));
                // Registers the health bar for multiple NPCs in a group
                yabhb.Call("hbFinishMultiple",
                    ModContent.NPCType<The404Celestial>(),
                    ModContent.NPCType<The404CelestialClone>());
                #endregion
#if false
                #region The 404 Infused Celestial Enemies
                yabhb.Call("hbStart");
                // Set custom textures for the standard health bar
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTexture",
                    GetTexture("UI/Health Bars/The404CelestialHealthBarStart"),
                    GetTexture("UI/Health Bars/The404CelestialHealthBarMiddle"),
                    GetTexture("UI/Health Bars/The404CelestialHealthBarEnd"),
                    GetTexture("UI/Health Bars/The404CelestialHealthBarFill"));
                
                /*// Set custom textures for the standard health bar in expert mode
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureExpert",
                    GetTexture("UI/Health Bars/The404CelestialLeftBar_Expert"),
                    GetTexture("UI/Health Bars/The404CelestialMidBar_Expert"),
                    GetTexture("UI/Health Bars/The404CelestialRightBar_Expert"));*/
                
                /*// Set custom textures for the small health bar
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureSmall",
                    GetTexture("UI/Health Bars/The404CelestialLeftBar_Small"),
                    GetTexture("UI/Health Bars/The404CelestialMidBar_Small"),
                    GetTexture("UI/Health Bars/The404CelestialRightBar_Small"),
                    GetTexture("UI/Health Bars/The404CelestialMidFill_Small"));*/
                
                /*// Set custom textures for the small health bar in expert mode
                // Values can be left as null to use the default textures
                yabhb.Call("hbSetTextureSmallExpert",
                    GetTexture("UI/Health Bars/The404CelestialLeftBar_Small_Expert"),
                    GetTexture("UI/Health Bars/The404CelestialMidBar_Small_Expert"),
                    GetTexture("UI/Health Bars/The404CelestialRightBar_Small_Expert"));*/
                // Methods for setting the offsets. See part 1 of the tutorial for more information.
                yabhb.Call("hbSetMidBarOffsetY", 10);
                yabhb.Call("hbSetMidBarOffset", 30, 10);
                yabhb.Call("hbSetBossHeadCentre", 80, 32);
                yabhb.Call("hbSetBossHeadCentreSmall", 14, 14);
                yabhb.Call("hbSetFillDecoOffset", 10);
                yabhb.Call("hbSetFillDecoOffsetSmall", 10);
                // Set the three colours the bar will change colours between. Defaults to (Green -> Yellow -> Red)
                yabhb.Call("hbSetColours",
                    new Color(0f, 1f, 0f), // 100%
                    new Color(1f, 1f, 0f), // 50%
                    new Color(1f, 0f, 0f));// 0%
                
                // Force the health bar to use a custom texture as the boss head icon.
                // A useful array to grab textures from is Main.npcHeadBossTexture[]
                yabhb.Call("hbSetBossHeadTexture", GetTexture("NPCs/The404Celestial/The404CelestialClone_Head_Boss"));
                // Registers the health bar for multiple NPCs in a group
                yabhb.Call("hbFinishMultiple",
                    ModContent.NPCType<WhiteCelestial>(),
                    ModContent.NPCType<BlackCelestial>(),
                    ModContent.NPCType<BlueCelestial>(),
                    ModContent.NPCType<PurpleCelestial>(),
                    ModContent.NPCType<YellowCelestial>(),
                    ModContent.NPCType<RainbowCelestialNPC>());
                #endregion*/
#endif
                #endregion
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            _mythicResourceBarUserInterface?.Update(gameTime);
            MythicResourceBar?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            MoToolsWorld modWorld = (MoToolsWorld)GetModWorld("MoToolsWorld");

            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
            if (resourceBarIndex != -1)
            {
                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                    "MoTools: Resouce Bars",
                    delegate
                    {
                        _mythicResourceBarUserInterface.Draw(Main.spriteBatch, new GameTime());

                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public static bool CheckAprilFools()
        {
            var date = DateTime.Now;
            return date.Month == 4 && date.Day <= 2;
        }

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
            {
                return;
            }
            // Make sure your logic here goes from lowest priority to highest so your intended priority is maintained.
            if (Main.LocalPlayer.GetModPlayer<MoToolsPlayer>().ZoneThe404Realm)
            {
                if (MoToolsSound != null)
                    music = MoToolsSound.GetSoundSlot(SoundType.Music, "Sounds/Music/The404Realm");
                priority = MusicPriority.Event;
            }

            if (Main.LocalPlayer.HasBuff(BuffType("CarMount")) || Main.LocalPlayer.HasBuff(BuffType("CelestialCarMount")) || Main.LocalPlayer.HasBuff(BuffType("CelestialMount")))
            {
                if (MoToolsSound != null)
                    music = MoToolsSound.GetSoundSlot(SoundType.Music, "Sounds/Music/DriversTheme");
                priority = MusicPriority.Environment;
            }
        }

        public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
        {
            if (MoToolsWorld.the404Tiles <= 0)
            {
                return;
            }

            float the404Strength = MoToolsWorld.the404Tiles / 200f;
            the404Strength = Math.Min(the404Strength, 1f);

            int sunR = backgroundColor.R;
            int sunG = backgroundColor.G;
            int sunB = backgroundColor.B;
            // Remove some green and more red.
            sunR -= (int)(180f * the404Strength * (backgroundColor.R / 255f));
            sunG -= (int)(90f * the404Strength * (backgroundColor.G / 255f));
            sunR = Utils.Clamp(sunR, 15, 255);
            sunG = Utils.Clamp(sunG, 15, 255);
            sunB = Utils.Clamp(sunB, 15, 255);
            backgroundColor.R = (byte)sunR;
            backgroundColor.G = (byte)sunG;
            backgroundColor.B = (byte)sunB;
        }

        public static bool NoInvasion(NPCSpawnInfo spawnInfo) => !spawnInfo.invasion && (!Main.pumpkinMoon && !Main.snowMoon || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime);

        public static bool NoBiome(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            return !player.ZoneJungle && !player.ZoneDungeon && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneSnow && !player.ZoneUndergroundDesert;
        }

        public static bool NoZoneAllowWater(NPCSpawnInfo spawnInfo) => !spawnInfo.sky && !spawnInfo.player.ZoneMeteor && !spawnInfo.spiderCave;

        public static bool NoZone(NPCSpawnInfo spawnInfo) => NoZoneAllowWater(spawnInfo) && !spawnInfo.water;

        public static bool NormalSpawn(NPCSpawnInfo spawnInfo) => !spawnInfo.playerInTown && NoInvasion(spawnInfo);

        public static bool NoZoneNormalSpawn(NPCSpawnInfo spawnInfo) => NormalSpawn(spawnInfo) && NoZone(spawnInfo);

        public static bool NoZoneNormalSpawnAllowWater(NPCSpawnInfo spawnInfo) => NormalSpawn(spawnInfo) && NoZoneAllowWater(spawnInfo);

        public static bool NoBiomeNormalSpawn(NPCSpawnInfo spawnInfo) => NormalSpawn(spawnInfo) && NoBiome(spawnInfo) && NoZone(spawnInfo);

        public override void PostSetupContent()
        {

            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
            }
        }

        public override void PostUpdateEverything()
        {
            ColorCounter += directionOfChange ? 0.02f : -0.02f;
            ColorCounter = MathHelper.Clamp(ColorCounter, 0, 1);
            if (ColorCounter >= 1) directionOfChange = false;
        }

        public void Init()
        {
            On.Terraria.Item.Prefix += UpdateRarity;
            RarityInit();
        }

        private bool UpdateRarity(On.Terraria.Item.orig_Prefix orig, Terraria.Item item, int pre)
        {
            orig(item, pre);
            Terraria.Item It = new Terraria.Item();
            It.SetDefaults(item.type);
            int baseRarity = It.rare;
            int baseDamage = It.damage;
            int baseUseTime = It.useTime;

            int baseMana = It.mana;
            float baseKnockback = It.knockBack;
            float baseScale = It.scale;
            float baseShootspeed = It.shootSpeed;
            int baseCrit = It.crit;
            item.rare = baseRarity;
            if (_isFixedRarity.Contains(item.rare))
            { return true; }

            float DamageInc = 1;
            if (baseDamage != 0)
            {
                DamageInc = item.damage / baseDamage;
            }
            float KnockBack = 1;
            if (baseKnockback != 0)
            {
                KnockBack = item.knockBack / baseKnockback;
            }
            float UseTimeMult = 1;
            if (baseUseTime != 0)
            {
                UseTimeMult = item.useTime / baseUseTime;
            }
            float ScaleMult = 1;
            if (baseScale != 0)
            {
                ScaleMult = item.scale / baseScale;
            }
            float ShootspeedMult = 1;
            if (baseShootspeed != 0)
            {
                ShootspeedMult = item.shootSpeed / baseShootspeed;
            }
            float ManaMult = 1;
            if (baseMana != 0)
            {
                ManaMult = item.mana / baseMana;
            }
            float CritMult = 1;
            if (baseCrit != 0)
            {
                CritMult = item.crit / baseCrit;
            };




            int i = item.prefix;
            float TotalValue = 1f * DamageInc * (2f - UseTimeMult) * (2f - ManaMult) * ScaleMult * KnockBack * ShootspeedMult * (1f + (float)CritMult * 0.02f);
            if (i == 62 || i == 69 || i == 73 || i == 77)
            {
                TotalValue *= 1.05f;
            }
            if (i == 63 || i == 70 || i == 74 || i == 78 || i == 67)
            {
                TotalValue *= 1.1f;
            }
            if (i == 64 || i == 71 || i == 75 || i == 79 || i == 66)
            {
                TotalValue *= 1.15f;
            }
            if (i == PrefixID.Warding || i == PrefixID.Menacing || i == PrefixID.Lucky || i == PrefixID.Quick || i == PrefixID.Violent)
            {
                TotalValue *= 1.2f;
            }
            if (i == ModContent.PrefixType<Shielding>() || i == ModContent.PrefixType<Wrathful>() || i == ModContent.PrefixType<Weighted>() || i == ModContent.PrefixType<Rapid>() || i == ModContent.PrefixType<Beserk>())
            {
                TotalValue *= 1.5f;
            }
            if ((double)TotalValue >= 1.5)
            {
                item.rare += 3;
            }
            else if ((double)TotalValue >= 1.2)
            {
                item.rare += 2;
            }
            else if ((double)TotalValue >= 1.05)
            {
                item.rare++;
            }
            else if ((double)TotalValue <= 0.8)
            {
                item.rare -= 2;
            }
            else if ((double)TotalValue <= 0.95)
            {
                item.rare--;
            }

            if (item.rare > MaxRarity)
            { item.rare = MaxRarity; }
            return true;
        }
        private void RarityInit()
        {
            _rarities.Clear();
            _dynamicRaritiesColor.Clear();
            _usesDiscoRGB.Clear();
            _isFixedRarity.Clear();
            _rarities.Add(-11, RarityAmber);
            _rarities.Add(-1, new Color(34, 66, 0));//grey           
            _rarities.Add(1, new Color(187, 238, 155));//snakeskin light 2
            _dynamicRaritiesColor.Add(1, new Color(238, 209, 154));//snakeskin light
            _rarities.Add(2, new Color(75, 198, 14));//toxic light
            _dynamicRaritiesColor.Add(2, new Color(14, 198, 78));//toxic light 2
            _rarities.Add(3, new Color(148, 95, 0));//ant light 
            _dynamicRaritiesColor.Add(3, new Color(148, 124, 3));//ant light 2
            _rarities.Add(4, new Color(0, 255, 136));//light turquoise
            _dynamicRaritiesColor.Add(4, new Color(0, 255, 213));//light blue
            _rarities.Add(5, new Color(255, 253, 0));//Yellow
            _dynamicRaritiesColor.Add(5, new Color(255, 0, 0));//Red
            _rarities.Add(6, new Color(31, 63, 208));//light blue 2
            _dynamicRaritiesColor.Add(6, new Color(31, 165, 208)); //light blue
            _rarities.Add(7, new Color(107, 134, 55));//yellow green
            _dynamicRaritiesColor.Add(7, new Color(46, 255, 0));//light green
            _rarities.Add(8, new Color(255, 109, 0));//light orange
            _dynamicRaritiesColor.Add(8, new Color(157, 255, 0));//light green
            _rarities.Add(9, new Color(255, 0, 136));//bright pink
            _dynamicRaritiesColor.Add(9, new Color(198, 0, 255));//bright purple
            _rarities.Add(10, new Color(255, 239, 0));//dark teal
            _dynamicRaritiesColor.Add(10, new Color(0, 255, 201));//light teal
            _rarities.Add(11, new Color(69, 239, 112));//green cyan
            _dynamicRaritiesColor.Add(11, new Color(69, 239, 197));//blue cyan
            DarkBlue db = new DarkBlue();
            db.Load();
            FieryOrange fo = new FieryOrange();
            fo.Load();
            VoidPurple vp = new VoidPurple();
            vp.Load();
            GalacticRainbow gr = new GalacticRainbow();
            gr.Load();
            Mental mt = new Mental();
            mt.Load();
            bool foundHighest = false;
            for (int i = 11; foundHighest == false; i++)
            {
                foundHighest = true;
                if (_rarities.ContainsKey(i)) { foundHighest = false; }
                if (_dynamicRaritiesColor.ContainsKey(i)) { foundHighest = false; }
                if (_usesDiscoRGB.Contains(i)) { foundHighest = false; }
                MaxRarity = i - 1;
            }
        }

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
