using System.Collections.Generic;
using UnityEngine;
using Kamatte.Core;
using Kamatte.Swinger;

namespace Kamatte.SwordCatch
{
    //  アニメーターのパラメーターをいじるシステムをServiceLocatorに登録する
    [DefaultExecutionOrder(-10)]
    public sealed class AnimParamSystemBootstrap : MonoBehaviour
    {
        [System.Serializable]
        class AnimatorBinding    //  インスペクターに表示するためのKVP
        {
            public AnimatorRole role;
            public Animator animator;
        }
        
        [SerializeField] List<AnimatorBinding> animatorBindings;    //  インスペクターにバインディングを表示するためのリスト
        Dictionary<AnimatorRole, Animator> animatorMap;    //  インスペクター用から処理用の辞書に変える


        AnimParamFacade paramFacade;    //  SLに登録するFacade
        AnimParam_Player playerParam;    //  プレイヤーのパラメータを集約してるクラス
        AnimParam_Swinger swingerParam;    //  刀振りのパラメータを集約してるクラス

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
            ServiceLocator.Register<AnimParamFacadeBase>(paramFacade);
        }

        //  インスペクター表示用Listから処理速度向上のためDictionaryを構築する
        void BuildDictionary()
        {
            animatorMap = new Dictionary<AnimatorRole, Animator>();

            foreach (var bind in animatorBindings)
            {
                if (!animatorMap.ContainsKey(bind.role))
                {
                    animatorMap.Add(bind.role, bind.animator);
                }
                else
                {
                    Debug.LogWarning($"Duplicate AnimatorRole: {bind.role}");
                }
            }
        }

        //  プレイヤーのアニメーションパラメータークラスを生成
        void GeneratePlayerSystem()
        {
            playerParam = new AnimParam_Player(animatorMap[AnimatorRole.Player], "Catch");
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
            swingerParam = new AnimParam_Swinger(animatorMap[AnimatorRole.SwordSwinger], ctx);
        }
    }
}