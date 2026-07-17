using System.Collections.Generic;
using UnityEngine;

namespace SwordCatch.Result
{
    [CreateAssetMenu(fileName = "PlayerLevelCatalog", menuName = "Result/PlayerLevelCatalog")]
    public sealed class PlayerLevelCatalog : ScriptableObject
    {
        [Header("リザルト用の称号リスト")]
        public List<PlayerLevelDef> Levels;
    }
}