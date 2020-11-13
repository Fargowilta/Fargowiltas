using Fargowiltas.Buffs;
using Fargowiltas.Utilities;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.ItemDropRules
{
    public static class ExtraItemDropRules
    {
        public class HasWoodDrop : IItemDropRuleCondition, IProvideItemConditionDescription
        {
            public bool CanDrop(DropAttemptInfo info) => info.npc.HasBuff(ModContent.BuffType<WoodDrop>());

            public bool CanShowItemDropInUI() => true;

            public string GetConditionDescription() => "If the NPC has the Wood Drop buff, which is inflicted by the Lumber Jaxe.";
        }

        public class MoonLordIsAlive : IItemDropRuleCondition, IProvideItemConditionDescription
        {
            public bool CanDrop(DropAttemptInfo info) => NPC.AnyNPCs(NPCID.MoonLordCore);

            public bool CanShowItemDropInUI() => true;

            public string GetConditionDescription() => "If the Moon Lord is currently alive.";
        }

        public class EridanusIsAlive : IItemDropRuleCondition, IProvideItemConditionDescription
        {
            public bool CanDrop(DropAttemptInfo info) => NPC.AnyNPCs(Fargowiltas.LoadedMods["FargowiltasSouls"].NPCType("ComsmosChampion"));

            public bool CanShowItemDropInUI() => true;

            public string GetConditionDescription() => "If Eridanus, Champion of Cosmos is currently alive.";
        }

        public class DD2EventIsNotOngoing : IItemDropRuleCondition, IProvideItemConditionDescription
        {
            public bool CanDrop(DropAttemptInfo info) => !DD2Event.Ongoing;

            public bool CanShowItemDropInUI() => true;

            public string GetConditionDescription() => "If the Dungeon Defenders 2 Event is not ongoing.";
        }

        public class DD2EventIsNotOngoingShouldDropCrystals : IItemDropRuleCondition, IProvideItemConditionDescription
        {
            public bool CanDrop(DropAttemptInfo info) => !DD2Event.Ongoing && DD2Event.ShouldDropCrystals();

            public bool CanShowItemDropInUI() => false;

            public string GetConditionDescription() => "";
        }

        /// <summary>
        /// Makes the NPC drop multiple items at the same time.
        /// </summary>
        /// <param name="dropsOutOfX"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IItemDropRule AllFromOptions(int dropsOutOfX, params int[] items) => new MultipleItemsDropRule(dropsOutOfX, 1, items);
    }
}