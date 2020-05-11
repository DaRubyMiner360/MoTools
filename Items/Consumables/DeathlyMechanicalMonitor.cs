using MoTools.Items;
using MoTools.NPCs.TheAnnihilator;
using MoTools.Projectiles.Bosses;
using MoTools.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Consumables
{
	public class DeathlyMechanicalMonitor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deathly Anni-O-Lator");
            Tooltip.SetDefault("Summons The Annihilator\nIgnores the rules that say only 1 of it.");
        }
        
        public override void SetDefaults()
		{
			item.width = 48;
			item.height = 40;
			item.maxStack = 20;
			item.rare = ItemRarityID.Pink;
			item.useAnimation = 45;
			item.useTime = 1;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Nothing>();
            item.value = Item.buyPrice(gold: 1);
            item.value = Item.sellPrice(silver: 50);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<TheAnnihilator>(), knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player) => !Main.dayTime;

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.HallowedBar, 5);
            recipe.AddIngredient(mod, nameof(MechanicalMonitor), 1);
            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}