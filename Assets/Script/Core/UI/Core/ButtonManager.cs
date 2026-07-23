using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SwordCatch.Core;

namespace SwordCatch.UI
{
    //  ボタンの管理関数保持クラス
    public sealed class ButtonManager : MonoBehaviour
    {
        [System.Serializable]
        public class ButtonMapping
        {
            public Button button;
            public ButtonID id;

#if UNITY_EDITOR
            public void OnValidate()
            {
                button = SceneManager.GetActiveScene()
                    .GetRootGameObjects()
                    .SelectMany(go => go.GetComponentsInChildren<Button>(true))
                    .FirstOrDefault(b => string.Equals(b.name, id.ToString(), StringComparison.Ordinal));
                if (button != null)
                {
                    MyLogger.Log("$\" {id} に {button.name} を自動割当しました。\"");
                }
                else
                {
                    MyLogger.Log($" {id.ToString()} に対応するボタンが見つかりませんでした。");
                }
            }
#endif
        }

        [SerializeField] ButtonMapping[] _buttonMapping;
        Dictionary<ButtonID, Button> _buttonMap = new();

#if UNITY_EDITOR
        void OnValidate()
        {
            if (_buttonMapping == null || _buttonMapping.Length == 0)
            {
                return;
            }

            foreach (var mapping in _buttonMapping)
            {
                if (mapping == null)
                {
                    continue;
                }
                if (mapping.button == null || mapping.button.name != mapping.id.ToString())
                {
                    mapping.OnValidate();
                }
            }
        }
#endif
        //  ボタン初期化
        void Awake()
        {
            InitializeButtons();
        }

        //  ボタンを初期化する
        void InitializeButtons()
        {
            _buttonMap.Clear();

            foreach (ButtonMapping mapping in _buttonMapping)
            {
                if (mapping.button != null)
                {
                    _buttonMap[mapping.id] = mapping.button;
                }
            }
        }

        //    ボタン反応入れ
        public void RegistReact(ButtonID ButtonID, Action callback)
        {
            if (_buttonMap.TryGetValue(ButtonID, out Button button))
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => callback?.Invoke());
            }
            else
            {
                MyLogger.WarningLog($"ボタンが見つかりません: {ButtonID}");
            }
        }

        //  ボタン反応解除
        public void UnregistReact(ButtonID ButtonID)
        {
            if (_buttonMap.TryGetValue(ButtonID, out Button button))
            {
                button.onClick.RemoveAllListeners(); // コールバック解除
            }
        }

        //  ボタン反応するかどうかを設定
        public void SetInteractable(ButtonID titleButtonID, bool interactable)
        {
            if (_buttonMap.TryGetValue(titleButtonID, out var button))
            {
                button.interactable = interactable;
            }
        }

        //  ボタン全部反応不可能にする
        public void DisableAllButtons()
        {
            foreach (var btn in _buttonMap.Values)
            {
                btn.interactable = false;
            }
        }

        //  ボタン全部反応可能にする
        public void EnableAllButtons()
        {
            foreach (var btn in _buttonMap.Values)
            {
                btn.interactable = true;
            }
        }
    }
}
