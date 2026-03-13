using System.Collections.Generic;
using UnityEngine;

namespace Kamatte.Core
{
    [RequireComponent(typeof(EffectActSystem))]    //  参照渡し先
    public class EffectActSystemBootstrap : MonoBehaviour    //  演出用動きさせるシステムの参照渡し  
    {
        [Header("演出用の動きをさせるコンポーネント")]
        [SerializeField] EffectActSystem _effectActSystem;
        [Header("演出用の動きのSOカタログ")]
        [SerializeField] EffectActCatalog _effectActCatalog;
        [Header("定義データの紐づけと演出用の動きをするオブジェクト")]
        [SerializeField] ActorObjectBind[] _actorObjectBind;

        Dictionary<EffectActor, GameObject> _actorObjectMap;    //  定義演者とシーン上のオブジェクトの紐づけ


        void Reset()
        {
            TryGetComponent(out _effectActSystem);    //  今のところ期待通りの動作してない
        }

        void Awake()
        {
            BuildActorMap();
            _effectActSystem.Initialize(_effectActCatalog, _actorObjectMap);
        }

        void BuildActorMap()    //  演者のマッピング
        {
            if (_actorObjectMap == null)
            {
                _actorObjectMap = new Dictionary<EffectActor, GameObject>();

                foreach (var bind in _actorObjectBind)
                {
                    if (_actorObjectMap.ContainsKey(bind.effectActor) &&
                        _actorObjectMap[bind.effectActor] == bind.exsitActor
                        )
                    { continue; }

                    _actorObjectMap.Add(bind.effectActor, bind.exsitActor);
                }
            }
        }
    }
}