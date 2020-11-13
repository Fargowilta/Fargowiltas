using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public abstract class SwarmSummonBase : ModItem
    {
        //wof only
        private int counter = 0;

        private int npcType;
        private readonly int maxSpawn; //energizer swarms are this size
        private readonly string spawnMessage;
        private readonly string material;

        protected SwarmSummonBase(int npcType, string spawnMessage, int maxSpawn, string material)
        {
            this.npcType = npcType;
            this.spawnMessage = spawnMessage;
            this.maxSpawn = maxSpawn;
            this.material = material;
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 100;
            item.value = 10000;
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.consumable = true;

            if (npcType == NPCID.WallofFlesh)
            {
                item.useAnimation = 20;
                item.useTime = 2;
                item.consumable = false;
            }
        }

        public override bool UseItem(Player player)
        {
            Fargowiltas.SwarmActive = true;
            Fargowiltas.SwarmTotal = 10 * player.inventory[player.selectedItem].stack;
            Fargowiltas.SwarmKills = 0;

            if (Fargowiltas.SwarmTotal < 100)
            {
                Fargowiltas.SwarmSpawned = 10;
            }
            else
            {
                //energizer swarms
                Fargowiltas.SwarmSpawned = maxSpawn;
            }

            //DG special case
            if (npcType == NPCID.SkeletronHead && Main.dayTime)
            {
                npcType = NPCID.DungeonGuardian;
            }
            //twins special case
            else if (npcType == NPCID.Retinazer)
            {
                Fargowiltas.SwarmTotal *= 2;
            }

            //wof mega special case
            if (npcType == NPCID.WallofFlesh)
            {
                FargoGlobalNPC.SpawnWalls(player);

                counter++;

                if (counter < 10)
                {
                    return true;
                }
            }
            else
            {
                //spawn the bosses
                for (int i = 0; i < Fargowiltas.SwarmSpawned; i++)
                {
                    //spawn the other twin as well
                    if (npcType == NPCID.Retinazer)
                    {
                        int twin = NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), NPCID.Spazmatism);
                        Main.npc[twin].GetGlobalNPC<FargoGlobalNPC>().swarmActive = true;
                    }

                    int boss = NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), npcType);
                    Main.npc[boss].GetGlobalNPC<FargoGlobalNPC>().swarmActive = true;
                }
            }

            // Kill whole stack
            player.inventory[player.selectedItem].stack = 0;

            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(spawnMessage), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText(spawnMessage, 175, 75, 255);
            }

            SoundEngine.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);

            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(null, material);
            recipe.AddIngredient(null, "Overloader");
            recipe.AddTile(TileID.DemonAltar);            recipe.Register();
        }
    }
}