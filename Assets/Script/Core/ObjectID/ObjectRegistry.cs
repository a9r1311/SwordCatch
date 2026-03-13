using System.Collections.Generic;
using UnityEngine;

//  オブジェクトとIDを辞書登録
namespace Kamatte.ID
{
    public class ObjectRegistry : MonoBehaviour
    {
        private static Dictionary<string, GameObject> registry = new();    //  オブジェクトのID辞書
        void Awake()
        {
            IDGenerater idObject = GetComponent<IDGenerater>();    //  IDObjectのインスタンス
            if (idObject != null)
            {
                //  オブジェクト登録
                Register(idObject.IDProperty, GetComponent<IDGenerater>());
            }
        }
        //  オブジェクト登録関数
        public static void Register(string id, IDGenerater idGenerator)
        {
            if (string.IsNullOrEmpty(id))
            {
                return;
            }
            if (!registry.ContainsKey(id))
            {
                registry.Add(id, idGenerator.gameObject);
            }
        }
        //  IDのゲームオブジェクトを出力
        public static GameObject Get(string id)
        {
            return registry.TryGetValue(id, out var go) ? go : null;
        }
    }
}