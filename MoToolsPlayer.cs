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
using MoTools.Items.Placeable.MusicBoxes;
using MoTools.Tiles.MusicBoxes;
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

        public int constantDamage;
        public float percentDamage;

        public const int maxLifeFruits = 10;
        public int lifeFruits;

        public bool Blaze { get; set; } = false;

        public bool FireTrail { get; set; } = false;

        public override void ResetEffects()
        {
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

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)player.whoAmI);
            packet.Write(lifeFruits);
            packet.Send(toWho, fromWho);
        }

        public static MoToolsPlayer Get() => Get(Main.LocalPlayer);
        public static MoToolsPlayer Get(Player player) => player.GetModPlayer<MoToolsPlayer>();

        public override void SetupStartInventory(IList<Item> items, bool mediumCoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("The404Ore"));
            item.SetDefaults(mod.ItemType("The404Essence"));
            item.SetDefaults(mod.ItemType("The404Ore"));
            items.Add(item);
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
                if (!SecretRecipe)
                {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(ItemID.DirtBlock);
                    recipe.SetResult(ItemType<Error666Wings>());
                    recipe.AddRecipe();

                    SecretRecipe = true;
                }
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