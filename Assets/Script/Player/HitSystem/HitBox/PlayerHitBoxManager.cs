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

        public Transform _playerHeadTF;
        PlayerController _controller;

        StateHolder _stateHolder;

        public HitBox ActiveBox => _activeBox;

        Vector3 StarEffectPos;
        Vector3 FireWorksPos = new Vector3(648,-507,269);
        Vector3 LightningCenterPos = new Vector3(616, -5.5f, 507);

        public PlayerHitBox
            (PlayerHitBoxData hitBoxData, PlayerController playerController, Transform playerHead, Vector3 starEffectPos, StateHolder stateHolder)    //  コンストラクタ
        {
            _hitbBoxDictionary = new Dictionary<HitBoxID, HitBox>();
            foreach (var box in hitBoxData.PlayerHitBoxes)
            {
                _hitbBoxDictionary[box.id] = box;
            }
            _controller = playerController;
            _playerHeadTF = playerHead;
            StarEffectPos = starEffectPos;
            _stateHolder = stateHolder; 
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
                    && !_stateHolder.IsCatchSword
                    && !_stateHolder.IsHitSwing
                    )
                {
                    _stateHolder.IsCatchSword = true;  // 一番上に書くべし
                    _controller.OnCatch();
                    PlayrRandomEffect();
                    _stateHolder.CatchSuccess();
                    EffectAPIWindow.Play(new EffectKey(GameMode.SwordCatch, EffectKind.CatchSword), StarEffectPos);

                    SwordCatchEventBus.CatchSuccess();
                    ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.IsCought(true);
                    MyLogger.Log("白刃取り成功");
                }
            }
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


        public Vector3 ResolveCenter(Transform owner)    //  当たり判定の中心座標を返す
        {
            return owner.position + owner.rotation * _activeBox.offset;
        }

        void PlayrRandomEffect()
        {
            if(_stateHolder.CatchSuccessCnt == 5)
            {
                EffectAPIWindow.Play(new EffectKey(GameMode.SwordCatch, EffectKind.FireWorks), FireWorksPos);
            }
            if(_stateHolder.CatchSuccessCnt > 20)
            {
                float radius = 7f;
                Vector3 LightningAddPos = Random.insideUnitSphere * radius;
                Vector3 LightningPos = new Vector3(LightningCenterPos.x + LightningAddPos.x, LightningCenterPos.y, LightningCenterPos.z + LightningAddPos.z);
                EffectAPIWindow.Play(new EffectKey(GameMode.SwordCatch, EffectKind.Lightning), LightningPos);
            }
        }
        public void DrawGizmos()
        {
            if (_activeBox == null || _playerHeadTF == null)
            {
                return;
            }

            // Gizmosの色を設定（赤色）
            Gizmos.color = Color.red;

            // 現在の判定位置と回転を取得
            Vector3 center = ResolveCenter(_playerHeadTF);
            Quaternion rotation = _playerHeadTF.rotation;
            Vector3 size = _activeBox.size;

            // 箱を描画
            Gizmos.matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
            Gizmos.DrawWireCube(Vector3.zero, size);
        }
    }
}