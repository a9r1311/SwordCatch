using System.Collections.Generic;
using UnityEngine;

namespace Kamatte.Core
{
    [CreateAssetMenu(fileName = "PlayerHitBox", menuName = "Player/HitBox")]
    //  当たり判定リスト
    public sealed class PlayerHitBoxData : ScriptableObject
    {
        [Header("ヒットボックスリスト")]
        [SerializeField] List<HitBox> _playerHitBoxes = new();

        public IReadOnlyList<HitBox> PlayerHitBoxes => _playerHitBoxes;
    }
}