using UnityEngine;

namespace Kamatte.SwordCatch
{
    //  頭にアタッチして衝突を検知してもらう
    [DisallowMultipleComponent]
    public sealed class HeadColliderProxy : MonoBehaviour
    {
        [SerializeField] SwordHitNotifier hitNotifier;

        void Start()
        {
            // 実行順の影響か何かでTrueになってしまうのでコメントアウト
            //Debug.Assert(hitNotifier == null, "hitNotifierの参照がありません。");
　　　　}

        void OnTriggerEnter(Collider other)
        {
            if (hitNotifier == null) return;
            if (!other.CompareTag("Sword")) return;

            hitNotifier.OnSwordHit(other);
        }
    }
}