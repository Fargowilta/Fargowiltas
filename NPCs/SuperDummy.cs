using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    public class SuperDummy : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Super Dummy");

            NPCID.Sets.NPCBestiaryDrawModifiers bestiaryData = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Hide = true
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, bestiaryData);


        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.TargetDummy);
            NPC.lifeMax = int.MaxValue;
            NPC.aiStyle = -1;
            NPC.width = 28;
            NPC.height = 50;
            NPC.immortal = false;
            NPC.npcSlots = 0;
            NPC.dontCountMe = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) => false;
        public override void OnSpawn(IEntitySource source)
        {
            NPC.life = NPC.lifeMax = int.MaxValue;
        }
        public override void AI()
        {
            NPC.life = NPC.lifeMax = int.MaxValue;

            if (FargoGlobalNPC.AnyBossAlive())
            {
                NPC.life = 0;
                NPC.HitEffect();
                NPC.SimpleStrikeNPC(int.MaxValue, 0, false, 0, null, false, 0, true);
                //NPC.StrikeNPCNoInteraction(int.MaxValue, 0, 0, false, false, false);
            }
        }

        public override bool CheckDead() => false;
    }
}
