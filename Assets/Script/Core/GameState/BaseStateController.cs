using UnityEngine;

public abstract class BaseStateController : MonoBehaviour    //  StateControllerの基底クラス
{
    protected virtual void Awake()
    {
        InitGameState();
        InitUI();
        InitAudio();
        InitOthers();
    }

    protected abstract void InitGameState();    //  ゲームの状態を設定
    protected abstract void InitUI();           //  UIを初期化
    protected abstract void InitAudio();        //  BGMや効果音を再生
    protected abstract void InitEffect();       //  BGMや効果音を再生
    protected virtual void InitOthers() { }     //  その他任意の処理（必要に応じて）
}
