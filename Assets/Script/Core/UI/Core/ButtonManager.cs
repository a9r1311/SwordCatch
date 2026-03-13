using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Kamatte.Core
{
    public class ButtonManager : MonoBehaviour    //  ボタンの管理関数保持クラス
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
                    Debug.Log("$\" {id} に {button.name} を自動割当しました。\"");
                }
                else
                {
                    Debug.Log($" {id.ToString()} に対応するボタンが見つかりませんでした。");
                }
            }
#endif
        }

        [SerializeField] private ButtonMapping[] buttonMapping;
        
        private Dictionary<ButtonID, Button> buttonMap = new();

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (buttonMapping == null || buttonMapping.Length == 0)
            {
                return;
            }

            foreach (var mapping in buttonMapping)
            {
                if(mapping == null)
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
        void Awake()
        {
            InitializeButtons();    //  ボタン初期化
        }

        private void InitializeButtons()    //  ボタンを初期化する
        {
            buttonMap.Clear();

            foreach (ButtonMapping mapping in buttonMapping)
            {
                if (mapping.button != null)
                {
                    buttonMap[mapping.id] = mapping.button;
                }
            }
        }

        public void RegistReact(ButtonID ButtonID, Action callback)    //    ボタン反応入れ
        {
            if (buttonMap.TryGetValue(ButtonID, out Button button))
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => callback?.Invoke());
            }
            else
            {
                Debug.LogWarning($"ボタンが見つかりません: {ButtonID}");
            }
        }
        
        public void UnregistReact(ButtonID ButtonID)    //  ボタン反応解除
        {
            if (buttonMap.TryGetValue(ButtonID, out Button button))
            {
                button.onClick.RemoveAllListeners(); // コールバック解除
            }
        }

        public void SetInteractable(ButtonID titleButtonID, bool interactable)    //  ボタン反応するかどうかを設定
        {
            if (buttonMap.TryGetValue(titleButtonID, out var button))
            {
                button.interactable = interactable;
            }
        }

        public void DisableAllButtons()    //  ボタン全部反応不可能にする
        {
            foreach (var btn in buttonMap.Values)
            {
                btn.interactable = false;
            }
        }

        public void EnableAllButtons()    //  ボタン全部反応可能にする
        {
            foreach (var btn in buttonMap.Values)
            {
                btn.interactable = true;
            }
        }
    }
}
