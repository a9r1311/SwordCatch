using SwordCatch.Animation;
using SwordCatch.CharacterPerformance;
using SwordCatch.Core;
using UnityEngine;
using UAssert = UnityEngine.Assertions.Assert;

namespace SwordCatch.Player
{
    //  刀が当たった時の処理をするクラス
    [DisallowMultipleComponent]
    public sealed class SwordHitNotifier : MonoBehaviour
    {
        [SerializeField] PlayerController _playerController;
        [SerializeField] StateHolder _stateHolder;  // ゲーム状態を保持しているクラス

        CharacterPerformanceSystem _characterPerformanceSystem;

        AnimParamFacade _animationFacade;

        void Awake()
        {
            UAssert.IsNotNull(_playerController, " playerContorollerが未設定です");
            UAssert.IsNotNull(_stateHolder, "stateHolderが未設定です");
        }

        void Start()
        {
            _animationFacade = ServiceLocator.Get<AnimParamFacade>();
            _characterPerformanceSystem = ServiceLocator.Get<CharacterPerformanceSystem>();
        }

        //  刀が当たった時の処理
        public void OnSwordHit(Collider other)
        {
            if (!other.CompareTag("Sword")) return;

            if (!_stateHolder.IsCatchSword)
            {
                _playerController.EraseHitBox();
                _stateHolder.IsHitSwing = true;
                _characterPerformanceSystem.Play(
                    new PerformaceKey(Performer.Player, EffectActTrigger.HitSword, PerformaceType.Blow)
                    );
                _animationFacade.SwingerParam.IsHit(true);
            }
        }
    }
}