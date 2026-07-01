using System.Collections.Generic;
using UnityEngine;
using Kamatte.Core;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    //  ヒットボックス管理者
    public sealed class PlayerHitBox
    {
        Dictionary<HitBoxID, HitBox> _hitbBoxDictionary;    //  当たり判定一覧
        HitBox _activeBox = null;    //  有効になっている当たり判定

        PlayerController controller;
        public Transform _playerHeadTF;

        HitBoxID activeID = HitBoxID.Unknown;    //  アクティブにするボックスID

        StateWriter_SwordCatch stateWriter;
        StateReader_SwordCatch stateRead;

        public HitBox ActiveBox => _activeBox;

        Vector3 StarEffectPos;
        Vector3 FireWorksPos = new Vector3(648,-507,269);
        Vector3 LightningCenterPos = new Vector3(616, -5.5f, 507);

        public PlayerHitBox
            (PlayerHitBoxData hitBoxData, PlayerController playerController, Transform playerHead, Vector3 starEffectPos, StateReader_SwordCatch read, StateWriter_SwordCatch writer)    //  コンストラクタ
        {
            _hitbBoxDictionary = new Dictionary<HitBoxID, HitBox>();
            foreach (var box in hitBoxData.PlayerHitBoxes)
            {
                _hitbBoxDictionary[box.id] = box;
            }
            controller = playerController;
            _playerHeadTF = playerHead;
            StarEffectPos = starEffectPos;

            stateRead = read;
            stateWriter = writer;
        }

        void Initalize()    //  初期化
        {
            _hitbBoxDictionary = new Dictionary<HitBoxID, HitBox>();
        }

        public void EnableHitBox(HitBoxID id)    //  当たり判定有効化
        {
            if (_hitbBoxDictionary.TryGetValue(id, out var box))
            {
                _activeBox = box;
                activeID = box.id;
                Debug.Log("ヒットボックス有効化");
            }
        }

        public void DisableHitBox(HitBoxID id)    //  当たり判定無効化
        {
            if (activeID.Equals(id))
            {
                _activeBox = null;
                Debug.Log("ヒットボックス無効化");
            }
        }

        public void Update()    //  毎フレーム実行処理
        {
            if (_activeBox == null) return;
            var hits = Physics.OverlapBox(ResolveCenter(_playerHeadTF), _activeBox.size * 0.5f);    //  gpt とここから
            foreach (var h in hits)
            {
                if (h.CompareTag("Sword") && !stateRead.AcceseState().CatchState.IsCatchSword && !stateRead.AcceseState().HitSwingState.IsHitSwing)
                {
                    PlayrRandomEffect();
                    stateWriter.ChangeCatchState(true);
                    stateWriter.AddCatchSuccessCnt();
                    EffectAPIWindow.Play(new EffectKey(GameMode.SwordCatch, EffectKind.CatchSword), StarEffectPos);

                    controller.OnCatch();
                    Debug.Log("白刃取り成功");
                    SwordCatchEventBus.CatchSuccess();
                    ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.IsCatch.SetBool(true);
                }
            }
        }

        Vector3 ResolveCenter(Transform owner)    //  当たり判定の中心座標を返す
        {
            return owner.position + owner.rotation * _activeBox.offset;
        }

        void PlayrRandomEffect()
        {
            if(stateRead.AcceseState().CatchState.CatchSuccessTime == 5)
            {
                EffectAPIWindow.Play(new EffectKey(GameMode.SwordCatch, EffectKind.FireWorks), FireWorksPos);
            }
            if(stateRead.AcceseState().CatchState.CatchSuccessTime > 20)
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