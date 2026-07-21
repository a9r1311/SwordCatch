using System.Collections;
using UnityEngine;

namespace SwordCatch.Core
{
    //  コルーチンランナー
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(-10)]
    public sealed class CoroutineRunner : MonoBehaviour
    {

        void Awake()
        {
            ServiceLocator.Register<CoroutineRunner>(this);
            DontDestroyOnLoad(this.gameObject);
        }

        // コルーチン開始
        public Coroutine StartCoroutine(IEnumerator routine) => base.StartCoroutine(routine);

        // コルーチン停止
        public void StopCoroutine(Coroutine coroutine) => base.StopCoroutine(coroutine);
    }
}