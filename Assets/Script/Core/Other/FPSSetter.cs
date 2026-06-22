using UnityEngine;

namespace Kamatte.Core
{
    [DisallowMultipleComponent]
    public sealed class FPSSetter : MonoBehaviour    //  FPSをセットする
    {
        [SerializeField, Range(30, 120)] private int _targetFPS = 60;

        private void Awake()
        {
            Application.targetFrameRate = _targetFPS;
            QualitySettings.vSyncCount = 0;
        }
    }
}