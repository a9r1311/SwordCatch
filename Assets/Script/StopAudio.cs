using System.Collections;
using UnityEngine;
using Kamatte.Core;

public class StopAudio : IGameModeChangeStep
{
    AudioSource audioSource;
    public int Order => 25;    //  Às‡(¬‚³‚¢•û‚ªæ)
    public StopAudio(AudioSource audioSource)
    {
        this.audioSource = audioSource;
    }
    public IEnumerator Execute(GameMode prev, GameMode next)    //  Step‚Ìˆ—ŠÖ”‚Ìƒ‰ƒbƒvŠÖ”
    {
        audioSource.volume = 0.02f;
        yield break;
    }
}
