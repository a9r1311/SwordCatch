namespace Kamatte.Core
{
    public readonly struct LogPrefix    //  ログプレフィクス定義クラス
    {
        // 事前定義タグ
        public static readonly LogPrefix AutoAssign = new("[AutoAssign]");
        public static readonly LogPrefix ScreenFader = new("[ScreenFader]");
        public static readonly LogPrefix FadeImageSetter = new("[FadeImageSetter]");
        public static readonly LogPrefix FadeImageEditorWindow = new("[FadeImageEditorWindow]");
        public static readonly LogPrefix IiManager = new("[UIManager]");
        public static readonly LogPrefix UiFactory = new("[UIFacotry]");
        public static readonly LogPrefix TitleButtonmanager = new("[TitleButtonManager]");
        public static readonly LogPrefix SceneUtility = new("[SceneUtility]");
        public static readonly LogPrefix SwingSwordController = new("[SwingSwordController]");
        public static readonly LogPrefix PlayerController = new("[SwingSwordController]");
        public static readonly LogPrefix CatchSwordNotifier = new("[CatchSwordNotifier]");
        public static readonly LogPrefix playerHitBoxController = new("[PlayerHitBoxController]");

        public string Value { get; }

        private LogPrefix(string value)
        {
            Value = value;
        }

        public override string ToString() => Value;

        // 等価比較（==, !=）できるように
        public override bool Equals(object obj)
        {
            return obj is LogPrefix other && Value == other.Value;
        }

        //  ハッシュコードゲット
        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(LogPrefix a, LogPrefix b) => a.Equals(b);
        public static bool operator !=(LogPrefix a, LogPrefix b) => !a.Equals(b);

        // 動的に作成も可能
        public static LogPrefix Custom(string value) => new(value);
    }
}