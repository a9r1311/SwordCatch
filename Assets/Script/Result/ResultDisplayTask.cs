using System.Collections;
using UnityEngine;
using TMPro;
using UAssert = UnityEngine.Assertions.Assert;
using SwordCatch.Core;

namespace SwordCatch.Result
{
    //  白刃取りのリザルト表示処理
    public sealed class ResultDisplayStep : IGameModeChangeTask
    {
        int _order;  // 実行順(小さい方が先)
        
        GameObject _resultRoot;
        TextMeshProUGUI _playerLevelTxt;
        TextMeshProUGUI _countTxt;

        StateHolder _stateHolder;
        PlayerLevelCatalog _levelCatalog;

        public int Order => _order;
        
        public ResultDisplayStep(
            int order,
            GameObject resultRoot,
            TextMeshProUGUI countText,
            TextMeshProUGUI levelText,
            StateHolder stateHolder,
            PlayerLevelCatalog levelCatalog
            )
        {
            UAssert.IsNotNull(resultRoot, "リザルトのルートオブジェクトの参照がNullです。");
            UAssert.IsNotNull(countText, "キャッチ回数表示用のテキストUIの参照がNullです。");
            UAssert.IsNotNull(levelText, "称号表示用のテキストUIの参照がNullです。");
            UAssert.IsNotNull(stateHolder, "ゲーム状態保持クラスの参照がNullです。");
            UAssert.IsNotNull(levelCatalog, "プレイヤーの回数と実力のデータ参照がNullです。");

            _order = order;
            _resultRoot = resultRoot;
            _countTxt = countText;
            _playerLevelTxt = levelText;
            _stateHolder= stateHolder;
            _levelCatalog = levelCatalog;
        }

        //  リザルト表示
        public IEnumerator Execute(GameMode prev, GameMode next)
        {
            if (prev == GameMode.SwordCatch && next == GameMode.SwordCatch)
            {
                MyLogger.Log("リザルト表示開始");
                _countTxt.text = _stateHolder.CatchSuccessCnt.ToString();
                _playerLevelTxt.text = GetPlayerLevel();
                _resultRoot.SetActive(true);
                yield break;
            }
        }

        // プレイヤーの称号を取得
        string GetPlayerLevel()
        {
            var count = _stateHolder.CatchSuccessCnt;

            foreach (var def in _levelCatalog.Levels)
            {
                if (count >= def.Threshold) return def.Name;
            }

            MyLogger.ErrorLog($"プレイヤーのキャッチ回数エラー Count : {count}");
            return "初挑戦";
        }
    }
}