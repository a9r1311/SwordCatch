using Kamatte.Core;
using UnityEngine;

namespace Kamatte.SwordCatch
{
    [DisallowMultipleComponent]
    public sealed class SwingTimeController : MonoBehaviour    //  刀を振るタイミングを決定するスクリプト
    {
        [SerializeField] SwingerIDStatPair _swingerIDStat;    //  お客さんの能力値が入ってるSO
        SwingerStatBlock _swingerStat;           //  お客さんの能力値
        SwordSwing _swingAction;             //  刀振りのコントローラー

        [SerializeField] StateHolder stateHolder;    //  ミニゲームのStateを集約してる、Reader層から呼ばれる。
        StateReader stateReader;    //  下位クラスからStateClassへのFacade、Judgeインスタンスからアクセス可否を判断する。
        StateWriter stateWriter;    //  下位クラスからStateを書き換えるためのFacade、judgeを通ったらState集約クラスの関数を使って書き換える
        
        SwingPersonal swingerPersonal;     //  刀振りの性格

        float swingTimer;     //  刀を振り下ろすまでのタイマー
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
            _swingAction = swingAction;

            swingerPersonal = _swingerStat.swingerPersonal;

            swingTimer = _swingerStat.swingTimer;
            stateReader = new StateReader(stateHolder);
            stateWriter = new StateWriter(stateHolder);
        }
        void Update()
        {
            if (!stateReader.AcceseState().HitSwingState.IsHitSwing)
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
                _swingAction.SwingSword(_swingTyep);
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