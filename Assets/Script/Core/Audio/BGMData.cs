using UnityEngine;

namespace Kamatte.Core
{
    [CreateAssetMenu(fileName = "BGMData", menuName = "Audio/BGM Data")]
    public class BGMData : ScriptableObject
    {
        [Header("説明")]
        [SerializeField]
        private string displayName;   // ラベル(説明専用)

        [SerializeField, TextArea]
        private string description;    //  説明文()

        [Header("Playback")]
        [SerializeField]
        private AudioClip audioClip;

        [SerializeField]
        private bool loop = true;

        [SerializeField]
        private float defaultVolume = 1.0f;

        [SerializeField]
        private float fadeTime = 1.0f;

        // ---- 外部API  ----  //

        public string DisplayName => displayName;    //  ラベル名
        public AudioClip AudioClip => audioClip;    //  音声クリップ
        public bool Loop => loop;    //  ループ設定
        public float DefaultVolume => defaultVolume;    //  デフォルト音量

        public float FadeTime => fadeTime;    //  フェード秒数
    }
}