using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamatte.Core
{
    //  システム系を使うためのServiceLocator
    public static class ServiceLocator
    {
        static readonly Dictionary<Type, object> services = new();  // 機能辞書

        //  --  Public API

        //  機能登録
        public static void Register<T>(T service)
        {
            var type = typeof(T);

#if UNITY_EDITOR
            if (services.ContainsKey(type))
            {
                Debug.LogWarning($"{type.Name} は既に登録されています。上書きします。");
            }
#endif
            services[typeof(T)] = service;
        }

        //  機能取り出し
        public static T Resolve<T>()
        {
            if (!services.TryGetValue(typeof(T), out var service))
            {
                throw new InvalidOperationException($"[ServiceLocator] {typeof(T).Name} が登録されていません。");
            }

            return (T)services[typeof(T)];
        }

        //  登録解除
        public static void Unregister<T>()
        {
            services.Remove(typeof(T));
        }

        //  全機能クリア
        public static void Clear()
        {
            services.Clear();
        }

        //  メモリ解法(重処理)
        public static void TrimServiceDict()
        {
            services.TrimExcess();
        }
    }
}