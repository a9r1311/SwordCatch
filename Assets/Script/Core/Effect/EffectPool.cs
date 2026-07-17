using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

namespace Kamatte.Core
{
    //  EffectSystemから呼び出すためのプール管理クラス
    //  (汎用性が欲しいクラスではないのでServiceLocatorには登録しません)
    public sealed class EffectPool
    {
        // エフェクトごとにプールを保持する辞書
        static readonly Dictionary<GameObject, IObjectPool<GameObject>> _pools = new();

        //  エフェクト取得
        public static GameObject Get(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            if (!_pools.TryGetValue(prefab, out var pool))
            {
                pool = new ObjectPool<GameObject>(
                    createFunc: () => Object.Instantiate(prefab),
                    actionOnGet: (obj) => {
                        obj.SetActive(true);
                        obj.transform.SetPositionAndRotation(position, rotation);
                    },
                    actionOnRelease: (obj) => obj.SetActive(false),
                    actionOnDestroy: (obj) => Object.Destroy(obj),
                    defaultCapacity: 10,
                    maxSize: 50
                );
                _pools[prefab] = pool;
            }

            var instance = pool.Get();
            instance.transform.SetPositionAndRotation(position, rotation);
            return instance;
        }

        //  エフェクト削除
        public static void Release(GameObject prefab, GameObject instance)
        {
            if (_pools.TryGetValue(prefab, out var pool))
            {
                pool.Release(instance);
            }
            else
            {
                Object.Destroy(instance);
            }
        }
    }
}