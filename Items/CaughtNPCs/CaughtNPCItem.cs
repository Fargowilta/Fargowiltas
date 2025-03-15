using Fargowiltas.Common.Configs;
using Fargowiltas.NPCs;
using Fargowiltas.Utilities.Extensions;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class CaughtNPCItem : ModItem
    {
        internal static Dictionary<int, int> CaughtTownies = new();

        public override string Name => _name;

        public string _name;
        public int AssociatedNpcId;
        public string NpcQuote;

        public CaughtNPCItem()
        {
            _name = base.Name;
            AssociatedNpcId = NPCID.None;
            NpcQuote = "";
        }

        public CaughtNPCItem(string internalName, int associatedNpcId, string npcQuote = "")
        {
            _name = internalName;
            AssociatedNpcId = associatedNpcId;
            NpcQuote = npcQuote;
        }

        public override bool IsLoadingEnabled(Mod mod) => AssociatedNpcId != NPCID.None;

        protected override bool CloneNewInstances => true;

        public override ModItem Clone(Item item)
        {
            CaughtNPCItem clone = base.Clone(item) as CaughtNPCItem;
            clone._name = _name;
            clone.AssociatedNpcId = AssociatedNpcId;
            clone.NpcQuote = NpcQuote;
            return clone;
        }

        public override bool IsCloneable => true;

        public override void Unload()
        {
            CaughtTownies.Clear();
        }

        public override string Texture => AssociatedNpcId < NPCID.Count ? $"Terraria/Images/NPC_{AssociatedNpcId}" : NPCLoader.GetNPC(AssociatedNpcId).Texture;

        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(6, Main.npcFrameCount[AssociatedNpcId]));
            ItemID.Sets.AnimatesAsSoul[Type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToCapturedCritter(AssociatedNpcId);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item44;

            if (AssociatedNpcId == NPCID.Angler)
            {
                Item.bait = 15;
            }
        }

        public override void PostUpdate()
        {
            if (AssociatedNpcId != NPCID.Guide || !Item.lavaWet || NPC.AnyNPCs(NPCID.WallofFlesh))
            {
                return;
            }

            NPC.SpawnWOF(Item.position);
            Item.TurnToAir();
        }

        public override bool CanUseItem(Player player)
        {
            //replaced tile in range check because items like toolbox exist and npcs just dont spawn if placed too far
            //what the fuck is terraria code anyway
            return player.Distance(Main.MouseWorld) < 4 * 16
                && !Collision.SolidCollision(Main.MouseWorld - player.DefaultSize / 2, (int)player.DefaultSize.X, (int)player.DefaultSize.Y)
                && NPC.CountNPCS(AssociatedNpcId) < 5;
        }

        public override bool? UseItem(Player player)
        {
            return null;
        }

        public static void RegisterItems()
        {
            CaughtTownies = new Dictionary<int, int>();

            // manually register mutant and vanillas
            Add("Abominationn", ModContent.NPCType<Abominationn>(), "'I sure wish I was a boss.'");
            Add("Angler", NPCID.Angler, "'You'd be a great helper minion!'");
            Add("ArmsDealer", NPCID.ArmsDealer, "'Keep your hands off my gun, buddy!'");
            Add("Clothier", NPCID.Clothier, "'Thanks again for freeing me from my curse.'");
            Add("Cyborg", NPCID.Cyborg,
                "'My expedition efficiency was critically reduced when a projectile impacted my locomotive actuator.'");
            Add("Demolitionist", NPCID.Demolitionist, "'It's a good day to die!'");
            Add("Deviantt", ModContent.NPCType<Deviantt>(),
                "'Embrace suffering... and while you're at it, embrace another purchase!'");
            Add("Dryad", NPCID.Dryad, "'Be safe; Terraria needs you!'");
            Add("DyeTrader", NPCID.DyeTrader, "'My dear, what you're wearing is much too drab.'");
            Add("GoblinTinkerer", NPCID.GoblinTinkerer, "'Looking for a gadgets expert? I'm your goblin!'");
            Add("Golfer", NPCID.Golfer, "'An early bird catches the worm, but an early hole catches the birdie.'");
            Add("Guide", NPCID.Guide, "'They say there is a person who will tell you how to survive in this land.'");
            Add("LumberJack", ModContent.NPCType<LumberJack>(),
                "'I eat a bowl of woodchips for breakfast... without any milk.'");
            Add("Mechanic", NPCID.Mechanic, "'Always buy more wire than you need!'");
            Add("Merchant", NPCID.Merchant, "'Did you say gold? I'll take that off of ya.'");
            Add("Mutant", ModContent.NPCType<Mutant>(), "'You're lucky I'm on your side.'");
            Add("Nurse", NPCID.Nurse, "'Show me where it hurts.'");
            Add("Painter", NPCID.Painter,
                "'I know the difference between turquoise and blue-green. But I won't tell you.'");
            Add("PartyGirl", NPCID.PartyGirl, "'We have to talk. It's... it's about parties.'");
            Add("Pirate", NPCID.Pirate, "'Stay off me booty, ya scallywag!'");
            Add("SantaClaus", NPCID.SantaClaus, "'What? You thought I wasn't real?'");
            Add("SkeletonMerchant", NPCID.SkeletonMerchant,
                "'You would not believe some of the things people throw at me... Wanna buy some of it?'");
            //if (ModLoader.TryGetMod("FargowiltasSouls", out Mod fargoSouls))
            Add("Squirrel", ModContent.NPCType<Squirrel>(), "*squeak*");
            Add("Steampunker", NPCID.Steampunker, "'Show me some gears!'");
            Add("Stylist", NPCID.Stylist, "'Did you even try to brush your hair today?'");
            Add("Tavernkeep", NPCID.DD2Bartender, "'What am I doing here...'");
            Add("TaxCollector", NPCID.TaxCollector, "'You again? Suppose you want more money!?'");
            Add("TravellingMerchant", NPCID.TravellingMerchant,
                "'I sell wares from places that might not even exist!'");
            Add("Truffle", NPCID.Truffle, "'Everyone in this town feels a bit off.'");
            Add("WitchDoctor", NPCID.WitchDoctor, "'Which doctor am I? The Witch Doctor am I.'");
            Add("Wizard", NPCID.Wizard, "'Want me to pull a coin from behind your ear? No? Ok.'");

            Add("Zoologist", NPCID.BestiaryGirl, "'I love animals, like, a lot!'");
            Add("Princess", NPCID.Princess, "'Pink is the best color anyone could ask for!'");

            //town pets
            Add("TownDog", NPCID.TownDog, "'Woof!'");
            Add("TownCat", NPCID.TownCat, "'Meow!'");
            Add("TownBunny", NPCID.TownBunny, "'*Bunny noises*'");
        }

        public static void Add(string internalName, int id, string quote)
        {
            CaughtNPCItem item = new(internalName, id, quote);
            Fargowiltas.Instance.AddContent(item);
            CaughtTownies.Add(id, item.Type);
        }
    }

    public class CaughtGlobalNPC : GlobalNPC
    {
        private static HashSet<int> npcCatchableWasFalse;

        public override void Load()
        {
            npcCatchableWasFalse = new HashSet<int>();
        }

        public override void Unload()
        {
            if (npcCatchableWasFalse != null)
            {
                foreach (var type in npcCatchableWasFalse)
                {
                    //Failing to unload this properly causes it to bleed into un-fargowiltas gameplay, causing various issues such as clients not being able to join a server
                    Main.npcCatchable[type] = false;
                }
                npcCatchableWasFalse = null;
            }
        }

        public override void SetDefaults(NPC npc)
        {
            int type = npc.type;
            if (CaughtNPCItem.CaughtTownies.ContainsKey(type) && FargoServerConfig.Instance.CatchNPCs)
            {
                npc.catchItem = (short)CaughtNPCItem.CaughtTownies.FirstOrDefault(x => x.Key.Equals(type)).Value;
                if (!Main.npcCatchable[type])
                {
                    npcCatchableWasFalse.Add(type);
                    Main.npcCatchable[type] = true;
                }
            }
        }
    }
}
