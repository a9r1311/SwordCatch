using Kamatte.Core;
using UnityEngine;

namespace Kamatte.SwordCatch
{
    //  刀を振るタイミングを決定するスクリプト
    [DisallowMultipleComponent]
    public sealed class SwingTimeController : MonoBehaviour
    {
        [SerializeField] StateHolder _stateHolder;  // ゲーム状態クラス

        [SerializeField] SwingerStatsHolder _statsHolder;  // スウィンガーの能力値SO
        SwingerStatBlock _stat;  // 刀役の能力値(キャッシュ用)
        Swing _swing;  // 刀振りのコントローラー
        //SwingPersonal swingerPersonal;     //  刀振りの性格

        SwingType _swingTyep;  // 刀を降る方法
        float _swingTimer;  // 刀を振り下ろすまでのタイマー
        float _screemToFastSwing;  // 叫んでから高速振り下ろしするまでの時間
        
        bool _isShout = false;  // 高速振り下ろし前に叫んだかどうか

        AnimParamFacadeBase _animatorParametor;  // アニメーターのパラメーターを保持してるクラス
        
        [SerializeField] AudioSource _audioSource;
        [SerializeField] AudioClip _roundVoiceClip;



        void Awake()
        {
            _stat = _statsHolder.GetStat(SwingerID.Samurai);
            //swingerPersonal = _swingerStat.SwingerPersonal;

            _swingTimer = _stat.FirstSwingTime;  // 最初の振り下ろしまでの時間を取得
            _swingTyep = _stat.FirstSwingType;  // 最初の振り下ろし方法を取得
            _screemToFastSwing = _stat.ScreemToSwing;
        }

        void Start()
        {
            _animatorParametor = ServiceLocator.Resolve<AnimParamFacadeBase>();
        }

        //  SwingClass受け取り
        public void Initialize(Swing swing)
        {
            _swing = swing;
        }

        void Update()
        {
            if (!_stateHolder.IsHitSwing)
            {
                _swingTimer -= Time.deltaTime;
            }

            //switch (swingerPersonal)
            //{
            //    case SwingPersonal.Chiken:
            //        ChikenUpdate();
            //        break;
            //    case SwingPersonal.SwordMaster:
            //        SwordMasterUpdate();
            //        break;
            //    case SwingPersonal.SpeedStar:
            //        SpeedStarUpdate();
            //        break;
            //}

            if(
                _swingTyep == SwingType.Fast &&
                _swingTimer < _screemToFastSwing&&
                !_isShout
                )
            {
                //  叫ぶ
                Shout();
            }

            if (_swingTimer < 0)
            {
                //  降り下ろす
                Swing();
            }
        }

        //  叫ぶ
        void Shout()
        {
            _isShout = true;
            _audioSource.PlayOneShot(_roundVoiceClip, 0.4f);
        }

        //  降り下ろす
        void Swing()
        {
            _stateHolder.IsCatchSword = false;
            _stateHolder.IsHitSwing = false;
            _animatorParametor.SwingerParam.IsCought(false);
            
            _swing.SwingSword(_swingTyep);
            _swingTimer = Random.Range(1, 10);
            _swingTyep = (SwingType)Random.Range(0, 2);

            _isShout = false;
        }

        ////  性格ChikenのUpdate
        //void ChikenUpdate()
        //{

        //}

        ////  性格SwordMasterUpdate
        //void SwordMasterUpdate()
        //{
        //    if (_swingTimer < 0)
        //    {
        //        //  Swing
        //    }
        //}

        ////  性格SpeedStarのUpdate
        //void SpeedStarUpdate()
        //{
        //    if (_swingTimer < 0)
        //    {
        //        //  Swing
        //    }
        //}
    }
}