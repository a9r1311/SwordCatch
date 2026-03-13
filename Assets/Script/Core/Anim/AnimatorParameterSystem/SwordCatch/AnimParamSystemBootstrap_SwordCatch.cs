using System.Collections.Generic;
using UnityEngine;
using Kamatte.Core;
using Kamatte.Player;

namespace Kamatte.SwordCatch
{
    public class AnimParamSystemBootstrap_SwordCatch : MonoBehaviour    //  アニメーターのパラメーターをいじるシステムをServiceLocatorに登録する。
    {
        [System.Serializable]
        class AnimatorBinding    //  インスペクターに表示するためのKVP
        {
            public AnimatorRole role;
            public Animator animator;
        }
        
        [SerializeField] List<AnimatorBinding> animatorBindings;    //  インスペクターにバインディングを表示するためのリスト
        Dictionary<AnimatorRole, Animator> animatorMap;    //  インスペクター用から処理用の辞書に変える

        AnimParamRead paramRead;    //  未使用(消したらエラー出る)
        AnimParamSet paramSet;    //  未使用(消したらエラー出る)

        AnimParamFacade_SwordCatch paramFacade;    //  SLに登録するFacade
        AnimParam_Player playerParam;    //  プレイヤーのパラメータを集約してるクラス
        AnimParam_Swinger swingerParam;    //  刀振りのパラメータを集約してるクラス

        void Awake()
        {
            BuildDictionary();    //  インスペクター表示用Listから処理用辞書を構築
            
            paramRead = new AnimParamRead();
            paramSet = new AnimParamSet();

            GeneratePlayerSystem();    //  プレイヤーのパラーメーターシステム初期化
            GenerateSwingerSystem();    //  刀振りのパラメーターシステム初期化

            paramFacade = new AnimParamFacade_SwordCatch(playerParam, swingerParam);

            ServiceLocator.Register<AnimParamFacadeBase>(paramFacade);    //  SLに登録
        }

        void BuildDictionary()    //  インスペクター表示用Listから処理速度向上のためDictionaryを構築する
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

        void GeneratePlayerSystem()    //  各パラメータークラスを初期化して集約クラスに渡す
        {
            PlayerParam_Catch catchParam = new(animatorMap[AnimatorRole.Player], "Catch");
            
            PlayerAnimParamContext ctx = new PlayerAnimParamContext(catchParam);

            playerParam = new AnimParam_Player(animatorMap[AnimatorRole.Player], paramRead, paramSet,ctx);
        }

        void GenerateSwingerSystem()  //  各パラメータークラスを初期化して集約クラスに渡す
        {
            SwingerParam_NormalSwing normalSwingParam = new(animatorMap[AnimatorRole.SwordSwinger], "NormalSwing");
            SwingerParam_FastSwing fastSwingParam = new(animatorMap[AnimatorRole.SwordSwinger], "FastSwing");
            SwingerParam_DelaySwing delaySwingParam = new(animatorMap[AnimatorRole.SwordSwinger], "DelaySwing");
            SwingerParam_IsHited isHitedParam = new(animatorMap[AnimatorRole.SwordSwinger], "IsHited");
            SwingerParam_IsCatch isCatchParam = new(animatorMap[AnimatorRole.SwordSwinger], "IsCatched");

            SwingerAnimParamContext ctx = new(normalSwingParam, fastSwingParam, delaySwingParam, isHitedParam, isCatchParam);

            swingerParam = new AnimParam_Swinger(animatorMap[AnimatorRole.SwordSwinger], paramRead, paramSet, ctx);
        }
    }
}