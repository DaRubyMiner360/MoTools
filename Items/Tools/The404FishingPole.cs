using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoTools.Items.Tools
{
    public class The404FishingPole : ModItem
    {

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.GoldenFishingRod);
            item.fishingPole = 1000000000;
            item.value = Item.sellPrice(0, 0, 16, 0);
            item.rare = 2; 
            item.shoot = mod.ProjectileType("The404FishingPole");
            item.shootSpeed = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("404 Fishing Pole");
            Tooltip.SetDefault("Has a chance to fish out a 404 crate");
            //DisplayName.AddTranslation(GameCulture.Chinese, "凝胶钓竿");
            //Tooltip.AddTranslation(GameCulture.Chinese, "有几率钓出粘液板条箱");
            //DisplayName.AddTranslation(GameCulture.Russian, "Удочка из слизи");
            //Tooltip.AddTranslation(GameCulture.Russian, "С некоторым шансом вылавливает слизневый ящик");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WormholePotion, 1);
            recipe.AddIngredient(ItemID.WoodFishingPole, 1);
            recipe.AddIngredient(mod, "The404Essence", 20);
            recipe.AddTile(mod, "ExtremeForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}