﻿using Fargowiltas.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Fargowiltas
{
    internal class DevianttDialogueTracker
    {
        public static class HelpDialogueType
        {
            public static readonly byte BossOrEvent = 0;
            public static readonly byte Environment = 1;
            public static readonly byte Misc = 2;
        }

        public struct HelpDialogue
        {
            public readonly string Message;
            public readonly byte Type;
            public readonly Predicate<string> Predicate;

            public HelpDialogue(string message, byte type, Predicate<string> predicate)
            {
                Message = message;
                Type = type;
                Predicate = predicate;
            }

            public bool CanDisplay(string deviName) => Predicate(deviName);
        }

        public List<HelpDialogue> PossibleDialogue;
        private int lastDialogueType;

        public DevianttDialogueTracker()
        {
            PossibleDialogue = new List<HelpDialogue>();
        }

        public void AddDialogue(string message, byte type, Predicate<string> predicate)
        {
            PossibleDialogue.Add(new HelpDialogue(message, type, predicate));
        }

        public string GetDialogue(string deviName)
        {
            WeightedRandom<string> dialogueChooser = new WeightedRandom<string>();
            (List<HelpDialogue> sortedDialogue, int type) = SortDialogue(deviName);

            foreach (HelpDialogue dialogue in sortedDialogue)
            {
                dialogueChooser.Add(dialogue.Message);
            }

            lastDialogueType = type;
            return dialogueChooser;
        }

        private (List<HelpDialogue> sortedDialogue, int type) SortDialogue(string deviName)
        {
            List<HelpDialogue> sortedDialogue = new List<HelpDialogue>();
            int typeChoice = 0;
            int attempts = 0;
            while (true)
            {
                attempts++;
                typeChoice = Main.rand.Next(3);
                if (typeChoice != lastDialogueType || typeChoice == HelpDialogueType.Misc) // There's a lot more misc so allow repeats
                {
                    sortedDialogue = PossibleDialogue.Where((dialogue) => dialogue.Type == typeChoice && dialogue.CanDisplay(deviName)).ToList();

                    if (sortedDialogue.Count != 0)
                        break;
                }
                
                if (attempts == 100)
                {
                    typeChoice = HelpDialogueType.BossOrEvent;
                    sortedDialogue = PossibleDialogue.Where((dialogue) => dialogue.Type == typeChoice && dialogue.CanDisplay(deviName)).ToList();
                    break;
                }
            }

            return (sortedDialogue, typeChoice);
        }

        public void AddVanillaDialogue()
        {
            AddDialogue("What's that? You want to fight me for real? ...nah, I can't put up a good fight on my own.",
                HelpDialogueType.BossOrEvent, (name) => (bool)(ModLoader.GetMod("FargowiltasSouls").Call("DownedMutant") ?? false));

            AddDialogue("What's that? You want to fight my big brother? ...maybe if he had a reason to.",
                HelpDialogueType.BossOrEvent, (name) => (bool)(ModLoader.GetMod("FargowiltasSouls").Call("DownedAbom") ?? false) && !(bool)(ModLoader.GetMod("FargowiltasSouls").Call("DownedMutant") ?? false));

            AddDialogue("Now's a good time to go for damage on your accessory modifiers. Keep an eye on your enemies and look for patterns!",
                HelpDialogueType.Misc, (name) => NPC.downedMoonlord && !(bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedAbom"));

            AddDialogue("Only a specific type of weapon will work against each specific pillar. As for that moon guy, his weakness will keep changing.",
                HelpDialogueType.BossOrEvent, (name) => NPC.downedAncientCultist && !NPC.downedMoonlord);

            AddDialogue("Some powerful enemies like that dungeon guy can create their own arenas. You won't be able to escape, so make full use of the room you do have.",
                HelpDialogueType.BossOrEvent, (name) => NPC.downedFishron && !NPC.downedAncientCultist);

            AddDialogue("Did you beat that fish pig dragon yet? He's strong enough to break defenses in one hit. Too bad you don't have any reinforced plating to prevent that, right?",
                HelpDialogueType.BossOrEvent, (name) => NPC.downedGolemBoss && !NPC.downedFishron);

            AddDialogue("That golem? It gets upset when you leave the temple, so fighting in there is best. Platforms won't work, but a Lihzahrd Instactuation Bomb can help clear space!",
                HelpDialogueType.BossOrEvent, (name) => NPC.downedPlantBoss && !NPC.downedGolemBoss);

            AddDialogue("That overgrown plant inflicts a special venom that works her into an enraged frenzy. She also has a ring of crystal leaves, but minions go through it.",
                HelpDialogueType.BossOrEvent, (name) => NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !NPC.downedPlantBoss);

            //AddDialogue("Watch out when you break your fourth altar! It might attract the pirates, so be sure you're ready when you do it.", HelpDialogueType.BossOrEvent, (name) => Main.hardMode && !NPC.downedPirates);

            AddDialogue("That metal worm has a few upgrades, but its probes were downgraded to compensate. It'll start shooting homing dark stars and flying. When it coils around you, don't try to escape!",
                HelpDialogueType.BossOrEvent, (name) => Main.hardMode && !NPC.downedMechBoss1);

            AddDialogue("I saw that metal eye spinning while firing a huge laser the other day. Also, even if you kill them, they won't die until they're both killed!",
                HelpDialogueType.BossOrEvent, (name) => Main.hardMode && !NPC.downedMechBoss2);

            AddDialogue("Focus on taking down that metal skull, not its limbs. Don't try to outrun its spinning limbs! Keep your eyes open and learn to recognize what's doing what.",
                HelpDialogueType.BossOrEvent, (name) => Main.hardMode && !NPC.downedMechBoss3);

            AddDialogue("That thing's mouth is as good as immune to damage, so you'll have to aim for the eye. Only one of them is vulnerable at a time, though. What thing? You know, that thing!",
                HelpDialogueType.BossOrEvent, (name) => (bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedDevi") && !Main.hardMode);

            AddDialogue("Next up is me! Make sure you learn to recognize whatever attack I'll throw at you. Quick tip: you won't turn to stone if I can't see your eyes!",
                HelpDialogueType.BossOrEvent, (name) => NPC.downedBoss3 && (bool)ModLoader.GetMod("FargowiltasSouls").Call("DownedDevi"));

            AddDialogue("The master of the dungeon can revive itself with a sliver of life for a last stand. Be ready to run for it when you make the killing blow!",
                HelpDialogueType.BossOrEvent, (name) => NPC.downedQueenBee && !NPC.downedBoss3);

            AddDialogue("The queen bee will summon her progeny for backup. She's harder to hurt while they're there, so take them out first. Oh, and her swarm can't hit right above or below her!",
                HelpDialogueType.BossOrEvent, (name) => NPC.downedBoss2 && !NPC.downedQueenBee);

            AddDialogue("Focus on how the ichor moves and don't get overwhelmed! When the brain gets mad, it'll confuse you every few seconds. Four rings to confuse you, one ring when it wears off!",
                HelpDialogueType.BossOrEvent, (name) => NPC.downedBoss1 && !NPC.downedBoss2 && WorldGen.crimson);

            AddDialogue("The more the world eater splits, the more worms can rush you at once. The head is extra sturdy now, but don't let them pile up too much!",
                HelpDialogueType.BossOrEvent, (name) => NPC.downedBoss1 && !NPC.downedBoss2 && !WorldGen.crimson);

            AddDialogue("Watch out when you break your second Crimson Heart! It might attract the goblins, so prepare before you do it.",
                HelpDialogueType.BossOrEvent, (name) => !NPC.downedGoblins && WorldGen.crimson);

            AddDialogue("Watch out when you break your second Shadow Orb! It might attract the goblins, so prepare before you do it.",
                HelpDialogueType.BossOrEvent, (name) => !NPC.downedGoblins && !WorldGen.crimson);

            // I added this because, if there isn't always dialogue available for a boss, the dialogue chooser self destructs
            AddDialogue("That big eyeball has the power of the moon, but it's too flashy for its own good! Learn to notice and focus only on the bits that threaten to hurt you.",
                HelpDialogueType.BossOrEvent, (name) => NPC.downedSlimeKing && !NPC.downedBoss1);

            AddDialogue("Gonna fight that slime king soon? Don't spend too long up and out of his reach or he'll get mad. Very, very mad.",
                HelpDialogueType.BossOrEvent, (name) => !NPC.downedSlimeKing);

            AddDialogue("Seems like everyone's learning to project auras these days. If you look at the particles, you can see whether it'll affect you at close range or a distance!",
                HelpDialogueType.Misc, (name) => true);

            AddDialogue("There's probably a thousand items to protect against all these debuffs. It's a shame you don't have a thousand hands to carry them all at once!",
                HelpDialogueType.Misc, (name) => true);

            AddDialogue("Don't forget you can turn off your soul toggles in the Mod Configurations menu!",
                HelpDialogueType.Misc, (name) => true);

            AddDialogue("Just so you know, ammos are less effective. Only a bit of their damage contributes to your total output!",
                HelpDialogueType.Misc, (name) => Main.LocalPlayer.HeldItem.ranged);

            AddDialogue("Found any Top Hat Squirrels yet? Keep one in your inventory and maybe a special friend will show up!",
                HelpDialogueType.Misc, (name) => !NPC.AnyNPCs(ModContent.NPCType<Squirrel>()));

            AddDialogue("I don't have any more Life Crystals for you, but Cthulhu's eye is going on a new diet of them. Not that they would share!",
                HelpDialogueType.Misc, (name) => Main.LocalPlayer.statLifeMax < 400);

            //AddDialogue("I've always wondered why those other monsters never bothered to carry any healing potions. Well, you probably shouldn't wait and see if they actually do.", HelpDialogueType.Misc, (name) => !Main.hardMode);

            AddDialogue("Watch out for those fish! Sharks will leave you alone if you leave them alone, but piranhas go wild when they smell blood.",
                HelpDialogueType.Misc, (name) => !Main.hardMode);

            AddDialogue("The water is bogging you down? Never had an issue with it, personally... Have you tried breathing water instead of air?",
                HelpDialogueType.Environment, (name) => !Main.LocalPlayer.accFlipper && !Main.LocalPlayer.gills && !(bool)(ModLoader.GetMod("FargowiltasSouls").Call("MutantAntibodies") ?? false));

            AddDialogue("The underworld has gotten a lot hotter since the last time I visited. I hear an obsidian skull is a good luck charm against burning alive, though!",
                HelpDialogueType.Environment, (name) => !Main.LocalPlayer.fireWalk && !(Main.LocalPlayer.lavaMax > 0) && !Main.LocalPlayer.buffImmune[BuffID.OnFire] && !(bool)(ModLoader.GetMod("FargowiltasSouls").Call("PureHeart") ?? false));

            AddDialogue("Want to have a breath-holding contest? The empty vacuum of space would be perfect. No, I won't cheat by breathing water instead of air!",
                HelpDialogueType.Environment, (name) => !Main.LocalPlayer.buffImmune[BuffID.Suffocation] && !(bool)(ModLoader.GetMod("FargowiltasSouls").Call("PureHeart") ?? false));

            //AddDialogue("The spirits of light and dark stopped by and they sounded pretty upset with you. Don't be too surprised if something happens to you for entering their territory!", HelpDialogueType.Environment, (name) => Main.hardMode && !(bool)(ModLoader.GetMod("FargowiltasSouls").Call("PureHeart") ?? false));

            //AddDialogue("Why not go hunting for some rare monsters every once in a while? Plenty of treasure to be looted and all that.", HelpDialogueType.Misc, (name) => Main.hardMode);

            AddDialogue("That's a funny face you're making... Is the underground Hallow too disorienting? Try controlling gravity on your own and maybe it can't flip you by force!",
                HelpDialogueType.Environment, (name) => Main.hardMode && !(bool)(ModLoader.GetMod("FargowiltasSouls").Call("PureHeart") ?? false));

            AddDialogue("If you ask me, Plantera is really letting herself go. Chlorophyte and Life Fruit aren't THAT healthy!",
                HelpDialogueType.Misc, (name) => Main.hardMode && Main.LocalPlayer.statLifeMax2 < 500);

            // This is much more possible than before because of how branching works, so I just decided to remove it.
            //AddDialogue("Ever tried out those 'enchantment' thingies? Try breaking a couple altars and see what you can make.",
            //    HelpDialogueType.Misc, (name) => Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3);
        }
    }
}