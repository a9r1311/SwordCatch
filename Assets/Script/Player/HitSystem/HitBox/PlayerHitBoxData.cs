using System.Collections.Generic;
using UnityEngine;

namespace Kamatte.Core
{
    [CreateAssetMenu(fileName = "PlayerHitBox", menuName = "Player/HitBox")]
    [System.Serializable]
    public class PlayerHitBoxData : ScriptableObject   //  ヒットボックスのデータ一覧
    {
        [Header("ヒットボックスリスト")]
        public List<HitBoxData> playerHitBoxes = new();
    }
}