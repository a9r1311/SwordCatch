using UnityEngine;

namespace Kamatte.SwordCatch
{
    public sealed class HeadColliderProxy : MonoBehaviour    //  頭オブジェクトにアタッチして代わりに衝突を検知してもらう
    {
        [SerializeField] private SwordHitNotifier hitNotifier;

        private void Awake()
        {
            if (hitNotifier == null)
            {
                Debug.LogError("hitNotifierの参照がありません。");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (hitNotifier != null)
            {
                hitNotifier.OnSwordHit(other);
            }
        }
    }
}