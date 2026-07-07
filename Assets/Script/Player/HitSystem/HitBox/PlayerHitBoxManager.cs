using System.Collections.Generic;
using UnityEngine;
using Kamatte.Core;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    //  ヒットボックス管理者
    public sealed class PlayerHitBox
    {
        readonly Dictionary<HitBoxID, HitBox> _hitbBoxDictionary;  // 当たり判定一覧
        readonly Collider[] _hitResults = new Collider[8];  // 当たった相手のCollider

        HitBox _activeBox = null;  // 有効になっている当たり判定
        HitBoxID activeID = HitBoxID.Unknown;  // アクティブにするボックスID

        Transform _playerHeadTF;
        PlayerController _controller;

        StateWriter stateWriter;
        StateReader stateRead;

        public HitBox ActiveBox => _activeBox;

        Vector3 StarEffectPos;
        Vector3 FireWorksPos = new Vector3(648,-507,269);
        Vector3 LightningCenterPos = new Vector3(616, -5.5f, 507);

        public PlayerHitBox
            (PlayerHitBoxData hitBoxData, PlayerController playerController, Transform playerHead, Vector3 starEffectPos, StateReader read, StateWriter writer)    //  コンストラクタ
        {
            _hitbBoxDictionary = new Dictionary<HitBoxID, HitBox>();
            foreach (var box in hitBoxData.PlayerHitBoxes)
            {
                _hitbBoxDictionary[box.id] = box;
            }
            _controller = playerController;
            _playerHeadTF = playerHead;
            StarEffectPos = starEffectPos;

            stateRead = read;
            stateWriter = writer;
        }

        //  当たり判定有効化
        public void EnableHitBox(HitBoxID id)
        {
            if (_hitbBoxDictionary.TryGetValue(id, out var box))
            {
                _activeBox = box;
                activeID = box.id;
                Debug.Log("ヒットボックス有効化");
            }
        }

        //  当たり判定無効化
        public void DisableHitBox(HitBoxID id)
        {
            if (activeID.Equals(id))
            {
                _activeBox = null;
                Debug.Log("ヒットボックス無効化");
            }
        }

        public void Update()
        {
            if (_activeBox == null)
            {
                return;
            }

            //  activeboxの情報を読んで当たり判定を生成
            var hits = Physics.OverlapBox(
                ResolveCenter(_playerHeadTF),
                _activeBox.size * 0.5f
                );
            
            foreach (var h in hits)
            {
                if (
                    h.CompareTag("Sword")
                    && !stateRead.StateHolder.IsCatchSword
                    && !stateRead.StateHolder.IsHitSwing
                    )
                {
                    _controller.OnCatch();
                    PlayrRandomEffect();
                    stateWriter.ChangeCatchState(true);
                    stateWriter.AddCatchSuccessCnt();
                    EffectAPIWindow.Play(new EffectKey(GameMode.SwordCatch, EffectKind.CatchSword), StarEffectPos);

                    SwordCatchEventBus.CatchSuccess();
                    ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.IsCatch.SetBool(true);
                    Debug.Log("白刃取り成功");
                }
            }
        }

        Vector3 ResolveCenter(Transform owner)    //  当たり判定の中心座標を返す
        {
            return owner.position + owner.rotation * _activeBox.offset;
        }

        void PlayrRandomEffect()
        {
            if(stateRead.StateHolder.CatchSuccessCnt == 5)
            {
                EffectAPIWindow.Play(new EffectKey(GameMode.SwordCatch, EffectKind.FireWorks), FireWorksPos);
            }
            if(stateRead.StateHolder.CatchSuccessCnt > 20)
            {
                float radius = 7f;
                Vector3 LightningAddPos = Random.insideUnitSphere * radius;
                Vector3 LightningPos = new Vector3(LightningCenterPos.x + LightningAddPos.x, LightningCenterPos.y, LightningCenterPos.z + LightningAddPos.z);
                EffectAPIWindow.Play(new EffectKey(GameMode.SwordCatch, EffectKind.Lightning), LightningPos);
            }

        }
    }
}

//public Vector3 ResolveCenter(Transform owner) => _activeBox.anchorType switch    //  当たり判定の中心地を返す
//{
//    HitBoxAnchor.Transform => owner.position + owner.rotation * _activeBox.offset,
//    HitBoxAnchor.Bone => _activeBox.bone.position + _activeBox.bone.rotation * _activeBox.offset,
//    HitBoxAnchor.World => _activeBox.worldCenter != null ? _activeBox.worldCenter : Vector3.zero,
//    _ => owner.position
//};