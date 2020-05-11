using MoTools.Items.Placeable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MoTools.Tiles
{
    public class SteamOreBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[56][ModContent.TileType<SteamOreBlock>()] = true;
            Main.tileMerge[ModContent.TileType<SteamOreBlock>()][56] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Steam Ore");
            AddMapEntry(new Color(150, 50, 50), name);
            mineResist = 1f;
            minPick = 75;
            drop = ModContent.ItemType<SteamOre>();
            dustType = 1;

            /*if (!Main.dedServ)
            {
                SteamTexture = this.GetType().GetTexture();
            }*/
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        /*public override bool CanExplode(int i, int j)
        {
            return false;
        }*/

    }
}