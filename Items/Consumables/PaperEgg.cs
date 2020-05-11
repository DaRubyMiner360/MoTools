using MoTools.Items;
using MoTools.NPCs.PaperCut;
using MoTools.Projectiles.Bosses;
using MoTools.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Consumables
{
	public class PaperEgg : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paper Egg");
            Tooltip.SetDefault("Summons Paper Cut");
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
            item.value = Item.buyPrice(gold: 50);
            item.value = Item.sellPrice(gold: 25);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<PaperCut>(), knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player) => /*!Main.dayTime && */NPC.CountNPCS(ModContent.NPCType<PaperCut>()) < 1;

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

            //recipe.AddIngredient(ItemID.HallowedBar, 5);
            recipe.AddIngredient(mod, nameof(Paper), 50);
			//recipe.AddIngredient(ItemID.Vertebrae, 3);
            //recipe.AddIngredient(mod, nameof(SoulOfHaught), 3);
            //recipe.AddIngredient(mod, nameof(SoulOfSought), 3);

            recipe.AddTile(TileID.MythrilAnvil);

			recipe.SetResult(this);
			recipe.AddRecipe();
            

            recipe = new ModRecipe(mod);

            //recipe.AddIngredient(ItemID.HallowedBar, 5);
            recipe.AddIngredient(mod, nameof(Paper), 50);
            //recipe.AddIngredient(ItemID.RottenChunk, 3);
            //recipe.AddIngredient(mod, nameof(SoulOfHaught), 3);
            //recipe.AddIngredient(mod, nameof(SoulOfSought), 3);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);

            recipe.AddRecipe();
        }
	}
}