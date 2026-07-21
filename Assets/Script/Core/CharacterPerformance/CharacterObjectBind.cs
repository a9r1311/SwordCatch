using UnityEngine;

namespace SwordCatch.CharacterPerformance
{
    // キャラクター定義と実際のオブジェクトの紐づけ用クラス
    [System.Serializable]
    public sealed class CharacterObjectBind
    {
        [Header("キャラクター")]
        public Performer Character;
        [Header("シーン上のキャラクター")]
        public GameObject CharacterOnScene;
    }
}