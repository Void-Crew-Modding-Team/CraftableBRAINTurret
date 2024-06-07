using BepInEx;
using CG.Client.UserData;
using CG.Ship.Object;
using ResourceAssets;
using VoidManager.Content;
using VoidManager.Utilities;

namespace CraftableBRAINTurret
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Void Crew.exe")]
    [BepInDependency("VoidManager")]
    public class BepinPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            GUIDUnion GUID = new GUIDUnion("6b2c6be56b6678643bd0039305890622");

            //Setup Crafting rules (alloy or insription, cost and recyclability)
            CraftingRules cr = new()
            {
                CraftingMethod = CraftMethod.ItemExchange,
                Recycle = new ResourceCurrency(ResourceType.Alloys, 4),
                ItemExchangeInfo = new CraftableWithItemExchange(ItemExchangeType.BlankBox, 1),
                CanBeRecycled = true
            };


            //Sets crafting recipe
            Craftables.Instance.SetRecipe(GUID, cr);

            //Sets recipe for Endless
            Craftables.Instance.AddQuestRecipeUsingDefaultRecipe(Game.EndlessQuestAsset, GUID);

            //Unlocks for crafting
            Unlocks.Instance.SetUnlockOptions(GUID, MyPluginInfo.PLUGIN_GUID, new UnlockOptions() { UnlockCriteria = UnlockCriteriaType.Always });

            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}