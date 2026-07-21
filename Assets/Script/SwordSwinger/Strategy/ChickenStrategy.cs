using SwordCatch.Core;
using SwordCatch.SwordCatch;

namespace SwordCatch.Swinger
{
    //  性格 : チキンの振り方
    public sealed class ChickenStrategy : ISwingStrategy
    {
        SwingerController _controller;  // 時間管理クラス
        StateHolder _stateHolder;  // ゲーム状況保持クラス
        readonly float _timeScale = 0.9f;  // 性格によるタイマー補正

        public ChickenStrategy(SwingerController controller, StateHolder stateHolder)
        {
            _controller = controller;
            _stateHolder = stateHolder;
        }

        public void Update(float deltaTime)
        {
            if (!_stateHolder.IsHitSwing)
            {
                _controller.SwingTimer -= deltaTime * _timeScale;

                if (
                    _controller.SwingTimer < _controller.ScreemToFastSwing &&
                    _controller.SwingTyep == SwingType.Fast &&
                    !_controller.IsShout
                    )
                {
                    _controller.Shout();
                }

                if (_controller.SwingTimer < 0)
                {
                    _controller.PerformSwing();
                }
            }
        }
    }
}