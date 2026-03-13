using UnityEngine;

namespace Kamatte.Core
{
    [System.Serializable]
    public class ActorObjectBind    // 演出用の動きをするオブジェクトのバインドに使うクラス
    {
        [Header("演者(定義データ)")]
        public EffectActor effectActor;    //  動きをするオブジェクト(定義データ)
        [Header("演者(シーン上)")]
        public GameObject  exsitActor;    //  動きをするオブジェクト(シーン上)
    }
}