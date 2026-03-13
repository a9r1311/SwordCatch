using UnityEngine;

namespace Kamatte.Core
{
    public class FPSSetter : MonoBehaviour    //  FPSを固定する
    {
        public static FPSSetter Instance { get; private set; }    //  インスタンス
        //public event Action OnGameFrameUpdate;                    //  フレーム進行でおこるイベント

        public int targetFPS = 60;
        public float FixedDeltaTime => 1f / targetFPS;
        public long FrameCount { get; private set; } = 0;

        private float timer = 0f;


        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        void Update()
        {
            timer += Time.unscaledDeltaTime;

            while (timer >= FixedDeltaTime)
            {
                timer -= FixedDeltaTime;
                FrameCount++;
                //OnGameFrameUpdate?.Invoke();
            }
        }
    }
}