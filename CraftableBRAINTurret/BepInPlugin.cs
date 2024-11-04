using BepInEx;
using CG.Client.UserData;
using ResourceAssets;
using VoidManager.Content;
using VoidManager.Utilities;

namespace CraftableBRAINTurret
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Void Crew.exe")]
    [BepInDependency(VoidManager.MyPluginInfo.PLUGIN_GUID)]
    public class BepinPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            GUIDUnion AutoBenedictionMk1GUID = new GUIDUnion("6b2c6be56b6678643bd0039305890622");
            GUIDUnion AutoBenedictionMk2GUID = new GUIDUnion("57a0ed79bfb068647a8fbef4bd619e1e");
            GUIDUnion AutoBenedictionMk3GUID = new GUIDUnion("5527af35a54518042b4c3712846f4bb2");
            GUIDUnion AutoCarronadeMk1GUID = new GUIDUnion("bc2dcf53afe3a90478b5d9fcffb1f523");
            GUIDUnion AutoCarronadeMk2GUID = new GUIDUnion("2f592cf15994875469eda092a4b159f0");
            GUIDUnion AutoCarronadeMk3GUID = new GUIDUnion("86d4f5371b6f29446a5795ac8eb41c70");

            //Setup Crafting rules (alloy or insription, cost and recyclability)
            CraftingRules Mk1cr = Craftables.Instance.GetRecipe(AutoBenedictionMk1GUID);
            Mk1cr.CraftingMethod = CraftMethod.ItemExchange;
            Mk1cr.ItemExchangeInfo = new CraftableWithItemExchange(ItemExchangeType.BlankBox, 1);

            CraftingRules Mk2cr = Craftables.Instance.GetRecipe(AutoBenedictionMk2GUID);
            Mk2cr.CraftingMethod = CraftMethod.ItemExchange;
            Mk2cr.ItemExchangeInfo = new CraftableWithItemExchange(ItemExchangeType.BlankBox, 2);

            CraftingRules Mk3cr = Craftables.Instance.GetRecipe(AutoBenedictionMk3GUID);
            Mk3cr.CraftingMethod = CraftMethod.ItemExchange;
            Mk3cr.ItemExchangeInfo = new CraftableWithItemExchange(ItemExchangeType.BlankBox, 3);

            CraftingRules CMk1cr = Craftables.Instance.GetRecipe(AutoCarronadeMk1GUID);
            Mk1cr.CraftingMethod = CraftMethod.ItemExchange;
            Mk1cr.ItemExchangeInfo = new CraftableWithItemExchange(ItemExchangeType.BlankBox, 1);

            CraftingRules CMk2cr = Craftables.Instance.GetRecipe(AutoCarronadeMk2GUID);
            Mk2cr.CraftingMethod = CraftMethod.ItemExchange;
            Mk2cr.ItemExchangeInfo = new CraftableWithItemExchange(ItemExchangeType.BlankBox, 2);

            CraftingRules CMk3cr = Craftables.Instance.GetRecipe(AutoCarronadeMk3GUID);
            Mk3cr.CraftingMethod = CraftMethod.ItemExchange;
            Mk3cr.ItemExchangeInfo = new CraftableWithItemExchange(ItemExchangeType.BlankBox, 3);


            //Unlocks for crafting
            Unlocks.Instance.SetUnlockOptions(AutoBenedictionMk1GUID, MyPluginInfo.PLUGIN_GUID, new UnlockOptions() { UnlockCriteria = UnlockCriteriaType.Always });
            Unlocks.Instance.SetUnlockOptions(AutoBenedictionMk2GUID, MyPluginInfo.PLUGIN_GUID, new UnlockOptions() { UnlockCriteria = UnlockCriteriaType.Always });
            Unlocks.Instance.SetUnlockOptions(AutoBenedictionMk3GUID, MyPluginInfo.PLUGIN_GUID, new UnlockOptions() { UnlockCriteria = UnlockCriteriaType.Always });
            Unlocks.Instance.SetUnlockOptions(AutoCarronadeMk1GUID, MyPluginInfo.PLUGIN_GUID, new UnlockOptions() { UnlockCriteria = UnlockCriteriaType.Always });
            Unlocks.Instance.SetUnlockOptions(AutoCarronadeMk2GUID, MyPluginInfo.PLUGIN_GUID, new UnlockOptions() { UnlockCriteria = UnlockCriteriaType.Always });
            Unlocks.Instance.SetUnlockOptions(AutoCarronadeMk3GUID, MyPluginInfo.PLUGIN_GUID, new UnlockOptions() { UnlockCriteria = UnlockCriteriaType.Always });

            //Sets crafting recipe
            Craftables.Instance.SetRecipe(AutoBenedictionMk1GUID, Mk1cr);
            Craftables.Instance.SetRecipe(AutoBenedictionMk2GUID, Mk2cr);
            Craftables.Instance.SetRecipe(AutoBenedictionMk3GUID, Mk3cr);
            Craftables.Instance.SetRecipe(AutoCarronadeMk1GUID, CMk1cr);
            Craftables.Instance.SetRecipe(AutoCarronadeMk2GUID, CMk2cr);
            Craftables.Instance.SetRecipe(AutoCarronadeMk3GUID, CMk3cr);

            //Sets recipe for Endless
            Craftables.Instance.AddQuestRecipeUsingDefaultRecipe(Game.EndlessQuestAsset, AutoBenedictionMk1GUID);
            Craftables.Instance.AddQuestRecipeUsingDefaultRecipe(Game.EndlessQuestAsset, AutoBenedictionMk2GUID);
            Craftables.Instance.AddQuestRecipeUsingDefaultRecipe(Game.EndlessQuestAsset, AutoBenedictionMk3GUID);
            Craftables.Instance.AddQuestRecipeUsingDefaultRecipe(Game.EndlessQuestAsset, AutoCarronadeMk1GUID);
            Craftables.Instance.AddQuestRecipeUsingDefaultRecipe(Game.EndlessQuestAsset, AutoCarronadeMk2GUID);
            Craftables.Instance.AddQuestRecipeUsingDefaultRecipe(Game.EndlessQuestAsset, AutoCarronadeMk3GUID);


            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}