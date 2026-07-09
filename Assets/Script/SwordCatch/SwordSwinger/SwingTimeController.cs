using Kamatte.Core;
using UnityEngine;

namespace Kamatte.SwordCatch
{
    //  刀を振るタイミングを決定するスクリプト
    [DisallowMultipleComponent]
    public sealed class SwingTimeController : MonoBehaviour
    {
        [SerializeField] StateHolder _stateHolder;  // ゲーム状態クラス

        [SerializeField] SwingerIDStatPair _swingerIDStat;  // スウィンガーの能力値SO
        SwingerStatBlock _swingerStat;  // 刀役の能力値(キャッシュ用)
        Swing _swing;  // 刀振りのコントローラー
        SwingPersonal swingerPersonal;     //  刀振りの性格

        float _swingTimer;  // 刀を振り下ろすまでのタイマー
        float _screemToFastSwing;  // 叫んでから高速振り下ろしするまでの時間
        bool IsSpraked = false;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip RoundVoiceClip;

        SwingType _swingTyep = SwingType.Normal;

        void Awake()
        {
            _swingerStat = _swingerIDStat.GetStat(SwingerID.Samurai);
            swingerPersonal = _swingerStat.SwingerPersonal;

            _swingTimer = _swingerStat.SwingTimer;
            _screemToFastSwing = _swingerStat.ScreemToSwing;
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
            switch (swingerPersonal)
            {
                case SwingPersonal.Chiken:
                    ChikenUpdate();
                    break;
                case SwingPersonal.SwordMaster:
                    SwordMasterUpdate();
                    break;
                case SwingPersonal.SpeedStar:
                    SpeedStarUpdate();
                    break;
            }
            //if(Swingway == 1 && swingTimer < 0.74f && !IsSpraked)
            if(_swingTyep == SwingType.Fast && _swingTimer < _screemToFastSwing && !IsSpraked)
            {
                IsSpraked = true;
                audioSource.PlayOneShot(RoundVoiceClip, 0.4f);
            }
            if (_swingTimer < 0)
            {
                _stateHolder.IsCatchSword = false;
                ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.IsCought(false);
                _stateHolder.IsHitSwing = false;
                _swing.SwingSword(_swingTyep);
                _swingTimer = Random.Range(1, 10);
                _swingTyep = (SwingType)Random.Range(0, 2);
                IsSpraked = false;
            }
        }

        //  性格ChikenのUpdate
        void ChikenUpdate()
        {

        }

        //  性格SwordMasterUpdate
        void SwordMasterUpdate()
        {
            if (_swingTimer < 0)
            {
                //  Swing
            }
        }

        //  性格SpeedStarのUpdate
        void SpeedStarUpdate()
        {
            if (_swingTimer < 0)
            {
                //  Swing
            }
        }
    }
}