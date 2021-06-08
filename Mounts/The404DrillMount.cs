using MoTools.Buffs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using static Terraria.Mount;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MoTools.Mounts
{
	internal class DrillBeam
	{
		public Point16 curTileTarget;

		public int cooldown;

		public DrillBeam()
		{
			this.curTileTarget = Point16.NegativeOne;
			this.cooldown = 0;
		}
	}

	internal class DrillMountData
	{
		public float diodeRotationTarget;

		public float diodeRotation;

		public float outerRingRotation;

		public DrillBeam[] beams;

		public int beamCooldown;

		public Vector2 crosshairPosition;

		public DrillMountData()
		{
			this.beams = new DrillBeam[4];
			for (int i = 0; i < this.beams.Length; i++)
			{
				this.beams[i] = new DrillBeam();
			}
		}
	}

	public class The404DrillMount : ModMountData
    {
		public static Vector2 drillDiodePoint1 = new Vector2(36f, -6f);

		public static Vector2 drillDiodePoint2 = new Vector2(36f, 8f);

		public static Vector2 drillTextureSize;

		public const int drillTextureWidth = 80;

		public const float drillRotationChange = 0.05235988f;

		public static int drillPickPower = 999;

		public static int drillPickTime = 2;

		public static int drillBeamCooldownMax = 0;

		public const float maxDrillLength = 999f;

		public object _mountSpecificData;

		public int _type;

		public bool _abilityActive;

		public int _frameState;

		public int _flyTime;

		public float _fatigue;

		public float _fatigueMax;

		public MountData _data;

		public int _frame;

		public int _idleTime;

		public int _idleTimeNext;

		public int xOffset;

		public int yOffset;

		public bool _active;

		public int _frameExtra;

		public float _frameExtraCounter;

		public int _abilityCharge;

		public bool _flipDraw;

		public int XOffset
		{
			get
			{
				return this._data.xOffset;
			}
		}

		public int YOffset
		{
			get
			{
				return this._data.yOffset;
			}
		}

		public int PlayerOffset
		{
			get
			{
				if (!this._active)
				{
					return 0;
				}
				return this._data.playerYOffsets[this._frame];
			}
		}

		public bool Cart
		{
			get
			{
				if (this._data != null && this._active)
				{
					return this._data.Minecart;
				}
				return false;
			}
		}

		public bool Directional
		{
			get
			{
				if (this._data == null)
				{
					return true;
				}
				return this._data.MinecartDirectional;
			}
		}

		public Vector2 Origin
		{
			get
			{
				return new Vector2((float)this._data.textureWidth / 2f, (float)this._data.textureHeight / (2f * (float)this._data.totalFrames));
			}
		}

		public override void SetDefaults()
        {
			int[] array = new int[mountData.totalFrames];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 30;
			}
			//array[1] += 2;
			//array[11] += 2;
			mountData.buff = BuffType<Buffs.The404DrillMount>();
			//mountData.buff = BuffID.DrillMount;
			mountData.spawnDust = 226;
			mountData.heightBoost = 16;
			mountData.flightTimeMax = 320;
			mountData.fatigueMax = 320;
			mountData.fallDamage = 1f;
			mountData.usesHover = true;
			mountData.swimSpeed = 4f;
			mountData.runSpeed = 20f;
			mountData.dashSpeed = 20f;
			mountData.acceleration = 2f;
			mountData.jumpHeight = 10;
			mountData.jumpSpeed = 20f;
			mountData.blockExtraJumps = true;
			mountData.emitsLight = true;
			mountData.lightColor = new Vector3(0.3f, 0.3f, 0.4f);
			mountData.totalFrames = 1;
			array = new int[mountData.totalFrames];
			/*for (int num3 = 0; num3 < array.Length; num3++)
			{
				array[num3] = 4;
			}*/
			mountData.playerYOffsets = array;
			mountData.xOffset = 1;
			mountData.bodyFrame = 3;
			mountData.yOffset = 4;
			mountData.playerHeadOffset = 18;
			mountData.standingFrameCount = 1;
			mountData.standingFrameDelay = 12;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 1;
			mountData.runningFrameDelay = 12;
			mountData.runningFrameStart = 0;
			mountData.flyingFrameCount = 1;
			mountData.flyingFrameDelay = 12;
			mountData.flyingFrameStart = 0;
			mountData.inAirFrameCount = 1;
			mountData.inAirFrameDelay = 12;
			mountData.inAirFrameStart = 0;
			mountData.idleFrameCount = 0;
			mountData.idleFrameDelay = 12;
			mountData.idleFrameStart = 8;
			mountData.swimFrameCount = 0;
			mountData.swimFrameDelay = 12;
			mountData.swimFrameStart = 0;
			if (Main.netMode != 2)
			{
				mountData.backTexture = Main.drillMountTexture[0];
				mountData.backTextureGlow = Main.drillMountTexture[3];
				mountData.backTextureExtra = null;
				mountData.backTextureExtraGlow = null;
				mountData.frontTexture = Main.drillMountTexture[1];
				mountData.frontTextureGlow = Main.drillMountTexture[4];
				mountData.frontTextureExtra = Main.drillMountTexture[2];
				mountData.frontTextureExtraGlow = Main.drillMountTexture[5];
				mountData.textureWidth = mountData.frontTexture.Width;
				mountData.textureHeight = mountData.frontTexture.Height;
			}
			drillTextureSize = new Vector2(80f, 80f);
			Vector2 value = new Vector2((float)mountData.textureWidth, (float)(mountData.textureHeight / mountData.totalFrames));
			/*if (Mount.drillTextureSize != value)
			{
				throw new Exception("Be sure to update the Drill texture origin to match the actual texture size of " + mountData.textureWidth.ToString() + ", " + mountData.textureHeight.ToString() + ".");
			}*/
		}

		public void UpdateDrill(Player mountedPlayer, bool controlUp, bool controlDown)
		{
			DrillMountData drillMountData = (DrillMountData)this._mountSpecificData;
			for (int i = 0; i < drillMountData.beams.Length; i++)
			{
				DrillBeam drillBeam = drillMountData.beams[i];
				if (drillBeam.cooldown > 1)
				{
					drillBeam.cooldown--;
				}
				else if (drillBeam.cooldown == 1)
				{
					drillBeam.cooldown = 0;
					drillBeam.curTileTarget = Point16.NegativeOne;
				}
			}
			drillMountData.diodeRotation = drillMountData.diodeRotation * 0.85f + 0.15f * drillMountData.diodeRotationTarget;
			if (drillMountData.beamCooldown > 0)
			{
				drillMountData.beamCooldown--;
			}
		}

		public void UseDrill(Player mountedPlayer)
		{
			if (this._type == 8 && this._abilityActive)
			{
				DrillMountData drillMountData = (DrillMountData)this._mountSpecificData;
				if (drillMountData.beamCooldown == 0)
				{
					for (int i = 0; i < drillMountData.beams.Length; i++)
					{
						DrillBeam drillBeam = drillMountData.beams[i];
						if (drillBeam.cooldown == 0)
						{
							Point16 point = this.DrillSmartCursor(mountedPlayer, drillMountData);
							if (point != Point16.NegativeOne)
							{
								drillBeam.curTileTarget = point;
								int pickPower = drillPickPower;
								bool flag = mountedPlayer.whoAmI == Main.myPlayer;
								if (flag)
								{
									bool flag2 = true;
									if (WorldGen.InWorld(point.X, point.Y, 0) && Main.tile[point.X, point.Y] != null && Main.tile[point.X, point.Y].type == 26 && !Main.hardMode)
									{
										flag2 = false;
										mountedPlayer.Hurt(PlayerDeathReason.ByOther(4), mountedPlayer.statLife / 2, -mountedPlayer.direction, false, false, false, -1);
									}
									if (mountedPlayer.noBuilding)
									{
										flag2 = false;
									}
									if (flag2)
									{
										mountedPlayer.PickTile(point.X, point.Y, pickPower);
									}
								}
								Vector2 vector = new Vector2((float)(point.X << 4) + 8f, (float)(point.Y << 4) + 8f);
								float num = (vector - mountedPlayer.Center).ToRotation();
								for (int j = 0; j < 2; j++)
								{
									float num2 = num + ((Main.rand.Next(2) == 1) ? -1f : 1f) * 1.57079637f;
									float num3 = (float)Main.rand.NextDouble() * 2f + 2f;
									Vector2 vector2 = new Vector2((float)Math.Cos((double)num2) * num3, (float)Math.Sin((double)num2) * num3);
									int num4 = Dust.NewDust(vector, 0, 0, 230, vector2.X, vector2.Y, 0, default(Color), 1f);
									Main.dust[num4].noGravity = true;
									Main.dust[num4].customData = mountedPlayer;
								}
								if (flag)
								{
									Tile.SmoothSlope(point.X, point.Y, true);
								}
								drillBeam.cooldown = drillPickTime;
							}
							break;
						}
					}
					drillMountData.beamCooldown = drillBeamCooldownMax;
				}
			}
		}

		private Point16 DrillSmartCursor(Player mountedPlayer, DrillMountData data)
		{
			Vector2 value = (mountedPlayer.whoAmI != Main.myPlayer) ? data.crosshairPosition : (Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY));
			Vector2 center = mountedPlayer.Center;
			Vector2 value2 = value - center;
			float num = value2.Length();
			if (num > 224f)
			{
				num = 224f;
			}
			num += 32f;
			value2.Normalize();
			Vector2 end = center + value2 * num;
			Point16 tilePoint = new Point16(-1, -1);
			if (!Utils.PlotTileLine(center, end, 65.6f, delegate (int x, int y)
			{
				tilePoint = new Point16(x, y);
				for (int i = 0; i < data.beams.Length; i++)
				{
					if (data.beams[i].curTileTarget == tilePoint)
					{
						return true;
					}
				}
				if (!WorldGen.CanKillTile(x, y))
				{
					return true;
				}
				if (Main.tile[x, y] != null && !Main.tile[x, y].inActive() && Main.tile[x, y].active())
				{
					return false;
				}
				return true;
			}))
			{
				return tilePoint;
			}
			return new Point16(-1, -1);
		}

		public void UseAbility(Player mountedPlayer, Vector2 mousePosition, bool toggleOn)
		{
			switch (this._type)
			{
				case 8:
					if (Main.myPlayer == mountedPlayer.whoAmI)
					{
						if (!toggleOn)
						{
							this._abilityActive = false;
						}
						else if (!this._abilityActive)
						{
							if (mountedPlayer.whoAmI == Main.myPlayer)
							{
								float num = Main.screenPosition.X + (float)Main.mouseX;
								float num2 = Main.screenPosition.Y + (float)Main.mouseY;
								float ai = num - mountedPlayer.position.X;
								float ai2 = num2 - mountedPlayer.position.Y;
								Projectile.NewProjectile(num, num2, 0f, 0f, 453, 0, 0f, mountedPlayer.whoAmI, ai, ai2);
							}
							this._abilityActive = true;
						}
					}
					else
					{
						this._abilityActive = toggleOn;
					}
					break;
			}
		}

		public bool Hover(Player mountedPlayer)
		{
			if (this._frameState == 2 || this._frameState == 4)
			{
				bool flag = true;
				float num = 1f;
				float num2 = mountedPlayer.gravity / Player.defaultGravity;
				if (mountedPlayer.slowFall)
				{
					num2 /= 3f;
				}
				if (num2 < 0.25f)
				{
					num2 = 0.25f;
				}
				if (this._type != 7 && this._type != 8 && this._type != 12)
				{
					if (this._flyTime > 0)
					{
						this._flyTime--;
					}
					else if (this._fatigue < this._fatigueMax)
					{
						this._fatigue += num2;
					}
					else
					{
						flag = false;
					}
				}
				if (this._type == 12 && !mountedPlayer.MountFishronSpecial)
				{
					num = 0.5f;
				}
				float num3 = this._fatigue / this._fatigueMax;
				if (this._type == 7 || this._type == 8 || this._type == 12)
				{
					num3 = 0f;
				}
				float num4 = 4f * num3;
				float num5 = 4f * num3;
				if (num4 == 0f)
				{
					num4 = -0.001f;
				}
				if (num5 == 0f)
				{
					num5 = -0.001f;
				}
				float num6 = mountedPlayer.velocity.Y;
				if ((mountedPlayer.controlUp || mountedPlayer.controlJump) & flag)
				{
					num4 = -2f - 6f * (1f - num3);
					num6 -= this._data.acceleration * num;
				}
				else if (mountedPlayer.controlDown)
				{
					num6 += this._data.acceleration * num;
					num5 = 8f;
				}
				else
				{
					int jump = mountedPlayer.jump;
				}
				if (num6 < num4)
				{
					num6 = ((!(num4 - num6 < this._data.acceleration)) ? (num6 + this._data.acceleration * num) : num4);
				}
				else if (num6 > num5)
				{
					num6 = ((!(num6 - num5 < this._data.acceleration)) ? (num6 - this._data.acceleration * num) : num5);
				}
				mountedPlayer.velocity.Y = num6;
				mountedPlayer.fallStart = (int)(mountedPlayer.position.Y / 16f);
			}
			else if (this._type != 7 && this._type != 8 && this._type != 12)
			{
				mountedPlayer.velocity.Y += mountedPlayer.gravity * mountedPlayer.gravDir;
			}
			else if (mountedPlayer.velocity.Y == 0f)
			{
				mountedPlayer.velocity.Y = 0.001f;
			}
			if (this._type == 7)
			{
				float num7 = mountedPlayer.velocity.X / this._data.dashSpeed;
				if ((double)num7 > 0.95)
				{
					num7 = 0.95f;
				}
				if ((double)num7 < -0.95)
				{
					num7 = -0.95f;
				}
				float fullRotation = 0.7853982f * num7 / 2f;
				float num8 = Math.Abs(2f - (float)this._frame / 2f) / 2f;
				Lighting.AddLight((int)(mountedPlayer.position.X + (float)(mountedPlayer.width / 2)) / 16, (int)(mountedPlayer.position.Y + (float)(mountedPlayer.height / 2)) / 16, 0.4f, 0.2f * num8, 0f);
				mountedPlayer.fullRotation = fullRotation;
			}
			else if (this._type == 8)
			{
				float num9 = mountedPlayer.velocity.X / this._data.dashSpeed;
				if ((double)num9 > 0.95)
				{
					num9 = 0.95f;
				}
				if ((double)num9 < -0.95)
				{
					num9 = -0.95f;
				}
				mountedPlayer.fullRotation = 0.7853982f * num9 / 2f;
				DrillMountData obj = (DrillMountData)this._mountSpecificData;
				float outerRingRotation = obj.outerRingRotation;
				outerRingRotation += mountedPlayer.velocity.X / 80f;
				if (outerRingRotation > 3.14159274f)
				{
					outerRingRotation -= 6.28318548f;
				}
				else if (outerRingRotation < -3.14159274f)
				{
					outerRingRotation += 6.28318548f;
				}
				obj.outerRingRotation = outerRingRotation;
			}
			return true;
		}

		private Vector2 ClampToDeadZone(Player mountedPlayer, Vector2 position)
		{
			int num;
			int num2;
			switch (this._type)
			{
				case 8:
					num = (int)drillTextureSize.Y;
					num2 = (int)drillTextureSize.X;
					break;
				default:
					return position;
			}
			Vector2 center = mountedPlayer.Center;
			position -= center;
			if (position.X > (float)(-num2) && position.X < (float)num2 && position.Y > (float)(-num) && position.Y < (float)num)
			{
				float num3 = (float)num2 / Math.Abs(position.X);
				float num4 = (float)num / Math.Abs(position.Y);
				position = ((!(num3 > num4)) ? (position * num3) : (position * num4));
			}
			return position + center;
		}

		public void Draw(List<DrawData> playerDrawData, int drawType, Player drawPlayer, Vector2 Position, Color drawColor, SpriteEffects playerEffect, float shadow)
		{
			if (playerDrawData != null)
			{
				Texture2D texture2D;
				Texture2D texture2D2;
				switch (drawType)
				{
					case 0:
						texture2D = this._data.backTexture;
						texture2D2 = this._data.backTextureGlow;
						break;
					case 1:
						texture2D = this._data.backTextureExtra;
						texture2D2 = this._data.backTextureExtraGlow;
						break;
					case 2:
						if (this._type == 0 && this._idleTime >= this._idleTimeNext)
						{
							return;
						}
						texture2D = this._data.frontTexture;
						texture2D2 = this._data.frontTextureGlow;
						break;
					case 3:
						texture2D = this._data.frontTextureExtra;
						texture2D2 = this._data.frontTextureExtraGlow;
						break;
					default:
						texture2D = null;
						texture2D2 = null;
						break;
				}
				if (texture2D != null)
				{
					int type = this._type;
					if ((type == 0 || type == 9) && drawType == 3 && shadow != 0f)
					{
						return;
					}
					int num = this.XOffset;
					int num2 = this.YOffset + this.PlayerOffset;
					if (drawPlayer.direction <= 0 && (!this.Cart || !this.Directional))
					{
						num *= -1;
					}
					Position.X = (float)(int)(Position.X - Main.screenPosition.X + (float)(drawPlayer.width / 2) + (float)num);
					Position.Y = (float)(int)(Position.Y - Main.screenPosition.Y + (float)(drawPlayer.height / 2) + (float)num2);
					int num3 = 0;
					bool flag = false;
					switch (this._type)
					{
						case 9:
							flag = true;
							switch (drawType)
							{
								case 0:
									num3 = this._frame;
									break;
								case 2:
									num3 = this._frameExtra;
									break;
								case 3:
									num3 = this._frameExtra;
									break;
								default:
									num3 = 0;
									break;
							}
							break;
						case 5:
							switch (drawType)
							{
								case 0:
									num3 = this._frame;
									break;
								case 1:
									num3 = this._frameExtra;
									break;
								default:
									num3 = 0;
									break;
							}
							break;
						default:
							num3 = this._frame;
							break;
					}
					int num4 = this._data.textureHeight / this._data.totalFrames;
					Rectangle value = new Rectangle(0, num4 * num3, this._data.textureWidth, num4);
					if (flag)
					{
						value.Height -= 2;
					}
					switch (this._type)
					{
						case 0:
							if (drawType == 3)
							{
								drawColor = Color.White;
							}
							break;
						case 9:
							if (drawType != 3)
							{
								break;
							}
							if (this._abilityCharge != 0)
							{
								drawColor = Color.Multiply(Color.White, (float)this._abilityCharge / (float)this._data.abilityChargeMax);
								drawColor.A = 0;
								break;
							}
							return;
						case 7:
							if (drawType == 3)
							{
								drawColor = new Color(250, 250, 250, 255) * drawPlayer.stealth * (1f - shadow);
							}
							break;
					}
					Color color = new Color(drawColor.ToVector4() * 0.25f + new Vector4(0.75f));
					switch (this._type)
					{
						case 11:
							if (drawType == 2)
							{
								color = Color.White;
								color.A = 127;
							}
							break;
						case 12:
							if (drawType == 0)
							{
								float scale = MathHelper.Clamp(drawPlayer.MountFishronSpecialCounter / 60f, 0f, 1f);
								color = Colors.CurrentLiquidColor;
								if (color == Color.Transparent)
								{
									color = Color.White;
								}
								color.A = 127;
								color *= scale;
							}
							break;
					}
					float num5 = 0f;
					switch (this._type)
					{
						case 8:
							{
								DrillMountData drillMountData = (DrillMountData)this._mountSpecificData;
								switch (drawType)
								{
									case 0:
										num5 = drillMountData.outerRingRotation - num5;
										break;
									case 3:
										num5 = drillMountData.diodeRotation - num5 - drawPlayer.fullRotation;
										break;
								}
								break;
							}
						case 7:
							num5 = drawPlayer.fullRotation;
							break;
					}
					Vector2 origin = this.Origin;
					type = this._type;
					float scale2 = 1f;
					SpriteEffects effect;
					switch (this._type)
					{
						case 7:
							effect = SpriteEffects.None;
							break;
						case 8:
							effect = (SpriteEffects)((drawPlayer.direction == 1 && drawType == 2) ? 1 : 0);
							break;
						case 6:
						case 13:
							effect = (SpriteEffects)(this._flipDraw ? 1 : 0);
							break;
						case 11:
							effect = ((Math.Sign(drawPlayer.velocity.X) == -drawPlayer.direction) ? (playerEffect ^ SpriteEffects.FlipHorizontally) : playerEffect);
							break;
						default:
							effect = playerEffect;
							break;
					}
					type = this._type;
					DrawData item;
					if (MountLoader.Draw(new Mount(), playerDrawData, drawType, drawPlayer, ref texture2D, ref texture2D2, ref Position, ref value, ref drawColor, ref color, ref num5, ref effect, ref origin, ref scale2, shadow))
					{
						item = new DrawData(texture2D, Position, value, drawColor, num5, origin, scale2, effect, 0);
						item.shader = Mount.currentShader;
						playerDrawData.Add(item);
						if (texture2D2 != null)
						{
							item = new DrawData(texture2D2, Position, value, color * ((float)(int)drawColor.A / 255f), num5, origin, scale2, effect, 0);
							item.shader = Mount.currentShader;
						}
						playerDrawData.Add(item);
					}
					type = this._type;
					if (type == 8 && drawType == 3)
					{
						DrillMountData drillMountData2 = (DrillMountData)this._mountSpecificData;
						Rectangle value2 = new Rectangle(0, 0, 1, 1);
						Vector2 vector = Mount.drillDiodePoint1.RotatedBy((double)drillMountData2.diodeRotation, default(Vector2));
						Vector2 vector2 = Mount.drillDiodePoint2.RotatedBy((double)drillMountData2.diodeRotation, default(Vector2));
						for (int i = 0; i < drillMountData2.beams.Length; i++)
						{
							DrillBeam drillBeam = drillMountData2.beams[i];
							if (!(drillBeam.curTileTarget == Point16.NegativeOne))
							{
								for (int j = 0; j < 2; j++)
								{
									Vector2 value3 = new Vector2((float)(drillBeam.curTileTarget.X * 16 + 8), (float)(drillBeam.curTileTarget.Y * 16 + 8)) - Main.screenPosition - Position;
									Vector2 vector3;
									Color color2;
									if (j == 0)
									{
										vector3 = vector;
										color2 = Color.CornflowerBlue;
									}
									else
									{
										vector3 = vector2;
										color2 = Color.LightGreen;
									}
									color2.A = 128;
									color2 *= 0.5f;
									Vector2 v = value3 - vector3;
									float num6 = v.ToRotation();
									float y = v.Length();
									Vector2 scale3 = new Vector2(2f, y);
									item = new DrawData(Main.magicPixel, vector3 + Position, value2, color2, num6 - 1.57079637f, Vector2.Zero, scale3, SpriteEffects.None, 0);
									item.ignorePlayerRotation = true;
									item.shader = Mount.currentShader;
									playerDrawData.Add(item);
								}
							}
						}
					}
				}
			}
		}

        public override void UpdateEffects(Player player)
        {
            if (!(Math.Abs(player.velocity.X) > 4f))
            {
                return;
            }


            Rectangle rect = player.getRect();
        }
    }
}