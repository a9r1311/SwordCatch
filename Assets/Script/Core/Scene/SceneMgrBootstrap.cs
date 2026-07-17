using UnityEngine;
using Kamatte.Core;

namespace SwordCatch.Core
{
    //  シーンマネージャーの
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(-10)]
    public sealed class SceneMgrBootstrap : MonoBehaviour
    {
        [SerializeField] SceneMapping _sceneMapping;

        void Awake()
        {
            SceneMgr sceneMgr = new SceneMgr(_sceneMapping);
            ServiceLocator.Register<SceneMgr>(sceneMgr);
        }
    }
}