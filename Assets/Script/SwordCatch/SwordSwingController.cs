using UnityEngine;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public class SwordSwingController    //  刀の振り下ろしをコントロール
    {
        public SwordSwingController()    //  コンストラクタ
        {
        }

        public void SwingSword(int swingWay)    //  刀振り下ろし
        {
            LogUtility.Log(LogPrefix.SwingSwordController, "刀振り下ろしアニメーション開始", LogLevel.Debug);
            int r = Random.Range(0, 2);

            if(swingWay == 0)
            {
                Debug.Log("Normal");
                ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.NormalSwing.SetTrigger();
            }
            else if(swingWay == 1)
            {
                ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.FastSwing.SetTrigger();
                Debug.Log("Fast");
            }
            else if (swingWay == 2)
            {
                Debug.Log("Delay");
                ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.DelaySwing.SetTrigger();
            }
        }
    }
}