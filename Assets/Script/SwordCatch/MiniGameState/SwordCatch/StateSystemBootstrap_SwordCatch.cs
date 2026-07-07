using UnityEngine;

namespace Kamatte.SwordCatch
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(StateHolder))]
    public sealed class StateSystemBootstrap : MonoBehaviour
    {
        [SerializeField] StateHolder stateHolder;    //  ミニゲームのStateを集約してる、Reader層から呼ばれる。

        void Awake()
        {
            if(stateHolder == null)
            {
                stateHolder =  GetComponent<StateHolder>();
                Debug.LogWarning("SwordCatchStateRunner isn't assigned");
            }
        }
    }
}