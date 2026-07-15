namespace Kamatte.SwordCatch
{
    //  “U‚è‚ÌAnimatorParametorStringƒNƒ‰ƒX(ˆø”È—ª—p)
    public sealed class SwingerAnimParameters
    {
        public string NormalSwing { get; private set; }
        public string FastSwing { get; private set; }
        //public string DelaySwing { get; private set; }  // Delay‚Í‚Ş‚¸‚¢‚©‚çˆê’U‚È‚µ
        public string IsHit { get; private set; }
        public string IsCought { get; private set; }
        
        public SwingerAnimParameters(
            string normalSwing,
            string fastSwing,
            //string delaySwing,  // Delay‚Í‚Ş‚¸‚¢‚©‚çˆê’U‚È‚µ
            string isHit,
            string isCought)
        {
            NormalSwing = normalSwing;
            FastSwing = fastSwing;
            //DelaySwing = delaySwing;  // Delay‚Í‚Ş‚¸‚¢‚©‚çˆê’U‚È‚µ
            IsHit = isHit;
            IsCought = isCought;
        }
    }
}