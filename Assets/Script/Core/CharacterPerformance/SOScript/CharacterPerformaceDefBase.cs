using UnityEngine;

namespace Kamatte.Core
{
    //  エフェクト定義クラス継承元
    public abstract class CharacterPerformanceDefBase : ScriptableObject
    {
        [Header("演出用動きを定義してるSOのKey")]

        //  --  Abstract
       
        public abstract PerformaceKey Key { get; }
        
        public abstract void Execute(GameObject target);    //  演出用の動き実行
       
        //  --  Virtual
    
        public virtual float BlowPower { get; }    //  吹き飛ばし力
        public virtual Vector3 BlowDir { get; }    //  吹き飛ばし方向

    }
}
