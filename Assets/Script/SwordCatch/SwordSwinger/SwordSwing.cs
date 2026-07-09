using UnityEngine;
using Kamatte.Core;
using UAssert = UnityEngine.Assertions.Assert;

namespace Kamatte.SwordCatch
{
    public sealed class Swing
    {
        AnimParamFacadeBase _animParameter;
        public Swing()
        {
            _animParameter = ServiceLocator.Resolve<AnimParamFacadeBase>();
            UAssert.IsNotNull( _animParameter,"animParameterの参照が取得できませんでした。");
        }

        //  刀振り下ろし
        public void SwingSword(SwingType swingType)
        {
            if(swingType == SwingType.Normal)
            {
                Debug.Log("通常振り下ろし開始");
                _animParameter.SwingerParam.NormmalSwing();
            }
            else if(swingType == SwingType.Fast)
            {
                Debug.Log("高速振り下ろし開始");
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