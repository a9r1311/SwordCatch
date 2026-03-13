using UnityEngine;

public class GameRoot : MonoBehaviour    //  GameRootオブジェクトの設定
{
    void OnAwake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
