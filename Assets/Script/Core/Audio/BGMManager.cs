//using UnityEngine;
//using UnityEngine.Audio;
//using System.Collections;

//namespace Kamatte.Core
//{
//    public class BGMManager : MonoBehaviour    //  BGM管理クラス
//    {
//        public static BGMManager Instance { get; private set; }    //  シングルトン

//        [SerializeField] private BGMDatabase database;    //  BGMDatabase
//        [SerializeField] private AudioMixerGroup mixerGroup;    //  ミキサー

//        private AudioSource _current;    //  現在のオーディオソース
//        private AudioSource _next;    //  次のオーディオソース
//        private Coroutine _fadeRoutine;    //  フェードコルーチン
        
//        void Awake()
//        {
//            if (Instance != null)
//            {
//                Destroy(gameObject);
//                return;
//            }
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//            _current = CreateSource("BGM_Current");
//            _next = CreateSource("BGM_Next");
//        }

//        AudioSource CreateSource(string name)
//        {
//            var go = new GameObject(name);
//            go.transform.SetParent(transform);
//            var src = go.AddComponent<AudioSource>();
//            src.outputAudioMixerGroup = mixerGroup;
//            src.playOnAwake = false;
//            return src;
//        }

//        //  ----  外部API

//        public void Play(BGMData bgmData)    //  BGMKkeyに応じたBGM再生
//        {
//            BGMKey key = BGMKeyGenerator.Generate(bgmData);

//            var data = database.Get(key);
//            if (data == null)
//            {
//                Debug.LogWarning($"BGM not found: {key}");
//                return;
//            }

//            if (_fadeRoutine != null)
//            {
//                StopCoroutine(_fadeRoutine);
//            }
//            _fadeRoutine = StartCoroutine(CrossFade(data));
//        }
//        public void Stop(float fadeTime = 1f)    //  BGM再生停止
//        {
//            if (_fadeRoutine != null)
//            {
//                StopCoroutine(_fadeRoutine);
//            }
//            _fadeRoutine = StartCoroutine(FadeOut(_current, fadeTime));
//        }
        
//        //  -- Internal API

//        IEnumerator CrossFade(BGMData data)
//        {
//            _next.clip = data.AudioClip;
//            _next.volume = 0f;
//            _next.loop = data.Loop;
//            _next.Play();
//            float time = 0f;

//            while (time < data.FadeTime)
//            {
//                time += Time.unscaledDeltaTime;
//                float t = time / data.FadeTime;
//                _current.volume = Mathf.Lerp(_current.volume, 0f, t);
//                _next.volume = Mathf.Lerp(0f, data.DefaultVolume, t);
//                yield return null;
//            }

//            _current.Stop();
//            SwapSources();
//        }

//        IEnumerator FadeOut(AudioSource source, float fadeTime)
//        {
//            float startVolume = source.volume;
//            float time = 0f;
//            while (time < fadeTime)
//            {
//                time += Time.unscaledDeltaTime;
//                source.volume = Mathf.Lerp(startVolume, 0f, time / fadeTime);
//                yield return null;
//            }
//            source.Stop();
//        }

//        //  ---- private API
//        void SwapSources()
//        {
//            var temp = _current;
//            _current = _next;
//            _next = temp;
//        }
//    }
//}