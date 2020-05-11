using System;
using MoTools.Buffs;
using MoTools.Dusts;
using MoTools.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.NPCs.PaperCut
{
    [AutoloadBossHead]
    public class PaperCutStage3_2 : ModNPC
    {
        public static Random rnd = new Random();
        public int spawn = 0;
        public bool stage2 = false;
        public float vel = 1f;
        public int velMult = 1;
        public static bool on = false;
        public bool poof = false;
        public bool bitherial = true;
        public int plays = 0;
        public int frame = 0;
        public int delay = 0;
        public int fHeight = 10;

        public override void SetStaticDefaults()
        {
            MoToolsVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("Paper Cut");
            Main.npcFrameCount[npc.type] = 8;
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
            npc.width = 400;
            npc.height = 480;
            npc.damage = 75;
            npc.defense = 20;
            npc.aiStyle = 5;
            npc.lifeMax = 145000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            plays = numPlayers;
            bitherial = true;
            npc.lifeMax = 250000 + numPlayers * 250000;
            npc.damage = 115;
        }
        

        public override void AI()
        {
            npc.rotation = 0;

            if (npc.active)
                on = true;
            else
                on = false;
            if (npc.velocity.X > 12) npc.velocity.X = 12;
            if (npc.velocity.Y > 12) npc.velocity.Y = 12;
            if (npc.life < npc.lifeMax && spawn < 1 && Main.netMode != 1)
            {
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 1;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperMimic>());
            }
            if (npc.life < npc.lifeMax * .9 && spawn < 2 && Main.netMode != 1)
            {
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 2;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperMimic>());
            }
            if (npc.life < npc.lifeMax * .8 && spawn < 3 && Main.netMode != 1)
            {
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 3;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperMimic>());
            }
            if (npc.life < npc.lifeMax * .7 && spawn < 4 && Main.netMode != 1)
            {
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 4;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperMimic>());
            }
            if (npc.life < npc.lifeMax * .6 && spawn < 5 && Main.netMode != 1)
            {
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 5;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperMimic>());
            }
            if (npc.life < npc.lifeMax * .5 && spawn < 6 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    npc.velocity *= 3;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperShelly>());
                }

                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 6;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperMimic>());
            }
            if (npc.life < npc.lifeMax * .4 && spawn < 7 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    npc.velocity *= 3;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperShelly>());
                }
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 7;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperMimic>());
            }
            if (npc.life < npc.lifeMax * .3 && spawn < 8 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    npc.velocity *= 3;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperShelly>());
                }
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 8;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperMimic>());
            }
            if (npc.life < npc.lifeMax * .2 && spawn < 9 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    npc.velocity *= 2;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperShelly>());
                }
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 9;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperMimic>());
            }
            if (npc.life < npc.lifeMax * .12 && spawn < 10 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    spawn = 10;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperShelly>());
                }
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 10;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperMimic>());
            }
            if (npc.life < npc.lifeMax * .02 && spawn < 11 && Main.expertMode && Main.netMode != 1)
            {
                if (Main.expertMode)
                {
                    poof = true;
                    spawn = 11;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperSlimer>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCreeper>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperCrawler>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<PaperMimic>());
                }
            }

            if (poof)
            {
                poof = false;

                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
            }

            delay++;
            int phase = 0;
            if (npc.life < npc.lifeMax * .5)
                phase = 1;
            if (delay >= 4)
            {
                delay = 0;
                frame++;
                if (frame > phase * 4 + 3)
                    frame = phase * 4;
            }
            npc.frame.Y = fHeight * frame;
        }


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
        }

        public override void NPCLoot()
        {
            PaperCreeper.despawn = true;
            PaperSlimer.despawn = true;
            PaperShelly.despawn = true;
            PaperMimic.despawn = true;
            PaperCrawler.despawn = true;

            if (plays < 1)
                plays = 1;
            //MoToolsPlayer modPlayer = MoToolsPlayer.Get();
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronBar, 13);
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SteamBar>(), Main.rand.Next(15, 30));
              
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SoulOfThought>(), Main.rand.Next(5, 10));
            }

            MoToolsWorld.downedPaperCut = true;
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<The404Essence>(), 1);

        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 499;
        }
        public override void FindFrame(int frameHeight)
        {

            fHeight= frameHeight;
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
    }
}
