using System.Collections.Generic;
using UnityEngine;
using Kamatte.Core;
using Kamatte.Swinger;

namespace Kamatte.SwordCatch
{
    //  アニメーターのパラメーターシステムをSLに登録するクラス
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(-10)]
    public sealed class AnimParamSystemBootstrap : MonoBehaviour
    {
        [System.Serializable]
        class AnimatorBinding
        {
            public AnimatorTarget target;
            public Animator animator;
        }
        
        [SerializeField] List<AnimatorBinding> animatorBindings;  // インスペクターにバインディングを表示するためのリスト
        Dictionary<AnimatorTarget, Animator> animatorMap;  // リストから処理用の辞書に切り替える

        AnimParamFacade paramFacade;  // パラーメーター集約クラス
        AnimParam_Player playerParam;  // プレイヤーのパラメータを保持してるクラス
        AnimParam_Swinger swingerParam;  // スウィンガーのパラメータを保持してるクラス

        void Awake()
        {
            //  インスペクター表示用Listから処理用の辞書を構築
            BuildDictionary();

            //  プレイヤーのアニメーターパラメータークラス生成
            GeneratePlayerSystem();
            //  スウィンガーのアニメーターパラメータークラス生成
            GenerateSwingerSystem();

            paramFacade = new AnimParamFacade(playerParam, swingerParam);
            //  SLに登録
            ServiceLocator.Register<AnimParamFacade>(paramFacade);
        }

        //  インスペクター表示用Listから処理速度向上のためDictionaryを構築する
        void BuildDictionary()
        {
            animatorMap = new Dictionary<AnimatorTarget, Animator>(animatorBindings.Count);

            foreach (var bind in animatorBindings)
            {
                if (!animatorMap.ContainsKey(bind.target))
                {
                    animatorMap.Add(bind.target, bind.animator);
                }
                else
                {
                    Debug.LogWarning($"Duplicate AnimatorRole: {bind.target}");
                }
            }
        }

        //  プレイヤーのアニメーションパラメータークラスを生成
        void GeneratePlayerSystem()
        {
            playerParam = new AnimParam_Player(animatorMap[AnimatorTarget.Player], "Catch");
        }

        //  刀振りのアニメーションパラメータークラスを生成
        void GenerateSwingerSystem()
        {
            SwingerAnimParameters ctx = new(
                SwingerAnimatorParameter.NormalSwing.ToString(),
                SwingerAnimatorParameter.FastSwing.ToString(),
                //SwingerAnimatorParameter.DelaySwing.ToString(), Delayは難しすぎたので一旦なし
                SwingerAnimatorParameter.IsHit.ToString(),
                SwingerAnimatorParameter.IsCought.ToString()
                );
            swingerParam = new AnimParam_Swinger(animatorMap[AnimatorTarget.SwordSwinger], ctx);
        }
    }
}