using UnityEngine;

namespace Kamatte.SwordCatch
{
    [RequireComponent(typeof(StateHolder))]
    [DisallowMultipleComponent]
    public class StateSystemBootstrap : MonoBehaviour
    {
        SwordCatchState swordCatchState;    //  ソードキャッチゲームの状態を集約してるクラス、ランナーに渡される。
        CatchState catchState;    //    キャッチの状況を持つクラス。
        HitSwingState hitSwingState;    //    キャッチの状況を持つクラス。

        [SerializeField] StateHolder stateHolder;    //  ミニゲームのStateを集約してる、Reader層から呼ばれる。
        StateReader stateReader;    //  下位クラスからStateClassへのFacade、Judgeインスタンスからアクセス可否を判断する。

        void Awake()
        {
            if(stateHolder == null)
            {
                stateHolder =  GetComponent<StateHolder>();
                Debug.LogWarning("SwordCatchStateRunner isn't assigned");
            }

            catchState = new CatchState();
            hitSwingState = new HitSwingState();
            swordCatchState = new SwordCatchState(catchState, hitSwingState);

            stateReader = new StateReader(stateHolder);
        }

        void Start()
        {
            stateHolder.Initialize(swordCatchState);
        }
    }
}