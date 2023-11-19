using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using Fargowiltas.Items.Summons.SwarmSummons;
using Fargowiltas.Items.Misc;
using Fargowiltas.Items.Summons.Mutant;
using Fargowiltas.Projectiles;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Fargowiltas.Items.Summons.Abom;
using Fargowiltas.Items.Tiles;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using ReLogic.Content;
using Fargowiltas.Common.Configs;
using Fargowiltas.Content.Biomes;
using Terraria.DataStructures;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class Mutant : ModNPC
    {
        private static int shopNum = 1;

        internal bool spawned;
        private bool canSayDefeatQuote = true;
        private int defeatQuoteTimer = 900;


        public override ITownNPCProfile TownNPCProfile()
        {
            return new MutantProfile();
        }

        //public override bool Autoload(ref string name)
        //{
        //    name = "Mutant";
        //    return true;// Mod.Properties.Autoload;
        //}

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mutant");

            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;

            NPCID.Sets.ShimmerTownTransform[NPC.type] = true; // This set says that the Town NPC has a Shimmered form. Otherwise, the Town NPC will become transparent when touching Shimmer like other enemies.

            NPCID.Sets.ShimmerTownTransform[Type] = true; // Allows for this NPC to have a different texture after touching the Shimmer liquid.

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<SkyBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<HallowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection<Abominationn>(AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection<Deviantt>(AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection<LumberJack>(AffectionLevel.Dislike);

            NPC.AddDebuffImmunities(new List<int>()
            {
                 BuffID.Suffocation
            });
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,
                new FlavorTextBestiaryInfoElement("Mods.Fargowiltas.Bestiary.Mutant")
            });
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = NPC.downedMoonlord ? 50 : 15;
            NPC.lifeMax = NPC.downedMoonlord ? 5000 : 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;

            if (GetInstance<FargoServerConfig>().CatchNPCs)
            {
                Main.npcCatchable[NPC.type] = true;
            //    NPC.catchItem = (short)Mod.ItemType("Mutant");
            }

            NPC.buffImmune[BuffID.Suffocation] = true;

            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedMutant"))
            {
                NPC.lifeMax = 77000;
                NPC.defense = 360;
            }
        }

        public override bool CanGoToStatue(bool toKingStatue) => true;

        public override void AI()
        {
            NPC.breath = 200;
            if (defeatQuoteTimer > 0)
                defeatQuoteTimer--;
            else
                canSayDefeatQuote = false;

            if (!spawned)
            {
                spawned = true;
                if (Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedMutant"))
                {
                    NPC.lifeMax = 77000;
                    NPC.life = NPC.lifeMax;
                    NPC.defense = 360;
                }
            }
            AnimationType = NPC.IsShimmerVariant ? -1 : NPCID.Guide;
            NPCID.Sets.CannotSitOnFurniture[NPC.type] = NPC.ShimmeredTownNPCs[NPC.type];
        }
        public override bool UsesPartyHat() => !NPC.IsShimmerVariant;

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)ModLoader.GetMod("FargowiltasSouls").Call("MutantAlive"))
            {
                return false;
            }

            return GetInstance<FargoServerConfig>().Mutant && FargoWorld.DownedBools["boss"] && !FargoGlobalNPC.AnyBossAlive();
        }

        public override List<string> SetNPCNameList()
        {
            string[] names = { "Flacken", "Dorf", "Bingo", "Hans", "Fargo", "Grim", "Mike", "Fargu", "Terrance", "Catty N. Pem", "Tom", "Weirdus", "Polly" };

            return new List<string>(names);
        }

        public override string GetChat()
        {
            if (NPC.homeless && canSayDefeatQuote && Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedMutant"))
            {
                canSayDefeatQuote = false;

                if ((bool)ModLoader.GetMod("FargowiltasSouls").Call("EternityMode"))
                    return "Congratulations. You truly embraced eternity... at least, I think you did? So what happens next? Ascend from this plane of existence? Fight a transcendant cat-like entity? Destroy the world? All the power's in your hands now.";
                else
                    return "Good work beating me, I guess. I still feel like stretching my wings... Why don't we go at it for real next time?";
            }

            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && Main.rand.NextBool(4))
            {
                if ((bool)ModLoader.GetMod("FargowiltasSouls").Call("MutantArmor"))
                    return "Nice armor you have, very realistic skin. As a matter of fact, mind if I borrow it? Your skin, that is.";
            }

            List<string> dialogue = new List<string>
            {
                "Savagery, barbarism, bloodthirst, that's what I like seeing in people.",
                "The stronger you get, the more stuff I sell. Makes sense, right?",
                "There's something all of you have that I don't... Death perception, I think it's called?",
                "It would be pretty cool if I sold a summon for myself...",
                "The only way to get stronger is to keep buying from me and in bulk too!",
                "Why are you looking at me like that, all I did was eat an apple.",
                "Don't bother with anyone else, all you'll ever need is right here.",
                "You're lucky I'm on your side.",
                "Why yes I would love a ham and swiss sandwich.",
                "Should I start wearing clothes? ...Nah.",
                "It's not like I can actually use all the gold you're spending.",
                "Violence for violence is the law of the beast.",
                "Those guys really need to get more creative. All of their first bosses are desert themed!",
                "You say you want to know how a Mutant and Abominationn are brothers? You're better off not knowing.",
                "I'm all you need for a calamity.",
                "Everything shall bow before me! ...after you make this purchase.",
                "It's clear that I'm helping you out, but uh.. what's in this for me? A house you say? I eat zombies for breakfast.",
                "Can I jump? No, I don't have something called a 'spacebar'.",
                "Got your nose, I needed one to replace mine.",
                "What's a Terry?",
                "Why do so many creatures carry around a weird looking blue doll? The world may never know.",
                "Impending doom approaches. ...If you don't buy anything of course.",
                "I've heard of a '3rd dimension', I wonder what that looks like.",
                "Boy don't I look fabulous today.",
                "You have fewer friends than I do eyes.",
                "The ocean is a dangerous place, I wonder where Diver is?",
                "Do you know what an Ee-arth is?",
                "I can't even spell 'apotheosis', do you expect me to know what it is?",
                "Where do monsters get their gold from? ...I don't have pockets you know.",
                "Dogs are cool and all, but cats don't try to bite my brain.",
                "Beware the green dragon... What's that face mean?",
                "Where is this O-hi-o I keep hearing about.",
                "I've told you 56 times already, I'm busy... Oh wait you want to buy something, I suppose I have time.",
                "I've heard of a 'Soul of Souls' that only exists in 2015.",
                "Adding EX after everything makes it way more difficult.",
                "I think that all modern art looks great, especially the bloody stuff.",
                "How many guides does it take to change a lightbulb? ... I don't know, how about you ask him.",
                "Good thing I don't have a bed, I'd probably never leave it.",
                "What's this about an update? Sounds rare.",
                "If you need me I'll be slacking off somewhere.",
                "What do you mean who is Fargo!",
                "Have you seen the ech cat?",
                "I don't understand music nowadays, I prefer some smooth jazz... or the dying screams of monsters.",
                "Cthulhu's got nothing on me!",
                "I heard of a rumor of infinite use boss summons. Makes me sick.."
            };

            if (Fargowiltas.ModLoaded["FargowiltasSouls"])
            {
                dialogue.AddWithCondition("Now that you've defeated the big guy, I'd say it's time to start collecting those materials!", NPC.downedMoonlord);

                if ((bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedMutant"))
                {
                    dialogue.Add("What's that? You want to fight me? ...sure, I guess.");
                }
                else if ((bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedFishronEX") || (bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedAbom"))
                {
                    dialogue.Add("What's that? You want to fight me? ...maybe if I had a reason.");
                }
            }
            else
            {
                dialogue.Add("What's that? You want to fight me? ...you're not worthy you rat.");
            }

            //dialogue.AddWithCondition("Why would you do this.", Fargowiltas.ModLoaded["CalamityMod"]);
            //dialogue.AddWithCondition("I feel a great imbalance in this world.", Fargowiltas.ModLoaded["CalamityMod"] && Fargowiltas.ModLoaded["ThoriumMod"]);
            //dialogue.AddWithCondition("A great choice, shame about that first desert boss thing though.", Fargowiltas.ModLoaded["ThoriumMod"]);
            dialogue.AddWithCondition("A bit spooky tonight, isn't it.", Main.pumpkinMoon);
            dialogue.AddWithCondition("I'd ask for a coat, but I don't think you have any my size.", Main.snowMoon);
            dialogue.AddWithCondition("Weather seems odd today, wouldn't you agree?", Main.slimeRain);
            dialogue.AddWithCondition("Lovely night, isn't it?", Main.bloodMoon);
            dialogue.AddWithCondition("I hope the constant arguing I'm hearing isn't my fault.", Main.bloodMoon);
            dialogue.AddWithCondition("I'd follow and help, but I'd much rather sit around right now.", !Main.dayTime);

            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (BirthdayParty.PartyIsUp)
            {
                if (partyGirl >= 0)
                {
                    dialogue.Add($"{Main.npc[partyGirl].GivenName} is the one who invited me, I don't understand why though.");
                }
                
                dialogue.Add("I don't know what everyone's so happy about, but as long as nobody mistakes me for a Pigronata, I'm happy too.");
            }

            int nurse = NPC.FindFirstNPC(NPCID.Nurse);
            if (nurse >= 0)
            {
                dialogue.Add($"Whenever we're alone, {Main.npc[nurse].GivenName} keeps throwing syringes at me, no matter how many times I tell her to stop!");
            }

            int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
            if (witchDoctor >= 0)
            {
                dialogue.Add($"Please go tell {Main.npc[witchDoctor].GivenName} to drop the 'mystical' shtick, I mean, come on! I get it, you make tainted water or something.");
            }

            int dryad = NPC.FindFirstNPC(NPCID.Dryad);
            if (dryad >= 0)
            {
                dialogue.Add($"Why does {Main.npc[dryad].GivenName}'s outfit make my wings flutter?");
            }

            int stylist = NPC.FindFirstNPC(NPCID.Stylist);
            if (stylist >= 0)
            {
                dialogue.Add($"{Main.npc[stylist].GivenName} once gave me a wig... I look hideous with long hair.");
            }

            int truffle = NPC.FindFirstNPC(NPCID.Truffle);
            if (truffle >= 0)
            {
                dialogue.Add("That mutated mushroom seems like my type of fella.");
            }

            int tax = NPC.FindFirstNPC(NPCID.TaxCollector);
            if (tax >= 0)
            {
                dialogue.Add($"{Main.npc[tax].GivenName} keeps asking me for money, but he won't accept my spawners!");
            }

            int guide = NPC.FindFirstNPC(NPCID.Guide);
            if (guide >= 0)
            {
                dialogue.Add($"Any idea why {Main.npc[guide].GivenName} is always cowering in fear when I get near him?");
            }

            int cyborg = NPC.FindFirstNPC(NPCID.Cyborg);
            if (truffle >= 0 && witchDoctor >= 0 && cyborg >= 0 && Main.rand.NextBool(52))
            {
                dialogue.Add($"If any of us could play instruments, I'd totally start a band with {Main.npc[witchDoctor].GivenName}, {Main.npc[truffle].GivenName}, and {Main.npc[cyborg].GivenName}.");
            }

            if (partyGirl >= 0)
            {
                dialogue.Add($"Man, {Main.npc[partyGirl].GivenName}'s confetti keeps getting stuck to my wings");
            }

            int demoman = NPC.FindFirstNPC(NPCID.Demolitionist);
            if (demoman >= 0)
            {
                dialogue.Add($"I'm surprised {Main.npc[demoman].GivenName} hasn't blown a hole in the floor yet, on second thought that sounds fun.");
            }

            int tavernkeep = NPC.FindFirstNPC(NPCID.DD2Bartender);
            if (tavernkeep >= 0)
            {
                dialogue.Add($"{Main.npc[tavernkeep].GivenName} keeps suggesting I drink some beer, something tells me he wouldn't like me when I'm drunk though.");
            }

            int dyeTrader = NPC.FindFirstNPC(NPCID.DyeTrader);
            if (dyeTrader >= 0)
            {
                dialogue.Add($"{Main.npc[dyeTrader].GivenName} wants to see what I would look like in blue... I don't know how to feel.");
            }

            return Main.rand.Next(dialogue);
        }

        private bool AnyHardmodeSummon => Main.hardMode || Fargowiltas.summonTracker.SortedSummons.Any(s => s.progression >= MutantSummonTracker.WallOfFlesh && s.downed.Invoke());
        private bool AnyPostMLSummon => NPC.downedMoonlord || Fargowiltas.summonTracker.SortedSummons.Any(s => s.progression >= MutantSummonTracker.Moonlord && s.downed.Invoke());
        private static string GetLocalization(string line) => Language.GetTextValue($"Mods.Fargowiltas.NPCs.Mutant.{line}");
        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (AnyHardmodeSummon)
            {
                button2 = GetLocalization("CycleShop");
            }
            else
            {
                shopNum = 1;
            }
            switch (shopNum)
            {
                case 1:
                    button = GetLocalization("PreHM");
                    break;

                case 2:
                    button = GetLocalization("HM");
                    break;

                default:
                    button = GetLocalization("PostML");
                    break;
            }

            

            if (AnyPostMLSummon)
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

        public const string ShopName1 = "Pre Hardmode Shop";
        public const string ShopName2 = "Hardmode Shop";
        public const string ShopName3 = "Post Moon Lord Shop";

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                switch (shopNum)
                {
                    case 1:
                        shopName = ShopName1;
                        break;
                    case 2:
                        shopName = ShopName2;
                        break;
                    default:
                        shopName = ShopName3;
                        break;
                }
            }
            else if (!firstButton && AnyHardmodeSummon)
            {
                shopNum++;
            }
        }

        public override void AddShops()
        {
            var npcShop1 = new NPCShop(Type, ShopName1)
                .Add(new Item(ItemType<Overloader>()) { shopCustomPrice = Item.buyPrice(copper: 400000) }, Condition.InExpertMode)
                .Add(new Item(ItemType<ModeToggle>()));

            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && TryFind("FargowiltasSouls", "Masochist", out ModItem masochist))
            {
                npcShop1.Add(new Item(masochist.Type) { shopCustomPrice = Item.buyPrice(copper: 10000) }); //mutants gift
            }

            foreach (MutantSummonInfo summon in Fargowiltas.summonTracker.SortedSummons)
            {
                //phm
                if (summon.progression <= MutantSummonTracker.WallOfFlesh)
                {
                    npcShop1.Add(new Item(summon.itemId) { shopCustomPrice = Item.buyPrice(copper: summon.price) }, new Condition("After the boss has been defeated", summon.downed));
                }
            }

            var npcShop2 = new NPCShop(Type, ShopName2);

            foreach (MutantSummonInfo summon in Fargowiltas.summonTracker.SortedSummons)
            {
                //hm
                if (summon.progression > MutantSummonTracker.WallOfFlesh && summon.progression <= MutantSummonTracker.Moonlord)
                {
                    npcShop2.Add(new Item(summon.itemId) { shopCustomPrice = Item.buyPrice(copper: summon.price) }, new Condition("After the boss has been defeated", summon.downed));
                }
            }

            var npcShop3 = new NPCShop(Type, ShopName3);

            foreach (MutantSummonInfo summon in Fargowiltas.summonTracker.SortedSummons)
            {
                //post ml
                if (summon.progression > MutantSummonTracker.Moonlord)
                {
                    npcShop3.Add(new Item(summon.itemId) { shopCustomPrice = Item.buyPrice(copper: summon.price) }, new Condition("After the boss has been defeated", summon.downed));
                }
            }

            npcShop3.Add(new Item(ItemType<AncientSeal>()) { shopCustomPrice = Item.buyPrice(copper: 100000000) });

            npcShop1.Add(new Item(ItemType<SiblingPylon>()), Condition.HappyEnoughToSellPylons, Condition.NpcIsPresent(NPCType<Abominationn>()), Condition.NpcIsPresent(NPCType<Deviantt>()));
            npcShop2.Add(new Item(ItemType<SiblingPylon>()), Condition.HappyEnoughToSellPylons, Condition.NpcIsPresent(NPCType<Abominationn>()), Condition.NpcIsPresent(NPCType<Deviantt>()));
            npcShop3.Add(new Item(ItemType<SiblingPylon>()), Condition.HappyEnoughToSellPylons, Condition.NpcIsPresent(NPCType<Abominationn>()), Condition.NpcIsPresent(NPCType<Deviantt>()));

            npcShop1.Register();
            npcShop2.Register();
            npcShop3.Register();
        }

        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            if (!ModLoader.TryGetMod("FargowiltasSouls", out Mod fargoSouls))
            {
                return;
            }

            if (shopName.Replace($"{Mod.Name}/{DisplayName}/", "") is ShopName1 or ShopName2 or ShopName3)
            {
                foreach (var item in items)
                {
                    if (item is null || item.IsAir)
                    {
                        continue;
                    }

                    float modifier = 1f;
                    if ((bool)fargoSouls.Call("MutantDiscountCard"))
                    {
                        modifier -= 0.2f;
                    }

                    if ((bool)fargoSouls.Call("MutantPact"))
                    {
                        modifier -= 0.3f;
                    }

                    item.shopCustomPrice = (int)((item.shopCustomPrice ?? item.GetStoreValue()) * modifier);
                }
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedMutant"))
            {
                damage = 700;
                knockback = 7f;
            }
            else if (NPC.downedMoonlord)
            {
                damage = 250;
                knockback = 6f;
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
            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedMutant") && TryFind("FargowiltasSouls", "MutantSpearThrownFriendly", out ModProjectile penetrator))
            {
                projType = penetrator.Type;
            }
            else if (NPC.downedMoonlord)
            {
                projType = ProjectileType<PhantasmalEyeProjectile>();
            }
            else if (Main.hardMode)
            {
                projType = ProjectileType<MechEyeProjectile>();
            }
            else
            {
                projType = ProjectileType<EyeProjectile>();
            }

            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedMutant"))
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
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("Fargowiltas", "MutantGore3").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("Fargowiltas", "MutantGore2").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("Fargowiltas", "MutantGore1").Type);
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

        private const int SquirrelFrameCount = 6;
        private int SquirrelFrame = 0;
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D texture = (Texture2D)TownNPCProfile().GetTextureNPCShouldUse(NPC);
            Rectangle rectangle = NPC.frame;
            if (NPC.IsShimmerVariant)
            {
                NPC.spriteDirection = NPC.direction;
                int height = 56; //we unfortunately have to explicitly set this value due to Restrictions
                if (NPC.velocity.X == 0)
                {
                    SquirrelFrame = 0;
                }
                else
                {
                    NPC.frameCounter++;
                    if (NPC.frameCounter >= 5)
                    {
                        NPC.frameCounter = 0;
                        SquirrelFrame++;
                        if (SquirrelFrame >= SquirrelFrameCount)
                        {
                            SquirrelFrame = 1;
                        }
                    }
                }
                rectangle.X = 0;
                rectangle.Y = height * SquirrelFrame;
                rectangle.Width = texture.Width;
                rectangle.Height = height;
            }
            
            Vector2 origin2 = NPC.frame.Size() / 2f;
            SpriteEffects effects = NPC.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY - 4), new Microsoft.Xna.Framework.Rectangle?(rectangle), NPC.GetAlpha(drawColor), NPC.rotation, origin2, NPC.scale, effects, 0f);
            return false;
        }

        
    }

    public class MutantProfile : ITownNPCProfile
    {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
        {
            if (npc.IsABestiaryIconDummy)
                return ModContent.Request<Texture2D>("Fargowiltas/NPCs/Mutant");

            if (npc.IsShimmerVariant)
            {
                if (npc.altTexture == 1)
                {
                    return ModContent.Request<Texture2D>("Fargowiltas/NPCs/Mutant_Shimmer_Party");
                }
                else
                {
                    return ModContent.Request<Texture2D>("Fargowiltas/NPCs/Mutant_Shimmer");
                }
            }

            return ModContent.Request<Texture2D>("Fargowiltas/NPCs/Mutant");
        }

        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("Fargowiltas/NPCs/Mutant_Head");
    }
}
