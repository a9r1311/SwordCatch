using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    //  アニメーションを操作するための窓口
    public sealed class AnimParamFacade : AnimParamFacadeBase
    {
        public override AnimParam_Player PlayerParam { get; }    //  プレイヤーのパラメーター保持クラス
        public override AnimParam_Swinger SwingerParam { get; }    //  刀振りのパラメーター保持クラス

        public AnimParamFacade(AnimParam_Player playerPalam, AnimParam_Swinger swingerParam)
        {
            PlayerParam = playerPalam;
            SwingerParam = swingerParam;
        }
    }
}