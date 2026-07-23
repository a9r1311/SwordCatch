using SwordCatch.Core;
using SwordCatch.Animation;
using SwordCatch.SwordCatch;

namespace SwordCatch.Swinger
{
    public sealed class Swing
    {
        AnimParamFacade _animParameter;
        public Swing()
        {
            _animParameter = ServiceLocator.Get<AnimParamFacade>();
        }

        //  刀振り下ろし
        public void SwingSword(SwingType swingType)
        {
            if(swingType == SwingType.Normal)
            {
                MyLogger.Log("通常振り下ろし開始");
                _animParameter.SwingerParam.NormmalSwing();
            }
            else if(swingType == SwingType.Fast)
            {
                MyLogger.Log("高速振り下ろし開始"); ;
                _animParameter.SwingerParam.FastSwing();
            }
            //else if (swingWay == 2)    //  Delayは難しすぎたのでコメントアウト中
            //{
            //    Debug.Log("Delay");
            //    ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.DelaySwing.SetTrigger();
            //}
        }
    }
}