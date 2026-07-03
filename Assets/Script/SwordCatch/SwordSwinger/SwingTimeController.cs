using Kamatte.Core;
using Kamatte.Customer;
using UnityEngine;

namespace Kamatte.SwordCatch
{
    public class SwingTimeController : MonoBehaviour    //  刀を振るタイミングを決定するスクリプト
    {
        [SerializeField] CustomerIDStatPair _customerIDStat;    //  お客さんの能力値が入ってるSO
        CustomerStatBlock _customerStat;           //  お客さんの能力値
        SwordSwing _swingAction;             //  刀振りのコントローラー

        [SerializeField] StateHolder_SwordCatch stateHolder;    //  ミニゲームのStateを集約してる、Reader層から呼ばれる。
        StateReader_SwordCatch stateReader;    //  下位クラスからStateClassへのFacade、Judgeインスタンスからアクセス可否を判断する。
        StateReadJudge_SwordCatch readJudge;    //  アクセスが適正かを判断する関数をReader層から呼ばれる。
        StateWriter stateWriter;    //  下位クラスからStateを書き換えるためのFacade、judgeを通ったらState集約クラスの関数を使って書き換える
        
        SwingerPersonal swingerPersonal;     //  刀振りの性格

        float swingTimer;     //  刀を振り下ろすまでのタイマー
        bool isTimerStop = false;
        bool IsSpraked = false;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip RoundVoiceClip;

        int Swingway = 0;
        SwingType _swingTyep = SwingType.Normal;

        private void Awake()
        {
            _customerStat = _customerIDStat.GetStat(CustomerID.Samurai);
            swingerPersonal = _customerStat.swingerPersonal;

            swingTimer = _customerStat.swingTimer;
        }
        public void Initialize(SwordSwing swingAction)    //  クラス変数初期化
        {
            _customerStat = _customerIDStat.GetStat(CustomerID.Samurai);
            _swingAction = swingAction;

            swingerPersonal = _customerStat.swingerPersonal;

            swingTimer = _customerStat.swingTimer;
            readJudge = new StateReadJudge_SwordCatch();
            stateReader = new StateReader_SwordCatch(stateHolder, readJudge);
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
                case SwingerPersonal.Chiken:
                    ChikenUpdate();
                    break;
                case SwingerPersonal.SwordMaster:
                    SwordMasterUpdate();
                    break;
                case SwingerPersonal.SpeedStar:
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