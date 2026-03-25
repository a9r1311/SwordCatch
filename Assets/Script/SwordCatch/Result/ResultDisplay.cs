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
        StateReader_SwordCatch stateRead;

        public int Order => 50;    //  実行順(小さい方が先)
        
        public ResultDisplay(GameObject resultRoot, TextMeshProUGUI countText, TextMeshProUGUI levelText, StateReader_SwordCatch stateRead)
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
                countTxt.text = stateRead.AcceseState().CatchState.CatchSuccessTime.ToString();
                playerLevelTxt.text = GetPlayerLevel();
                resultRoot.SetActive(true);
                yield break;
            }
        }
        string GetPlayerLevel()
        {
            if (stateRead.AcceseState().CatchState.CatchSuccessTime > 30)
            {
                return "宮本武蔵";
            }
            else if (stateRead.AcceseState().CatchState.CatchSuccessTime > 24)
            {
                return PlayerPower.GOAT.ToString();
            }
            else if (stateRead.AcceseState().CatchState.CatchSuccessTime > 19)
            {
                return PlayerPower.Chanmpion.ToString();
            }
            else if (stateRead.AcceseState().CatchState.CatchSuccessTime > 17)
            {
                return "モンスター";
            }
            else if (stateRead.AcceseState().CatchState.CatchSuccessTime > 14)
            {
                return "F1レーサー";
            }
            else if (stateRead.AcceseState().CatchState.CatchSuccessTime > 12)
            {
                return "侍";
            }
            else if (stateRead.AcceseState().CatchState.CatchSuccessTime > 9)
            {
                return "中堅";
            }
            else if (stateRead.AcceseState().CatchState.CatchSuccessTime > 7)
            {
                return "育ち盛り";
            }
            else if (stateRead.AcceseState().CatchState.CatchSuccessTime > 4)
            {
                return "足軽";
            }
            else if (stateRead.AcceseState().CatchState.CatchSuccessTime > 2)
            {
                return "寝起き";
            }
            else if (stateRead.AcceseState().CatchState.CatchSuccessTime > 0)
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