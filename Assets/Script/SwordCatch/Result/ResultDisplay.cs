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
        StateReader stateRead;

        public int Order => 50;    //  実行順(小さい方が先)
        
        public ResultDisplay(GameObject resultRoot, TextMeshProUGUI countText, TextMeshProUGUI levelText, StateReader stateRead)
        {
            this.resultRoot = resultRoot;
            this.countTxt = countText;
            playerLevelTxt = levelText;
            this.stateRead = stateRead;
        }

        public IEnumerator Execute(GameMode prev, GameMode next)    //  Stepの処理関数のラップ関数
        {
            if (prev == GameMode.SwordCatch && next == GameMode.SwordCatch)
            {
                countTxt.text = stateRead.StateHolder.CatchSuccessCnt.ToString();
                playerLevelTxt.text = GetPlayerLevel();
                resultRoot.SetActive(true);
                yield break;
            }
        }
        string GetPlayerLevel()
        {
            if (stateRead.StateHolder.CatchSuccessCnt > 30)
            {
                return "宮本武蔵";
            }
            else if (stateRead.StateHolder.CatchSuccessCnt > 24)
            {
                return PlayerPower.GOAT.ToString();
            }
            else if (stateRead.StateHolder.CatchSuccessCnt > 19)
            {
                return PlayerPower.Chanmpion.ToString();
            }
            else if (stateRead.StateHolder.CatchSuccessCnt > 17)
            {
                return "モンスター";
            }
            else if (stateRead.StateHolder.CatchSuccessCnt > 14)
            {
                return "F1レーサー";
            }
            else if (stateRead.StateHolder.CatchSuccessCnt > 12)
            {
                return "侍";
            }
            else if (stateRead.StateHolder.CatchSuccessCnt > 9)
            {
                return "中堅";
            }
            else if (stateRead.StateHolder.CatchSuccessCnt > 7)
            {
                return "育ち盛り";
            }
            else if (stateRead.StateHolder.CatchSuccessCnt > 4)
            {
                return "足軽";
            }
            else if (stateRead.StateHolder.CatchSuccessCnt > 2)
            {
                return "寝起き";
            }
            else if (stateRead.StateHolder.CatchSuccessCnt > 0)
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