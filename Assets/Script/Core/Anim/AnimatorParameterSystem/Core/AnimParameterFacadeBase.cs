using Kamatte.SwordCatch;

namespace Kamatte.Core
{
    public abstract class AnimParamFacadeBase    //  イベントなどの際に差し替えするためのBaseClass
    {
        public virtual AnimParam_Player PlayerParam { get;}    //  プレイヤーのパラーメーター集約クラス
        public virtual AnimParam_Swinger SwingerParam { get; }    //  刀振りのパラーメーター集約クラス
    }
}