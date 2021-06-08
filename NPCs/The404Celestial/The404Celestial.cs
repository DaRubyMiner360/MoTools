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
using System.Collections.Specialized;
using static Terraria.ModLoader.ModContent;
using On.Terraria.DataStructures;

namespace MoTools.NPCs.The404Celestial
{
    [AutoloadBossHead]
    public class The404Celestial : ModNPC
    {
        public static Random rnd = new Random();
        public int spawn = 0;
        public int plays = 0;

        // AI
        int ai;
        int attackTimer;
        bool fastSpeed;

        bool stunned;
        int stunnedTimer;

        // Animation
        int frame;
        double counting;

        public override void SetStaticDefaults()
        {
            MoToolsVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("The 404 Infused Celestial Lord");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.width = 128;
            npc.height = 128;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.npcSlots = 30f;
            npc.value = Item.buyPrice(platinum: 500, gold: 500, silver: 500, copper: 500);
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            //npc.noTileCollide = true;
            //music = mod.GetSoundSlot(SoundType.Music, "../MoToolsSound/Sounds/Music/The404Celestial");
            music = mod.GetSoundSlot(SoundType.Music, "../MoToolsSound/Sounds/Music/TheCelestial");
            //bossBag = ItemType<The404CelestialTreasureBag>();
            bossBag = ItemType<TheCelestialTreasureBag>();

            if (Main.expertMode)
            {
                npc.lifeMax = 500000000;
                npc.damage = 500;
                npc.defense = 2000;
            }
            else
            {
                npc.lifeMax = 250000000;
                npc.damage = 250;
                npc.defense = 1000;
            }

            //npc.CloneDefaults(NPCID.MartianSaucer);
            //npc.aiStyle = 0;
            //aiType = NPCID.MartianSaucer;
            //animationType = NPCID.MartianSaucer;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            plays = numPlayers;

            if (Main.expertMode)
            {
                npc.lifeMax = (int)(500000000 + numPlayers * 500000000);
                npc.damage = 500;
                npc.defense = 2000;
            }
            else
            {
                npc.lifeMax = (int)(250000000 + numPlayers * 250000000);
                npc.damage = 250;
                npc.defense = 1000;
            }
        }

        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            if (damage >= 25000000)
            {
                int rand = Main.rand.Next(1, 4);
                if (rand == 1 || rand == 2)
                {
                    Main.NewText("Hahahahha", 126, 25, 27);
                    Main.NewText("No", 126, 25, 27);
                    Main.NewText("No butchering ME!!", 126, 25, 27);
                    Main.NewText("We invented butchering!!!", 126, 25, 27);
                    Main.NewText("Now have a taste of your own medicine!!", 126, 25, 27);
                    // Insta-kill the player
                    Player player = Main.player[npc.target];
                    player.AddBuff(BuffType<The404Curse>(), int.MaxValue);
                    var attack = player.statLife;
                    player.statLife -= attack;
                    player.statLife -= attack;
                    player.statMana -= player.statMana;
                    player.statDefense -= player.statDefense;
                }
                else
                {
                    Main.NewText("Hahahahha!!", 126, 25, 27);
                    Main.NewText("Uno Reverse Card!!", 126, 25, 27);
                    // Deal the amount of damage to the boss, but instead to the player
                    Player player = Main.player[npc.target];
                    player.statLife -= (int)damage;
                    player.statMana -= (int)damage;
                    player.statDefense -= (int)damage;
                }
                damage = 0;
                knockback = 0;
                crit = false;
                return false;
            }
            return true;
		}

        public override bool CheckDead()
        {
            npc.life = 1;
            npc.dontTakeDamage = true;

            Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
            spawn = 1;
            Main.NewText("WHAT??!??", 126, 25, 27);
            Main.NewText("IMPOSSIBLE!!!!", 126, 25, 27);
            Main.NewText("HOW??!??", 126, 25, 27);
            Main.NewText("HOW DID YOU JUST DEFEAT ME?!?!?!?", 126, 25, 27);
            Main.NewText("HOW??!??", 126, 25, 27);

            Player player = Main.player[npc.target];
            if (player.statLife == player.statLifeMax2 || player.statLife == player.statLifeMax2 - 1)
            {
                Main.NewText("WHY??!??", 126, 25, 27);
                Main.NewText("DID YOU REALLY HAVE TO CHEAT TO DEFEAT ME?!?!??!?", 126, 25, 27);
                Main.NewText("NOW YOU MUST DIE!!!!!", 126, 25, 27);
                var attack = player.statLife;
                player.statLife -= attack;
                player.statLife -= attack;
            }

            float timer = 0f;
            while (timer < 10f)
            {
                timer += 0.25f;
            }

            npc.dontTakeDamage = false;
            npc.life = 0;

            return base.CheckDead();
        }

        bool speak = true;
        public override void AI()
        {
            if (npc.life == npc.lifeMax && spawn < 1)
            {
                Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 1;
                if (MoToolsWorld.downedThe404Celestial)
                {
                    Main.NewText("WHAT, YOU AGAIN?", 126, 25, 27);
                    Main.NewText("WHY ARE YOU FIGHTING ME AGAIN???", 126, 25, 27);
                    Main.NewText("HAVEN'T YOU HUMILIATED ME ENOUGH ALREADY?!?!?", 126, 25, 27);
                    Main.NewText("WHY DON'T YOU GO AHEAD AND FIGHT MY BOSS, THE 404 GOD?!?", 126, 25, 27);
                }
                else
                {
                    Main.NewText("YOU MAY HAVE DEFEATED THE ORIGINAL VERSION OF ME, BUT YOU SHALL NOT DEFEAT ME, THE 404 INFUSED VERSION OF THE CELESTIAL LORD!!!!", 126, 25, 27);
                    Main.NewText("PREPARE FOR YOUR LIFE TO END ONCE AND FOR ALL!!!!", 126, 25, 27);
                }
                Main.NewText("NOW SHOW ME THE POWER THAT HAS SAVED TERRARIA AND DEFEATED THE ORIGINAL CELESTIAL LORD!!!!", 126, 25, 27);
            }
            if (npc.life < npc.lifeMax && spawn < 1 && Main.netMode != 1)
            {
                Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 1;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
            }
            if (npc.life < npc.lifeMax * .9 && spawn < 2 && Main.netMode != 1)
            {
                Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 2;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
            }
            if (npc.life < npc.lifeMax * .8 && spawn < 3 && Main.netMode != 1)
            {
                Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 3;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
            }
            if (npc.life < npc.lifeMax * .7 && spawn < 4 && Main.netMode != 1)
            {

                Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 4;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
            }
            if (npc.life < npc.lifeMax * .6 && spawn < 5 && Main.netMode != 1)
            {

                Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 5;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
                //stage3 = false;
                //stage = 2;
                /*npc.position.X = player.position.X;
                npc.position.Y = player.position.Y;*/
            }
            if (npc.life < npc.lifeMax * .5 && spawn < 6 && Main.netMode != 1)
            {

                if (Main.expertMode)
                {
                    npc.velocity *= 3;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());

                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.TheCelestial.TheCelestialClone>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.TheCelestial.TheCelestialClone>());
                }

                Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 6;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
            }
            if (npc.life < npc.lifeMax * .4 && spawn < 7 && Main.netMode != 1)
            {

                if (Main.expertMode)
                {
                    npc.velocity *= 3;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
                }
                Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 7;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
            }
            if (npc.life < npc.lifeMax * .3 && spawn < 8 && Main.netMode != 1)
            {

                if (Main.expertMode)
                {
                    npc.velocity *= 3;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
                }
                Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 8;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
            }
            if (npc.life < npc.lifeMax * .2 && spawn < 9 && Main.netMode != 1)
            {

                if (Main.expertMode)
                {
                    npc.velocity *= 2;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
                }
                Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 9;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
            }
            if (npc.life < npc.lifeMax * .12 && spawn < 10 && Main.netMode != 1)
            {

                if (Main.expertMode)
                {
                    spawn = 10;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
                }
                Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 10;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
            }
            if (npc.life < npc.lifeMax * .02 && spawn < 11 && Main.expertMode && Main.netMode != 1)
            {
                if (Main.expertMode)
                {
    
                    spawn = 11;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
                }
            }

            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            npc.rotation = 0;
            npc.netAlways = true;
            if (npc.life >= npc.lifeMax)
                npc.life = npc.lifeMax;
            if ((npc.target < 0 || npc.target == 255 || player.dead || !player.active) && speak)
            {
                speak = false;
                Main.NewText("HAHAHAHHAHAHAHAHAHAAAA!!!!!", 126, 25, 27);
                Main.NewText("I WIN!!!!!", 126, 25, 27);
                Main.NewText("MWAHAHAHAHAHAHAHAHAHAHAHAAAAAAAAAAAAAAAAAAAA!!!!!", 126, 25, 27);
                npc.TargetClosest(false);
                npc.direction = 1;
                npc.velocity.Y = npc.velocity.Y - 0.1f;
                if (npc.timeLeft > 20)
                {
                    npc.timeLeft = 20;
                    Main.NewText("The 404 Infused Celestial Flies Away To Report To The 404 God...", 150, 250, 150);
                    return;
                }
            }

            if (stunned)
            {
                npc.velocity.X = 0;
                npc.velocity.Y = 0;

                stunnedTimer++;

                if (stunnedTimer >= 100)
                {
                    stunned = false;
                    stunnedTimer = 0;
                }
            }

            ai++;

            npc.ai[0] = (float)ai * 1f;
            int distance = (int)Vector2.Distance(target, npc.Center);
            if ((double)npc.ai[0] < 300)
            {
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[0] >= 300 && (double)npc.ai[0] < 450)
            {
                stunned = true;
                if (Main.expertMode)
                {
                    npc.damage = 250;
                    npc.defense = 1000;
                }
                else
                {
                    npc.damage = 125;
                    npc.defense = 500;
                }
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[0] >= 450)
            {
                stunned = false;
                if (Main.expertMode)
                {
                    npc.damage = 500;
                    npc.defense = 2000;
                }
                else
                {
                    npc.damage = 250;
                    npc.defense = 1000;
                }
                if (!fastSpeed)
                {
                    fastSpeed = true;
                }
                else
                {
                    if ((double)npc.ai[0] % 50 == 0)
                    {
                        float speed = 30f;
                        Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float x = player.position.X + (float)(player.width / 2) - vector.X;
                        float y = player.position.Y + (float)(player.height / 2) - vector.Y;
                        float distance2 = (float)Math.Sqrt(x * x + y * y);
                        float factor = speed / distance2;
                        npc.velocity.X = x * factor;
                        npc.velocity.Y = y * factor;
                    }
                }
                npc.netUpdate = true;
            }
            if ((double)npc.ai[0] % (Main.expertMode ? 100 : 150) == 0 && !stunned && !fastSpeed)
            {
                attackTimer++;
                if (attackTimer <= 2)
                {
                    npc.velocity.X = 0f;
                    npc.velocity.Y = 0f;
                    Vector2 shootPos = npc.Center;
                    float accuracy = 5f * (npc.life / npc.lifeMax);
                    Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
                    shootVel.Normalize();
                    shootVel *= 7.5f;
                    for (int i = 0; i < (Main.expertMode ? 5 : 3); i++)
                    {
                        Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 31), shootPos.Y - (float)Main.rand.Next(-50, 40), shootVel.X, shootVel.Y, mod.ProjectileType("TheCelestialShot"), npc.damage / 3, 5f);
                    }
                }
                else
                {
                    attackTimer = 0;
                }
            }

            if ((double)npc.ai[0] >= 650)
            {
                ai = 0;
                npc.alpha = 0;
                fastSpeed = false;
            }
        }

        void MoveTowards(NPC npc, Vector2 playerTarget, float speed, float turnResistance)
        {
            var move = playerTarget - npc.Center;
            float length = move.Length();
            if (length > speed)
            {
                move *= speed / length;
            }
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            length = move.Length();
            if (length > speed)
            {
                move *= speed / length;
            }
            npc.velocity = move;
        }
/*

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            if (Main.expertMode)
            {
                int debuff = BuffType<Steamy>();
                if (debuff >= 0)
                {
                    player.AddBuff(debuff, 90, true);
                }
            }
        }*/

        public override void NPCLoot()
        {
            if (plays < 1)
                plays = 1;
            //MoToolsPlayer modPlayer = MoToolsPlayer.Get();
            {
                int piller = Main.rand.Next(1, 7);

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<WhiteCelestialShard>(), Main.rand.Next(7, 14));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<YellowCelestialShard>(), Main.rand.Next(7, 14));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<BlackCelestialShard>(), Main.rand.Next(7, 14));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<BlueCelestialShard>(), Main.rand.Next(7, 14));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<PurpleCelestialShard>(), Main.rand.Next(7, 14));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<RainbowCelestialShard>(), Main.rand.Next(7, 14));

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<The404LifeFruit>(), Main.rand.Next(1, 3));

                if (piller == 1)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.LunarTowerSolar);
                }
                else if(piller == 2)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.LunarTowerVortex);
                }
                else if (piller == 3)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.LunarTowerNebula);
                }
                else if (piller == 4)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.LunarTowerStardust);
                }
                else if (piller == 5)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.MoonLordCore);
                }
                else if (piller == 6)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.MartianSaucer);
                    //NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.MartianSaucer);
                    //NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.MartianSaucer);
                }

                /*NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCType<LunarTowerStardust>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCType<LunarTowerNebula>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCType<LunarTowerVortex>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCType<LunarTowerSolar>());

                if (spectraMod != null)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCType<LunarTowerPlanetoid>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCType<LunarTowerNature>());
                }*/

                /*if (exampleMod != null)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), exampleMod.NPCType("PuritySpirit"));
                    //NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), exampleMod.NPCType("LunarTowerNature"));
                }*/
                
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<WhiteCelestialShard>(), Main.rand.Next(15, 30));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<YellowCelestialShard>(), Main.rand.Next(15, 30));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<BlackCelestialShard>(), Main.rand.Next(15, 30));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<BlueCelestialShard>(), Main.rand.Next(15, 30));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<PurpleCelestialShard>(), Main.rand.Next(15, 30));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<RainbowCelestialShard>(), Main.rand.Next(15, 30));

                //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SoulOfThought>(), Main.rand.Next(20, 40));
            }

            if (Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<WhiteCelestialShard>(), Main.rand.Next(30, 60));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<YellowCelestialShard>(), Main.rand.Next(30, 60));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<BlackCelestialShard>(), Main.rand.Next(30, 60));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<BlueCelestialShard>(), Main.rand.Next(30, 60));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<PurpleCelestialShard>(), Main.rand.Next(30, 60));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<RainbowCelestialShard>(), Main.rand.Next(30, 60));

                npc.DropBossBags();
            }
            MoToolsWorld.downedThe404Celestial = true;

        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            //potionType = 499;
            potionType = ItemID.GreaterHealingPotion;
        }
        public override void FindFrame(int frameHeight)
        {
            if(frame == 0)
            {
                counting += 1.0;
                if(counting < 8.0)
                {
                    npc.frame.Y = 0;
                }
                else if(counting < 16.0)
                {
                    npc.frame.Y = frameHeight;
                }
                else if(counting < 24.0)
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if(counting < 32.0)
                {
                    npc.frame.Y = frameHeight * 3;
                }
                else
                {
                    counting = 0.0;
                }
            }
            else if(frame == 1)
            {
                npc.frame.Y = frameHeight * 4;
            }
            else
            {
                npc.frame.Y = frameHeight * 5;
            }
        }


        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Microsoft.Xna.Framework.Color color9 = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
            float num66 = 0f;
            Vector2 vector11 = new Vector2((float)(Main.npcTexture[npc.type].Width / 2), (float)(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (npc.spriteDirection == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Microsoft.Xna.Framework.Rectangle frame6 = npc.frame;
            Microsoft.Xna.Framework.Color alpha15 = npc.GetAlpha(color9);
            float num212 = 1f - (float)npc.life / (float)npc.lifeMax;
            num212 *= num212;
            alpha15.R = (byte)((float)alpha15.R * num212);
            alpha15.G = (byte)((float)alpha15.G * num212);
            alpha15.B = (byte)((float)alpha15.B * num212);
            alpha15.A = (byte)((float)alpha15.A * num212);
            for (int num213 = 0; num213 < 4; num213++)
            {
                Vector2 position9 = npc.position;
                float num214 = Math.Abs(npc.Center.X - Main.player[Main.myPlayer].Center.X);
                float num215 = Math.Abs(npc.Center.Y - Main.player[Main.myPlayer].Center.Y);
                if (num213 == 0 || num213 == 2)
                {
                    position9.X = Main.player[Main.myPlayer].Center.X + num214;
                }
                else
                {
                    position9.X = Main.player[Main.myPlayer].Center.X - num214;
                }
                position9.X -= (float)(npc.width / 2);
                if (num213 == 0 || num213 == 1)
                {
                    position9.Y = Main.player[Main.myPlayer].Center.Y + num215;
                }
                else
                {
                    position9.Y = Main.player[Main.myPlayer].Center.Y - num215;
                }
                position9.Y -= (float)(npc.height / 2);
                Main.spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(position9.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)Main.npcTexture[npc.type].Width * npc.scale / 2f + vector11.X * npc.scale, position9.Y - Main.screenPosition.Y + (float)npc.height - (float)Main.npcTexture[npc.type].Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + vector11.Y * npc.scale + num66 + npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(frame6), alpha15, npc.rotation, vector11, npc.scale, spriteEffects, 0f);
            }
            Main.spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(npc.position.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)Main.npcTexture[npc.type].Width * npc.scale / 2f + vector11.X * npc.scale, npc.position.Y - Main.screenPosition.Y + (float)npc.height - (float)Main.npcTexture[npc.type].Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + vector11.Y * npc.scale + num66 + npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(frame6), npc.GetAlpha(color9), npc.rotation, vector11, npc.scale, spriteEffects, 0f);
            return false;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 0f;
            return null;
        }
        /*
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = Main.rand.Next(139, 143);
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}*/

        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustType<Magma>(), 0f, 0f);
        }
    }
}
