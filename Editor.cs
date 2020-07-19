using System;
using MoTools.Buffs;
using MoTools.Dusts;
using MoTools.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using MoTools.Items;
using System.Collections.Specialized;
using static Terraria.ModLoader.ModContent;

namespace MoTools
{
    public class Editor
    {
        public bool isEditor = false;

        public void Set()
        {
            Mod cheatSheet = ModLoader.GetMod("CheatSheet");
            Mod herosMod = ModLoader.GetMod("HerosMod");

            if (cheatSheet != null || herosMod != null)
            {
                isEditor = true;
            }
        }
    }
}