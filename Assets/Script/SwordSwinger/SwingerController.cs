using UnityEngine;
using SwordCatch.Core;
using SwordCatch.SwordCatch;
using SwordCatch.Animation;
using SwordCatch.Audio;

namespace SwordCatch.Swinger
{
    //  刀を振るタイミングを決定するスクリプト
    [DisallowMultipleComponent]
    public sealed class SwingerController : MonoBehaviour
    {
        [SerializeField] StateHolder _stateHolder;  // ゲーム状態保持クラス

        [SerializeField] SwingerStatsHolder _statsHolder;  // Swingerの能力値
        SwingerStatBlock _stat;  // Swignerの能力値(キャッシュ用)
        Swing _swing;  // Swingerのコントローラー

        SwingerPersonal _personal;  // Swingerの性格
        ISwingStrategy _strategy;  // 性格ごとの振り方

        AnimParamFacade _animatorParametor;  // アニメーターのパラメーターを保持してるクラス
        
        AudioManager _audioManager;
        [SerializeField] AudioClip _shoutClip;  // 高速振り下ろし前の合図Voice

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
            _animatorParametor = ServiceLocator.Get<AnimParamFacade>();
            _audioManager = ServiceLocator.Get<AudioManager>();

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
            MyLogger.Log("Shout");
            IsShout = true;
            _audioManager.PlaySE(_shoutClip, 0.4f);
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
    }
}