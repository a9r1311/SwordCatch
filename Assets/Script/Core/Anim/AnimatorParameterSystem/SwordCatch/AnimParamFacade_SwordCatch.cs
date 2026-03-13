using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public sealed class AnimParamFacade_SwordCatch : AnimParamFacadeBase    //  下位クラスからSLを通してアクセスされるアニメーションパラメータいじるシステム
    {
        public override AnimParam_Player PlayerParam { get; }    //  プレイヤーのパラメーター集約クラス
        public override AnimParam_Swinger SwingerParam { get; }    //  刀振りのパラメーター集約クラス

        public AnimParamFacade_SwordCatch(AnimParam_Player playerPalam, AnimParam_Swinger swingerParam)
        {
            PlayerParam = playerPalam;
            SwingerParam = swingerParam;
        }
    }
}