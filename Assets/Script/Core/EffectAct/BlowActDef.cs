using UnityEngine;

namespace Kamatte.Core
{
    [CreateAssetMenu(fileName ="BlowActDef",menuName = "EffectAct/BlowActDef")]
    public class BlowActDef : EffectActDef    //  êÅÇ´îÚÇ—ââèoíËã`
    {
        [Header("Key")]
        [SerializeField] EffectActKey _key;
        [Header("êÅÇ´îÚÇŒÇµóÕ")]
        [SerializeField] float _blowPower;
        [Header("êÅÇ´îÚÇŒÇµï˚å¸")]
        [SerializeField] Vector3 _blowDir;


        //  --  Public API

        public override EffectActKey EffectActKey => _key;
        public override float BlowPower  => _blowPower;
        public override Vector3 BlowDir => _blowDir;

        public override void Execute(GameObject target)    //  êÅÇ´îÚÇ—é¿çs
        {
            Vector3 BlowForce = _blowPower * _blowDir;

            if(target == null)
            {
                return; }

            Rigidbody rb;
            if (!target.TryGetComponent<Rigidbody>(out rb))
            {
                rb = target.AddComponent<Rigidbody>();
            }

            rb.AddForce(BlowForce, ForceMode.Impulse);

        }
    }
}