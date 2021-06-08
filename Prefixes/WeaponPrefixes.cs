using Terraria.ModLoader;

namespace MoTools.Prefixes
{
    public class CarefulPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Careful");
        }
		
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 1.33333f;
            useTimeMult = 1.15f;
            shootSpeedMult = 1.15f;
            critBonus = 15;
        }
        // change your category this way, defaults to Custom
        public override PrefixCategory Category
            => PrefixCategory.AnyWeapon;
    }
    public class KnowledgeablePrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Knowledgeable");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            manaMult = -.2f;
            critBonus = 20;
        }
        // change your category this way, defaults to Custom
        public override PrefixCategory Category
            => PrefixCategory.Magic;
    }
    public class HallowedPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hallowed");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            useTimeMult = .65f;
            critBonus = 15;
        }
        // change your category this way, defaults to Custom
        public override PrefixCategory Category
            => PrefixCategory.AnyWeapon;
    }
    public class ColossalPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Colossal");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            scaleMult = 5f;
            damageMult = 1.61f;
            useTimeMult = 1.5f;
        }
        // change your category this way, defaults to Custom
        public override PrefixCategory Category
            => PrefixCategory.Melee;
    }
    public class MagicalPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Magical");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            manaMult = -5f;
            damageMult = 1.5f;
        }
        // change your category this way, defaults to Custom
        public override PrefixCategory Category
            => PrefixCategory.Magic;
    }
    public class AntiMagicalPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Anti-Magical");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            manaMult = 5f;
            damageMult = .5f;
        }
        // change your category this way, defaults to Custom
        public override PrefixCategory Category
            => PrefixCategory.Magic;
    }
    public class SpeedOfLightPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Speed of Light");
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            useTimeMult = -2.33f;
        }
        // change your category this way, defaults to Custom
        public override PrefixCategory Category
            => PrefixCategory.AnyWeapon;
    }
}