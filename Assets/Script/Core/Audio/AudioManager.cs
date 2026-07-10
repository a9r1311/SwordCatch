using System.Collections.Generic;
using UnityEngine;

namespace Kamatte.Core
{

    //  Audio管理クラス
    [DisallowMultipleComponent]
    public sealed class AudioManager : MonoBehaviour
    {
        static AudioManager _instance;
        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<AudioManager>();
                    if (_instance == null)
                    {
                        var go = new GameObject("AudioManager");
                        _instance = go.AddComponent<AudioManager>();
                        DontDestroyOnLoad(go);
                    }
                }
                return _instance;
            }
        }

        [Header("プール設定")]
        [SerializeField] int _initialPoolSize = 16;

        readonly Queue<AudioSource> _pool = new();
        readonly List<AudioSource> _activeSources = new();

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);

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
            if (clip == null)
            {
                Debug.Log("nari");
                return;
            }
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