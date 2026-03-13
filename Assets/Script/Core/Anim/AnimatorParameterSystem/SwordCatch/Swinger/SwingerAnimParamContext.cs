namespace Kamatte.SwordCatch
{
    public class SwingerAnimParamContext
    {
        public SwingerParam_NormalSwing NormalSwing { get; }
        public SwingerParam_FastSwing FastSwing{ get; }
        public SwingerParam_DelaySwing DelaySwing { get; }
        public SwingerParam_IsHited IsHited { get; }
        public SwingerParam_IsCatch IsCatch { get; }

        public SwingerAnimParamContext(SwingerParam_NormalSwing normalSwing, SwingerParam_FastSwing fastSwing, SwingerParam_DelaySwing delaySwing, SwingerParam_IsHited isHited, SwingerParam_IsCatch isCatch)
        {
            NormalSwing = normalSwing;
            FastSwing = fastSwing;
            DelaySwing = delaySwing;
            IsHited = isHited;
            IsCatch = isCatch;
        }
    }
}