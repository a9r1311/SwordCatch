using SwordCatch.Core;
using System.Collections.Generic;
using UnityEngine;

namespace SwordCatch.Audio
{
    //  オーディオ管理クラス
    [DefaultExecutionOrder(-5)]
    [DisallowMultipleComponent]
    public sealed class AudioManager : MonoBehaviour
    {
        [Header("プール設定")]
        [SerializeField] int _initialPoolSize = 16;

        readonly Queue<AudioSource> _pool = new();
        readonly List<AudioSource> _activeSources = new();

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            ServiceLocator.Register(this);
            
            //  Pool初期化
            InitializePool();
        }

        //  Pool初期化
        void InitializePool()
        {
            for (int i = 0; i < _initialPoolSize; i++)
            {
                _pool.Enqueue(CreateNewAudioSourceInstance());
            }
        }

        //  PoolAudioSource作成
        AudioSource CreateNewAudioSourceInstance()
        {
            var child = new GameObject("PooledAudioSource");
            child.transform.SetParent(transform);
            var source = child.AddComponent<AudioSource>();
            source.playOnAwake = false;
            return source;
        }

        //  API
        public void PlaySE(AudioClip clip, float volume = 1f, float pitch = 1f, float spatialBlend = 0f)
        {
            if (clip == null) return;

            var source = _pool.Count > 0 ? _pool.Dequeue() : CreateNewAudioSourceInstance();

            source.clip = clip;
            source.volume = volume;
            source.pitch = pitch;
            source.loop = false;
            source.spatialBlend = spatialBlend;

            source.Play();

            _activeSources.Add(source);
        }

        void Update()
        {
            //  AudioSource再利用
            for (int i = _activeSources.Count - 1; i >= 0; i--)
            {
                var source = _activeSources[i];
                if (!source.isPlaying)
                {
                    _activeSources.RemoveAt(i);
                    source.clip = null;
                    _pool.Enqueue(source);
                }
            }
        }
    }
}