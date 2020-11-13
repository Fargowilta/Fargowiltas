using Fargowiltas.Gores;
using Fargowiltas.Items.Summons.Deviantt;
using Fargowiltas.Projectiles;
using Fargowiltas.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class Deviantt : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deviantt");

            Main.npcFrameCount[npc.type] = 23;
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
            npc.lifeMax = NPC.downedMoonlord ? 2500 : 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Angler;
            Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)ModContent.ItemType<Items.CaughtNPCs.Deviantt>();
            npc.buffImmune[BuffID.Suffocation] = true;
        }

        /*public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[1] { BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface });
            bestiaryEntry.Info.Add(new FlavorTextBestiaryInfoElement("This energetic creature knows more than she lets on about the state of the world. Gets pouty when told jokes about her name."));
        }*/

        public override bool CanTownNPCSpawn(int numTownnpcs, int money)
        {
            if (Fargowiltas.ModLoaded("FargowiltasSouls") && (bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DevianttAlive"))
            {
                return false;
            }

            return ModContent.GetInstance<FargoConfig>().devi && !FargoGlobalNPC.AnyBossAlive() && (FargoWorld.DownedBools["rareEnemy"] || (Fargowiltas.ModLoaded("FargowiltasSouls") && (bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("Masomode")));
        }

        public override bool CanGoToStatue(bool toKingStatue) => !toKingStatue;

        public override void AI() => npc.breath = 200;

        public override string TownNPCName() => Language.GetTextValue("NPC_Dialogue_Deviantt." + Main.rand.Next(11));

        public override string GetChat()
        {
            if (Main.bloodMoon && Main.rand.NextBool(2))
            {
                return "The blood moon's effects? I'm not human anymore, so nope!";
            }

            List<string> dialogue = new List<string>
            {
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.MusicGenres"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.NotALoliISwearDevianttIsLegal"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.TallerBody"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.ScremCat"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.HamsterInfestation", Main.LocalPlayer.name),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.TallerTerrarian"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.Deviated"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.RipandTear"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.ChungusDog"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.Prison"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.DevianttHasAwoken"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.SummonforMyself"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.KilledaLot"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.ExtraLetter"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.MoreStuffISell")
            };

            int mutant = NPC.FindFirstNPC(ModContent.NPCType<Mutant>());

            if (mutant != -1)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.MutantClothes", Main.npc[mutant].GivenName));
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.MutantSummonJoke", Main.npc[mutant].GivenName));
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.MutantTheChaddestBrotherAlive", Main.npc[mutant].GivenName));
            }

            int abom = NPC.FindFirstNPC(ModContent.NPCType<Abominationn>());

            if (abom != -1)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.Abom", Main.npc[abom].GivenName));
            }

            int lumberjack = NPC.FindFirstNPC(ModContent.NPCType<LumberJack>());

            if (lumberjack != -1)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.LumberJack", Main.npc[lumberjack].GivenName));
            }

            int angler = NPC.FindFirstNPC(NPCID.Angler);

            if (angler != -1)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.Angler", Main.npc[angler].GivenName));
            }

            if (Fargowiltas.ModLoaded("FargowiltasSouls") && (bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("Masomode"))
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_Deviantt.EMode"));
            }

            return Main.rand.Next(dialogue);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");

            if (Fargowiltas.ModLoaded("FargowiltasSouls") && (bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("Masomode"))
            {
                button2 = (bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedMutant") ? Language.GetTextValue("Mods.Fargowiltas.NPC_ChatButtons_Deviantt.Lore") : Language.GetTextValue("Mods.Fargowiltas.NPC_ChatButtons_Deviantt.Help");
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else if (Fargowiltas.ModLoaded("FargowiltasSouls") && (bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("Masomode"))
            {
                if ((bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedMutant"))
                {
                    FargosLore();
                }
                else
                {
                    Fargos();
                }
            }
        }

        public static void AddItem(bool check, int item, int price, ref Chest shop, ref int nextSlot)
        {
            if (check)
            {
                shop.item[nextSlot].SetDefaults(item);
                shop.item[nextSlot++].shopCustomPrice = price;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (Fargowiltas.ModLoaded("FargowiltasSouls"))
            {
                shop.item[nextSlot++].SetDefaults(Fargowiltas.LoadedMods["FargowiltasSouls"].ItemType("EurusSock"));
            }

            AddItem(FargoWorld.DownedBools["pinky"], ModContent.ItemType<PinkSlimeCrown>(), Item.buyPrice(0, 5), ref shop, ref nextSlot);
            AddItem(FargoWorld.DownedBools["doctorBones"], ModContent.ItemType<Eggplant>(), Item.buyPrice(0, 2), ref shop, ref nextSlot);
            AddItem(FargoWorld.DownedBools["undeadMiner"], ModContent.ItemType<AttractiveOre>(), Item.buyPrice(0, 3), ref shop, ref nextSlot);
            AddItem(FargoWorld.DownedBools["tim"], ModContent.ItemType<HolyGrail>(), Item.buyPrice(0, 5), ref shop, ref nextSlot);
            AddItem(NPC.downedBoss3 && FargoWorld.DownedBools["dungeonSlime"], ModContent.ItemType<SlimyLockBox>(), Item.buyPrice(0, 10), ref shop, ref nextSlot);
            AddItem(Main.hardMode && FargoWorld.DownedBools["medusa"], ModContent.ItemType<AthenianIdol>(), Item.buyPrice(0, 5), ref shop, ref nextSlot);
            AddItem(Main.hardMode && FargoWorld.DownedBools["clown"], ModContent.ItemType<ClownLicense>(), Item.buyPrice(0, 5), ref shop, ref nextSlot);
            AddItem(FargoWorld.DownedBools["nymph"], ModContent.ItemType<HeartChocolate>(), Item.buyPrice(0, 10), ref shop, ref nextSlot);
            AddItem(FargoWorld.DownedBools["babyGuardian"], ModContent.ItemType<InnocuousSkull>(), Item.buyPrice(0, 10), ref shop, ref nextSlot);
            AddItem(Main.hardMode && FargoWorld.DownedBools["moth"], ModContent.ItemType<MothLamp>(), Item.buyPrice(0, 10), ref shop, ref nextSlot);
            AddItem(Main.hardMode && FargoWorld.DownedBools["rainbowSlime"], ModContent.ItemType<DilutedRainbowMatter>(), Item.buyPrice(0, 10), ref shop, ref nextSlot);
            AddItem(Main.hardMode && FargoWorld.DownedBools["wyvern"], ModContent.ItemType<CloudSnack>(), Item.buyPrice(0, 10), ref shop, ref nextSlot);
            AddItem(Main.hardMode && FargoWorld.DownedBools["runeWizard"], ModContent.ItemType<RuneOrb>(), Item.buyPrice(0, 15), ref shop, ref nextSlot);
            AddItem(Main.hardMode && FargoWorld.DownedBools["mimic"], ModContent.ItemType<SuspiciousLookingChest>(), Item.buyPrice(0, 20), ref shop, ref nextSlot);
            AddItem(Main.hardMode && FargoWorld.DownedBools["mimicHallow"], ModContent.ItemType<HallowChest>(), Item.buyPrice(0, 30), ref shop, ref nextSlot);
            AddItem(Main.hardMode && FargoWorld.DownedBools["mimicCorrupt"], ModContent.ItemType<CorruptChest>(), Item.buyPrice(0, 30), ref shop, ref nextSlot);
            AddItem(Main.hardMode && FargoWorld.DownedBools["mimicCrimson"], ModContent.ItemType<CrimsonChest>(), Item.buyPrice(0, 30), ref shop, ref nextSlot);
            AddItem(Main.hardMode && FargoWorld.DownedBools["mimicJungle"], ModContent.ItemType<JungleChest>(), Item.buyPrice(0, 30), ref shop, ref nextSlot);
            AddItem(Main.hardMode && FargoWorld.DownedBools["iceGolem"], ModContent.ItemType<CoreoftheFrostCore>(), Item.buyPrice(0, 10), ref shop, ref nextSlot);
            AddItem(Main.hardMode && FargoWorld.DownedBools["sandElemental"], ModContent.ItemType<ForbiddenForbiddenFragment>(), Item.buyPrice(0, 10), ref shop, ref nextSlot);
            AddItem(Main.hardMode && NPC.downedGoblins && FargoWorld.DownedBools["goblinSummoner"], ModContent.ItemType<ShadowflameIcon>(), Item.buyPrice(0, 10), ref shop, ref nextSlot);
            AddItem(Main.hardMode && NPC.downedPirates && FargoWorld.DownedBools["pirateCaptain"], ModContent.ItemType<PirateFlag>(), Item.buyPrice(0, 15), ref shop, ref nextSlot);
            AddItem(NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && FargoWorld.DownedBools["mothron"], ModContent.ItemType<MothronEgg>(), Item.buyPrice(0, 15), ref shop, ref nextSlot);
            AddItem(NPC.downedPlantBoss && FargoWorld.DownedBools["boneLee"], ModContent.ItemType<LeesHeadband>(), Item.buyPrice(0, 15), ref shop, ref nextSlot);
            AddItem(NPC.downedPlantBoss && FargoWorld.DownedBools["paladin"], ModContent.ItemType<GrandCross>(), Item.buyPrice(0, 15), ref shop, ref nextSlot);
            AddItem(NPC.downedPlantBoss && FargoWorld.DownedBools["skeletonGun"], ModContent.ItemType<AmalgamatedSkull>(), Item.buyPrice(0, 30), ref shop, ref nextSlot);
            AddItem(NPC.downedPlantBoss && FargoWorld.DownedBools["skeletonMage"], ModContent.ItemType<AmalgamatedSpirit>(), Item.buyPrice(0, 30), ref shop, ref nextSlot);
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (NPC.downedMoonlord)
            {
                damage = 80;
                knockback = 4f;
            }
            else if (Main.hardMode)
            {
                damage = 40;
                knockback = 4f;
            }
            else
            {
                damage = 20;
                knockback = 2f;
            }
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
            projType = NPC.downedMoonlord ? ModContent.ProjectileType<FakeHeartMarkDevianttProj>() : ModContent.ProjectileType<FakeHeartDevianttProj>();
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 10f;
            randomOffset = 0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default, 0.8f);
                }

                /*Gore.NewGore(npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2)), npc.velocity, ModContent.GoreType<DevianttGore1>());
                Gore.NewGore(npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2)), npc.velocity, ModContent.GoreType<DevianttGore2>());
                Gore.NewGore(npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2)), npc.velocity, ModContent.GoreType<DevianttGore3>());*/
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default, 0.6f);
                }
            }
        }

        // TODO: Can't be asked to localize this shiz
        private void Fargos()
        {
            Player player = Main.LocalPlayer;

            //devi gifts
            if (!(bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("GiftsReceived"))
            {
                Fargowiltas.LoadedMods["FargowiltasSouls"].Call("GiveDevianttGifts");

                Main.npcChatText = "This world looks tougher than usual, so you can have these on the house just this once! Talk to me if you need any tips, yeah?";

                return;
            }

            if (Main.rand.NextBool(4))
            {
                if ((bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedMutant"))
                {
                    Main.npcChatText = "What's that? You want to fight me for real? ...nah, I can't put up a good fight on my own.";
                }
                else if ((bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedAbom") && (bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedFishronEX"))
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.npcChatText = "What's that? You want to fight my big brother? ...maybe if he had a reason to.";
                    }
                    else
                    {
                        Main.npcChatText = "Don't forget you can equip a soul and its components for extra stat boosts! Good luck out there against my big brothers!";
                    }
                }
                else if ((bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedFishronEX"))
                {
                    Main.npcChatText = "Big brother Abominationn mentioned he's pretty excited to fight you! Make sure you're really well prepared before taking him on, though!";
                }
                else if ((bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedAbom"))
                {
                    //Main.npcChatText = "When you're ready, go fishing with a Truffle Worm EX. But until then... yeah, keep farming. So what are you buying today?";
                    Main.npcChatText = "What's that? You want to fight my big brother? ...maybe if he had a reason to.";
                }
                else if (NPC.downedMoonlord)
                {
                    //Main.npcChatText = "You've got two options now: a powerful foe's rematch or one of my brothers. Prepare as much as you can before going for either one, though!";
                    /*Main.npcChatText = Main.rand.Next(2) == 0
                        ? "Don't forget you can equip a soul and its components for extra stat boosts! Good luck out there against my big brothers!"
                        : "Purity, night, hallow, buried desert, deep snow, caverns, underworld, ocean, space... I'm pretty sure those are where the Sigil of Champions works!";*/
                    Main.npcChatText = "Now's a good time to go for damage on your accessory modifiers. Keep an eye on your enemies and look for patterns!";
                }
                else if (NPC.downedAncientCultist)
                {
                    Main.npcChatText = "Only a specific type of weapon will work against each specific pillar. As for that moon guy, his weakness will keep changing.";
                }
                else if (NPC.downedFishron)
                {
                    Main.npcChatText = "Some powerful enemies like that dungeon guy can create their own arenas. You won't be able to escape, so make full use of the room you do have.";
                }
                else if (NPC.downedGolemBoss)
                {
                    Main.npcChatText = "Did you beat that fish pig dragon yet? He's strong enough to break defenses in one hit. Too bad you don't have any reinforced plating to prevent that, right?";
                }
                else if (NPC.downedPlantBoss)
                {
                    Main.npcChatText = "That golem? It gets upset when you leave the temple, so fighting in there is best. It'll also try to take the high ground against you...";
                }
                else if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                {
                    Main.npcChatText = "That overgrown plant inflicts a special venom that works her into an enraged frenzy. She also has a ring of crystal leaves, but minions go through it.";
                }
                else if (Main.hardMode)
                {
                    if (!NPC.downedPirates)
                    {
                        Main.npcChatText = "Watch out when you break your fourth altar! It might attract the pirates, so be sure you're ready when you do it.";
                    }

                    if (!NPC.downedMechBoss1) //destroyer
                    {
                        Main.npcChatText = "That metal worm has a few upgrades. It'll start shooting dark stars and flying. When it coils around you, don't try to escape!";
                    }
                    else if (!NPC.downedMechBoss2) //twins
                    {
                        Main.npcChatText = "I saw that metal eye spinning while firing a huge laser the other day. Too bad you can't teleport through an attack like that on command, right?";
                    }
                    else if (!NPC.downedMechBoss3) //prime
                    {
                        Main.npcChatText = "You'll have to destroy the limbs before you can hurt that metal skull. But once it reveals its true form, focus on taking down the head instead.";
                    }
                    else //probably impossible to see lol
                    {
                        Main.npcChatText = "Ever tried out those 'enchantment' thingies? Try breaking a couple altars and see what you can make.";
                    }
                }
                else if ((bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("DownedDevi"))
                {
                    Main.npcChatText = "That thing's mouth is as good as immune to damage, so you'll have to aim for the eyes. What thing? You know, that thing.";
                }
                else if (NPC.downedBoss3)
                {
                    Main.npcChatText = "Next up is me! Make sure you can recognize whatever attack I'll throw at you. Blocks and turning away can nullify petrification!";
                }
                else if (NPC.downedQueenBee)
                {
                    Main.npcChatText = "The master of the dungeon can revive itself with a sliver of life for a last stand. Be ready to run for it when you make the killing blow.";
                }
                else if (NPC.downedBoss2)
                {
                    Main.npcChatText = "The queen bee will summon her progeny for backup. She's harder to hurt while they're there, so take them out first.";
                }
                else if (NPC.downedBoss1)
                {
                    Main.npcChatText = WorldGen.crimson
                        ? "When the brain gets mad, it'll confuse you every few seconds. Four rings to confuse you, one ring when it wears off!"
                        : "When you hurt the world eater, its segments will break off as smaller eaters. Don't let them pile up!";
                }
                else if (NPC.downedSlimeKing)
                {
                    Main.npcChatText = "Keep an eye on Cthulhu's eye when you're fighting. It might just teleport behind you whenever it finishes a set of mad dashes.";
                }
                else if (!NPC.downedGoblins)
                {
                    Main.npcChatText = "Watch out when you break your second " + (WorldGen.crimson ? "Crimson Heart" : "Shadow Orb") + "! It might attract the goblins, so prepare before you do it.";
                }
                else
                {
                    Main.npcChatText = "Gonna fight that slime king soon? Don't spend too long up and out of his reach or he'll get mad. Very, very mad.";
                }
            }
            else
            {
                IList<string> dialogue = new List<string>
                {
                    "Seems like everyone's learning to project auras these days. If you look at the particles, you can see whether it'll affect you at close range or a distance.",
                    "There's probably a thousand items to protect against all these debuffs. It's a shame you don't have a thousand hands to carry them all at once.",
                    "Don't forget you can turn off your soul toggles in the Mod Configurations menu!",
                    "Remember to disable any soul toggles you don't need in the Mod Configurations menu!",
                    //"Powerful enemies can drop all sorts of helpful loot. They'll also come back for revenge after you beat them, so keep an eye out for that.",
                    //"Why bother fishing when you can massacre bosses for the same goods? With spawners provided by my big brother, of course!",
                };

                if (player.HeldItem.DamageType == DamageClass.Ranged)
                {
                    dialogue.Add("Just so you know, ammos are less effective. Only a tiny fraction of their damage can contribute to your total output!");
                }

                if (!NPC.AnyNPCs(ModContent.NPCType<Squirrel>()))
                {
                    dialogue.Add("Found any Top Hat Squirrels yet? Keep one in your inventory and maybe a special friend will show up!");
                }

                if (!Main.hardMode)
                {
                    dialogue.Add("I've always wondered why those other monsters never bothered to carry any healing potions. Well, you probably shouldn't wait and see if they actually do.");
                    dialogue.Add("Watch out for those fish! Sharks will leave you alone if you leave them alone, but piranhas go wild when they smell blood.");
                }

                if (!player.accFlipper && !player.gills && !(bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("MutantAntibodies"))
                {
                    dialogue.Add("The water is bogging you down? Never had an issue with it, personally... Have you tried breathing water instead of air?");
                }

                if (!player.fireWalk && !player.buffImmune[BuffID.OnFire])
                {
                    dialogue.Add("The underworld has gotten a lot hotter since the last time I visited. I hear an obsidian skull is a good luck charm against burning alive, though.");
                }

                if (!player.buffImmune[BuffID.Suffocation] && !(bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("PureHeart"))
                {
                    dialogue.Add("Want to have a breath-holding contest? The empty vacuum of space would be perfect.");
                }

                if (player.statLifeMax < 400)
                {
                    dialogue.Add("I don't have any more Life Crystals for you, but Cthulhu's eye is going on a new diet of them. Not that they would share.");
                }

                if (NPC.downedBoss3 && !(bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("SinisterIcon"))
                {
                    dialogue.Add("Dungeon Guardian sent me photos of their kids earlier. Cute little skull demons hiding in other skeletons, aren't they? Oh, and their drop wards off random boss spawns, I guess.");
                }

                if (Main.hardMode)
                {
                    if (!(bool)Fargowiltas.LoadedMods["FargowiltasSouls"].Call("PureHeart"))
                    {
                        dialogue.Add("The spirits of light and dark stopped by and they sounded pretty upset with you. Don't be too surprised if something happens to you for entering their territory!");
                    }

                    dialogue.Add("Why not go hunting for some rare monsters every once in a while? Plenty of treasure to be looted and all that.");
                    //dialogue.Add("The desert monsters keep sending me letters about all the fossils they're collecting. I don't get the craze about it, myself!");

                    if (player.statLifeMax < 500)
                    {
                        dialogue.Add("If you ask me, Plantera is really letting herself go. Chlorophyte and Life Fruit aren't THAT healthy!");
                    }
                }

                if (NPC.downedPlantBoss)
                {
                    dialogue.Add("Trick or treat? Merry Christmas? I don't have anything for you, but go ask Pumpking or Ice Queen!");
                }

                Main.npcChatText = Main.rand.Next(dialogue);
            }
        }

        private void FargosLore()
        {
            IList<string> dialogue = new List<string>
            {
                "We all came from the end of time. This past world is a lot better than the timeless abyss of nothing!",
                "Lumberjack is 'the one who cuts.' That means trees, connections, and even severing alternate timelines.",
                "Who do you think we are? We're parts of you, a few hundred million years from now after you shed the need for a physical body.",
                "Mutant is inhabiting the physical shell of your future self, but we're all manifestations of your power and experience.",
                "In our first past, it took you eons to amass power. Since we happened to come back, we decided to help speed it up a little!",
                "Even if the three of us joined forces again, we still wouldn't regain the full power of our original self. You could probably still beat us!",
                "To accelerate your growth, Mutant released his powers to the rest of the world. Good work gathering it all back for yourself!",
                "Don't worry about our true names. We don't actually have any!",
                "No hard feelings about killing Abominationn, by the way. He comes back, right? Not that it won't miff Mutant if you do it again!",
                "We summon enemies and control events because we are them! Sort of. It's a long story.",
                "Take on a bigger form? I could do that, but I don't feel like it! Sorry!",
                "Why was Mutant in that big slime? It was the best way to power it up. Too bad he's too lazy to do that with the rest!",
                "Don't worry about the end of time, it's still billions of years away! I think. Dunno how this timey-wimey stuff works, really!",
                "There's no fighting Lumberjack at full power. He's already cut away every timeline in which you tried.",
                "Cthulhu? Hastur? All I know is where we came from, so your guess is as good as mine when it comes to them!",
                "I once heard Mutant mention a once cat-like being so far beyond us that its existence transcends cause and effect. It's more like a law of reality."
            };

            Main.npcChatText = Main.rand.Next(dialogue);
        }

        /*public override void NPCLoot()
        {
            if (Fargowiltas.ModLoaded("FargowiltasSouls") && NPC.AnyNPCs(Fargowiltas.FargosGetMod("FargowiltasSouls").NPCType("CosmosChampion")))
                Item.NewItem(npc.Hitbox, ModContent.ItemType<WalkingRick>());
        }*/

        /*public override void ModifyNPCLoot(ItemDropDatabase database)
        {
            if (Fargowiltas.ModLoaded("FargowiltasSouls"))
            {
                database.RegisterToNPC(ModContent.ItemType<WalkingRick>(), new ItemDropWithConditionRule(ModContent.ItemType<WalkingRick>(), 1, 1, 1, new ExtraItemDropRules.EridanusIsAlive()));
            }
        }*/
    }
}