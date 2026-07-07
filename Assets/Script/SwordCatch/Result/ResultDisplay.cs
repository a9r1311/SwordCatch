using System.Collections;
using UnityEngine;
using Kamatte.Core;
using TMPro;

namespace Kamatte.SwordCatch
{
    public class ResultDisplay : IGameModeChangeStep
    {
        GameObject resultRoot;
        TextMeshProUGUI playerLevelTxt;
        TextMeshProUGUI countTxt;
        StateHolder _stateHolder;

        public int Order => 50;    //  実行順(小さい方が先)
        
        public ResultDisplay(GameObject resultRoot, TextMeshProUGUI countText, TextMeshProUGUI levelText, StateHolder stateHolder)
        {
            this.resultRoot = resultRoot;
            this.countTxt = countText;
            playerLevelTxt = levelText;
            _stateHolder= stateHolder;
        }

        public IEnumerator Execute(GameMode prev, GameMode next)    //  Stepの処理関数のラップ関数
        {
            if (prev == GameMode.SwordCatch && next == GameMode.SwordCatch)
            {
                countTxt.text = _stateHolder.CatchSuccessCnt.ToString();
                playerLevelTxt.text = GetPlayerLevel();
                resultRoot.SetActive(true);
                yield break;
            }
        }

        // プレイヤーの実力を取得
        string GetPlayerLevel()
        {
            if (_stateHolder.CatchSuccessCnt > 30)
            {
                return "宮本武蔵";
            }
            else if (_stateHolder.CatchSuccessCnt > 24)
            {
                return PlayerPower.GOAT.ToString();
            }
            else if (_stateHolder.CatchSuccessCnt > 19)
            {
                return PlayerPower.Chanmpion.ToString();
            }
            else if (_stateHolder.CatchSuccessCnt > 17)
            {
                return "モンスター";
            }
            else if (_stateHolder.CatchSuccessCnt > 14)
            {
                return "F1レーサー";
            }
            else if (_stateHolder.CatchSuccessCnt > 12)
            {
                return "侍";
            }
            else if (_stateHolder.CatchSuccessCnt > 9)
            {
                return "中堅";
            }
            else if (_stateHolder.CatchSuccessCnt > 7)
            {
                return "育ち盛り";
            }
            else if (_stateHolder.CatchSuccessCnt > 4)
            {
                return "足軽";
            }
            else if (_stateHolder.CatchSuccessCnt > 2)
            {
                return "寝起き";
            }
            else if (_stateHolder.CatchSuccessCnt > 0)
            {
                return "赤ちゃん";
            }
            else
            {
                return "初挑戦";
            }
        }
    }
}