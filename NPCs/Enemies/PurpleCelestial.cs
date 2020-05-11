using MoTools.Items;
using MoTools.Dusts;
using MoTools.Items.Banners;
using MoTools.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.NPCs.Enemies
{
	public class PurpleCelestial : Hover
	{
		public PurpleCelestial() {
			speedY = 1f;
			accelerationY = 0.1f;
		}

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Purple Celestial");
		}

		public override void SetDefaults() {
			npc.lifeMax = 1100;
			npc.damage = 140;
			npc.defense = 100;
			npc.knockBackResist = 0.3f;
			npc.width = 26;
			npc.height = 56;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 15, 0);
			npc.buffImmune[BuffID.Cursed] = true;
			npc.buffImmune[BuffID.Slow] = true;
			npc.buffImmune[BuffID.Darkness] = true;
			banner = npc.type;
			bannerItem = ItemType<PurpleCelestialBanner>();
		}

		public override void CustomBehavior(ref float ai) {
			Player player = Main.player[npc.target];
			ai += 1f;
			if (Math.Abs(npc.Center.X - player.Center.X) < 16f * 30f && Math.Abs(npc.Center.Y - player.Center.Y) < 16f * 20f) {
				if (!player.buffImmune[BuffID.Cursed] && ai >= 120f) {
					ai = -60f;
					npc.netUpdate = true;
				}
				else if (ai >= 180f) {
					ai = -120f;
					if (Main.netMode != 1) {
						int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, ProjectileType<WhiteCelestialLaser>(), npc.damage / 2, 0f, Main.myPlayer, player.Center.X, player.Center.Y);
					}
					npc.netUpdate = true;
				}
			}
			else if (ai > 300f) {
				ai = 300f;
			}
			if (ai < 0f) {
				if (Math.Abs(npc.velocity.X) >= 0.01f) {
					npc.velocity *= 0.95f;
				}
				else {
					npc.velocity.X = 0.01f * npc.direction;
				}
				if (ai == -60f || ai == -120f) {
					Main.PlaySound(SoundID.NPCDeath6, npc.position);
				}
				if (ai == -1f)
				{
					for (int k = 0; k < 255; k++)
					{
						Player target = Main.player[k];
						if (Math.Abs(npc.Center.X - target.Center.X) < 16f * 30f && Math.Abs(npc.Center.Y - target.Center.Y) < 16f * 20f)
						{
							target.AddBuff(BuffID.MagicPower, 240, true);
							target.AddBuff(BuffID.ManaRegeneration, 240, true);
							target.AddBuff(BuffID.Battle, 240, true);
							target.AddBuff(BuffID.Archery, 240, true);
							target.AddBuff(BuffID.Hunter, 240, true);
							target.AddBuff(BuffID.Ironskin, 240, true);
							target.AddBuff(BuffID.Invisibility, 240, true);
							target.AddBuff(BuffID.UnicornMount, 240, true);
							target.AddBuff(BuffID.WeaponImbueVenom, 240, true);
							target.AddBuff(BuffID.WeaponImbueCursedFlames, 240, true);
							target.AddBuff(BuffID.WeaponImbueFire, 240, true);
							target.AddBuff(BuffID.WeaponImbueGold, 240, true);
							target.AddBuff(BuffID.WeaponImbueIchor, 240, true);
							target.AddBuff(BuffID.WeaponImbueNanites, 240, true);
							target.AddBuff(BuffID.WeaponImbueConfetti, 240, true);
							target.AddBuff(BuffID.WeaponImbuePoison, 240, true);
							if (target.FindBuffIndex(BuffID.Cursed) >= 0 || target.FindBuffIndex(BuffID.Slow) >= 0 || target.FindBuffIndex(BuffID.Darkness) >= 0)
							{
							}
						}
					}
				}
				if (ai == -61f) {
					ai = -1f;
				}
			}
		}

		public override bool ShouldMove(float ai) {
			return ai >= 0;
		}

		public override void FindFrame(int frameHeight) {
			npc.frameCounter += 1;
			if (npc.frameCounter >= 30) {
				npc.rotation = Main.rand.Next(-2, 3) * (float)Math.PI / 32f;
				npc.frameCounter = 0;
			}
			npc.spriteDirection = npc.direction;
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), mod.ItemType("PurpleCelestialShard"), Main.rand.Next(15, 18));
			// Drop 10-20 in expert mode, 5-10 in normal mode:
			if (Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("SoulOfHeight"), Main.rand.Next(10, 21));
			}
			else
			{
				Item.NewItem(npc.getRect(), mod.ItemType("SoulOfHeight"), Main.rand.Next(5, 11));
			}
		}

		public override void OnHitPlayer(Player player, int damage, bool crit) {
			if (Main.rand.NextBool(3)) {
				player.AddBuff(BuffID.MagicPower, 240, true);
				player.AddBuff(BuffID.ManaRegeneration, 240, true);
				player.AddBuff(BuffID.Battle, 240, true);
				player.AddBuff(BuffID.Archery, 240, true);
				player.AddBuff(BuffID.Hunter, 240, true);
				player.AddBuff(BuffID.Ironskin, 240, true);
				player.AddBuff(BuffID.Invisibility, 240, true);
				player.AddBuff(BuffID.UnicornMount, 240, true);
				player.AddBuff(BuffID.WeaponImbueVenom, 240, true);
				player.AddBuff(BuffID.WeaponImbueCursedFlames, 240, true);
				player.AddBuff(BuffID.WeaponImbueFire, 240, true);
				player.AddBuff(BuffID.WeaponImbueGold, 240, true);
				player.AddBuff(BuffID.WeaponImbueIchor, 240, true);
				player.AddBuff(BuffID.WeaponImbueNanites, 240, true);
				player.AddBuff(BuffID.WeaponImbueConfetti, 240, true);
				player.AddBuff(BuffID.WeaponImbuePoison, 240, true);
			}
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor) {
			if (npc.ai[3] < 0f && npc.ai[3] >= -60f) {
				float angle = npc.ai[3] / 30f * (float)Math.PI;
				spriteBatch.Draw(mod.GetTexture("NPCs/Seal"), npc.Center - Main.screenPosition + new Vector2(0f, 10f), null, Lighting.GetColor((int)(npc.Center.X / 16f), (int)(npc.Center.Y / 16f)) * 0.9f, angle, new Vector2(16f, 16f), 1f, SpriteEffects.None, 0f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.ZoneSkyHeight && NPC.downedMoonlord)
			{
				return 0f;
			}
			if (SpawnCondition.Sky.Chance > 0f)
			{
				return SpawnCondition.Sky.Chance / 3f;
			}
			return SpawnCondition.Sky.Chance;
		}
	}
}