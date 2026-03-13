using System.Collections;
using Kamatte.Core;

public class SceneLoadStep : IGameModeChangeStep
{
    public int Order => 40;    //  Às‡(¬‚³‚¢•û‚ªæ)
    public IEnumerator Execute(GameMode prev, GameMode next)    //  Step‚Ìˆ—ŠÖ”‚Ìƒ‰ƒbƒvŠÖ”
    {
        SceneUtility.LoadScene(SceneNameMap.GetName(SceneID.Shop));
        yield break;
    }
}
