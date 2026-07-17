using System.Collections;
using UnityEngine;
using Kamatte.Core;

namespace SwordCatch.Audio
{
    //  リザルト画面で音量を小さくする
    public sealed class LowerAudio : IGameModeChangeTask
    {
        int _order;  // 実行順(小さい方が先)

        AudioSource _audioSource;  // BGMAudioSouce
        float _resultVolume;  // リザルト画面の音量

        public int Order => _order;

        public LowerAudio(int order, AudioSource audioSource, float resultVolume)
        {
            _order = order;
            _audioSource = audioSource;
            _resultVolume = resultVolume;
        }

        // 音量下げ
        public IEnumerator Execute(GameMode prev, GameMode next)
        {
            _audioSource.volume = _resultVolume;
            MyLogger.Log("音量下げ完了");
            yield break;
        }
    }
}