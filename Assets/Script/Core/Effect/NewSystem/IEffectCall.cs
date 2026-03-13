using System;

namespace Kamatte.Core
{
    public interface IEffectCall<T> where T : Enum   //  下位クラス専用のエフェクトコール<T>を束ねるクラス
    {
        void Play<T>(T effectKey);    //  判断層を通ってエフェクトを発生させる
    }
}