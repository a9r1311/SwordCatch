using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using SwordCatch.Core;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;
#if UNITY_EDITOR
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
#endif

namespace SwordCatch.UI
{
    //  UIコントローラーを生成する
    [CreateAssetMenu(fileName ="UIFactory", menuName = "UI/UIFactory")]
    public sealed class UIFactory : ScriptableObject
    {
        //  UIIDの対応したUIのRootのkvp
        [Serializable]
        public struct UIMap
        {
            public UIID uiID;
            public AssetReference uiPrefab;
            //public GameObject uiPrefab;
        }

        //  インスペクターでのアサイン用
        [SerializeField] UIMap[] _uiMappings;

        [SerializeField] SceneIDConvert _sceneIDConvert;  // SceneIDからUIIDに変換してくれるSO
        Dictionary<UIID, AssetReference> _prefabDictionary;

        void OnEnable()
        {
            BuildUIMapping();    //  uiMappingを初期化
        }

        //    SceneIDとUIIDの辞書を初期化
        void BuildUIMapping()
        {
            _prefabDictionary = new();

            foreach (var map in _uiMappings)
            {
                if (map.uiPrefab != null)
                {
                    _prefabDictionary[map.uiID] = map.uiPrefab;
                }
            }
        }

        //  GameStateIDに対応したUIコントローラーを生成
        public async UniTask<IUIController> CreateUI(GameStateID gameStateID)
        {
            if (!_sceneIDConvert.TryGetUIID(gameStateID, out var buttonControllerID))
            {
                MyLogger.WarningLog($"SceneID {gameStateID} に対応する ButtonControllerID が見つかりません");
                return null;
            }

            if (!_prefabDictionary.TryGetValue(buttonControllerID, out var prefabRef))
            {
                MyLogger.WarningLog($"シーンIDに対応したUIコントローラーのプレハブが未登録です SceneID : {gameStateID}");
                return null;
            }

            var handle = Addressables.InstantiateAsync(prefabRef);
            var instance = await handle.Task;

            var controller = instance.GetComponent<IUIController>();
            if (controller == null)
            {
                Debug.LogWarning($"IUIControllerがありません: {instance.name}");
                Addressables.ReleaseInstance(instance);
                return null;
            }

            return controller;
        }


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

            foreach (var map in _uiMappings)
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

            _uiMappings = uniqueMap.Values.ToArray();
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
                    MyLogger.ErrorLog($"\"{address} に対応するAddressablesアセットが見つかりません。\"");
                    continue;
                }

                var path = AssetDatabase.GUIDToAssetPath(foundEntry.guid);
                var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

                if (prefab == null)
                {
                    MyLogger.WarningLog($"アドレス {address} に対応するPrefabが見つかりませんでした。");
                    continue;
                }

                int index = Array.FindIndex(_uiMappings, m => m.uiID.Equals(uiID));
                
                if (index >= 0)
                {
                    var guid = foundEntry.guid;
                    _uiMappings[index].uiPrefab = new AssetReference(guid);
                }
            }
        }
#endif
    }
}