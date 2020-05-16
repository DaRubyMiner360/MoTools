using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items.Weapons
{
    public class Unlimited404Bullets : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unlimited 404 Bullets");
            Tooltip.SetDefault("The bullet that was infused with Error 404.");
        }
        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.ranged = true;
            item.damage = 574;
            item.width = 32;
            item.height = 32;
            item.consumable = false;
            item.knockBack = 2.5f;
            item.value = 1000;
            item.rare = 8;
            item.shoot = mod.ProjectileType("The404Bullet");
            item.shootSpeed = 9f;
            item.ammo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("The404Bullet"), 3996);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Unlimited"), 1);
            recipe.AddIngredient(mod.ItemType("The404Bullet"), 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        /*
        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            add += (player.magicDamage - 1f);
            mult *= player.magicDamageMult;
        }
        */
        public override void GetWeaponCrit(Player player, ref int crit)
        {
            crit += player.rangedCrit;
            crit /= 2;
        }
    }
}

