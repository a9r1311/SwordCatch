using UnityEngine;

namespace Kamatte.Core
{
    public abstract class EffectActDef : ScriptableObject    //  エフェクト定義クラス継承元
    {
        [Header("演出用動きを定義してるSOのKey")]
        

        //  --  Abstract
       
        public abstract EffectActKey EffectActKey { get; }
        
        public abstract void Execute(GameObject target);    //  演出用の動き実行
       
        //  --  Virtual
    
        public virtual float BlowPower { get; }    //  吹き飛ばし力
        public virtual Vector3 BlowDir { get; }    //  吹き飛ばし方向

    }
}
