﻿using MoTools.Items;
using MoTools.NPCs.The404BoC;
using MoTools.Projectiles.Bosses;
using MoTools.Projectiles;
using MoTools.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Consumables
{
	public class ErroredBloodySpine : ModItem
    {
        public NPCSpawnInfo player;

        public override string Texture => "Terraria/Item_" + ItemID.BloodySpine;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Errored Bloody Spine");
            Tooltip.SetDefault("Summons The 404 Infused Brain of Cthulhu");
        }
        
        public override void SetDefaults()
		{
			item.width = 48;
			item.height = 40;
			item.maxStack = 20;
			item.rare = ItemRarityID.Pink;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<Nothing>();
            item.value = Item.buyPrice(gold: 75);
            item.value = Item.sellPrice(gold: 37, silver: 50);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<The404BoC>(), knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player) => /*!Main.dayTime && */NPC.CountNPCS(ModContent.NPCType<The404BoC>()) < 1 && NPC.downedMoonlord && NPC.downedBoss2 && MoToolsWorld.downedThe404EoC && player.ZoneCrimson;

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.BloodySpine, 1);
            recipe.AddIngredient(ItemID.ViciousPowder, 3);
			recipe.AddIngredient(ItemID.Vertebrae, 3);
            recipe.AddIngredient(mod, nameof(The404Essence), 3);
            recipe.AddIngredient(mod, nameof(The404Ore), 3);

            recipe.AddTile(mod, nameof(The404Forge));
            recipe.AddTile(TileID.DemonAltar);

            recipe.SetResult(this);
			recipe.AddRecipe();
            

            recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.BloodySpine, 1);
            recipe.AddIngredient(ItemID.ViciousPowder, 3);
            recipe.AddIngredient(ItemID.RottenChunk, 3);
            recipe.AddIngredient(mod, nameof(The404Essence), 3);
            recipe.AddIngredient(mod, nameof(The404Ore), 3);

            recipe.AddTile(mod, nameof(The404Forge));
            recipe.AddTile(TileID.DemonAltar);
            
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}