using System.Collections.Generic;
using Fargowiltas.Items.Summons.Deviantt;
using Fargowiltas.Items.Summons.Abom;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Fargowiltas.Items.Vanity;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Fargowiltas.Items.Tiles;
using Fargowiltas.Common.Configs;
using Fargowiltas.Content.Biomes;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class Abominationn : ModNPC
    {
        private bool canSayDefeatQuote = true;
        private bool canSayMutantShimmerQuote = false;
        private int defeatQuoteTimer = 900;

        //public override bool Autoload(ref string name)
        //{
        //    name = "Abominationn";
        //    return mod.Properties.Autoload;
        //}

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Abominationn");

            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 2;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<SkyBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<OceanBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<DungeonBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection<Mutant>(AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection<Deviantt>(AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.Nurse, AffectionLevel.Hate);

            NPC.AddDebuffImmunities(new List<int>()
            {
                 BuffID.Suffocation
            });
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,
                new FlavorTextBestiaryInfoElement("Mods.Fargowiltas.Bestiary.Abominationn")
            });
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 40;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = NPC.downedMoonlord ? 50 : 15;
            NPC.lifeMax = NPC.downedMoonlord ? 5000 : 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;
            NPC.buffImmune[BuffID.Suffocation] = true;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && ((bool)ModLoader.GetMod("FargowiltasSouls").Call("MutantAlive") || (bool)ModLoader.GetMod("FargowiltasSouls").Call("AbomAlive")))
            {
                return false;
            }
            return GetInstance<FargoServerConfig>().Abom && NPC.downedGoblins && !FargoGlobalNPC.AnyBossAlive();
        }

        public override bool CanGoToStatue(bool toKingStatue) => toKingStatue;

        public override void AI()
        {
            NPC.breath = 200;
            if (defeatQuoteTimer > 0)
                defeatQuoteTimer--;
            else
                canSayDefeatQuote = false;
            int mutant = NPC.FindFirstNPC(ModContent.NPCType<Mutant>());
            if (mutant != -1)
            {
                if (!Main.npc[mutant].IsShimmerVariant)
                {
                    canSayMutantShimmerQuote = true;
                }
            }
        }

        public override List<string> SetNPCNameList()
        {
            string[] names = { "Wilta", "Jack", "Harley", "Reaper", "Stevenn", "Doof", "Baroo", "Fergus", "Entev", "Catastrophe", "Bardo", "Betson" };

            return new List<string>(names);
        }

        public override string GetChat()
        {
            if (NPC.homeless && canSayDefeatQuote && Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedAbom"))
            {
                canSayDefeatQuote = false;
                return "You really defeated me... not bad. Now do it again without getting hit. Oh, and Copper Shortsword only.";
            }

            int mutant = NPC.FindFirstNPC(ModContent.NPCType<Mutant>());
            if (mutant != -1)
            {
                if (Main.npc[mutant].IsShimmerVariant)
                {
                    if (canSayMutantShimmerQuote)
                    {
                        canSayMutantShimmerQuote = false;
                        return "He turned into a squirrel. Funniest thing I've ever seen.";
                    }

                }
            }

            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && Main.rand.NextBool(3))
            {
                if ((bool)ModLoader.GetMod("FargowiltasSouls").Call("StyxArmor"))
                    return "What nostalgic armor you're wearing... No, it doesn't fit on me anymore. And its battery takes too long to charge.";
            }

            List<string> dialogue = new List<string>
            {
                "Where'd I get my scythe from? " + (!Main.hardMode ? "Ask me later." : "You'll figure it out."),
                "I have defeated everything in this land... nothing can beat me.",
                "Have you ever had a weapon stuck to your hand? It's not very handy.",
                "What happened to Yoramur? No idea who you're talking about.",
                "You wish you could dress like me? Ha! Actually yea.. you can.",
                "You ever read the ancient classics, I love all the fighting in them.",
                "I'm a world class poet, ever read my piece about impending doom?",
                "You want swarm summons? Maybe next year.",
                "Like my wings? Thanks, the thing I got them from didn't like it much.",
                "Heroism has no place in this world, instead let's just play ping pong.",
                "Why are you looking at me like that? Your fashion sense isn't going to be winning you any awards either.",
                "No, you can't have my hat.",
                "Embrace suffering... Wait what do you mean that's already taken?",
                "Your attempt to exploit my anger is admirable, but I cannot be angered.",
                "Is it really a crime if everyone else does it.",
                "Inflicting suffering upon others is the most amusing thing there is.",
                "Irony is the best kind of humor, isn't that ironic?",
                "I like Cat... What do you mean who's Cat?",
                "Check the wiki if you need anything, the kirb is slowly getting it up to par.",
                "I've heard tales of a legendary Diver... Anyway what was that about a giant jellyfish?",
                "Overloaded events...? Yeah, they're pretty cool.",
                "It's not like I don't enjoy your company, but can you buy something?",
                "I have slain one thousand humans! Huh? You're a human? There's so much blood on your hands..",
            };

            if (Main.LocalPlayer.ZoneGraveyard)
            {
                dialogue.Add("I hope all these graves lying around don't belong to you.");
            }

            int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
            if (mechanic != -1)
            {
                dialogue.Add($"Can you please ask {Main.npc[mechanic].GivenName} to stop touching my laser arm please.");
            }

            return Main.rand.Next(dialogue);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = Language.GetTextValue("Mods.Fargowiltas.NPCs.Abominationn.CancelEvent");
        }

        public const string ShopName = "Shop";

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = ShopName;
            }
            else
            {
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    var netMessage = Mod.GetPacket();
                    netMessage.Write((byte)6);
                    netMessage.Send();
                }

                if (Fargowiltas.IsEventOccurring)
                {
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        var netMessage = Mod.GetPacket();
                        netMessage.Write((byte)2);
                        netMessage.Send();
                    }

                    Main.npcChatText = Fargowiltas.TryClearEvents() ? "Hocus pocus, the event is over" : $"I'm not feeling it right now, come back in {FargoWorld.AbomClearCD / 60} seconds.";
                }
                else
                {
                    Main.npcChatText = "I don't think there's an event right now.";
                }
            }
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)
                .Add(new Item(ItemType<PartyCone>()) { shopCustomPrice = Item.buyPrice(copper: 10000) })
                .Add(new Item(ItemType<WeatherBalloon>()) { shopCustomPrice = Item.buyPrice(copper: 20000) })
                .Add(new Item(ItemType<Anemometer>()) { shopCustomPrice = Item.buyPrice(copper: 30000) })
                .Add(new Item(ItemType<ForbiddenScarab>()) { shopCustomPrice = Item.buyPrice(copper: 30000) })
                .Add(new Item(ItemType<SlimyBarometer>()) { shopCustomPrice = Item.buyPrice(copper: 40000) })
                .Add(new Item(ItemID.BloodMoonStarter) { shopCustomPrice = Item.buyPrice(copper: 50000) })
                .Add(new Item(ItemID.GoblinBattleStandard) { shopCustomPrice = Item.buyPrice(copper: 60000) })
                .Add(new Item(ItemType<MatsuriLantern>()) { shopCustomPrice = Item.buyPrice(copper: 100000) }, new Condition("Mods.Fargowiltas.Conditions.BossDown", () => FargoWorld.DownedBools["boss"]))
                .Add(new Item(ItemID.SnowGlobe) { shopCustomPrice = Item.buyPrice(copper: 150000) }, Condition.Hardmode)
                .Add(new Item(ItemID.PirateMap) { shopCustomPrice = Item.buyPrice(copper: 200000) }, Condition.DownedPirates)
                .Add(new Item(ItemType<PlunderedBooty>()) { shopCustomPrice = Item.buyPrice(copper: 150000) }, new Condition("Mods.Fargowiltas.Conditions.DutchmanDown", () => NPC.downedPirates && FargoWorld.DownedBools["flyingDutchman"]))
                .Add(new Item(ItemID.SolarTablet) { shopCustomPrice = Item.buyPrice(copper: 200000) }, Condition.DownedMechBossAny)
                .Add(new Item(ItemType<ForbiddenTome>()) { shopCustomPrice = Item.buyPrice(copper: 50000) }, new Condition("Mods.Fargowiltas.Conditions.MageDown", () => FargoWorld.DownedBools["darkMage"] || NPC.downedMechBossAny))
                .Add(new Item(ItemType<BatteredClub>()) { shopCustomPrice = Item.buyPrice(copper: 150000) }, new Condition("Mods.Fargowiltas.Conditions.OgreDown", () => FargoWorld.DownedBools["ogre"] || NPC.downedGolemBoss))
                .Add(new Item(ItemType<BetsyEgg>()) { shopCustomPrice = Item.buyPrice(copper: 400000) }, new Condition("Mods.Fargowiltas.Conditions.BetsyDown", () => FargoWorld.DownedBools["betsy"]))
                .Add(new Item(ItemID.PumpkinMoonMedallion) { shopCustomPrice = Item.buyPrice(copper: 500000) }, Condition.DownedPumpking)
                 .Add(new Item(ItemType<HeadofMan>()) { shopCustomPrice = Item.buyPrice(copper: 200000) }, new Condition("Mods.Fargowiltas.Conditions.HorsemanDown", () => FargoWorld.DownedBools["headlessHorseman"]))
                 .Add(new Item(ItemType<SpookyBranch>()) { shopCustomPrice = Item.buyPrice(copper: 200000) }, Condition.DownedMourningWood)
                 .Add(new Item(ItemType<SuspiciousLookingScythe>()) { shopCustomPrice = Item.buyPrice(copper: 300000) }, Condition.DownedPumpking)
                 .Add(new Item(ItemID.NaughtyPresent) { shopCustomPrice = Item.buyPrice(copper: 500000) }, Condition.DownedIceQueen)
                 .Add(new Item(ItemType<FestiveOrnament>()) { shopCustomPrice = Item.buyPrice(copper: 200000) }, Condition.DownedEverscream)
                 .Add(new Item(ItemType<NaughtyList>()) { shopCustomPrice = Item.buyPrice(copper: 200000) }, Condition.DownedSantaNK1)
                 .Add(new Item(ItemType<IceKingsRemains>()) { shopCustomPrice = Item.buyPrice(copper: 300000) }, Condition.DownedIceQueen)
                 .Add(new Item(ItemType<RunawayProbe>()) { shopCustomPrice = Item.buyPrice(copper: 500000) }, Condition.DownedGolem)
                 .Add(new Item(ItemType<MartianMemoryStick>()) { shopCustomPrice = Item.buyPrice(copper: 300000) }, Condition.DownedMartians)
                 .Add(new Item(ItemType<PillarSummon>()) { shopCustomPrice = Item.buyPrice(copper: 750000) }, new Condition("Mods.Fargowiltas.Conditions.PillarsDown", () => NPC.downedTowers))
                 .Add(new Item(ItemType<AbominationnScythe>()) { shopCustomPrice = Item.buyPrice(copper: 50000) }, new Condition("Mods.Fargowiltas.Conditions.PillarsDown", () => NPC.downedTowers))
                .Add(new Item(ItemType<SiblingPylon>()), Condition.HappyEnoughToSellPylons, Condition.NpcIsPresent(NPCType<Mutant>()), Condition.NpcIsPresent(NPCType<Deviantt>()))

            ;

            npcShop.Register();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = NPC.downedMoonlord ? 150 : 20;
            knockback = NPC.downedMoonlord ? 10f : 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = NPC.downedMoonlord ? 1 : 30;
            if (!NPC.downedMoonlord)
            {
                randExtraCooldown = 30;
            }
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = NPC.downedMoonlord ? ProjectileType<Projectiles.DeathScythe>() : ProjectileID.DeathSickle;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hit.HitDirection, -2.5f, Scale: 0.8f);
                }

                if (!Main.dedServ)
                {
                    Vector2 pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("Fargowiltas", "AbomGore3").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("Fargowiltas", "AbomGore2").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("Fargowiltas", "AbomGore1").Type);
                }
            }
            else
            {
                for (int k = 0; k < hit.Damage / NPC.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, hit.HitDirection, -1f, Scale: 0.6f);
                }
            }
        }
    }
}
