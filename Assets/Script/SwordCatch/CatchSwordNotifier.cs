using UnityEngine;
using Kamatte.Core;

namespace Kamatte.Player
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class CatchSwordNotifier : MonoBehaviour    //  白刃取り
    {
        [SerializeField] Vector3 StarEffectSpawnPos;    //  星を生成するポジション

        private void OnEnable()
        {
            //SwordCatchEventBus.OnCatchPressed += ;
        }

        private void OnDisable()
        {
            //SwordCatchEventBus.OnCatchPressed -= HandleCatch;
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sword"))
            {
                Debug.Log("嵐北まるでざぶーん");
                LogUtility.Log(LogPrefix.CatchSwordNotifier, "嵐北まるでざぶーん", LogLevel.Info);
                //SwordCatchEventBus.OnCatchSuccess();
            }
        }
    }
}
