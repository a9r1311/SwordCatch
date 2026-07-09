using Kamatte.Core;
using Kamatte.Swinger;
using UnityEngine;

namespace Kamatte.SwordCatch
{
    //  刀を振るタイミングを決定するスクリプト
    [DisallowMultipleComponent]
    public sealed class SwingerController : MonoBehaviour
    {
        [SerializeField] StateHolder _stateHolder;  // ゲーム状態クラス

        [SerializeField] SwingerStatsHolder _statsHolder;  // スウィンガーの能力値SO
        SwingerStatBlock _stat;  // 刀役の能力値(キャッシュ用)
        Swing _swing;  // 刀振りのコントローラー

        SwingerPersonal _personal;  // 刀振りの性格
        ISwingStrategy _strategy;  // 性格ごとの振り方

        AnimParamFacadeBase _animatorParametor;  // アニメーターのパラメーターを保持してるクラス
        
        [SerializeField] AudioSource _audioSource;
        [SerializeField] AudioClip _roundVoiceClip;

        public float SwingTimer { get; set; }  // 刀を振り下ろすまでのタイマー
        public float ScreemToFastSwing { get; set; }  // 叫んでから高速振り下ろしするまでの時間
        public bool IsShout { get; set; } = false;  // 高速振り下ろし前に叫んだかどうか
        public SwingType SwingTyep { get; private set; }  // 刀を振る方法

        void Awake()
        {
            _stat = _statsHolder.GetStat(SwingerID.Samurai);
            _personal = _stat.SwingerPersonal;

            SwingTimer = _stat.FirstSwingTime;  // 最初の振り下ろしまでの時間を取得
            ScreemToFastSwing = _stat.ScreemToSwing;
            SwingTyep = _stat.FirstSwingType;  // 最初の振り下ろし方法を取得

        }

        void Start()
        {
            _animatorParametor = ServiceLocator.Resolve<AnimParamFacadeBase>();

            switch (_personal)
            {
                case SwingerPersonal.Normal:
                    _strategy = new NormalStrategy(this, _stateHolder);
                    break;
                case SwingerPersonal.Chiken:
                    _strategy = new ChickenStrategy(this, _stateHolder);
                    break;
                case SwingerPersonal.SpeedStar:
                    _strategy = new SpeedStarStrategy(this, _stateHolder);
                    break;
            }
        }

        //  SwingClass受け取り
        public void Initialize(Swing swing)
        {
            _swing = swing;
        }

        void Update()
        {
            _strategy.Update(Time.deltaTime);
        }

        //  叫ぶ
        public void Shout()
        {
            IsShout = true;
            _audioSource.PlayOneShot(_roundVoiceClip, 0.4f);
        }

        //  振り下ろす
        public void PerformSwing()
        {
            _stateHolder.IsCatchSword = false;
            _stateHolder.IsHitSwing = false;
            _animatorParametor.SwingerParam.IsCought(false);
            
            _swing.SwingSword(SwingTyep);
            SwingTimer = Random.Range(1, 10);
            SwingTyep = (SwingType)Random.Range(0, 2);

            IsShout = false;
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