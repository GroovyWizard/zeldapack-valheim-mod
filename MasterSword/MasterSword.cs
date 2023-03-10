// MasterSword
// a Valheim mod skeleton using J?tunn
// 
// File:    MasterSword.cs
// Project: MasterSword

using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;
using UnityEngine.Assertions;

namespace MasterSword
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]

    internal class MasterSword : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.MasterSword";
        public const string PluginName = "MasterSword";
        public const string PluginVersion = "0.0.1";
        //(VALHEIM_INSTALL)\BepInEx\plugins\JotunnModExample\Assets
        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

       private static void DeployCheatySword()
        {
            var cheatybundle = AssetUtils.LoadAssetBundleFromResources("cheatsword");
            Jotunn.Logger.LogInfo(cheatybundle);
            var cheaty = cheatybundle.LoadAsset<GameObject>("Cheaty");
            ItemManager.Instance.AddItem(new CustomItem(cheaty, fixReference: true));
            cheatybundle.Unload(false);
        }

        private static void DeployMasterSword()
        {
            var masterSwordBundle = AssetUtils.LoadAssetBundleFromResources("mastersword");
            Jotunn.Logger.LogInfo(masterSwordBundle);
            var masterSword = masterSwordBundle.LoadAsset<GameObject>("MasterSword");
            ItemManager.Instance.AddItem(new CustomItem(masterSword, fixReference: true));
            masterSwordBundle.Unload(false);
        }

        private static void DeployHylianShield()
        {
            var hylianShieldBundle = AssetUtils.LoadAssetBundleFromResources("hylianshield");
            Jotunn.Logger.LogInfo(hylianShieldBundle);
            var hylianShield = hylianShieldBundle.LoadAsset<GameObject>("HylianShield");
            ItemManager.Instance.AddItem(new CustomItem(hylianShield, fixReference: true));
            hylianShieldBundle.Unload(false);
        }
        private static void DeployMajorasMask()
        {
            var majorasMaskBundle = AssetUtils.LoadAssetBundleFromResources("majorasmask");
            Jotunn.Logger.LogInfo(majorasMaskBundle);
            var majorasMask = majorasMaskBundle.LoadAsset<GameObject>("MajorasMask");
            ItemManager.Instance.AddItem(new CustomItem(majorasMask, fixReference: true));
            majorasMaskBundle.Unload(false);
        }
        private void AddRecipes()
        {
            // MajorasMask recipe
            var majorasConfig = new RecipeConfig();
            majorasConfig.Item = "MajorasMask"; // Name of the item prefab to be crafted
            majorasConfig.AddRequirement(new RequirementConfig("Stone", 2));
            majorasConfig.AddRequirement(new RequirementConfig("Wood", 1));
            ItemManager.Instance.AddRecipe(new CustomRecipe(majorasConfig));
        }

        private void AddMockedItems()
        {
            MasterSword.DeployMasterSword();
            MasterSword.DeployHylianShield();
            MasterSword.DeployMajorasMask();
        }
        private void Awake()
        {
            AddMockedItems();
            AddRecipes();
            // Jotunn comes with its own Logger class to provide a consistent Log style for all mods using it
            Jotunn.Logger.LogInfo("Zeldapack has landed");
            
            // To learn more about Jotunn's features, go to
            // https://valheim-modding.github.io/Jotunn/tutorials/overview.html
        }
    }
}

