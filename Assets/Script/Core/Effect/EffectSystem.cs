using UnityEngine;
using System.Collections.Generic;

namespace Kamatte.Core
{
    //  エフェクト処理システム
    [DefaultExecutionOrder(-10)]
    public sealed class EffectSystem : MonoBehaviour
    {
        [Header("エフェクトカタログ")]
        [SerializeField] EffectCatalog _catalog;

        readonly Dictionary<EffectKey, GameObject> _playingEffects = new();

        void Awake()
        {
            //  登録
            ServiceLocator.Register<EffectSystem>(this);
        }

        void OnDestroy()
        {
            //  登録解除
            ServiceLocator.Unregister<EffectSystem>();
        }

        //  エフェクト再生
        public void Play(EffectKey key)
        {
            EffectDefinition definition = _catalog.Get(key);

            if (definition == null)
            {
                Debug.LogWarning($"EffectDefinition not found : {key}");
                return;
            }

            //  エフェクトを一回再生終了する
            Stop(key);

            GameObject effect;

            if (definition.PotitionType == EffectPositionType.NonFixedPositon)
            {
                effect = Instantiate(definition.EffectPrefab, GetLightningPos(definition) , definition.EffectPrefab.transform.rotation);
            }
            else
            {
                effect = Instantiate(definition.EffectPrefab, definition.Position, definition.EffectPrefab.transform.rotation);
            }

            _playingEffects[key] = effect;
        }

        //  エフェクト停止
        public void Stop(EffectKey key)
        {
            if (!_playingEffects.TryGetValue(key, out var instance))
                return;

            Destroy(instance);
            _playingEffects.Remove(key);
        }

        //  雷の座標(ランダム)を取得する
        Vector3 GetLightningPos(EffectDefinition definition)
        {
            if (definition.Key.Equals(new EffectKey(GameMode.SwordCatch, EffectKind.Lightning)))
            {
                Vector3 LightningAddPos = Random.insideUnitSphere * definition.RandomEffectPosRadius;
                Vector3 LightningPos = new Vector3(definition.Position.x + LightningAddPos.x, definition.Position.y, definition.Position.z + LightningAddPos.z);

                return LightningPos;
            }
            else
            {
                return definition.Position;
            }
        }
    }
}