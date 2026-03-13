using UnityEngine;

namespace Kamatte.SwordCatch
{
    [System.Serializable]
    public class SwordCatchPlayerStat    //  プレイヤー白刃取りステータス項目
    {
        [Header("当たり判定半径")]
        public float catchRadius = 0.3f;    //  当たり判定半径
    }
}