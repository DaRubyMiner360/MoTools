using System;
using System.IO;
using System.Collections.Generic;
using MoTools.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using MoTools.Items.Accessories;
using MoTools.Items.Equipables;
using MoTools.Items;

namespace MoTools
{
    public partial class MoToolsWorld : ModWorld
    {
        public static bool downedAnnihilator = false;
        public static bool downedPaperCut = false;
        public static bool downedThe404KingSlime = false;
        public static bool spawned404Crystals = false;
        public static int power = 0;
        public static bool obEnf = false; //steamEnfused
        public static bool bysmal = false;

        public static int sizeMult = (int)(Math.Round(Main.maxTilesX / 4200f)); //Small = 2; Medium = ~3; Large = 4;

        public static int zawarudo = 0;
        public static int dungeonSide = 1;

        public static int steamPosition = 0;

        public override void Initialize()
        {
            sizeMult = (int)(Math.Floor(Main.maxTilesX / 4200f));
            power = 0;
            downedAnnihilator = false;
            downedPaperCut = false;
            downedThe404KingSlime = false;
            spawned404Crystals = false;
            zawarudo = 0;
            obEnf = false;
            bysmal = false;
            steamPosition = 0;
        }

        public override void PostUpdate()
        {
            /*if (downedEtheria)
            {
                Main.dayTime = false;
                Main.time = 16200.0;
            }*/

            Ameldera = Main.raining;
        }

        public override TagCompound Save()
        {
            List<string> downed = new List<string>();
            bool obs = false;
            int pwr = 0;
            if (downedAnnihilator) downed.Add("annihilator");
            if (downedPaperCut) downed.Add("paperCut");
            if (downedThe404KingSlime) downed.Add("the404KingSlime");
            if (obEnf) obs = true;
            pwr = power;

            return new TagCompound {
                {"downed", downed},
                {"bysmal", bysmal },
                {"power", pwr }
            };
        }

        public override void Load(TagCompound tag)
        {
            IList<string> downed = tag.GetList<string>("downed");
            downedAnnihilator = downed.Contains("annihilator");
            downedPaperCut = downed.Contains("paperCut");
            downedThe404KingSlime = downed.Contains("the404KingSlime");
            obEnf = tag.GetBool("steam");
            bysmal = tag.GetBool("bysmal");
            power = tag.GetInt("power");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedAnnihilator = flags[0];
                downedPaperCut = flags[1];
                downedThe404KingSlime = flags[2];

                BitsByte flags2 = reader.ReadByte();
                obEnf = flags2[4];
                bysmal = flags2[6];
            }
            else
            {
                ErrorLogger.Log("MoTools: Unknown loadVersion: " + loadVersion);
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedAnnihilator;
            flags[1] = downedPaperCut;
            flags[2] = downedThe404KingSlime;

        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedAnnihilator = flags[0];
            downedPaperCut = flags[1];

        }

        public override void ResetNearbyTileEffects()
        {
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            // The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
            // First, we find out which step "Shinies" is.
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex != -1)
            {
                // Next, we insert our step directly after the original "Shinies" step. 
                // ExampleModOres is a method seen below.
                tasks.Insert(ShiniesIndex + 1, new PassLegacy("404 Crystals", The404Ore));
            }

            /*int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            int xO = Main.maxTilesX / 2;
            int yO = (int)(Main.maxTilesY * .7f);
            tasks.Insert(genIndex + 1, new PassLegacy("Generating 404 Cavern", delegate (GenerationProgress progress)
            {
                progress.Message = "404 Infusion";
            }));

            int genIndex2 = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            tasks.Insert(genIndex2 + 2, new PassLegacy("404 Features", delegate (GenerationProgress progress)
            {
                progress.Message = "404 Core";
            }));*/
        }

        private void The404Ore(GenerationProgress progress)
        {
            // progress.Message is the message shown to the user while the following code is running. Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes. 
            progress.Message = "404 Crystals";

            // Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
            // "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
            for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                // The inside of this for loop corresponds to one single splotch of our Ore.
                // First, we randomly choose any coordinate in the world by choosing a random x and y value.
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

                // Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
                // WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), TileType<The404Ore>(), false, 0f, 0f, false, true);

                // Alternately, we could check the tile already present in the coordinate we are interested. Wrapping WorldGen.TileRunner in the following condition would make the ore only generate in Hellstone.
                /*Tile tile = Framing.GetTileSafely(x, y);
                if (tile.active() && tile.type == TileID.Hellstone || tile.type == TileID.Ash)
                {
                    WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 5), TileType<The404Ore>(), false, 0f, 0f, false, true);
                }*/
            }
        }

        public override void PostWorldGen()
        {
            // This is simply generating a line of Chlorophyte halfway down the world.
            for (int i = -1; i < Main.maxTilesX; i++)
            {
            	Main.tile[i, Main.maxTilesY / 2].type = TileID.Ebonstone;
            }
            for (int i = 1; i < Main.maxTilesX; i++)
            {
                Main.tile[i, Main.maxTilesY / 2].type = TileID.Crimstone;
            }
        }

        public static int GetCurseCount()
        {
            int count = 0;
            int numBosses = CountDownedBosses();
            if (numBosses >= 5)
                count++;
            if (numBosses >= 10)
                count++;
            if (numBosses >= 15)
                count++;
            if (numBosses >= 20)
                count++;
            return count;
        }

        private static int GetSteamLoot()
        {
            int[] steamLoot = new int[] { /*ModContent.ItemType<Eruption>(), */ModContent.ItemType<FireDust>(), ModContent.ItemType<CrystalizedMagma>(), ModContent.ItemType<SteamLily>(), ModContent.ItemType<MagmaHeart>(), ModContent.ItemType<Ragnashia>(), };

            if (steamPosition < steamLoot.GetLength(0))
                return steamLoot[steamPosition];
            else
            {
                steamPosition = 0;
                return steamLoot[steamPosition];
            }
        }

        private static int[] GetSteamOreLoot()
        {
            int[] oreLoot = new int[] { ItemID.GoldBar, ItemID.PlatinumBar, ItemID.TungstenBar, ItemID.SilverBar };
            int orePos = Main.rand.Next(oreLoot.GetLength(0));
            int oreCount = Main.rand.Next(6, 16);
            int[] ore = { 0, 0 };
            ore[0] = oreLoot[orePos];
            ore[1] = oreCount;
            return ore;
        }

        private static int[] GetSteamPotionLoot()
        {
            int[] potLoot = new int[] { /*ModContent.ItemType<DestructionPotion>(), ModContent.ItemType<IllusionPotion>(), ModContent.ItemType<ConjurationPotion>(), ModContent.ItemType<JumpBoostPotion>(), */ItemID.InfernoPotion, ItemID.LifeforcePotion, ItemID.WrathPotion };
            int potPos = Main.rand.Next(potLoot.GetLength(0));
            int potCount = Main.rand.Next(2, 5);
            int[] pot = { 0, 0 };
            pot[0] = potLoot[potPos];
            pot[1] = potCount;
            return pot;
        }

        private static int[] GetSteamMoneyLoot()
        {
            int monType = 0;
            int monCount = 0;
            if (Main.rand.Next(2) == 0)
            {
                monType = ItemID.GoldCoin;
                monCount = Main.rand.Next(1, 4);
            }
            else
            {
                monType = ItemID.SilverCoin;
                monCount = Main.rand.Next(60, 99);
            }
            int[] mon = { 0, 0 };
            mon[0] = monType;
            mon[1] = monCount;
            return mon;
        }

        private static int[] GetSteamMiscLoot()
        {
            int[] mscLoot = new int[] {
                ModContent.ItemType<Items.Placeable.LavaGem>(), ModContent.ItemType<ArcaneShard>(),
                ModContent.ItemType<Items.Placeable.LavaGem>(), ModContent.ItemType<RubrumDust>(),
                /*ModContent.ItemType<AlbusDust>(), ModContent.ItemType<VerdiDust>() */};

            int mscPos = Main.rand.Next(mscLoot.GetLength(0));
            int mscCount = Main.rand.Next(2, 6);
            int[] msc = { 0, 0 };
            msc[0] = mscLoot[mscPos];
            msc[1] = mscCount;
            return msc;
        }

        public static void PlaceSteamChest(int x, int y, ushort floorType)
        {
            ClearSpaceForChest(x, y, floorType);
            int chestIndex = WorldGen.PlaceChest(x, y, (ushort)ModContent.TileType<SteamChest>(), false, 0);

            int specialItem = GetSteamLoot();
            steamPosition++;
            int[] oreLoot = GetSteamOreLoot();
            int[] potionLoot = GetSteamPotionLoot();
            int[] money = GetSteamMoneyLoot();
            int[] miscLoot = GetSteamMiscLoot();

            int[] itemsToPlaceInChests = new int[] { specialItem, oreLoot[0], potionLoot[0], money[0], miscLoot[0] };
            int[] itemCounts = new int[] { 1, oreLoot[1], potionLoot[1], money[1], miscLoot[1] };

            FillChest(chestIndex, itemsToPlaceInChests, itemCounts);
        }

        private void PlaceTile(int x, int y, int tileType)
        {
            WorldGen.KillTile(x, y);
            WorldGen.KillWall(x, y);
            Main.tile[x, y].liquid = 0;
            WorldGen.PlaceTile(x, y, tileType, true, true);
        }

        private void PlaceTile(int x, int y, int tileType, int wallType)
        {
            WorldGen.KillTile(x, y);
            WorldGen.KillWall(x, y);
            Main.tile[x, y].liquid = 0;
            WorldGen.PlaceTile(x, y, tileType, true, true);
            WorldGen.PlaceWall(x, y, wallType, true);
        }

        private static bool TileCheckSafe(int i, int j)
        {
            if (i > 0 && i < Main.maxTilesX - 1 && j > 0 && j < Main.maxTilesY - 1)
            {
                if (TileID.Sets.BasicChest[Main.tile[i, j].type])
                    return false;
                return true;
            }
            return false;
        }

        private float Distance(int x1, int y1, int x2, int y2)
        {
            return (float)(Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
        }

        private static void ClearSpaceForChest(int x, int y, ushort floorType)
        {
            WorldGen.KillTile(x, y);
            WorldGen.KillTile(x, y - 1);
            WorldGen.KillTile(x + 1, y - 1);
            WorldGen.KillTile(x + 1, y);
            WorldGen.PlaceTile(x + 1, y + 1, floorType, true, true);
            WorldGen.PlaceTile(x, y + 1, floorType, true, true);
            Main.tile[x, y].liquid = 0;
            Main.tile[x + 1, y].liquid = 0;
            Main.tile[x, y + 1].liquid = 0;
            Main.tile[x + 1, y + 1].liquid = 0;
        }

        private static void FillChest(int chestIndex, int[] itemsToPlaceInChests, int[] itemCounts)
        {
            if (chestIndex < Main.chest.GetLength(0) && chestIndex >= 0)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == 0 && inventoryIndex < itemsToPlaceInChests.GetLength(0))
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInChests[inventoryIndex]);
                            chest.item[inventoryIndex].stack = itemCounts[inventoryIndex];
                        }
                    }
                }
            }
        }

        public static int CountDownedBosses()
        {
            int count = 0;
            if (NPC.downedSlimeKing) count++;
            if (NPC.downedBoss1) count++;
            if (NPC.downedBoss2) count++;
            if (NPC.downedQueenBee) count++;
            if (NPC.downedBoss3) count++;
            if (Main.hardMode) count++;
            if (NPC.downedMechBoss2) count++;
            if (NPC.downedMechBoss1) count++;
            if (NPC.downedMechBoss3) count++;
            if (downedAnnihilator) count++;
            if (downedPaperCut) count++;
            if (NPC.downedPlantBoss) count++;
            if (NPC.downedGolemBoss) count++;
            if (NPC.downedFishron) count++;
            if (NPC.downedMoonlord) count++;
            return count;
        }

        public static bool Ameldera { get; private set; }
    }
}