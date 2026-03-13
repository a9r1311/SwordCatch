namespace Kamatte.SwordCatch
{
    public abstract class SwordCatchStateBase
    {
        public abstract CatchState CatchState { get; }
        public abstract HitSwingState HitSwingState { get; }
    }
}