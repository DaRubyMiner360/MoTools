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

namespace MoTools.NPCs.TheCelestial
{
    [AutoloadBossHead]
    public class TheCelestial : ModNPC
    {
        public static Random rnd = new Random();
        public int spawn = 0;
        public static bool stage2 = false;
        public static bool stage3 = false;
        public float vel = 1f;
        public int velMult = 1;
        public static bool on = false;
        public bool poof = false;
        public bool bitherial = true;
        public int plays = 0;
        public int delay = 0;
        public int fHeight = 10;

        // AI
        public int ai;
        public int attackTimer = 0;
        public bool fastSpeed = false;

        public bool stunned = false;
        public int stunnedTimer;

        // Animation
        public int frame = 0;
        public double counting;

        public override void SetStaticDefaults()
        {
            MoToolsVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("The Celestial Lord");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            fHeight = 0;
            delay = 0;
            frame = 0;
            plays = 1;
            bitherial = true;
            poof = false;
            on = true;
            spawn = 0;
            stage2 = false;
            stage3 = false;
            stage = 1;
            npc.width = 64;
            npc.height = 64;
            //npc.aiStyle = 5;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            //npc.noTileCollide = true;
            music = mod.GetSoundSlot(SoundType.Music, "../MoToolsSound/Sounds/Music/TheCelestial");
            bossBag = ModContent.ItemType<TheCelestialTreasureBag>();

            if (Main.expertMode == true)
            {
                //long max = 5000000000;

                //npc.lifeMax = (int)max;
                npc.lifeMax = 500000000;
                npc.damage = 500;
                npc.defense = 300;
            }
            else
            {
                //long max = 2500000000;

                //npc.lifeMax = (int)max;
                npc.lifeMax = 250000000;
                npc.damage = 250;
                npc.defense = 150;
            }

            //npc.CloneDefaults(NPCID.MartianSaucer);
            //npc.aiStyle = 0;
            //aiType = NPCID.MartianSaucer;
            //animationType = NPCID.MartianSaucer;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            plays = numPlayers;

            if (Main.expertMode == true)
            {
                //long max = 5000000000;

                //npc.lifeMax = (int)max + numPlayers * (int)max;
                npc.lifeMax = 500000000 + numPlayers * 500000000;
                npc.damage = 500;
                npc.defense = 300;
            }
            else
            {
                //long max = 2500000000;

                //npc.lifeMax = (int)max + numPlayers * (int)max;
                npc.lifeMax = 250000000 + numPlayers * 250000000;
                npc.damage = 250;
                npc.defense = 150;
            }
        }

        public int stage
        {
            get => (int)npc.ai[0];
            set => npc.ai[0] = value;
        }

        private float moveCool
        {
            get => npc.ai[1];
            set => npc.ai[1] = value;
        }

        private int moveTime = 300;
        private int moveTimer = 60;

        public void Heal()
        {
            if (Main.expertMode == true)
            {
                npc.life += 50000;
            }
            else
            {
                npc.life += 25000;
            }
        }

        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            if (damage >= 25000000)
            {
                int rand = Main.rand.Next(1, 3);
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
                    player.statLife -= player.statLife;
                    player.statMana -= player.statMana;
                    player.statDefense -= player.statDefense;
                    // player.KillMe(PlayerDeathReason.ByNPC, player.statLife, hitDirection);
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

        public override void AI()
        {
            Player player = Main.player[npc.target];

            // Ensures NPC Life is not greater than its max life
            if (npc.life >= npc.lifeMax)
                npc.life = npc.lifeMax;

            // Handles Despawning
            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.direction = 1;
                npc.velocity.Y = npc.velocity.Y - 0.1f;
                if (npc.timeLeft > 20)
                {
                    npc.timeLeft = 20;
                    return;
                }
            }

            while (!player.active || player.dead)
            {
                int shouldHeal = Main.rand.Next(1, 21);
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, 10f);
                    if (npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                    return;
                }
                if (shouldHeal == 1)
                {
                    Heal();
                }
                else if (shouldHeal == 2)
                {
                }
                else if (shouldHeal == 3)
                {
                }
                else if (shouldHeal == 4)
                {
                }
                else if (shouldHeal == 5)
                {
                }
                else if (shouldHeal == 6)
                {
                }
                else if (shouldHeal == 7)
                {
                }
                else if (shouldHeal == 8)
                {
                }
                else if (shouldHeal == 9)
                {
                }
                else if (shouldHeal == 10)
                {
                }
                else if (shouldHeal == 11)
                {
                }
                else if (shouldHeal == 12)
                {
                }
                else if (shouldHeal == 13)
                {
                }
                else if (shouldHeal == 14)
                {
                }
                else if (shouldHeal == 15)
                {
                }
                else if (shouldHeal == 16)
                {
                }
                else if (shouldHeal == 17)
                {
                }
                else if (shouldHeal == 18)
                {
                }
                else if (shouldHeal == 19)
                {
                }
                else if (shouldHeal == 20)
                {
                }
            }

            npc.rotation = 0;

            if (npc.active)
            {
                on = true;
                if (frame == 0)
                {
                    frame = 1;
                }
                if (frame == 1)
                {
                    frame = 0;
                }
            }
            else
            {
                on = false;
            }
            //if (npc.velocity.X > 12) npc.velocity.X = 12;
            //if (npc.velocity.Y > 12) npc.velocity.Y = 12;
            if (npc.life == npc.lifeMax && spawn < 1 && Main.netMode != 1)
            {
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 1;
                if (MoToolsWorld.downedTheCelestial)
                {
                    Main.NewText("What, you again?", 150, 250, 150);
                    Main.NewText("Why are you fighting me again???", 150, 250, 150);
                    Main.NewText("Why don't you fight my 404 infused brother?!?", 150, 250, 150);
                }
                else
                {
                    Main.NewText("I have awoken!!", 150, 250, 150);
                    Main.NewText("Prepare for your life to end!!", 150, 250, 150);
                }
                Main.NewText("Show me the power that has saved Terraria!", 150, 250, 150);

                stage = 1;
                stage2 = false;
                stage3 = false;
            }
            if (npc.life < npc.lifeMax && spawn < 1 && Main.netMode != 1)
            {
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
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
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
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
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
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
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
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
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 5;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
                stage2 = true;
                //stage3 = false;
                //stage = 2;
                /*npc.position.X = player.position.X;
                npc.position.Y = player.position.Y;*/
            }
            if (npc.life < npc.lifeMax * .5 && spawn < 6 && Main.netMode != 1)
            {
                poof = true;
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

                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
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
                poof = true;
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
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
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
                poof = true;
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
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
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
                poof = true;
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
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
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
                poof = true;
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
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
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
                    poof = true;
                    spawn = 11;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
                }
            }
            /*while (stage2 && !stage3)
            {
                int celestial = Main.rand.Next(1, 7);

                if (celestial == 1)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.WhiteCelestial>());
                }
                else if (celestial == 2)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.YellowCelestial>());
                }
                else if (celestial == 3)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlackCelestial>());
                }
                else if (celestial == 4)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.BlueCelestial>());
                }
                else if (celestial == 5)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Enemies.PurpleCelestial>());
                }
                else if (celestial == 6)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<NPCs.Critters.RainbowCelestialNPC>());
                }
            }*/
            bool trigger = false;
            if(npc.life < npc.lifeMax * .6 && spawn < 5 && Main.netMode != 1)
                trigger = true;
            while (/*stage2 && !stage3*/trigger)
            {
                // Gets the Player and Target Vector
                npc.TargetClosest(true);
                Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
                // Ensures that the NPC is not rotated
                npc.rotation = 0.0f;
                npc.netAlways = true;
                npc.TargetClosest(true);
                // Stunned
                if (stunned)
                {
                    // Ensure that the NPC cannot move
                    npc.velocity.X = 0.0f;
                    npc.velocity.Y = 0.0f;
                    // Incremement the timer
                    stunnedTimer++;
                    // No longer stunned and timer reset
                    if (stunnedTimer >= 100)
                    {
                        stunned = false;
                        stunnedTimer = 0;
                    }
                }
                // Increment AI
                ai++;
                // Movement
                npc.ai[0] = (float)ai * 1f;
                int distance = (int)Vector2.Distance(target, npc.Center);
                if ((double)npc.ai[0] < 300)
                {
                    frame = 0;
                    MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                    npc.netUpdate = true;
                }
                else if ((double)npc.ai[0] >= 300 && (double)npc.ai[0] < 450.0)
                {
                    stunned = true;
                    frame = 1;
                    if (Main.expertMode == true)
                    {
                        npc.defense = 600;
                        npc.damage = 125;
                    }
                    else
                    {
                        npc.defense = 300;
                        npc.damage = 63;
                    }
                    MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                    npc.netUpdate = true;
                }
                else if ((double)npc.ai[0] >= 450.0)
                {
                    //frame = 2;
                    frame = 0;
                    stunned = false;
                    if (Main.expertMode == true)
                    {
                        npc.damage = 500;
                        npc.defense = 300;
                    }
                    else
                    {
                        npc.damage = 250;
                        npc.defense = 150;
                    }
                    if (!fastSpeed)
                    {
                        fastSpeed = true;
                    }
                    else
                    {
                        if ((double)npc.ai[0] % 50 == 0)
                        {
                            float speed = 12f;
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
                // Attack
                if((double)npc.ai[0] % (Main.expertMode ? 100 : 150) == 0 && !stunned && !fastSpeed)
                {
                    attackTimer++;
                    if(attackTimer <= 2)
                    {
                        frame = 0;
                        npc.velocity.X = 0f;
                        npc.velocity.Y = 0f;
                        Vector2 shootPos = npc.Center;
                        float accuracy = 5f * (npc.life / npc.lifeMax);
                        Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
                        shootVel.Normalize();
                        shootVel *= 7.5f;
                        for(int i = 0; i < (Main.expertMode ? 5 : 3); i++)
                        {
                            Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), shootPos.Y - (float)Main.rand.Next(-50, 40), shootVel.X, shootVel.Y, mod.ProjectileType("CelestialLaser"), npc.damage / 3, 5f);
                        }
                    }
                    else
                    {
                        attackTimer = 0;
                    }
                }



                if((double)npc.ai[0] >= 650.0)
                {
                    ai = 0;
                    npc.alpha = 0;
                    //npc.ai[2] = 0;
                    fastSpeed = false;
                }
            }

            if (npc.life < npc.lifeMax * .333 && spawn < 2 && Main.netMode != 1 && stage == 2)
            {
                stage2 = false;
                stage3 = false;
                //stage = 3;
                npc.position.X = player.position.X;
                npc.position.Y = player.position.Y;
            }

            while ((stage == 3) || (!stage2 && stage3))
            {
                // Gets the Player and Target Vector
                npc.TargetClosest(true);
                Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
                // Ensures that the NPC is not rotated
                npc.rotation = 0.0f;
                npc.netAlways = true;
                npc.TargetClosest(true);
                // Stunned
                if (stunned)
                {
                    // Ensure that the NPC cannot move
                    npc.velocity.X = 0.0f;
                    npc.velocity.Y = 0.0f;
                    // Incremement the timer
                    stunnedTimer++;
                    // No longer stunned and timer reset
                    if (stunnedTimer >= 100000)
                    {
                        stunned = false;
                        stunnedTimer = 0;
                    }
                }
                // Increment AI
                ai++;
                // Movement
                npc.ai[0] = (float)ai * 1f;
                int distance = (int)Vector2.Distance(target, npc.Center);
                if ((double)npc.ai[0] < 300)
                {
                    frame = 0;
                    MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                    npc.netUpdate = true;
                }
                else if ((double)npc.ai[0] >= 300 && (double)npc.ai[0] < 450.0)
                {
                    stunned = true;
                    frame = 1;
                    if (Main.expertMode == true)
                    {
                        npc.defense = 600;
                        npc.damage = 125;
                    }
                    else
                    {
                        npc.defense = 300;
                        npc.damage = 63;
                    }
                    MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                    npc.netUpdate = true;
                }
                else if ((double)npc.ai[0] >= 450.0)
                {
                    //frame = 2;
                    frame = 0;
                    stunned = false;
                    if (Main.expertMode == true)
                    {
                        npc.damage = 500;
                        npc.defense = 300;
                    }
                    else
                    {
                        npc.damage = 250;
                        npc.defense = 150;
                    }
                    if (!fastSpeed)
                    {
                        fastSpeed = true;
                    }
                    else
                    {
                        if ((double)npc.ai[0] % 50 == 0)
                        {
                            float speed = 12f;
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
                // Attack
                if ((double)npc.ai[0] % (Main.expertMode ? 100 : 150) == 0 && !stunned && !fastSpeed)
                {
                    attackTimer++;
                    if (attackTimer <= 2)
                    {
                        frame = 0;
                        npc.velocity.X = 0f;
                        npc.velocity.Y = 0f;
                        Vector2 shootPos = npc.Center;
                        float accuracy = 5f * (npc.life / npc.lifeMax);
                        Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
                        shootVel.Normalize();
                        shootVel *= 7.5f;
                        for (int i = 0; i < (Main.expertMode ? 5 : 3); i++)
                        {
                            //Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), shootPos.Y - (float)Main.rand.Next(-50, 40), shootVel.X, shootVel.Y, mod.ProjectileType("CelestialLaser"), npc.damage / 3, 5f);
                        }
                    }
                    else
                    {
                        attackTimer = 0;
                    }
                }



                if ((double)npc.ai[0] >= 650.0)
                {
                    ai = 0;
                    npc.alpha = 0;
                    //npc.ai[2] = 0;
                    fastSpeed = false;
                }
            }

            if (poof)
            {
                poof = false;

                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Magma>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Magma>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Magma>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Magma>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Magma>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Magma>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Magma>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Magma>(), 0f, 0f);
            }

            /*delay++;
            if (delay >= 4)
            {
                delay = 0;
                frame++;
                //if (frame > phase * 2 + 3)
                    frame = stage * 2;
            }
            npc.frame.Y = fHeight * frame;*/
        }
/*

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            if (Main.expertMode)
            {
                int debuff = ModContent.BuffType<Steamy>();
                if (debuff >= 0)
                {
                    player.AddBuff(debuff, 90, true);
                }
            }
        }*/

        public override void NPCLoot()
        {
            /*MechanicalCreeper.despawn = true;
            MechanicalSlimer.despawn = true;
            MechanicalShelly.despawn = true;
            MechanicalMimic.despawn = true;
            MechanicalCrawler.despawn = true;*/

            if (plays < 1)
                plays = 1;
            //MoToolsPlayer modPlayer = MoToolsPlayer.Get();
            {
                //Mod spectraMod = ModLoader.GetMod("SpectraMod");
                Mod exampleMod = ModLoader.GetMod("MoTools");

                int piller = Main.rand.Next(1, 7);

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WhiteCelestialShard>(), Main.rand.Next(7, 14));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<YellowCelestialShard>(), Main.rand.Next(7, 14));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BlackCelestialShard>(), Main.rand.Next(7, 14));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BlueCelestialShard>(), Main.rand.Next(7, 14));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PurpleCelestialShard>(), Main.rand.Next(7, 14));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RainbowCelestialShard>(), Main.rand.Next(7, 14));

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<The404LifeFruit>(), Main.rand.Next(1, 3));

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

                /*NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<LunarTowerStardust>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<LunarTowerNebula>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<LunarTowerVortex>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<LunarTowerSolar>());

                if (spectraMod != null)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<LunarTowerPlanetoid>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<LunarTowerNature>());
                }*/

                /*if (exampleMod != null)
                {
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), exampleMod.NPCType("PuritySpirit"));
                    //NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), exampleMod.NPCType("LunarTowerNature"));
                }*/
                
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WhiteCelestialShard>(), Main.rand.Next(15, 30));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<YellowCelestialShard>(), Main.rand.Next(15, 30));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BlackCelestialShard>(), Main.rand.Next(15, 30));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BlueCelestialShard>(), Main.rand.Next(15, 30));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PurpleCelestialShard>(), Main.rand.Next(15, 30));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RainbowCelestialShard>(), Main.rand.Next(15, 30));

                //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SoulOfThought>(), Main.rand.Next(20, 40));
            }

            if (Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WhiteCelestialShard>(), Main.rand.Next(30, 60));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<YellowCelestialShard>(), Main.rand.Next(30, 60));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BlackCelestialShard>(), Main.rand.Next(30, 60));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BlueCelestialShard>(), Main.rand.Next(30, 60));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PurpleCelestialShard>(), Main.rand.Next(30, 60));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RainbowCelestialShard>(), Main.rand.Next(30, 60));

                npc.DropBossBags();
            }
            MoToolsWorld.downedTheCelestial = true;

        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            //potionType = 499;
            potionType = ItemID.GreaterHealingPotion;
        }
        public override void FindFrame(int frameHeight)
        {
            //fHeight= frameHeight;
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

        private void MoveTowards(NPC npc, Vector2 playerTarget, float speed, float turnResistance)
        {
            var move = playerTarget - npc.Center;
            float length = move.Length();
            if(length > speed)
            {
                move *= speed / length;
            }
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            length = move.Length();
            if(length > speed)
            {
                move *= speed / length;
            }
            npc.velocity = move;
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
            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Magma>(), 0f, 0f);
        }
    }
}
