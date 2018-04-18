using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using System.Linq;
using Terraria.ModLoader.IO;
using Fargowiltas;
using System;
using Terraria.UI;

namespace Fargowiltas
{
    public class FargoWorld : ModWorld
    {
        public static bool movedLumberjack = false;
        public static bool downedBetsy = false;
        public static bool downedBoss = false;

        //masomode
        public static bool masochistMode = false;
        public static int eyeCount = 0;
        public static int slimeCount = 0;
        public static int eaterCount = 0;
        public static int brainCount = 0;
        public static int beeCount = 0;
        public static int skeletronCount = 0;
        public static int wallCount = 0;
        public static int destroyerCount = 0;
        public static int primeCount = 0;
        public static int twinsCount = 0;
        public static int planteraCount = 0;
        public static int golemCount = 0;
        public static int fishronCount = 0;
        public static int cultistCount = 0;
        public static int moonlordCount = 0;

        //town npcs
        public static bool guide = false;
        public static bool merch = false;
        public static bool nurse = false;
        public static bool demo = false;
        public static bool dye = false;
        public static bool dryad = false;
        public static bool keep = false;
        public static bool dealer = false;
        public static bool style = false;
        public static bool paint = false;
        public static bool angler = false;
        public static bool goblin = false;
        public static bool doc = false;
        public static bool cloth = false;
        public static bool mech = false;
        public static bool party = false;
        public static bool wiz = false;
        public static bool tax = false;
        public static bool truf = false;
        public static bool pirate = false;
        public static bool steam = false;
        public static bool borg = false;

        public override void Initialize()
        {
            movedLumberjack = false;
            downedBetsy = false;
            downedBoss = false;

            //masomode
            masochistMode = false;
            eyeCount = 0;
            slimeCount = 0;
            eaterCount = 0;
            brainCount = 0;
            beeCount = 0;
            skeletronCount = 0;
            wallCount = 0;
            destroyerCount = 0;
            primeCount = 0;
            twinsCount = 0;
            planteraCount = 0;
            golemCount = 0;
            fishronCount = 0;
            cultistCount = 0;
            moonlordCount = 0;

            //town npcs
            guide = false;
            merch = false;
            nurse = false;
            demo = false;
            dye = false;
            dryad = false;
            keep = false;
            dealer = false;
            style = false;
            paint = false;
            angler = false;
            goblin = false;
            doc = false;
            cloth = false;
            mech = false;
            party = false;
            wiz = false;
            tax = false;
            truf = false;
            pirate = false;
            steam = false;
            borg = false;

        }

        public override TagCompound Save()
        {
            var count = new List<int>();
            count.Add(eyeCount);
            count.Add(slimeCount);
            count.Add(eaterCount);
            count.Add(brainCount);
            count.Add(beeCount);
            count.Add(skeletronCount);
            count.Add(wallCount);
            count.Add(destroyerCount);
            count.Add(primeCount);
            count.Add(twinsCount);
            count.Add(planteraCount);
            count.Add(golemCount);
            count.Add(fishronCount);
            count.Add(cultistCount);
            count.Add(moonlordCount);

            var downed = new List<string>();
            if (movedLumberjack) downed.Add("lumberjack");
            if (downedBetsy) downed.Add("betsy");
            if (downedBoss) downed.Add("boss");

            //masomode
            if (masochistMode) downed.Add("masochist");

            //town npcs
            if (guide) downed.Add("guide");
            if (merch) downed.Add("merch");
            if (nurse) downed.Add("nurse");
            if (demo) downed.Add("demo");
            if (dye) downed.Add("dye");
            if (dryad) downed.Add("dryad");
            if (keep) downed.Add("keep");
            if (dealer) downed.Add("dealer");
            if (style) downed.Add("style");
            if (paint) downed.Add("paint");
            if (angler) downed.Add("angler");
            if (goblin) downed.Add("goblin");
            if (doc) downed.Add("doc");
            if (cloth) downed.Add("cloth");
            if (mech) downed.Add("mech");
            if (party) downed.Add("party");
            if (wiz) downed.Add("wiz");
            if (tax) downed.Add("tax");
            if (truf) downed.Add("truf");
            if (pirate) downed.Add("pirate");
            if (steam) downed.Add("steam");
            if (borg) downed.Add("borg");

            return new TagCompound {
                {"downed", downed}, { "count", count}
            };
        }

        public override void Load(TagCompound tag)
        {
            if (tag.ContainsKey("count"))
            {
                var count = tag.GetList<int>("count");
                eyeCount = count[0];
                slimeCount = count[1];
                eaterCount = count[2];
                brainCount = count[3];
                beeCount = count[4];
                skeletronCount = count[5];
                wallCount = count[6];
                destroyerCount = count[7];
                primeCount = count[8];
                twinsCount = count[9];
                planteraCount = count[10];
                golemCount = count[11];
                fishronCount = count[12];
                cultistCount = count[13];
                moonlordCount = count[14];
            }

            var downed = tag.GetList<string>("downed");
            movedLumberjack = downed.Contains("lumberjack");
            downedBetsy = downed.Contains("betsy");
            downedBoss = downed.Contains("boss");
            masochistMode = downed.Contains("masochist");

            guide = downed.Contains("guide");
            merch = downed.Contains("merch");
            nurse = downed.Contains("nurse");
            demo = downed.Contains("demo");
            dye = downed.Contains("dye");
            dryad = downed.Contains("dryad");
            keep = downed.Contains("keep");
            dealer = downed.Contains("dealer");
            style = downed.Contains("style");
            paint = downed.Contains("paint");
            angler = downed.Contains("angler");
            goblin = downed.Contains("goblin");
            doc = downed.Contains("doc");
            cloth = downed.Contains("cloth");
            mech = downed.Contains("mech");
            party = downed.Contains("party");
            wiz = downed.Contains("wiz");
            tax = downed.Contains("tax");
            truf = downed.Contains("truf");
            pirate = downed.Contains("pirate");
            steam = downed.Contains("steam");
            borg = downed.Contains("borg");
        }

        public override void NetReceive(BinaryReader reader)
        {
            eyeCount = reader.ReadInt32();
            slimeCount = reader.ReadInt32();
            eaterCount = reader.ReadInt32();
            brainCount = reader.ReadInt32();
            beeCount = reader.ReadInt32();
            skeletronCount = reader.ReadInt32();
            wallCount = reader.ReadInt32();
            destroyerCount = reader.ReadInt32();
            primeCount = reader.ReadInt32();
            twinsCount = reader.ReadInt32();
            planteraCount = reader.ReadInt32();
            golemCount = reader.ReadInt32();
            fishronCount = reader.ReadInt32();
            cultistCount = reader.ReadInt32();
            moonlordCount = reader.ReadInt32();

            BitsByte flags = reader.ReadByte();
            downedBetsy = flags[0];
            downedBoss = flags[1];
            masochistMode = flags[2];
            guide = flags[3];
            merch = flags[4];
            nurse = flags[5];
            demo = flags[6];
            dye = flags[7];

            BitsByte flags2 = reader.ReadByte();
            dryad = flags2[0];
            keep = flags2[1];
            dealer = flags2[2];
            style = flags2[3];
            paint = flags2[4];
            angler = flags2[5];
            goblin = flags2[6];
            doc = flags2[7];

            BitsByte flags3 = reader.ReadByte();
            cloth = flags3[0];
            mech = flags3[1];
            party = flags3[2];
            wiz = flags3[3];
            tax = flags3[4];
            truf = flags3[5];
            pirate = flags3[6];
            steam = flags3[7];

            BitsByte flags4 = reader.ReadByte();
            borg = flags4[0];
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(eyeCount);
            writer.Write(slimeCount);
            writer.Write(eaterCount);
            writer.Write(brainCount);
            writer.Write(beeCount);
            writer.Write(skeletronCount);
            writer.Write(wallCount);
            writer.Write(destroyerCount);
            writer.Write(primeCount);
            writer.Write(twinsCount);
            writer.Write(planteraCount);
            writer.Write(golemCount);
            writer.Write(fishronCount);
            writer.Write(cultistCount);
            writer.Write(moonlordCount);

            BitsByte flags = new BitsByte();
            flags[0] = downedBetsy;
            flags[1] = downedBoss;
            flags[2] = masochistMode;
            flags[3] = guide;
            flags[4] = merch;
            flags[5] = nurse;
            flags[6] = demo;
            flags[7] = dye;

            BitsByte flags2 = new BitsByte();
            flags2[0] = dryad;
            flags2[1] = keep;
            flags2[2] = dealer;
            flags2[3] = style;
            flags2[4] = paint;
            flags2[5] = angler;
            flags2[6] = goblin;
            flags2[7] = doc;

            BitsByte flags3 = new BitsByte();
            flags3[0] = cloth;
            flags3[1] = mech;
            flags3[2] = party;
            flags3[3] = wiz;
            flags3[4] = tax;
            flags3[5] = truf;
            flags3[6] = pirate;
            flags3[7] = steam;

            BitsByte flags4 = new BitsByte();
            flags4[0] = borg;

            writer.Write(flags);
            writer.Write(flags2);
            writer.Write(flags3);
            writer.Write(flags4);

        }

        public override void PostUpdate()
        {
            if (Soulcheck.GetValue("Seasonal Enemies"))
            {
                Main.xMas = true;
                Main.halloween = true;
            }

            Player player = Main.player[Main.myPlayer];

            //right when day starts
            /*if(/*Main.time == 0 && Main.dayTime && !Main.eclipse && FargoWorld.masochistMode)
			{
					Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0, 1f, 0f);
					
					if (Main.netMode == 0)
					{
						Main.eclipse = true;
						//Main.NewText(Lang.misc[20], 50, 255, 130, false);
					}
					else
					{
						//NetMessage.SendData(61, -1, -1, "", player.whoAmI, -6f, 0f, 0f, 0, 0, 0);
					}
				
				
			}*/

            // if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == 361 && Main.CanStartInvasion(1, true))
            // {
            // this.itemTime = item.useTime;
            // Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0, 1f, 0f);
            // if (Main.netMode != 1)
            // {
            // if (Main.invasionType == 0)
            // {
            // Main.invasionDelay = 0;
            // Main.StartInvasion(1);
            // }
            // }
            // else
            // {
            // NetMessage.SendData(61, -1, -1, "", this.whoAmI, -1f, 0f, 0f, 0, 0, 0);
            // }
            // }
            // if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == 602 && Main.CanStartInvasion(2, true))
            // {
            // this.itemTime = item.useTime;
            // Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0, 1f, 0f);
            // if (Main.netMode != 1)
            // {
            // if (Main.invasionType == 0)
            // {
            // Main.invasionDelay = 0;
            // Main.StartInvasion(2);
            // }
            // }
            // else
            // {
            // NetMessage.SendData(61, -1, -1, "", this.whoAmI, -2f, 0f, 0f, 0, 0, 0);
            // }
            // }
            // if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == 1315 && Main.CanStartInvasion(3, true))
            // {
            // this.itemTime = item.useTime;
            // Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0, 1f, 0f);
            // if (Main.netMode != 1)
            // {
            // if (Main.invasionType == 0)
            // {
            // Main.invasionDelay = 0;
            // Main.StartInvasion(3);
            // }
            // }
            // else
            // {
            // NetMessage.SendData(61, -1, -1, "", this.whoAmI, -3f, 0f, 0f, 0, 0, 0);
            // }
            // }
            // if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == 1844 && !Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon && !DD2Event.Ongoing)
            // {
            // this.itemTime = item.useTime;
            // Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0, 1f, 0f);
            // if (Main.netMode != 1)
            // {
            // Main.NewText(Lang.misc[31], 50, 255, 130, false);
            // Main.startPumpkinMoon();
            // }
            // else
            // {
            // NetMessage.SendData(61, -1, -1, "", this.whoAmI, -4f, 0f, 0f, 0, 0, 0);
            // }
            // }

            // if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == 3601 && NPC.downedGolemBoss && Main.hardMode && !NPC.AnyDanger() && !NPC.AnyoneNearCultists())
            // {
            // Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0, 1f, 0f);
            // this.itemTime = item.useTime;
            // if (Main.netMode == 0)
            // {
            // WorldGen.StartImpendingDoom();
            // }
            // else
            // {
            // NetMessage.SendData(61, -1, -1, "", this.whoAmI, -8f, 0f, 0f, 0, 0, 0);
            // }
            // }
            // if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == 1958 && !Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon && !DD2Event.Ongoing)
            // {
            // this.itemTime = item.useTime;
            // Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0, 1f, 0f);
            // if (Main.netMode != 1)
            // {
            // Main.NewText(Lang.misc[34], 50, 255, 130, false);
            // Main.startSnowMoon();
            // }
            // else
            // {
            // NetMessage.SendData(61, -1, -1, "", this.whoAmI, -5f, 0f, 0f, 0, 0, 0);
            // }
            // }

        }
    }
}
