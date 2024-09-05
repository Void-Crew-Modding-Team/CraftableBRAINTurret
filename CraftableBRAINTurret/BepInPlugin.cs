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
            GUIDUnion Mk1GUID = new GUIDUnion("6b2c6be56b6678643bd0039305890622");
            GUIDUnion Mk2GUID = new GUIDUnion("57a0ed79bfb068647a8fbef4bd619e1e");
            GUIDUnion Mk3GUID = new GUIDUnion("5527af35a54518042b4c3712846f4bb2");

            //Setup Crafting rules (alloy or insription, cost and recyclability)
            CraftingRules Mk1cr = Craftables.Instance.GetRecipe(Mk1GUID);
            Mk1cr.CraftingMethod = CraftMethod.ItemExchange;
            Mk1cr.ItemExchangeInfo = new CraftableWithItemExchange(ItemExchangeType.BlankBox, 1);

            CraftingRules Mk2cr = Craftables.Instance.GetRecipe(Mk2GUID);
            Mk2cr.CraftingMethod = CraftMethod.ItemExchange;
            Mk2cr.ItemExchangeInfo = new CraftableWithItemExchange(ItemExchangeType.BlankBox, 2);

            CraftingRules Mk3cr = Craftables.Instance.GetRecipe(Mk2GUID);
            Mk3cr.CraftingMethod = CraftMethod.ItemExchange;
            Mk3cr.ItemExchangeInfo = new CraftableWithItemExchange(ItemExchangeType.BlankBox, 3);


            //Unlocks for crafting
            Unlocks.Instance.SetUnlockOptions(Mk1GUID, MyPluginInfo.PLUGIN_GUID, new UnlockOptions() { UnlockCriteria = UnlockCriteriaType.Always });
            Unlocks.Instance.SetUnlockOptions(Mk2GUID, MyPluginInfo.PLUGIN_GUID, new UnlockOptions() { UnlockCriteria = UnlockCriteriaType.Always });
            Unlocks.Instance.SetUnlockOptions(Mk3GUID, MyPluginInfo.PLUGIN_GUID, new UnlockOptions() { UnlockCriteria = UnlockCriteriaType.Always });

            //Sets crafting recipe
            Craftables.Instance.SetRecipe(Mk1GUID, Mk1cr);
            Craftables.Instance.SetRecipe(Mk2GUID, Mk2cr);
            Craftables.Instance.SetRecipe(Mk3GUID, Mk3cr);

            //Sets recipe for Endless
            Craftables.Instance.AddQuestRecipeUsingDefaultRecipe(Game.EndlessQuestAsset, Mk1GUID);
            Craftables.Instance.AddQuestRecipeUsingDefaultRecipe(Game.EndlessQuestAsset, Mk2GUID);
            Craftables.Instance.AddQuestRecipeUsingDefaultRecipe(Game.EndlessQuestAsset, Mk3GUID);


            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}