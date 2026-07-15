using System.Collections;
using UnityEngine;

namespace Kamatte.Core
{
    //  コルーチンランナー
    public sealed class CoroutineRunner : MonoBehaviour
    {
        public Coroutine StartCoroutine(IEnumerator routine) => base.StartCoroutine(routine);  // コルーチン開始
        public void StopCoroutine(Coroutine coroutine) => base.StopCoroutine(coroutine);  // コルーチン停止
        
        void Awake()
        {
            ServiceLocator.Register<CoroutineRunner>(this);
            DontDestroyOnLoad(this.gameObject);
        }
    }
}