using SwordCatch.HitBox;
using System.Collections.Generic;
using UnityEngine;

namespace SwordCatch.Player
{
    [CreateAssetMenu(fileName = "PlayerHitBox", menuName = "Player/HitBox")]
    //  当たり判定リスト
    public sealed class PlayerHitBoxData : ScriptableObject
    {
        [Header("ヒットボックスリスト")]
        [SerializeField] List<HitBoxData> _playerHitBoxes = new();

        public IReadOnlyList<HitBoxData> PlayerHitBoxes => _playerHitBoxes;
    }
}