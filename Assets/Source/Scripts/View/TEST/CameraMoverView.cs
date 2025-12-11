using System;
using Source.Scripts.Core.TEST;
using UnityEngine;

namespace Source.Scripts.View.TEST
{
    [Serializable]
    public class CameraMoverView : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private float _smoothSpeed = 1f;
        
        private CoreWorld _world;

        public void Init(CoreWorld world)
        {
            _world = world;
        }

        void Update()
        {
            var move = _world.CameraMovementData;

            if (move.MoveOffsetX != 0 || move.MoveOffsetY != 0)
            {
                Vector3 targetPos = _cameraTransform.position + new Vector3(move.MoveOffsetX, 0, move.MoveOffsetY) * Time.deltaTime;
                _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, targetPos, _smoothSpeed);
            }
        }
    }
}