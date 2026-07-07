using Kamatte.Core;
using UnityEngine;

namespace Kamatte.SwordCatch
{
    //  刀を振るタイミングを決定するスクリプト
    [DisallowMultipleComponent]
    public sealed class SwingTimeController : MonoBehaviour
    {
        [SerializeField] SwingerIDStatPair _swingerIDStat;  // 刀役の能力値が入ってるSO
        SwingerStatBlock _swingerStat;  // 刀役の能力値(キャッシュ)
        SwordSwing _swordSwing;  // 刀振りのコントローラー
        SwingPersonal swingerPersonal;     //  刀振りの性格

        [SerializeField] StateHolder stateHolder;  // ゲーム状態クラス
        StateReader stateReader;  // ゲーム状態を読み取るクラス
        StateWriter stateWriter;  // ゲーム状態を書き換える

        float swingTimer;  // 刀を振り下ろすまでのタイマー
        bool IsSpraked = false;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip RoundVoiceClip;

        SwingType _swingTyep = SwingType.Normal;

        private void Awake()
        {
            _swingerStat = _swingerIDStat.GetStat(SwingerID.Samurai);
            swingerPersonal = _swingerStat.swingerPersonal;

            swingTimer = _swingerStat.swingTimer;
        }
        public void Initialize(SwordSwing swingAction)    //  クラス変数初期化
        {
            _swingerStat = _swingerIDStat.GetStat(SwingerID.Samurai);
            _swordSwing = swingAction;

            swingerPersonal = _swingerStat.swingerPersonal;

            swingTimer = _swingerStat.swingTimer;
            stateReader = new StateReader(stateHolder);
            stateWriter = new StateWriter(stateHolder);
        }
        void Update()
        {
            if (!stateReader.StateHolder.IsHitSwing)
            {
                swingTimer -= Time.deltaTime;
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
            if(_swingTyep == SwingType.Fast && swingTimer < 0.74f && !IsSpraked)
            {
                IsSpraked = true;
                audioSource.PlayOneShot(RoundVoiceClip, 0.4f);
            }
            if (swingTimer < 0)
            {
                stateWriter.ChangeCatchState(false);
                ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.IsCatch.SetBool(false);
                stateWriter.ChangeHitSwingState(false);
                _swordSwing.SwingSword(_swingTyep);
                swingTimer = Random.Range(1, 10);
                _swingTyep = (SwingType)Random.Range(0, 2);
                IsSpraked = false;
            }
        }
        void ChikenUpdate()    //  性格ChikenのUpdate
        {

        }
        void SwordMasterUpdate()    //  性格SwordMasterUpdate
        {
            if (swingTimer < 0)
            {
                //  Swing
            }
        }
        void SpeedStarUpdate()    //  性格SpeedStarのUpdate
        {
            if (swingTimer < 0)
            {
                //  Swing
            }
        }
    }
}