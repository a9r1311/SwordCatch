using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Kamatte.UI.Buttons;

#if UNITY_EDITOR
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
#endif

namespace Kamatte.Core
{
    [CreateAssetMenu(fileName ="UIFactory", menuName = "UI/UIFactory")]
    public class UIFactory : ScriptableObject    //  UIコントローラーを生成する
    {
        [Serializable]
        public struct UIMap    //  UIIDの対応したUIのRootのkvp
        {
            public UIID uiID;
            public GameObject uiPrefab;
        }
        
        [SerializeField] private UIMap[] uiMappings;    //  インスペクターでのアサイン用

        [SerializeField] private SceneIDConvert sceneIDConvert;    //  SceneIDからUIIDに変換してくれるSO
        private Dictionary<UIID, GameObject> prefabDict;

        void OnEnable()
        {
            BuildUIMapping();    //  uiMappingを初期化
        }

        //    SceneIDとUIIDの辞書を初期化
        void BuildUIMapping()
        {
            prefabDict = new();

            foreach (var map in uiMappings)
            {
                if (map.uiPrefab != null)
                {
                    prefabDict[map.uiID] = map.uiPrefab;
                }
            }
        }

        //  GameStateIDに対応したUIコントローラーを生成
        public IUIController CreateUI(GameStateID gameStateID)
        {
            if (!sceneIDConvert.TryGetUIID(gameStateID, out var buttonControllerID))
            {
                Debug.LogWarning($"SceneID {gameStateID} に対応する ButtonControllerID が見つかりません");
                return null;
            }

            if (!prefabDict.TryGetValue(buttonControllerID, out var prefab))
            {
                Debug.LogWarning($"シーンIDに対応したUIコントローラーのプレハブがありません SceneID : {gameStateID}");
                return null;
            }

            var instance = Instantiate(prefab);
            var controller = instance.GetComponent<IUIController>();

            if (controller == null)
            {
                Debug.LogWarning($"UIController doesn't have Controller Conponet UIController : {instance}");
            }

            return controller;
        }

        //  --  Editor process

#if UNITY_EDITOR
        void OnValidate()
        {
            EnsureAllEnumValuesExist();    //  配列要素数拡張
            AutoAssignPrefabs();    //  Enum対応Prefab自動登録
        }

        //  配列の要素をEnumの要素数に拡張
        private void EnsureAllEnumValuesExist()
        {
            var enumValues = Enum.GetValues(typeof(UIID)).Cast<UIID>().ToArray();
            Dictionary<UIID, UIMap> uniqueMap = new Dictionary<UIID, UIMap>();

            foreach (var map in uiMappings)
            {
                if (!uniqueMap.ContainsKey(map.uiID))
                {
                    uniqueMap[map.uiID] = map;
                }
            }

            foreach (var id in enumValues)
            {
                if (!uniqueMap.ContainsKey(id))
                {
                    uniqueMap[id] = new UIMap
                    {
                        uiID = id,
                        uiPrefab = null
                    };
                }
            }

            uiMappings = uniqueMap.Values.ToArray();
        }

        //  Enum対応Prefab自動登録
        private void AutoAssignPrefabs()
        {
            foreach (var id in Enum.GetValues(typeof(UIID)))
            {
                UIID uiID = (UIID)id;
                string address = uiID.ToString();

                AddressableAssetSettings settings = AddressableAssetSettingsDefaultObject.Settings;
                AddressableAssetEntry foundEntry = null;

                foreach (var group in settings.groups)
                {
                    if (group == null) continue;

                    foundEntry = group.entries.FirstOrDefault(e => e != null && e.address == address);
                    if (foundEntry != null) break;
                }

                if (foundEntry == null)
                {
                    Debug.LogWarning($"{address} に対応するAddressablesアセットが見つかりません。");
                    continue;
                }

                var path = AssetDatabase.GUIDToAssetPath(foundEntry.guid);
                var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

                if (prefab == null)
                {
                    Debug.LogWarning($"アドレス {address} に対応するPrefabが見つかりませんでした。");
                    continue;
                }

                int index = Array.FindIndex(uiMappings, m => m.uiID.Equals(uiID));
                if (index >= 0 && uiMappings[index].uiPrefab != prefab)
                {
                    uiMappings[index].uiPrefab = prefab;
                    Debug.Log($"{uiID} に {prefab.name} をAddressablesから自動割当しました。");
                }

                GameObject uiPrefab = uiMappings[index].uiPrefab;
                if (uiPrefab != null && uiPrefab.name != uiID.ToString())
                {
                    uiMappings[index].uiPrefab = null;
                }
            }
        }

        ////  stringでprefabを取得する
        //private GameObject FindPrefabByName(string name)
        //{
        //    string[] guids = AssetDatabase.FindAssets($"t:GameObject {name}");
        //    foreach (var guid in guids)
        //    {
        //        var path = AssetDatabase.GUIDToAssetPath(guid);
        //        var go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        //        if (go != null && go.name == name)
        //        {
        //            return go;
        //        }
        //    }
        //    return null;
        //}
#endif
    }
}