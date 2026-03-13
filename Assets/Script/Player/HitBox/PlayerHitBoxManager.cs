using System.Collections.Generic;
using UnityEngine;
using Kamatte.Core;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    public class PlayerHitBoxMgr    //  ヒットボックス管理者
    {
        Dictionary<HitBoxID, HitBoxData> _hitbBoxDictionary;    //  当たり判定一覧
        HitBoxData _activeBox = null;    //  アクティブになってる当たり判定
        PlayerHitBoxController controller;
        public Transform _playerHeadTF;    //  プレイヤーの頭
        HitBoxID activeID = HitBoxID.Unknown;                       //  アクティブにするボックスID

        StateWriter_SwordCatch stateWriter;
        StateReader_SwordCatch stateRead;

        public HitBoxData ActiveBox => _activeBox;

        Vector3 StarEffectPos;
        Vector3 FireWorksPos = new Vector3(648,-507,269);
        Vector3 LightningCenterPos = new Vector3(616, -5.5f, 507);

        public PlayerHitBoxMgr
            (PlayerHitBoxData hitBoxData, PlayerHitBoxController playerController, Transform playerHead, Vector3 starEffectPos, StateReader_SwordCatch read, StateWriter_SwordCatch writer)    //  コンストラクタ
        {
            _hitbBoxDictionary = new Dictionary<HitBoxID, HitBoxData>();
            foreach (var box in hitBoxData.playerHitBoxes)
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
            _hitbBoxDictionary = new Dictionary<HitBoxID, HitBoxData>();
        }

        public void EnableHitBox(HitBoxID id)    //  当たり判定有効化
        {
            if (_hitbBoxDictionary.TryGetValue(id, out var box))
            {
                _activeBox = box;
                activeID = box.id;
                LogUtility.Log(LogPrefix.playerHitBoxController, $"{id} ヒットボックス有効", LogLevel.Info);
            }
        }

        public void DisableHitBox(HitBoxID id)    //  当たり判定無効化
        {
            if (activeID.Equals(id))
            {
                _activeBox = null;
                LogUtility.Log(LogPrefix.playerHitBoxController, $"{id} ヒットボックス無効", LogLevel.Info);
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

                    controller.PlayCatchSound();
                    LogUtility.Log(LogPrefix.playerHitBoxController, "白刃取り成功", LogLevel.Info);
                    SwordCatchEventBus.CatchSuccess();
                    ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.IsCatch.SetBool(true);
                }
            }
        }

        public Vector3 ResolveCenter(Transform owner) => _activeBox.anchorType switch    //  当たり判定の中心地を返す
        {
            HitBoxAnchorType.Transform => owner.position + owner.rotation * _activeBox.offset,
            HitBoxAnchorType.Bone => _activeBox.boneTransform.position + _activeBox.boneTransform.rotation * _activeBox.offset,
            HitBoxAnchorType.World => _activeBox.worldCenter != null ? _activeBox.worldCenter : Vector3.zero,
            _ => owner.position
        };

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