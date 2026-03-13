using UnityEngine;

namespace Kamatte.SwordCatch
{
    [RequireComponent(typeof(StateHolder_SwordCatch))]
    [DisallowMultipleComponent]
    public class StateSystemBootstrap_SwordCatch : MonoBehaviour
    {
        SwordCatchState swordCatchState;    //  ソードキャッチゲームの状態を集約してるクラス、ランナーに渡される。
        CatchState catchState;    //    キャッチの状況を持つクラス。
        HitSwingState hitSwingState;    //    キャッチの状況を持つクラス。

        [SerializeField] StateHolder_SwordCatch stateHolder;    //  ミニゲームのStateを集約してる、Reader層から呼ばれる。
        StateReader_SwordCatch stateReader;    //  下位クラスからStateClassへのFacade、Judgeインスタンスからアクセス可否を判断する。
        StateReadJudge_SwordCatch accessJudge;    //  アクセスが適正かを判断する関数をReader層から呼ばれる。

        void Awake()
        {
            if(stateHolder == null)
            {
                stateHolder =  GetComponent<StateHolder_SwordCatch>();
                Debug.LogWarning("SwordCatchStateRunner isn't assigned");
            }

            catchState = new CatchState();
            hitSwingState = new HitSwingState();
            swordCatchState = new SwordCatchState(catchState, hitSwingState);

            accessJudge = new StateReadJudge_SwordCatch();
            stateReader = new StateReader_SwordCatch(stateHolder, accessJudge);
        }

        void Start()
        {
            stateHolder.Initialize(swordCatchState);
        }
    }
}