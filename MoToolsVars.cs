using System.Collections.Generic;
using MoTools.NPCs.TheAnnihilator;
using MoTools.NPCs.PaperCut;
using MoTools.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools
{
    internal class MoToolsVars //A list of all of the important vars!
    {
        // TODO Change this to an actual instance of MoTools, taken from LaugicalityMod.
        /*public static Mod Mod => MoTools.Instance;*/

        public enum ClassType
        {
            Undefined, //(No class) 0
                       /*Melee*/
            Warrior, //(Dmg) 1
            Tank, //(Def) 2
            Paladin, //(Util/Survivability) 3
                     /*Magic*/
            Warlock, //(Dmg) 4
            Wizard, //(Mana) 5
            Mage, //(Util/Survivability) 6
                  /*Range*/
            Sharpshooter, //(Dmg) 7
            Rogue, //(Mobility) 8
            Hunter, //(Util/Survivability) 9
                    /*Summn*/
            Necromancer, //(Dmg) 10
            Sorcerer, //(Minions & Mana) 11
            Shaman, //(Util/Survivability) 12
                    /*Throw*/
            Assasin, //(Dmg) 13
            Ninja, //(Vel & Sp & Mobility) 14
            Thief, //(Util/Survivability) 15
                   /*Mystc:*/
            Destructionist, //(Dmg) 16
            Illusionist, //(BuffDur & Mobility) 17
            Conjurer //(Util/Survivability) 18
        }
        /* -------------- Etherial NPCs and Projectiles -------------- */

        public static readonly HashSet<int> eNPCs =
            new HashSet<int>
            {
            };

        public static readonly HashSet<int> eProjectiles =
            new HashSet<int>
            {
                31, 67, 68, 56, 71, 241, 179, 270, 55, 83, 99, 100, 96, 605, 101, 102, 257, 275, 276, 277, 262, 258, 259, 288, 384, 385, 386, 464, 465, 466, 467, 468, 490, 455, 454, 452, 657, 658, 670, 671, 672, 673, 673, 675, 676, 681, 682, 683, 684, 685, 686, 687, 
            };

        public static readonly HashSet<int> eBosses =
            new HashSet<int>
            {
                NPCID.KingSlime, NPCID.EyeofCthulhu, NPCID.BrainofCthulhu, NPCID.QueenBee, NPCID.SkeletronHead, NPCID.TheDestroyer, NPCID.SkeletronPrime, ModContent.NPCType<TheAnnihilator>(), ModContent.NPCType<PaperCut>(), NPCID.Plantera, NPCID.Golem, NPCID.DukeFishron, NPCID.MoonLordCore
            };

        //Projectiles that are immune to time stop
        public static readonly HashSet<int> zProjectiles =
            new HashSet<int>
            {
            };

        //Projectiles that are immune to time stop while in the Etherial
        public static readonly HashSet<int> ezProjectiles =
            new HashSet<int>
            {
            };

        //Bosses that are immune to time stop
        public static readonly HashSet<int> zNPCs =
            new HashSet<int>
            {
            };

        public static readonly HashSet<int> eBad =
            new HashSet<int>
            {
                430, 431, 432, 433, 434, 435, 436
            };


        public static readonly HashSet<int> frigImmune =
            new HashSet<int>
            {
                13, 14, 15
            };

        public static readonly HashSet<int> etherial =
            new HashSet<int>
            {
                
            };


        public static readonly HashSet<int> obsidiumTiles =
            new HashSet<int>
            {
                 TileID.Obsidian,
            };

        public static readonly HashSet<int> steamTiles =
            new HashSet<int>
            {
                 ModContent.TileType<Tiles.SteamRock>(), ModContent.TileType<SteamBrick>(), /*ModContent.TileType<Lycoris>(), ModContent.TileType<Tiles.Radiata>(),*/ ModContent.TileType<SteamOreBlock>(),
            };

        /* -------------- SLIMEKING -------------- */
        public static readonly HashSet<int> slimeThrow =
            new HashSet<int> { (int)MoToolsVars.ClassType.Assasin, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Thief };
        public static readonly HashSet<int> slimeJump =
            new HashSet<int> { (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Paladin, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Illusionist, (int)MoToolsVars.ClassType.Shaman, (int)MoToolsVars.ClassType.Mage, (int)MoToolsVars.ClassType.Conjurer };
        public static readonly HashSet<int> slimeMinion =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Hunter, (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Destructionist };
        public static readonly HashSet<int> slimeVelocity =
            new HashSet<int> { (int)MoToolsVars.ClassType.Assasin, (int)MoToolsVars.ClassType.Thief };

        /* -------------- BOSS1 -------------- */
        public static readonly HashSet<int> boss1Thorns =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Thief, (int)MoToolsVars.ClassType.Destructionist };
        public static readonly HashSet<int> boss1Speed =
            new HashSet<int> { (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Shaman, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Illusionist };
        public static readonly HashSet<int> boss1Detect =
            new HashSet<int> { (int)MoToolsVars.ClassType.Paladin, (int)MoToolsVars.ClassType.Mage, (int)MoToolsVars.ClassType.Hunter, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Assasin, (int)MoToolsVars.ClassType.Conjurer };
        public static readonly HashSet<int> boss1Damage =
            new HashSet<int> { (int)MoToolsVars.ClassType.Destructionist, (int)MoToolsVars.ClassType.Illusionist, (int)MoToolsVars.ClassType.Conjurer };

        /* -------------- BOSS2 -------------- */
        public static readonly HashSet<int> boss2Rage =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Assasin, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Destructionist };
        public static readonly HashSet<int> boss2Defence =
            new HashSet<int> { (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Paladin, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Shaman, (int)MoToolsVars.ClassType.Illusionist };
        public static readonly HashSet<int> boss2Regen =
            new HashSet<int> { (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Mage, (int)MoToolsVars.ClassType.Hunter, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Thief, (int)MoToolsVars.ClassType.Conjurer };
        public static readonly HashSet<int> boss2RBonus =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Mage };

        /* -------------- QUEENBEE -------------- */
        public static readonly HashSet<int> beeTrue =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Destructionist };
        public static readonly HashSet<int> beeRegen =
            new HashSet<int> { (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Paladin, (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Assasin, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Thief, (int)MoToolsVars.ClassType.Conjurer };
        public static readonly HashSet<int> beeMinions =
            new HashSet<int> { (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Mage, (int)MoToolsVars.ClassType.Hunter, (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Shaman, (int)MoToolsVars.ClassType.Illusionist };
        public static readonly HashSet<int> beeMDamage =
            new HashSet<int> { (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Shaman };

        /* -------------- BOSS3 -------------- */
        public static readonly HashSet<int> boss3Damage =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Assasin, (int)MoToolsVars.ClassType.Destructionist };
        public static readonly HashSet<int> boss3Defense =
            new HashSet<int> { (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Illusionist };
        public static readonly HashSet<int> boss3Speed =
            new HashSet<int> { (int)MoToolsVars.ClassType.Paladin, (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Mage, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Hunter, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Shaman, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Thief, (int)MoToolsVars.ClassType.Conjurer };
        public static readonly HashSet<int> boss3Crit =
            new HashSet<int> { (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Hunter };

        /* -------------- HARDMODE -------------- */
        public static readonly HashSet<int> hardDamage =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Assasin, (int)MoToolsVars.ClassType.Destructionist };
        public static readonly HashSet<int> hardRegen =
            new HashSet<int> { (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Illusionist, (int)MoToolsVars.ClassType.Paladin, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Hunter, (int)MoToolsVars.ClassType.Shaman, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Thief };
        public static readonly HashSet<int> hardMana =
            new HashSet<int> { (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Mage, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Conjurer };
        public static readonly HashSet<int> hardObsid =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Paladin };

        /* -------------- MECH1 -------------- */
        public static readonly HashSet<int> mech1Crit =
            new HashSet<int> { (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Hunter };
        public static readonly HashSet<int> mech1Speed =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Paladin, (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Mage, (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Shaman, (int)MoToolsVars.ClassType.Assasin, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Thief, (int)MoToolsVars.ClassType.Destructionist, (int)MoToolsVars.ClassType.Illusionist, (int)MoToolsVars.ClassType.Conjurer };

        /* -------------- MECH2 -------------- */
        public static readonly HashSet<int> mech2Magic =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Mage, (int)MoToolsVars.ClassType.Destructionist, (int)MoToolsVars.ClassType.Illusionist, (int)MoToolsVars.ClassType.Conjurer, (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Shaman };
        public static readonly HashSet<int> mech2Jump =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Paladin, (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Hunter, (int)MoToolsVars.ClassType.Assasin, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Thief };

        /* -------------- MECH3 -------------- */
        public static readonly HashSet<int> mech3Damage =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Paladin };
        public static readonly HashSet<int> mech3Defense =
            new HashSet<int> { (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Hunter, (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Mage, (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Shaman, (int)MoToolsVars.ClassType.Assasin, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Thief, (int)MoToolsVars.ClassType.Destructionist, (int)MoToolsVars.ClassType.Illusionist, (int)MoToolsVars.ClassType.Conjurer };

        /* -------------- PLANT -------------- */
        public static readonly HashSet<int> plantBonus =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Mage, (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Shaman, (int)MoToolsVars.ClassType.Destructionist, (int)MoToolsVars.ClassType.Illusionist, (int)MoToolsVars.ClassType.Conjurer  };
        public static readonly HashSet<int> plantThorns =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Paladin, (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Hunter, (int)MoToolsVars.ClassType.Assasin, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Thief };

        /* -------------- GOLEM -------------- */
        public static readonly HashSet<int> golemCrit =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Assasin };
        public static readonly HashSet<int> golemRegen =
            new HashSet<int> { (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Paladin, (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Mage, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Hunter, (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Shaman, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Thief, (int)MoToolsVars.ClassType.Destructionist, (int)MoToolsVars.ClassType.Illusionist, (int)MoToolsVars.ClassType.Conjurer };


        /* -------------- FISH -------------- */
        public static readonly HashSet<int> fishDouche =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Paladin, (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Hunter };
        public static readonly HashSet<int> fishSpeed =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Mage, (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Shaman, (int)MoToolsVars.ClassType.Assasin, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Thief };
        public static readonly HashSet<int> fishMDamage =
            new HashSet<int> { (int)MoToolsVars.ClassType.Destructionist, (int)MoToolsVars.ClassType.Illusionist, (int)MoToolsVars.ClassType.Conjurer };

        /* -------------- CULTIST -------------- */
        public static readonly HashSet<int> cultistDamage1 =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warrior, (int)MoToolsVars.ClassType.Tank, (int)MoToolsVars.ClassType.Paladin, (int)MoToolsVars.ClassType.Sharpshooter, (int)MoToolsVars.ClassType.Rogue, (int)MoToolsVars.ClassType.Hunter, (int)MoToolsVars.ClassType.Assasin, (int)MoToolsVars.ClassType.Ninja, (int)MoToolsVars.ClassType.Thief };
        public static readonly HashSet<int> cultistDamage2 =
            new HashSet<int> { (int)MoToolsVars.ClassType.Warlock, (int)MoToolsVars.ClassType.Wizard, (int)MoToolsVars.ClassType.Mage, (int)MoToolsVars.ClassType.Necromancer, (int)MoToolsVars.ClassType.Sorcerer, (int)MoToolsVars.ClassType.Shaman, (int)MoToolsVars.ClassType.Destructionist, (int)MoToolsVars.ClassType.Illusionist, (int)MoToolsVars.ClassType.Conjurer };

    }
}
