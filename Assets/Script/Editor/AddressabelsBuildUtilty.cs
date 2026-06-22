#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

//  手動アセットビルドツール(※Editorファイル内に配置)
public static class AddressablesBuild
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

        //  アセットをビルド
        AddressableAssetSettings.BuildPlayerContent();
        Debug.Log("Addressables Build Completed.");
    }
}
#endif