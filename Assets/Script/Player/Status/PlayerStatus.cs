using UnityEngine;
using Kamatte.SwordCatch;
using Kamatte.Core;

namespace Kamatte.Player
{
    [CreateAssetMenu(fileName = "PlayerStatus", menuName = "Player/Status")]
    public class PlayerStatus : ScriptableObject
    {
        //  プレイヤーステータスクラス
        [System.Serializable]
        public class PlayerStats
        {
            public SwordCatchPlayerStat swordCatchPlayerStat;    //  白刃取りのステータスブロック
            public PlayerHitBoxData hitBoxData;                  //  当たり判定のデータブロック
        }

        public PlayerStats playerStats = new PlayerStats();
    }
}