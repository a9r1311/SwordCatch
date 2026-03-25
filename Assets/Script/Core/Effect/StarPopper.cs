using UnityEngine;

namespace Kamatte.Effect
{
    public class StarPopper : MonoBehaviour    //  星がポッピングするエフェクト調整クラス
    {
        [SerializeField] ParticleSystem _particleSystem;    //  パーティクルシステム
        [SerializeField] float popSpeed;     //  ポッピングスピード
        [SerializeField] int starCnt;     //  星の数

        private void Start()
        {            Pop(popSpeed, starCnt);    //  出現と同時にエフェクト再生
        }
        public void Pop(float spd, int starCnt)    //  ポップさせる
        {
            for (int popedStar = 0; popedStar < starCnt; popedStar++)
            {
                ParticleSystem.EmitParams ep = new ParticleSystem.EmitParams();

                //Vector3 dir = Vector3.up + new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(-0.5f, 0.5f));
                Vector3 dir = Vector3.up + Vector3.right * Random.Range(-0.5f, 0.5f);

                Debug.Log(dir);
                ep.velocity = dir.normalized * spd;

                _particleSystem.Emit(ep, 1);
            }
        }
    }
}