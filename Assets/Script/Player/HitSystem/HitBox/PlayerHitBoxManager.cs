using SwordCatch.Core;
using SwordCatch.HitBox;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace SwordCatch.Player
{
    //  ヒットボックス管理者
    public sealed class PlayerHitBox
    {
        PlayerController _controller;

        readonly Dictionary<HitBoxID, HitBoxData> _hitbBoxDictionary;  // 当たり判定一覧
        readonly Collider[] _hitResults = new Collider[8];  // 当たった相手のCollider

        HitBoxData _activeBox = null;  // 有効になっている当たり判定
        HitBoxID activeID = HitBoxID.Unknown;  // アクティブにするボックスID

        Transform _playerHeadTF;  // プレイヤーの頭(判定位置計算用)
        Vector3 _currentCenter;  // 当たり判定中心地
        Quaternion _currentRotation;  // 当たり判定回転

        StateHolder _stateHolder;  // ゲーム状況保持クラス

        public PlayerHitBox
            (PlayerHitBoxData hitBoxData,
            PlayerController playerController,
            Transform playerHead,
            StateHolder stateHolder)
        {
            _hitbBoxDictionary = new Dictionary<HitBoxID, HitBoxData>();
            foreach (var box in hitBoxData.PlayerHitBoxes)
            {
                _hitbBoxDictionary[box.id] = box;
            }

            _controller = playerController;
            _playerHeadTF = playerHead;
            _stateHolder = stateHolder; 
        }

        public void Update()
        {
            if (_activeBox == null)
            {
                return;
            }

            //  activeboxの情報を読んで当たり判定を生成
            int hitCount = Physics.OverlapBoxNonAlloc(
                            _currentCenter,
                            _activeBox.size * 0.5f,
                            _hitResults,
                            _currentRotation
                        );

            for (int i = 0; i < hitCount; i++)
            {
                var h = _hitResults[i];
                if (
                    h.CompareTag("Sword") &&
                    !_stateHolder.IsCatchSword &&
                    !_stateHolder.IsHitSwing)
                {
                    _controller.OnCatch();
                    break;
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

                _currentRotation = _playerHeadTF.rotation;
                _currentCenter = _playerHeadTF.position + _currentRotation * _activeBox.offset;
                
                MyLogger.Log("ヒットボックス有効化");
            }
        }

        //  当たり判定無効化
        public void DisableHitBox(HitBoxID id)
        {
            if (activeID.Equals(id))
            {
                _activeBox = null;
                MyLogger.Log("ヒットボックス無効化");
            }
        }

        [Conditional("UNITY_EDITOR")]
        public void DrawGizmos()
        {
            if (_activeBox == null || _playerHeadTF == null)
            {
                return;
            }

            Gizmos.color = Color.red;
            
            Vector3 size = _activeBox.size;
            
            Gizmos.matrix = Matrix4x4.TRS(_currentCenter, _currentRotation, Vector3.one);
            Gizmos.DrawWireCube(Vector3.zero, size);
        }
    }
}