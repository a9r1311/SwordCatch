using UnityEngine;
using UAssert = UnityEngine.Assertions.Assert;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    //  Swingerのアニメーターのパラメータ保持クラス
    public sealed class AnimParam_Swinger : AnimParamCollectionBase
    {
        readonly int _normalSwinghash;
        readonly int _fastSwinghash;
        readonly int _isHithash;
        readonly int _isCoughthash;

        public AnimParam_Swinger
            (Animator animator, SwingerAnimParameters paramters) : base(animator)
        {
            UAssert.IsNotNull(animator, "animatorの参照が取得できませんでした。");
            UAssert.IsNotNull(paramters, "parametersの参照が取得できませんでした。");

            _normalSwinghash = Animator.StringToHash(paramters.NormalSwing);
            _fastSwinghash = Animator.StringToHash(paramters.FastSwing);
            //_delaySwinghash = Animator.StringToHash(_paramters.DelaySwing);
            _isHithash = Animator.StringToHash(paramters.IsHit);
            _isCoughthash = Animator.StringToHash(paramters.IsCought);
        }

        //  普通の振り下ろし
        public void NormmalSwing() => animator.SetTrigger(_normalSwinghash);

        //  高速振り下ろし
        public void FastSwing() => animator.SetTrigger(_fastSwinghash);

        //  難しすぎたのでDelayは一旦なし
        //public void DelaySwing() => animator.SetTrigger(_nameHashPair[_paramters.NormalSwing]);

        //  刀が当たったかどうか
        public void IsHit(bool flag) => animator.SetBool(_isHithash, flag);

        //  キャッチされたかどうか
        public void IsCought(bool flag) => animator.SetBool(_isCoughthash, flag);
    }
}