using UnityEngine;

namespace Kamatte.Core
{
    //  吹き飛び演出定義
    [CreateAssetMenu(fileName ="PlayerBlowPerformaneceDef",menuName = "Character/Performace/PlayerBlow")]
    public sealed class PlayerBlowPerformaneceDef : CharacterPerformanceDefBase
    {
        [Header("プレイヤーの白刃取り失敗吹き飛び")]
        [SerializeField] PerformaceKey _key;
        [SerializeField] float _blowPower = 30f;
        [SerializeField] Vector3 _blowDir;

        public override PerformaceKey Key => _key;
        public override float BlowPower  => _blowPower;
        public override Vector3 BlowDir => _blowDir;

        //  吹き飛び実行
        public override void Execute(GameObject target)
        {
            Vector3 BlowForce = _blowPower * _blowDir;

            if(target == null) return;

            Rigidbody rb;

            if (!target.TryGetComponent<Rigidbody>(out rb))
            {
                rb = target.AddComponent<Rigidbody>();
            }
            else
            {
                MyLogger.ErrorLog("PlayerにRigidBodyがアタッチされています、外して下さい");
            }
            rb.AddForce(BlowForce, ForceMode.Impulse);
        }
    }
}