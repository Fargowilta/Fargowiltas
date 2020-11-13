using Fargowiltas.Gores;
using Fargowiltas.Projectiles;
using Fargowiltas.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;

//using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class Mutant : ModNPC
    {
        private static bool prehardmodeShop;
        private static bool hardmodeShop;
        private static int shopNum = 1;

        internal bool spawned;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mutant");

            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0) { Velocity = 1f });
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = NPC.downedMoonlord ? 50 : 15;
            npc.lifeMax = NPC.downedMoonlord ? 5000 : 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
            Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)ModContent.ItemType<Items.CaughtNPCs.Mutant>();
            npc.buffImmune[BuffID.Suffocation] = true;

            if (Fargowiltas.ModLoaded("FargowiltasSouls") && (bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedMutant"))
            {
                npc.lifeMax = 7700000;
                npc.defense = 400;
            }
        }

        /*public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[1] { BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface });
            bestiaryEntry.Info.Add(new FlavorTextBestiaryInfoElement("Called brother by its siblings, but refuses to confirm its gender. More interested in looking for fuzzy critters than talking about its past."));
        }*/

        public override bool CanGoToStatue(bool toKingStatue) => toKingStatue;

        public override void AI()
        {
            npc.breath = 200;

            if (!spawned)
            {
                spawned = true;

                if (Fargowiltas.ModLoaded("FargowiltasSouls") && (bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedMutant"))
                {
                    npc.lifeMax = 77000;
                    npc.life = npc.lifeMax;
                    npc.defense = 400;
                }
            }
        }

        public override bool CanTownNPCSpawn(int numTownnpcs, int money)
        {
            if (Fargowiltas.ModLoaded("FargowiltasSouls") && (bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("MutantAlive"))
            {
                return false;
            }

            return ModContent.GetInstance<FargoConfig>().mutant && FargoWorld.DownedBools["boss"] && !FargoGlobalNPC.AnyBossAlive();
        }

        public override string TownNPCName() => Language.GetTextValue("Mods.Fargowiltas.NPC_Names_Mutant." + Main.rand.Next(13));

        public override string GetChat()
        {
            List<string> dialogue = new List<string>
            {
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Savagery"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.StrongerYouGet"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.DeathPerception"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.SummonofMyself"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.BuyingInBulk"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.EatAnApple"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.AllYoullEverNeed"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.OnYourSide"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.House"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.HamandSwiss"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Clothes"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.UseGold"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.ViolenceforViolence"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.DesertBoss"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Brothers"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Calamity"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.BowBeforeMe"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.HelpingYouOut"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Spacebar"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.GotYourNose"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Terry"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.BlueDoll"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.ImpendingDoomApproaches"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.ThirdDimension"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.LookFabulous"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.FewerFriends"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Diver"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Earth"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Apotheosis"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Pockets"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.DogsandCats"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.GreenDragon"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Ohio"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.IHaveTime"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.SoulofSouls"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.ExDifficulty"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.ModernArt"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.GuideLightbulb"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.NoBed"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.RareUpdate"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Slacking"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.WhoIsFargo"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.EchCat"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.JazzScreams"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Cthulhu")
            };

            if (Fargowiltas.ModLoaded("FargowiltasSouls"))
            {
                dialogue.AddWithCondition(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.BigGuy"), NPC.downedMoonlord);

                if ((bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedMutant"))
                {
                    dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.FightMeYes"));
                }
                else if ((bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedFishronEX") || (bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedAbom"))
                {
                    dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.FightMeNo"));
                }
            }
            else
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.FightMeFuckYou"));
            }

            dialogue.AddWithCondition(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.CalamityMeme"), Fargowiltas.ModLoaded("CalamityMod"));
            dialogue.AddWithCondition(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.CalamityThoriumMeme"), Fargowiltas.ModLoaded("CalamityMod") && Fargowiltas.ModLoaded("ThoriumMod"));
            dialogue.AddWithCondition(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.ThoriumMeme"), Fargowiltas.ModLoaded("ThoriumMod"));
            dialogue.AddWithCondition(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.PumpkinMoon"), Main.pumpkinMoon);
            dialogue.AddWithCondition(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.SnowMoon"), Main.snowMoon);
            dialogue.AddWithCondition(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.SlimeRain"), Main.slimeRain);
            dialogue.AddWithCondition(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.BloodMoonLovely"), Main.bloodMoon);
            dialogue.AddWithCondition(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.BloodMoonPeriodReference"), Main.bloodMoon);
            dialogue.AddWithCondition(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.NightTime"), !Main.dayTime);

            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);

            if (partyGirl >= 0 && BirthdayParty.PartyIsUp)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.PartyGirlConfetti", Main.npc[partyGirl].GivenName));
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.PartyGirlInvitation", Main.npc[partyGirl].GivenName));
            }

            if (BirthdayParty.PartyIsUp)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Party"));
            }

            int lumberJack = NPC.FindFirstNPC(ModContent.NPCType<LumberJack>());

            if (lumberJack >= 0)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.LumberJack", Main.npc[npc.whoAmI], Main.npc[lumberJack].GivenName));
            }

            int nurse = NPC.FindFirstNPC(NPCID.Nurse);

            if (nurse >= 0)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Nurse", Main.npc[nurse].GivenName));
            }

            int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);

            if (witchDoctor >= 0)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.WitchDoctor", Main.npc[witchDoctor].GivenName));
            }

            int dryad = NPC.FindFirstNPC(NPCID.Dryad);

            if (dryad >= 0)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Dryad", Main.npc[dryad].GivenName));
            }

            int stylist = NPC.FindFirstNPC(NPCID.Stylist);

            if (stylist >= 0)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Stylist", Main.npc[stylist].GivenName));
            }

            int truffle = NPC.FindFirstNPC(NPCID.Truffle);

            if (truffle >= 0)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Truffle"));
            }

            int tax = NPC.FindFirstNPC(NPCID.TaxCollector);

            if (tax >= 0)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.TaxCollector", Main.npc[tax].GivenName));
            }

            int guide = NPC.FindFirstNPC(NPCID.Guide);

            if (guide >= 0)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Guide", Main.npc[guide].GivenName));
            }

            int cyborg = NPC.FindFirstNPC(NPCID.Cyborg);

            if (truffle >= 0 && witchDoctor >= 0 && cyborg >= 0 && Main.rand.NextBool(52))
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.Cyborg", Main.npc[witchDoctor].GivenName, Main.npc[truffle].GivenName, Main.npc[cyborg].GivenName));
            }

            int demoman = NPC.FindFirstNPC(NPCID.Demolitionist);

            if (demoman >= 0)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.DemoMan", Main.npc[demoman].GivenName));
            }

            int tavernkeep = NPC.FindFirstNPC(NPCID.DD2Bartender);

            if (tavernkeep >= 0)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.TavernKeep", Main.npc[tavernkeep].GivenName));
            }

            int dyeTrader = NPC.FindFirstNPC(NPCID.DyeTrader);

            if (dyeTrader >= 0)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Mutant.DyeTrader", Main.npc[dyeTrader].GivenName));
            }

            return Main.rand.Next(dialogue);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            switch (shopNum)
            {
                case 1:
                    button = Language.GetTextValue("NPC_ChatButtons_Mutant.PreHM");
                    break;

                case 2:
                    button = Language.GetTextValue("NPC_ChatButtons_Mutant.HM");
                    break;

                default:
                    button = Language.GetTextValue("NPC_ChatButtons_Mutant.PostML");
                    break;
            }

            if (Main.hardMode)
            {
                button2 = Language.GetTextValue("NPC_ChatButtons_Mutant.CycleShop");
            }

            if (NPC.downedMoonlord)
            {
                if (shopNum >= 4)
                {
                    shopNum = 1;
                }
            }
            else
            {
                if (shopNum >= 3)
                {
                    shopNum = 1;
                }
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;

                switch (shopNum)
                {
                    case 1:
                        prehardmodeShop = true;
                        hardmodeShop = false;
                        break;

                    case 2:
                        hardmodeShop = true;
                        prehardmodeShop = false;
                        break;

                    default:
                        prehardmodeShop = false;
                        hardmodeShop = false;
                        break;
                }
            }
            else if (!firstButton && Main.hardMode)
            {
                shopNum++;
            }
        }

        public static void AddItem(bool check, string mod, string item, int price, ref Chest shop, ref int nextSlot)
        {
            if (!check || shop is null)
            {
                return;
            }

            ModLoader.TryGetMod(mod, out Mod addedItemsMod);

            shop.item[nextSlot].SetDefaults(addedItemsMod.ItemType(item));
            shop.item[nextSlot].value = price;

            // Lowered prices with discount card and pact
            if (Fargowiltas.ModLoaded("FargowiltasSouls"))
            {
                float modifier = 1f;

                if ((bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("MutantDiscountCard"))
                {
                    modifier -= 0.2f;
                }

                if ((bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("MutantPact"))
                {
                    modifier -= 0.3f;
                }

                shop.item[nextSlot].value = (int)(shop.item[nextSlot].value * modifier);
            }

            nextSlot++;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            AddItem(Main.expertMode, "Fargowiltas", "Overloader", 400000, ref shop, ref nextSlot);

            if (prehardmodeShop)
            {
                AddItem(true, "Fargowiltas", "ExpertToggle", 100000, ref shop, ref nextSlot);

                if (Fargowiltas.ModLoaded("FargowiltasSouls"))
                {
                    AddItem(true, "FargowiltasSouls", "Masochist", 10000, ref shop, ref nextSlot); // mutants gift, dam meme namer
                }

                foreach (MutantSummonInfo summon in MutantSummonTracker.SortedSummons)
                {
                    //phm
                    if (summon.progression <= 6f)
                    {
                        AddItem(summon.downed(), summon.modSource, summon.itemName, summon.price, ref shop, ref nextSlot);
                    }
                }
            }
            else if (hardmodeShop)
            {
                foreach (MutantSummonInfo summon in MutantSummonTracker.SortedSummons)
                {
                    //hm
                    if (summon.progression > 6f && summon.progression <= 14)
                    {
                        AddItem(summon.downed(), summon.modSource, summon.itemName, summon.price, ref shop, ref nextSlot);
                    }
                }
            }
            else
            {
                foreach (MutantSummonInfo summon in MutantSummonTracker.SortedSummons)
                {
                    //post ml
                    if (summon.progression > 14f)
                    {
                        AddItem(summon.downed(), summon.modSource, summon.itemName, summon.price, ref shop, ref nextSlot);
                    }
                }

                AddItem(true, "Fargowiltas", "AncientSeal", 100000000, ref shop, ref nextSlot);
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (Fargowiltas.ModLoaded("FargowiltasSouls") && (bool)Fargowiltas.LoadedMods["Fargowiltas"].Call("DownedMutant"))
            {
                damage = 720;
                knockback = 10f;
            }
            else if (NPC.downedMoonlord)
            {
                damage = 250;
                knockback = 10f;
            }
            else if (Main.hardMode)
            {
                damage = 60;
                knockback = 5f;
            }
            else
            {
                damage = 20;
                knockback = 4f;
            }
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            if (NPC.downedMoonlord)
            {
                cooldown = 1;
            }
            else if (Main.hardMode)
            {
                cooldown = 20;
                randExtraCooldown = 25;
            }
            else
            {
                cooldown = 30;
                randExtraCooldown = 30;
            }
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (Fargowiltas.ModLoaded("FargowiltasSouls") && (bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedMutant"))
            {
                projType = Fargowiltas.LoadedMods["FargowiltasSouls"].ProjectileType("MutantSpearThrownFriendly");
            }
            else if (NPC.downedMoonlord)
            {
                projType = ModContent.ProjectileType<PhantasmalEyeProj>();
            }
            else if (Main.hardMode)
            {
                projType = ModContent.ProjectileType<MechEyeProj>();
            }
            else
            {
                projType = ModContent.ProjectileType<EyeProj>();
            }

            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            if (Fargowiltas.ModLoaded("FargowiltasSouls") && (bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedMutant"))
            {
                multiplier = 25f;
                randomOffset = 0f;
            }
            else
            {
                multiplier = 12f;
                randomOffset = 2f;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, Scale: 0.8f);
                }

                /*Gore.NewGore(npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2)), npc.velocity, ModContent.GoreType<MutantGore1>());
                Gore.NewGore(npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2)), npc.velocity, ModContent.GoreType<MutantGore2>());
                Gore.NewGore(npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2)), npc.velocity, ModContent.GoreType<MutantGore3>());*/
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, Scale: 0.6f);
                }
            }
        }
    }
}