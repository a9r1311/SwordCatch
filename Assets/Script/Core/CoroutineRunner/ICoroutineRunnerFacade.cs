using UnityEngine;
using System.Collections;

namespace Kamatte.Core
{
    public interface ICoroutineRunnerFacade    //  SL‚É“o˜^‚³‚ê‚ÄŒÄ‚Î‚ê‚éFacadeClass‚ÌIB
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine coroutine);
    }
}