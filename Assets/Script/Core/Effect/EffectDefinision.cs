using UnityEngine;

namespace Kamatte.Core
{
    //  Effect定義
    [CreateAssetMenu(fileName = "EffectDefinition", menuName = "Effect/Definition")]
    public sealed class EffectDefinition : ScriptableObject
    {
        [Header("エフェクト設定")]

        [Tooltip("エフェクト特定の為のオリジナルKey")]
        public EffectKey Key;
        
        [Tooltip("再生するエフェクトのプレハブ")]
        public GameObject EffectPrefab;
        
        [Tooltip("エフェクトの座標が固定か、ブレるか")]
        public EffectPositionType PotitionType;

        [Tooltip("エフェクト再生位置")]
        public Vector3 Position;
    }
}