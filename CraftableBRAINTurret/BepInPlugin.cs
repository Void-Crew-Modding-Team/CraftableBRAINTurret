using BepInEx;
using CG.Client.UserData;
using CG.Ship.Object;
using HarmonyLib;
using ResourceAssets;
using System.Reflection;

namespace CraftableBRAINTurret
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Void Crew.exe")]
    [BepInDependency("VoidManager")]
    public class BepinPlugin : BaseUnityPlugin
    {
        static FieldInfo UnlockOptionsFI = AccessTools.Field(typeof(UnlockItemDef), "unlockOptions");

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
            ResourceAssetContainer<CraftingDataContainer, UnityEngine.Object, CraftableItemDef>.Instance.GetAssetDefById(GUID).crafting = cr;

            //Unlocks for crafting
            UnlockOptionsFI.SetValue(ResourceAssetContainer<UnlockContainer, UnityEngine.Object, UnlockItemDef>.Instance.GetAssetDefById(GUID), new UnlockOptions() { UnlockCriteria = UnlockCriteriaType.Always });

            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}