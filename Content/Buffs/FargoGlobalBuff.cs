using Fargowiltas.Common.Configs;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Buffs
{
    public class FargoGlobalBuff : GlobalBuff
    {
        static bool BuffCanBeHidden(Player player, int buffIndex)
        {
            int buffTime = player.buffTime[buffIndex];
            int buffType = player.buffType[buffIndex];
            return buffTime <= 2
                && (!Main.debuff[buffType] || buffType == BuffID.Tipsy)
                && !Main.buffNoTimeDisplay[buffType]
                && !BuffID.Sets.TimeLeftDoesNotDecrease[buffType];
        }

        public override void Update(int type, Player player, ref int buffIndex)
        {
            if (type == BuffID.Lucky && player.GetModPlayer<FargoPlayer>().luckPotionBoost > 0 && player.buffTime[buffIndex] > 2)
            {
                player.buffTime[buffIndex] = 2;
            }

            //basically all of this is to reorganize buffs with hidden unlims
            //if unorganized, the hidden buffs are just hidden and leaves open gaps in the buff tray
            //yes, this causes the swapped visible buff to be skipped for a tick
            //there has to be a better way to do this...
            if (player.whoAmI == Main.myPlayer)
            {
                bool canBeHidden = BuffCanBeHidden(player, buffIndex);
                if (canBeHidden && FargoClientConfig.Instance.HideUnlimitedBuffs)
                {
                    if (buffIndex + 1 < player.buffType.Length) //check it's not end of array
                    {
                        //check if next buff can be hidden
                        int nextBuffIndex = buffIndex + 1;
                        bool nextBuffCanBeHidden = BuffCanBeHidden(player, nextBuffIndex);

                        //if next buff is a visible buff
                        if (!nextBuffCanBeHidden)
                        {
                            //look for somewhere to put it
                            int indexToSwap = buffIndex;
                            while (indexToSwap >= 0) //end of array check
                            {
                                //keep walking backwards through the buffs until you find another visible one
                                bool indexCanBeHidden = BuffCanBeHidden(player, indexToSwap);

                                //found another visible buff or reached first index (they are all invisible)
                                if (!indexCanBeHidden || indexToSwap == 0)
                                {
                                    //swap the leftmost hidden unlim buff with the "floating" visible buff
                                    if (!indexCanBeHidden)
                                        indexToSwap++;
                                    int tempBuffType = player.buffType[indexToSwap];
                                    int tempBuffTime = player.buffTime[indexToSwap];
                                    player.buffType[indexToSwap] = player.buffType[buffIndex + 1];
                                    player.buffTime[indexToSwap] = player.buffTime[buffIndex + 1];
                                    player.buffType[buffIndex + 1] = tempBuffType;
                                    player.buffTime[buffIndex + 1] = tempBuffTime;
                                    //buffIndex = indexToSwap;
                                    break;
                                }

                                indexToSwap--;
                            }
                        }
                    }
                }
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, int type, int buffIndex, ref BuffDrawParams drawParams)
        {
            if (BuffCanBeHidden(Main.LocalPlayer, buffIndex) && FargoClientConfig.Instance.HideUnlimitedBuffs)
            {
                return false;
            }
            return true;
        }
    }
}