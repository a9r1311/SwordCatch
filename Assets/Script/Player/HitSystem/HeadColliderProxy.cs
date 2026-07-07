using UnityEngine;

namespace Kamatte.SwordCatch
{
    //  頭にアタッチして衝突を検知してもらう
    [DisallowMultipleComponent]
    public sealed class HeadColliderProxy : MonoBehaviour
    {
        [SerializeField] SwordHitNotifier hitNotifier;

        void Awake()
        {
            if (hitNotifier == null)
            {
                Debug.LogError("hitNotifierの参照がありません。");
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (hitNotifier == null) return;
            if (!other.CompareTag("Sword")) return;
         
            hitNotifier.OnSwordHit(other);
        }
    }
}