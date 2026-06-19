using UnityEngine;
using Kamatte.Core;
using UAssert = UnityEngine.Assertions.Assert;

namespace Kamatte.SwordCatch
{
    public sealed class SwordSwing
    {
        AnimParamFacadeBase _animParameter;
        public SwordSwing()
        {
            _animParameter = ServiceLocator.Resolve<AnimParamFacadeBase>();
            UAssert.IsNotNull( _animParameter,"[SwordSwing] animParameterの参照が取得できませんでした。");
        }


        public void SwingSword(SwingType swingType)    //  刀振り下ろし
        {

            if(swingType == SwingType.Normal)
            {
                Debug.Log("通常振り下ろし開始");
                _animParameter.SwingerParam.NormalSwing.SetTrigger();
            }
            else if(swingType == SwingType.Fast)
            {
                Debug.Log("高速振り下ろし開始");
                _animParameter.SwingerParam.FastSwing.SetTrigger();
            }
            //else if (swingWay == 2)    //  Delayは難しすぎたのでコメントアウト中
            //{
            //    Debug.Log("Delay");
            //    ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.DelaySwing.SetTrigger();
            //}
        }
    }
}