#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets;
using UnityEngine;

public static class AddressablesBuildUtility
{
    [MenuItem("Tools/Addressables/Build Player Content")]
    public static void BuildAddressablesContent()
    {
        AddressableAssetSettings settings = AddressableAssetSettingsDefaultObject.Settings;
        if (settings == null)
        {
            Debug.LogError("AddressableAssetSettings not found.");
            return;
        }

        AddressableAssetSettings.BuildPlayerContent();
        Debug.Log("✅ Addressables Build Completed!");
    }
}
#endif