using System.Threading.Tasks;

namespace Kamatte.Core
{
    public abstract class SceneStartStepExcuteBase    //  シーン開始時の処理をするクラスの抽象化用
    {
        public abstract ValueTask StartSteps();
    }
}