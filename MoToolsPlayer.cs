using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.IO;
using Terraria.UI;
using System.Collections.Generic;
using MoTools.Items.Consumables;
using MoTools.Items.Placeable;
using MoTools.Items;
//using MoTools.Items.Placeable.MusicBoxes;
//using MoTools.Tiles.MusicBoxes;
using MoTools.Projectiles.Accessories;
using MoTools.Projectiles;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace MoTools
{
    public class MoToolsPlayer : ModPlayer
    {
        public Vector2 mouseWorld;


        public bool backCommand;

        public bool consumeItemDisruption;
        public bool consumeAmmoDisruption;
        public bool consumeManaDisruption;
        public bool loseHealthDisruption;
        public bool disruption;
        public bool Error666Wings;
        public bool SecretRecipe;
        public bool had404Curse;
        public bool had404Curse1;
        public bool had404Curse2;
        public bool had404Curse3;
        public bool cured404Curse;
        public bool immuneTo404Curse;

        public bool dsEquip;
        public bool ksEquip;
        public bool eocEquip;
        public bool eowEquip;
        public bool bocEquip;
        public bool tfEquip;
        public bool qbEquip;
        public bool skEquip;
        public bool qaEquip;
        public bool wofEquip;
        public bool ifEquip;
        public bool ttEquip;
        public bool tdEquip;
        public bool spEquip;
        public bool ptEquip;
        public bool gmEquip;
        public bool clEquip;
        public bool lcEquip;
        public bool mlEquip;
        public bool dfEquip;
        public bool fdEquip;
        public bool vsEquip;
        public bool frEquip;
        public bool rmEquip;
        public bool cyEquip;

        public bool tvEquip;
        public bool ggEquip;

        public bool has404Curse;

        public int constantDamage;
        public float percentDamage;

        public const int maxLifeFruits = 10;
        public int lifeFruits;

        public bool ZoneThe404Realm;
		
		public bool bonesHurt = false;
        public float boneHurtDamage = 1;
		
		public bool corruptSoul = false;
        public bool lifeRend = false;
        public bool infectedRed = false;
        public bool infectedGreen = false;
        public bool infectedBlue = false;
        public bool infectedYellow = false;

        public bool Blaze { get; set; } = false;

        public bool FireTrail { get; set; } = false;

        public Vector2 position = Main.LocalPlayer.position;

        public bool voidMonolith = false;

        public override void ResetEffects()
        {
			bonesHurt = false;
			
			if (!player.HasBuff(mod.BuffType("BoneHurt")))
            {
                boneHurtDamage = 1;
            }
			
			corruptSoul = false;
            lifeRend = false;
            infectedRed = false;
            infectedGreen = false;
            infectedBlue = false;

            dsEquip = false;
            eocEquip = false;
            eowEquip = false;
            bocEquip = false;
            tfEquip = false;
            qbEquip = false;
            skEquip = false;
            qaEquip = false;
            ifEquip = false;
            ttEquip = false;
            tdEquip = false;
            spEquip = false;
            ptEquip = false;
            gmEquip = false;
            clEquip = false;
            mlEquip = false;
            dfEquip = false;
            fdEquip = false;
            vsEquip = false;
            ggEquip = false;
            cyEquip = false;

            consumeItemDisruption = false;
            consumeAmmoDisruption = false;
            consumeManaDisruption = false;
            loseHealthDisruption = false;
            disruption = false;
            Error666Wings = false;
            SecretRecipe = false;

            constantDamage = 0;
            percentDamage = 0f;

            Blaze = false;

            FireTrail = false;

            player.statLifeMax2 += lifeFruits * 10;
        }

        public override void PlayerConnect(Player player)
        {
            int[] tiles = { TileType<Tiles.The404Block>(), TileType<Tiles.The404Sand>(), TileType<Tiles.The404Chair>(), TileType<Tiles.The404Chest>(), TileType<Tiles.The404Forge>(), TileType<Tiles.The404Platform>(), TileType<Tiles.The404Workbench>(), TileType<Tiles.ExtremeForge>() };

            MoToolsWorld.total404Tiles = 0;
            MoToolsWorld.allTilesCount = 0;

            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int o = 0; o < Main.maxTilesY; o++)
                {
                    Tile tile = Framing.GetTileSafely(i, o);
                    if (tile.active())
                    {
                        MoToolsWorld.allTilesCount++;
                    }

                    for (int p = 0; p < tiles.Length; p++)
                    {
                        if (Main.tile[i, o].type == tiles[p])
                        {
                            MoToolsWorld.total404Tiles++;
                        }
                    }
                }
            }
        }

        public override void PlayerDisconnect(Player player)
        {
            int[] tiles = { TileType<Tiles.The404Block>(), TileType<Tiles.The404Sand>(), TileType<Tiles.The404Chair>(), TileType<Tiles.The404Chest>(), TileType<Tiles.The404Forge>(), TileType<Tiles.The404Platform>(), TileType<Tiles.The404Workbench>(), TileType<Tiles.ExtremeForge>() };

            MoToolsWorld.total404Tiles = 0;
            MoToolsWorld.allTilesCount = 0;

            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int o = 0; o < Main.maxTilesY; o++)
                {
                    Tile tile = Framing.GetTileSafely(i, o);
                    if (tile.active())
                    {
                        MoToolsWorld.allTilesCount++;
                    }

                    for (int p = 0; p < tiles.Length; p++)
                    {
                        if (Main.tile[i, o].type == tiles[p])
                        {
                            MoToolsWorld.total404Tiles++;
                        }
                    }
                }
            }
        }

        public override void OnEnterWorld(Player player)
        {
            int[] tiles = { TileType<Tiles.The404Block>(), TileType<Tiles.The404Sand>(), TileType<Tiles.The404Chair>(), TileType<Tiles.The404Chest>(), TileType<Tiles.The404Forge>(), TileType<Tiles.The404Platform>(), TileType<Tiles.The404Workbench>(), TileType<Tiles.ExtremeForge>() };

            MoToolsWorld.total404Tiles = 0;
            MoToolsWorld.allTilesCount = 0;

            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int o = 0; o < Main.maxTilesY; o++)
                {
                    Tile tile = Framing.GetTileSafely(i, o);
                    if (tile.active())
                    {
                        MoToolsWorld.allTilesCount++;
                    }

                    for (int p = 0; p < tiles.Length; p++)
                    {
                        if (Main.tile[i, o].type == tiles[p])
                        {
                            MoToolsWorld.total404Tiles++;
                        }
                    }
                }
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (bonesHurt)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                boneHurtDamage += 0.0167f;
                player.lifeRegen -= (int)boneHurtDamage * 2;
                if (player.boneArmor)
                {
                    player.lifeRegen -= (int)boneHurtDamage * 2;
                }
            }
			if (corruptSoul)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 10;
            }
            /* if (infectedRed && !XShield)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 5;
            }
            if (infectedGreen && !XShield)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 5;
            }
            if (infectedBlue && !XShield)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 5;
            }
            if (infectedYellow && !XShield)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 5;
            } */
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)player.whoAmI);
            packet.Write(lifeFruits);
            packet.Send(toWho, fromWho);

            if (MoTools.CheckAprilFools())
            {
                var modLoaderMod = ModLoader.GetMod("ModLoader");
                int aprilFoolsItem = modLoaderMod.ItemType("AprilFools");

                Main.LocalPlayer.QuickSpawnItem(aprilFoolsItem, 1);
            }
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore,
            ref PlayerDeathReason damageSource)
        {
            if (player.HasItem(mod.ItemType("OmegaHealingPotion")) && !player.HasBuff(BuffID.PotionSickness))
            {
                player.ConsumeItem(mod.ItemType("OmegaHealingPotion")); player.immune = true;
                player.AddBuff(BuffID.PotionSickness, 7200);
                player.immuneTime = 180;

                if (player.statLife + 450 < player.statLifeMax2)
                {
                    player.statLife += 450;
                    player.HealEffect(450);
                }
                else
                {
                    player.HealEffect(player.statLifeMax2 - player.statLife);
                    player.statLife = player.statLifeMax2;
                }
                return false;
            }

            if (backCommand)
            {
                return false;
            }

            return true;
        }

        public override bool CanBeHitByNPC(NPC npc, ref int cooldownSlot)
        {
            if (ggEquip && !npc.boss) { return false; }
            return true;
        }
        /*public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (crit)
            {
                if (dsEquip) { player.armorPenetration += 10; target.AddBuff(ModContent.BuffType<Melting>(), 180); }
                if (qaEquip)
                {
                    int[] buffchoice = new int[3] { ModContent.BuffType<Shocked>(), ModContent.BuffType<Burning>(), ModContent.BuffType<Melting>() }; target.AddBuff(Main.rand.Next(buffchoice), 220);
                    for (int i = 0; i < 2; i++)
                    { Projectile.NewProjectile(target.Center.X, target.Center.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), mod.ProjectileType("AntBiterJaws"), 40, 1f, player.whoAmI); }
                }

                player.armorPenetration += criticalArmorPen;
                damage = (int)(damage * criticalDamageMult);
            }

        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (ggEquip && !target.boss) { crit = true; damage = target.lifeMax; }
            if (crit)
            {
                if (dsEquip) { player.armorPenetration += 10; target.AddBuff(ModContent.BuffType<Melting>(), 180); }
                if (qaEquip)
                {
                    int[] buffchoice = new int[3] { ModContent.BuffType<Shocked>(), ModContent.BuffType<Burning>(), ModContent.BuffType<Melting>() }; target.AddBuff(Main.rand.Next(buffchoice), 220);
                    for (int i = 0; i < 2; i++)
                    { Projectile.NewProjectile(target.Center.X, target.Center.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), mod.ProjectileType("AntBiterJaws"), 40, 1f, player.whoAmI); }
                }

                player.armorPenetration += criticalArmorPen;
                damage = (int)(damage * criticalDamageMult);
            }


            if ((proj.minion || ProjectileID.Sets.MinionShot[proj.type]) && target.whoAmI == player.MinionAttackTargetNPC) { damage += summonTagDamage; if (summonTagCrit > 0) { if (Main.rand.Next(1, 101) < summonTagCrit) { crit = true; } } }

        }*/

        public static MoToolsPlayer Get() => Get(Main.LocalPlayer);
        public static MoToolsPlayer Get(Player player) => player.GetModPlayer<MoToolsPlayer>();

        public override void SetupStartInventory(IList<Item> items, bool mediumCoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("The404Ore"));
            items.Add(item);
            Item item2 = new Item();
            item2.SetDefaults(mod.ItemType("The404Essence"));
            items.Add(item2);
            Item item3 = new Item();
            item3.SetDefaults(mod.ItemType("The404Ore"));
            items.Add(item3);
            Item item4 = new Item();
            item4.SetDefaults(mod.ItemType("Mental"));
            items.Add(item4);
        }

        public override void UpdateBiomes()
        {
            ZoneThe404Realm = MoToolsWorld.the404Tiles > 50;
        }

        public override bool CustomBiomesMatch(Player other)
        {
            MoToolsPlayer modOther = other.GetModPlayer<MoToolsPlayer>();
            return ZoneThe404Realm == modOther.ZoneThe404Realm;
            // If you have several Zones, you might find the &= operator or other logic operators useful:
            // bool allMatch = true;
            // allMatch &= ZoneThe404Realm == modOther.ZoneThe404Realm;
            // allMatch &= ZoneModel == modOther.ZoneModel;
            // return allMatch;
            // Here is an example just using && chained together in one statement
            // return ZoneThe404Realm == modOther.ZoneThe404Realm && ZoneModel == modOther.ZoneModel;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            MoToolsPlayer modOther = other.GetModPlayer<MoToolsPlayer>();
            modOther.ZoneThe404Realm = ZoneThe404Realm;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = ZoneThe404Realm;
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            ZoneThe404Realm = flags[0];
        }

        public override void UpdateBiomeVisuals()
        {
            //bool usePurity = NPC.AnyNPCs(NPCType<PuritySpirit>());
            //player.ManageSpecialBiomeVisuals("MoTools:PuritySpirit", usePurity);
            //bool useVoidMonolith = voidMonolith && !usePurity && !NPC.AnyNPCs(NPCID.MoonLordCore);
            //player.ManageSpecialBiomeVisuals("MoTools:MonolithVoid", useVoidMonolith, player.Center);
        }

        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneThe404Realm)
            {
                return mod.GetTexture("The404RealmBiomeMapBackground");
            }
            return null;
        }

        public override void PostUpdateEquips()
        {
            PostAccessories();
            if (Verdi > 0)
            {
                player.maxRunSpeed *= 1.1f;
            }
            if (Blaze)
                BlazeEffect();
        }

        private void BlazeEffect()
        {
            foreach (NPC npc in Main.npc)
            {
                float range = 120;
                if (npc.active && !npc.friendly && (npc.damage > 0 || npc.type == NPCID.TargetDummy) && !npc.dontTakeDamage && !npc.buffImmune[BuffID.Frostburn] && Vector2.Distance(player.Center, npc.Center) <= range)
                {
                    if (npc.FindBuffIndex(BuffID.OnFire) == -1)
                    {
                        npc.AddBuff(BuffID.OnFire, 2 * 60, false);
                    }
                }
            }
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (FireTrail && Math.Abs(player.velocity.X) > 3)
            {
                if (Main.rand.Next(12) == 0)
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 12, 2 - Main.rand.Next(4), Math.Abs(player.velocity.Y) / 4, ModContent.ProjectileType<GoodFireball>(), (int)(8 * GetGlobalDamage()), 0, player.whoAmI);
            }
        }

        private void PostAccessories()
        {
            if (Verdi > 0)
                player.maxRunSpeed += .1f;
        }

        public void DamageBoost(float amount)
		{
			player.allDamage += amount;
		}

		public void CritBoost(int amount)
		{
			player.meleeCrit += amount;
			player.magicCrit += amount;
			player.thrownCrit += amount;
			player.rangedCrit += amount;
		}

        public float GetGlobalDamage()
        {
            return player.allDamage;
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            position = Main.LocalPlayer.position;
        }

        //public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore,
        //    ref PlayerDeathReason damageSource)
        //{
        //    position = Main.LocalPlayer.position;
        //    return true;
        //}

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Error666Wings)
            {
                if (MoTools.DevSpeedHotKey.Current)
                {
                    //Error666Wings.HorizontalWingSpeeds(player, ref speed, ref acceleration).speed = 50f;
                    //Error666Wings.HorizontalWingSpeeds(player, ref speed, ref acceleration).acceleration *= 30.0f;

                    player.runAcceleration *= 30.0f;
                    player.accRunSpeed = 50f;
                }
            }

            if (MoTools.SecretHotKey.Current)
            {
                /*if (!SecretRecipe)
                {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(ItemID.DirtBlock);
                    recipe.SetResult(ItemType<Error666Wings>());
                    recipe.AddRecipe();

                    SecretRecipe = true;
                }*/
                /*else
                {
                    RecipeFinder finder = new RecipeFinder(); // make a new RecipeFinder

                    finder = new RecipeFinder(); // make a new RecipeFinder
                    finder.AddIngredient(ItemID.DirtBlock); // add a required tile, any anvil
                    finder.SetResult(ItemType<Error666Wings>()); // set the result to be 10 chains
                    Recipe exactRecipe = finder.FindExactRecipe(); // try to find the exact recipe matching our criteria

                    bool isRecipeFound = exactRecipe != null; // if our recipe is not null, it means we found the exact recipe
                    if (isRecipeFound) // since our recipe is found, we can continue
                    {
                        RecipeEditor editor = new RecipeEditor(exactRecipe); // for our recipe, make a new RecipeEditor
                        editor.DeleteRecipe(); // delete the recipe
                    }

                    SecretRecipe = false;
                }*/
            }
            else
            {
                RecipeFinder finder = new RecipeFinder(); // make a new RecipeFinder

                finder = new RecipeFinder(); // make a new RecipeFinder
                finder.AddIngredient(ItemID.DirtBlock); // add a required tile, any anvil
                finder.SetResult(ItemType<Error666Wings>()); // set the result to be 10 chains
                Recipe exactRecipe = finder.FindExactRecipe(); // try to find the exact recipe matching our criteria

                bool isRecipeFound = exactRecipe != null; // if our recipe is not null, it means we found the exact recipe
                if (isRecipeFound) // since our recipe is found, we can continue
                {
                    RecipeEditor editor = new RecipeEditor(exactRecipe); // for our recipe, make a new RecipeEditor
                    editor.DeleteRecipe(); // delete the recipe
                }

                SecretRecipe = false;
            }
        }

        public override TagCompound Save()
        {
            // Read https://github.com/tModLoader/tModLoader/wiki/Saving-and-loading-using-TagCompound to better understand Saving and Loading data.
            return new TagCompound {
				// {"somethingelse", somethingelse}, // To save more data, add additional lines
                {"lifeFruits", lifeFruits},
            };
            //note that C# 6.0 supports indexer initializers
            //return new TagCompound {
            //	["score"] = score
            //};
        }

        public override void Load(TagCompound tag)
        {
            lifeFruits = tag.GetInt("lifeFruits");
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
            ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (constantDamage > 0 || percentDamage > 0f)
            {
                int damageFromPercent = (int)(player.statLifeMax2 * percentDamage);
                damage = Math.Max(constantDamage, damageFromPercent);
                customDamage = true;
            }
            constantDamage = 0;
            percentDamage = 0f;
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }

        #region Buffs

        public const int MAX_BUFFS = 42;

        public bool Steam { get; set; }

        public bool Frost { get; set; }

        public bool Frigid { get; set; }

        public bool Frosty { get; set; }

        public bool Rocks { get; set; }

        public bool Sandy { get; set; }

        public bool TrueCurse { get; set; }

        public bool NoRegen { get; set; }

        public bool HalfDef { get; set; }

        public int Connected { get; set; }

        public int Verdi { get; set; }

        #endregion
    }
}