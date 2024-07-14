using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Fargowiltas.NPCs;
using System;
using System.Linq;
using Terraria.ModLoader.IO;
using Fargowiltas.Projectiles;
using Fargowiltas.Items;
using Terraria.GameContent.Events;
using System.IO;
using Fargowiltas.Common.Configs;

////using Fargowiltas.Toggler;

namespace Fargowiltas
{
    public class FargoPlayer : ModPlayer
    {
        //        //public ToggleBackend Toggler = new ToggleBackend();
        //        public Dictionary<string, bool> TogglesToSync = new Dictionary<string, bool>();



        public bool extractSpeed;
        public bool HasDrawnDebuffLayer;
        internal bool BattleCry;
        internal bool CalmingCry;

        internal int originalSelectedItem;
        internal bool autoRevertSelectedItem;

        public float luckPotionBoost;
        public float ElementalAssemblerNearby;

        public float StatSheetMaxAscentMultiplier;
        public float StatSheetWingSpeed;
        public bool? CanHover = null;

        public int DeathFruitHealth;
        public bool bigSuck;

        public int StationSoundCooldown;

        internal Dictionary<string, bool> FirstDyeIngredients = [];

        public bool[] ItemHasBeenOwned; // If you've owned this item type ever

        private readonly string[] tags =
        [
            "RedHusk",
            "OrangeBloodroot",
            "YellowMarigold",
            "LimeKelp",
            "GreenMushroom",
            "TealMushroom",
            "CyanHusk",
            "SkyBlueFlower",
            "BlueBerries",
            "PurpleMucos",
            "VioletHusk",
            "PinkPricklyPear",
            "BlackInk"
        ];
        public override void Initialize()
        {
            ItemHasBeenOwned = ItemID.Sets.Factory.CreateBoolSet(false);
        }
        public override void SaveData(TagCompound tag)
        {
            string name = "FargoDyes" + Player.name;
            List<string> dyes = [];

            foreach (string tagString in tags)
            {

                if (FirstDyeIngredients.TryGetValue(tagString, out bool value))
                {
                    dyes.AddWithCondition(tagString, FirstDyeIngredients[tagString]);
                }
                else
                {
                    dyes.AddWithCondition(tagString, false);
                }
            }

            tag.Add(name, dyes);
            tag.Add("DeathFruitHealth", DeathFruitHealth);

            if (BattleCry)
                tag.Add($"FargoBattleCry{Player.name}", true);

            if (CalmingCry)
                tag.Add($"FargoCalmingCry{Player.name}", true);

            List<string> ownedItemsData = [];
            for (int i = 0; i < ItemHasBeenOwned.Length; i++)
            {
                if (ItemHasBeenOwned[i])
                {
                    if (i >= ItemID.Count) // modded item, variable type, add name instead
                    {
                        if (ItemLoader.GetItem(i) is ModItem modItem && modItem != null)
                            ownedItemsData.Add($"{modItem.FullName}");
                    }
                    else // vanilla item
                    {
                        ownedItemsData.Add($"{i}");
                    }
                }
            }
            tag.Add("OwnedItemsList", ownedItemsData);
        }

        //        public override void Initialize()
        //        {
        //            //Toggler.Load(this);
        //        }
        public override void LoadData(TagCompound tag)
        {
            string name = "FargoDyes" + Player.name;

            IList<string> dyes = tag.GetList<string>(name);
            foreach (string downedTag in tags)
            {
                FirstDyeIngredients[downedTag] = dyes.Contains(downedTag);
            }

            DeathFruitHealth = tag.GetInt("DeathFruitHealth");
            BattleCry = tag.ContainsKey($"FargoBattleCry{Player.name}");
            CalmingCry = tag.ContainsKey($"FargoCalmingCry{Player.name}");

            ItemHasBeenOwned = ItemID.Sets.Factory.CreateBoolSet(false);
            var ownedItemsData = tag.GetList<string>("OwnedItemsList");
            foreach (var entry in ownedItemsData)
            {
                if (int.TryParse(entry, out int type) && type < ItemID.Count)
                {
                    ItemHasBeenOwned[type] = true;
                }
                else
                {
                    ModItem item = ModContent.Find<ModItem>(entry);
                    ItemHasBeenOwned[item.Type] = true;
                }
            }
        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)9);
            packet.Write((byte)Player.whoAmI);
            packet.Write((byte)DeathFruitHealth);
            packet.Send(toWho, fromWho);
        }

        // Called in ExampleMod.Networking.cs
        public void ReceivePlayerSync(BinaryReader reader)
        {
            DeathFruitHealth = reader.ReadByte();
        }

        public override void CopyClientState(ModPlayer targetCopy)
        {
            FargoPlayer clone = (FargoPlayer)targetCopy;
            clone.DeathFruitHealth = DeathFruitHealth;
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            FargoPlayer clone = (FargoPlayer)clientPlayer;

            if (DeathFruitHealth != clone.DeathFruitHealth)
                SyncPlayer(toWho: -1, fromWho: Main.myPlayer, newPlayer: false);
        }
        public override void ModifyStartingInventory(IReadOnlyDictionary<string, List<Item>> itemsByMod, bool mediumCoreDeath)
        {
            foreach (string tag in tags)
            {
                FirstDyeIngredients[tag] = false;
            }
        }

        public override void OnEnterWorld()
        {
            Items.Misc.BattleCry.SyncCry(Player);
        }

        public override void ResetEffects()
        {
            extractSpeed = false;
            HasDrawnDebuffLayer = false;
            bigSuck = false;
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {

            if (Fargowiltas.HomeKey.JustPressed)
            {
                AutoUseMirror();
            }

            if (Fargowiltas.StatKey.JustPressed)
            {
                if (!Main.playerInventory)
                {
                    Main.playerInventory = true;
                }
                Fargowiltas.UserInterfaceManager.ToggleStatSheet();
            }
        }

        public override void PostUpdateBuffs()
        {
            if (FargoServerConfig.Instance.UnlimitedPotionBuffsOn120)
            {
                foreach (Item item in Player.bank.item)
                {
                    FargoGlobalItem.TryUnlimBuff(item, Player);
                }

                foreach (Item item in Player.bank2.item)
                {
                    FargoGlobalItem.TryUnlimBuff(item, Player);
                }
            }

            if (FargoServerConfig.Instance.PiggyBankAcc)
            {
                foreach (Item item in Player.bank.item)
                {
                    FargoGlobalItem.TryPiggyBankAcc(item, Player);
                }

                foreach (Item item in Player.bank2.item)
                {
                    FargoGlobalItem.TryPiggyBankAcc(item, Player);
                }
            }
        }
        public override void PostUpdateEquips()
        {
            if (Fargowiltas.SwarmActive)
            {
                Player.buffImmune[BuffID.Horrified] = true;
            }
        }
        public override void UpdateDead()
        {
            StationSoundCooldown = 0;
        }
        public override void PostUpdateMiscEffects()
        {
            if (ElementalAssemblerNearby > 0)
            {
                ElementalAssemblerNearby -= 1;
                Player.alchemyTable = true;
            }
            if (StationSoundCooldown > 0)
                StationSoundCooldown--;

            if (Player.equippedWings == null)
                ResetStatSheetWings();

            ForceBiomes();
        }

        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            #region Stat Sliders
            FargoServerConfig config = FargoServerConfig.Instance;
            if (config.EnemyDamage != 1 || config.BossDamage != 1)
            {
                bool boss = config.BossDamage > config.EnemyDamage && // only relevant if boss health is higher than enemy health
                    (npc.boss || npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail || (config.BossApplyToAllWhenAlive && FargoGlobalNPC.AnyBossAlive()));
                if (boss)
                    modifiers.FinalDamage *= config.BossDamage;
                else
                    modifiers.FinalDamage *= config.EnemyDamage;
            }
            #endregion
        }

        public void ResetStatSheetWings()
        {
            StatSheetMaxAscentMultiplier = 0;
            StatSheetWingSpeed = 0;
            CanHover = null;
        }

        private void ForceBiomes()
        {
            if (FargoGlobalNPC.SpecificBossIsAlive(ref FargoGlobalNPC.eaterBoss, NPCID.EaterofWorldsHead)
                && Player.Distance(Main.npc[FargoGlobalNPC.eaterBoss].Center) < 3000)
            {
                Player.ZoneCorrupt = true;
            }

            if (FargoGlobalNPC.SpecificBossIsAlive(ref FargoGlobalNPC.brainBoss, NPCID.BrainofCthulhu)
                && Player.Distance(Main.npc[FargoGlobalNPC.brainBoss].Center) < 3000)
            {
                Player.ZoneCrimson = true;
            }

            if ((FargoGlobalNPC.SpecificBossIsAlive(ref FargoGlobalNPC.plantBoss, NPCID.Plantera)
                && Player.Distance(Main.npc[FargoGlobalNPC.plantBoss].Center) < 3000)
                || (FargoGlobalNPC.SpecificBossIsAlive(ref FargoGlobalNPC.beeBoss, NPCID.QueenBee)
                && Player.Distance(Main.npc[FargoGlobalNPC.beeBoss].Center) < 3000))
            {
                Player.ZoneJungle = true;
            }

            if (FargoServerConfig.Instance.Fountains)
            {
                switch (Main.SceneMetrics.ActiveFountainColor)
                {
                    case -1: //no fountain active
                        goto default;

                    case 0: //pure water, ocean
                        Player.ZoneBeach = true;
                        break;

                    case 2: //corrupt
                        Player.ZoneCorrupt = true;
                        break;

                    case 3: //jungle
                        Player.ZoneJungle = true;
                        break;

                    case 4: //hallow
                        if (Main.hardMode)
                            Player.ZoneHallow = true;
                        break;

                    case 5: //ice
                        Player.ZoneSnow = true;
                        break;

                    case 6: //oasis
                        goto case 12;

                    case 8: //cavern
                        goto default;

                    case 9: //blood fountain
                        goto default;

                    case 10: //crimson
                        Player.ZoneCrimson = true;
                        break;

                    case 12: //desert fountain
                        Player.ZoneDesert = true;
                        if (Player.Center.Y > 3200f)
                            Player.ZoneUndergroundDesert = true;
                        break;

                    default:
                        break;
                }
            }
        }

        public override void PostUpdate()
        {
            if (autoRevertSelectedItem)
            {
                if (Player.itemTime == 0 && Player.itemAnimation == 0)
                {
                    Player.selectedItem = originalSelectedItem;
                    autoRevertSelectedItem = false;
                }
            }

            if (FargoWorld.OverloadedSlimeRain && Main.rand.NextBool(20))
            {
                SlimeRainSpawns();
            }
        }

        public void SlimeRainSpawns()
        {
            int type = NPCID.GreenSlime;

            int[] slimes = [NPCID.SlimeSpiked, NPCID.SandSlime, NPCID.IceSlime, NPCID.SpikedIceSlime, NPCID.MotherSlime, NPCID.SpikedJungleSlime, NPCID.DungeonSlime, NPCID.UmbrellaSlime, NPCID.ToxicSludge, NPCID.CorruptSlime, NPCID.Crimslime, NPCID.IlluminantSlime];

            int rand = Main.rand.Next(50);

            if (rand == 0)
            {
                type = NPCID.Pinky;
            }
            else if (rand < 20)
            {
                type = slimes[Main.rand.Next(slimes.Length)];
            }

            Vector2 pos = new Vector2((int)Player.position.X + Main.rand.Next(-800, 800), (int)Player.position.Y + Main.rand.Next(-800, -250));

            //Projectile.NewProjectile( pos, Vector2.Zero, ModContent.ProjectileType<SpawnProj>(), 0, 0, Main.myPlayer, type);
        }

        public override bool PreModifyLuck(ref float luck)
        {
            if (FargoWorld.Matsuri && !Main.IsItRaining && !Main.IsItStorming)
            {
                LanternNight.GenuineLanterns = true;
                LanternNight.ManualLanterns = false;
            }

            return base.PreModifyLuck(ref luck);
        }

        public override void ModifyLuck(ref float luck)
        {
            luck += luckPotionBoost;

            luckPotionBoost = 0; //look nowhere else works ok
        }

        public void AutoUseMirror()
        {
            int potionofReturn = -1;
            int recallPotion = -1;
            int magicMirror = -1;

            for (int i = 0; i < Player.inventory.Length; i++)
            {
                switch (Player.inventory[i].type)
                {
                    case ItemID.PotionOfReturn:
                        potionofReturn = i;
                        break;

                    case ItemID.RecallPotion:
                        recallPotion = i;
                        break;

                    case ItemID.MagicMirror:
                    case ItemID.IceMirror:
                    case ItemID.CellPhone:
                    case ItemID.Shellphone:
                        magicMirror = i;
                        break;
                }
            }

            if (potionofReturn != -1)
                QuickUseItemAt(potionofReturn);
            else if (recallPotion != -1)
                QuickUseItemAt(recallPotion);
            else if (magicMirror != -1)
                QuickUseItemAt(magicMirror);
        }
        public override void ModifyMaxStats(out StatModifier health, out StatModifier mana)
        {
            health = StatModifier.Default with { Base = -(DeathFruitHealth) };
            mana = StatModifier.Default;
        }

        public void QuickUseItemAt(int index, bool use = true)
        {
            if (!autoRevertSelectedItem && Player.selectedItem != index && Player.inventory[index].type != 0)
            {
                originalSelectedItem = Player.selectedItem;
                autoRevertSelectedItem = true;
                Player.selectedItem = index;
                Player.controlUseItem = true;
                if (use && CombinedHooks.CanUseItem(Player, Player.inventory[Player.selectedItem]))
                {
                    if (Player.whoAmI == Main.myPlayer)
                        Player.ItemCheck();
                    //Player.ItemCheck(Main.myPlayer);
                }
            }
        }

        //        /*public override void clientClone(ModPlayer clientClone)
        //        {
        //            FargoPlayer modPlayer = clientClone as FargoPlayer;
        //            modPlayer.Toggler = Toggler;
        //        }*/

        //        /*public void SyncToggle(string key)
        //        {
        //            if (!TogglesToSync.ContainsKey(key))
        //                TogglesToSync.Add(key, player.GetToggle(key).ToggleBool);
        //        }*/

        //        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        //        {
        //            foreach (KeyValuePair<string, bool> toggle in TogglesToSync)
        //            {
        //                ModPacket packet = mod.GetPacket();

        //                packet.Write((byte)80);
        //                packet.Write((byte)player.whoAmI);
        //                packet.Write(toggle.Key);
        //                packet.Write(toggle.Value);

        //                packet.Send(toWho, fromWho);
        //            }

        //            TogglesToSync.Clear();
        //        }

        //        /*public override void SendClientChanges(ModPlayer clientPlayer)
        //        {
        //            FargoPlayer modPlayer = clientPlayer as FargoPlayer;
        //            if (modPlayer.Toggler.Toggles != Toggler.Toggles)
        //            {
        //                ModPacket packet = mod.GetPacket();
        //                packet.Write((byte)79);
        //                packet.Write((byte)player.whoAmI);
        //                packet.Write((byte)Toggler.Toggles.Count);

        //                for (int i = 0; i < Toggler.Toggles.Count; i++)
        //                {
        //                    packet.Write(Toggler.Toggles.Values.ElementAt(i).ToggleBool);
        //                }

        //                packet.Send();
        //            }
        //        }*/
    }
}
